using MathNet.Numerics;

namespace IRPG_Calculator
{
    internal static class CritComboCalculator
    {
        //private readonly static int MINIMUMCONTRIBUTION_LN = -23;
        public readonly static int COMBATSCENARIOS = 3;

        public static double[][] RevivalBattle_WinChances_Estimate(Character player, Enemy enemy)
        {
            CalculationVariables variables = new CalculationVariables(player, enemy);
            return RevivalBattle_WinChances_Estimate(variables);
        }

        public static double[][] RevivalBattle_WinChances_Precise(Character player, Enemy enemy)
        {
            CalculationVariables variables = new CalculationVariables(player, enemy);
            return RevivalBattle_WinChances_Precise(variables);
        }

        public static double[][] RevivalBattle_WinChances_Estimate(CalculationVariables variables)
        {
            int scenarios = COMBATSCENARIOS;
            int maxSlots = Character.MAXREVIVALSLOTS;

            double[][] results = new double[scenarios][];

            for (int scenario = 0; scenario < scenarios; scenario++)
            {
                results[scenario] = new double[1 + maxSlots];

                for (int slots = 0; slots <= maxSlots; slots++)
                {
                    Console.WriteLine($"Scenario {scenario} Slot {slots}");
                    SpecificCalculationVariables specificCalculationVariables = new SpecificCalculationVariables(variables, scenario, slots);
                    results[scenario][slots] = RevivalBattle_WinChance_Estimate(specificCalculationVariables);
                }
            }

            return results;
        }

        public static double[][] RevivalBattle_WinChances_Precise(CalculationVariables variables)
        {
            int scenarios = COMBATSCENARIOS;
            int maxSlots = Character.MAXREVIVALSLOTS;

            double[][] results = new double[scenarios][];

            for (int scenario = 0; scenario < scenarios; scenario++)
            {
                results[scenario] = new double[1 + maxSlots];

                for (int slots = 0; slots <= maxSlots; slots++)
                {
                    SpecificCalculationVariables specificCalculationVariables = new SpecificCalculationVariables(variables, scenario, slots);
                    results[scenario][slots] = RevivalBattle_WinChance_Precise(specificCalculationVariables);
                }
            }

            return results;
        }

        public static double RevivalBattle_WinChance_Estimate(SpecificCalculationVariables variables)
        {
            double averageDamage = variables.DAMAGE + variables.CRITICALRATE * variables.COMBORATE * variables.EXTRACRITICALDAMAGE + variables.CRITICALRATELOW * (1 - variables.COMBORATE) * variables.EXTRACRITICALDAMAGELOW;
            double averageFirstCritDamage = 0;
            for (int i = 0; i < variables.FIRSTCRITICALS; i++)
            {
                averageFirstCritDamage += Math.Pow(variables.COMBORATE, variables.FIRSTCRITICALS - 1 - i) * Math.Pow(1 - variables.COMBORATE, i) * SpecialFunctions.Binomial(variables.FIRSTCRITICALS - 1, i) * ((variables.FIRSTCRITICALS - i) * variables.CRITICALDAMAGE + i * variables.CRITICALDAMAGELOW);
            }
            double averageHits = variables.FIRSTCRITICALS + (variables.HEALTH - averageFirstCritDamage) / averageDamage;
            double result = Math.Pow(variables.COMBORATE + variables.REVIVERATE * (1 - variables.COMBORATE), Math.Ceiling(averageHits) - 1);

            return result;
        }

        public static double RevivalBattle_WinChance_Precise(SpecificCalculationVariables variables)
        {
            double killHits;
            double variableSuccess, guaranteedSuccess;
            double subtotal, result;

            int min_extraHitsForSuccess, max_extraHitsForFailure;

            killHits = (double)variables.HEALTH / variables.DAMAGE;
            min_extraHitsForSuccess = (int)Math.Max(0, Math.Ceiling((double)(variables.HEALTH - variables.CRITICALDAMAGE) / variables.CRITICALDAMAGELOW));
            max_extraHitsForFailure = (int)Math.Ceiling(killHits - 1) - 1;

            subtotal = 0;
            double extraHitChance;
            for (int extraHits = min_extraHitsForSuccess; extraHits <= max_extraHitsForFailure; extraHits++)
            {
                extraHitChance = RevivalExtraHits_WinChance(variables, killHits, extraHits);
                subtotal += extraHitChance;
            }

            variableSuccess = subtotal * (1 - variables.COMBORATE) * (1 - variables.REVIVERATE);
            guaranteedSuccess = Math.Pow(variables.COMBORATE + variables.REVIVERATE * (1 - variables.COMBORATE), 1 + max_extraHitsForFailure);
            result = variableSuccess + guaranteedSuccess;
            return result;
        }

        private static double RevivalExtraHits_WinChance(SpecificCalculationVariables variables, double killHits, int extraHits)
        {
            double subtotal;
            int extraFirstCriticals;

            extraFirstCriticals = Math.Max(0, Math.Min(variables.FIRSTCRITICALS - 1, extraHits));

            if (variables.REVIVERATE == 0)
            {
                int combos = extraHits - extraFirstCriticals;
                double term = Math.Pow(variables.COMBORATE, combos);
                double criticalChance = RevivalCritical_WinChance(variables, killHits, extraHits, combos, extraFirstCriticals);
                subtotal = term * criticalChance;
            }
            else
            {
                int min_combo = 0;
                int max_combo = extraHits - extraFirstCriticals;
                double criticalChance, term, term1, term2, term3;

                subtotal = 0;
                for (int combos = min_combo;  combos <= max_combo; combos++)
                {
                    term1 = combos * Math.Log(variables.COMBORATE);
                    term2 = (max_combo - combos) * (Math.Log(1 - variables.COMBORATE) + Math.Log(variables.REVIVERATE));
                    term3 = SpecialFunctions.BinomialLn(max_combo, combos);
                    term = Math.Exp(term1 + term2 + term3);
                    criticalChance = RevivalCritical_WinChance(variables, killHits, extraHits, combos, extraFirstCriticals);
                    subtotal += term * criticalChance;
                }
            }

            return subtotal;
        }

        private static double RevivalCritical_WinChance(SpecificCalculationVariables variables, double killHits, int extraHits, int combos, int extraFirstCriticals)
        {
            double subtotal;

            if (variables.REVIVERATE == 0)
            {
                int firstCriticalRegs = variables.FIRSTCRITICALS;
                int firstCriticalLows = 0;
                double term = Math.Pow(variables.COMBORATE, extraFirstCriticals);
                double criticalLowChance = RevivalCriticalLow_WinChance(variables, killHits, extraHits, combos, extraFirstCriticals, firstCriticalRegs, firstCriticalLows);
                subtotal = term * criticalLowChance;
            }
            else
            {
                int firstCriticalRegs, extra_firstCriticalRegs;
                double criticalLowChance, term, term1, term2, term3;

                int min_firstCriticalLow = 0;
                int max_firstCriticalLow = extraFirstCriticals;

                subtotal = 0;
                for (int firstCriticalLows = min_firstCriticalLow; firstCriticalLows <= max_firstCriticalLow; firstCriticalLows++)
                {
                    firstCriticalRegs = variables.FIRSTCRITICALS - firstCriticalLows;
                    extra_firstCriticalRegs = Math.Max(0, firstCriticalRegs - 1);

                    term1 = extra_firstCriticalRegs * Math.Log(variables.COMBORATE);
                    term2 = firstCriticalLows * (Math.Log(1 - variables.COMBORATE) + Math.Log(variables.REVIVERATE));
                    term3 = SpecialFunctions.BinomialLn(max_firstCriticalLow, firstCriticalLows);
                    term = Math.Exp(term1 + term2 + term3);
                    criticalLowChance = RevivalCriticalLow_WinChance(variables, killHits, extraHits, combos, extraFirstCriticals, firstCriticalRegs, firstCriticalLows);
                    subtotal += term * criticalLowChance;
                }
            }

            return subtotal;
        }

        private static double RevivalCriticalLow_WinChance(SpecificCalculationVariables variables, double killHits, int extraHits, int combos, int extraFirstCriticals, int firstCriticalRegs, int firstCriticalLows)
        {
            double subtotal;
            double criticalRegChance, term, term1, term2, term3;

            int min_criticalLow = 0;
            int max_criticalLow = extraHits - extraFirstCriticals - combos;

            subtotal = 0;
            for (int other_criticalLows = min_criticalLow; other_criticalLows <= max_criticalLow; other_criticalLows++)
            {
                term1 = other_criticalLows * Math.Log(variables.CRITICALRATELOW);
                term2 = (max_criticalLow - other_criticalLows) * Math.Log(1 - variables.CRITICALRATELOW);
                term3 = SpecialFunctions.BinomialLn(max_criticalLow, other_criticalLows);
                term = Math.Exp(term1 + term2 + term3);
                criticalRegChance = RevivalCriticalReg_WinChance(variables, killHits, extraHits, combos, firstCriticalRegs, firstCriticalLows + other_criticalLows);
                subtotal += term * criticalRegChance;
            }

            return subtotal;
        }

        private static double RevivalCriticalReg_WinChance(SpecificCalculationVariables variables, double killHits, int extraHits, int combos, int firstCriticalRegs, int criticalLows)
        {
            double subtotal;
            double term, term1, term2, term3;

            long remainingHP = variables.HEALTH - (1 + extraHits) * variables.DAMAGE - criticalLows * variables.EXTRACRITICALDAMAGELOW - firstCriticalRegs * variables.EXTRACRITICALDAMAGE;
            if (remainingHP <= 0)
            {
                return 1.0;
            }

            int min_criticalReg = (int)Math.Ceiling((double)remainingHP / variables.EXTRACRITICALDAMAGE);
            int max_criticalReg;
            if (variables.FIRSTCRITICALS == 0)
            {
                max_criticalReg = 1 + combos;
            }
            else
            {
                max_criticalReg = combos;
            }

            subtotal = 0;
            for (int other_criticalRegs = min_criticalReg; other_criticalRegs <= max_criticalReg; other_criticalRegs++)
            {
                term1 = other_criticalRegs * Math.Log(variables.CRITICALRATE);
                term2 = (max_criticalReg - other_criticalRegs) * Math.Log(1 - variables.CRITICALRATE);
                term3 = SpecialFunctions.BinomialLn(max_criticalReg, other_criticalRegs);
                term = Math.Exp(term1 + term2 + term3);
                subtotal += term;
            }

            return subtotal;
        }

        public readonly struct SpecificCalculationVariables
        {
            public int SCENARIO { get; }
            public int SLOTS { get; }
            public long HEALTH { get; }
            public long DAMAGE { get; }
            public long CRITICALDAMAGE { get; }
            public long CRITICALDAMAGELOW { get; }
            public long EXTRACRITICALDAMAGE { get; }
            public long EXTRACRITICALDAMAGELOW { get; }
            public double CRITICALMULTIPLIER { get; }
            public double CRITICALMULTIPLIERLOW { get; }
            public double EXTRACRITICALMULTIPLIER { get; }
            public double EXTRACRITICALMULTIPLIERLOW { get; }
            public double PERCENTHPRECOVERED { get; }
            public double REVIVERATE { get; }
            public double COMBORATE { get; }
            public double COMBORATELOW { get; }
            public double CRITICALRATE { get; }
            public double CRITICALRATELOW { get; }
            public int FIRSTCRITICALS { get; }

            public SpecificCalculationVariables(CalculationVariables variables, int scenario, int slots)
            {
                SCENARIO = scenario;
                SLOTS = slots;
                HEALTH = variables.HEALTH[scenario][slots];
                DAMAGE = variables.DAMAGE[scenario][slots];
                CRITICALDAMAGE = variables.CRITICALDAMAGE[scenario][slots];
                CRITICALDAMAGELOW = variables.CRITICALDAMAGELOW[scenario][slots];
                EXTRACRITICALDAMAGE = variables.EXTRACRITICALDAMAGE[scenario][slots];
                EXTRACRITICALDAMAGELOW = variables.EXTRACRITICALDAMAGELOW[scenario][slots];
                CRITICALMULTIPLIER = variables.CRITICALMULTIPLIER[scenario][slots];
                CRITICALMULTIPLIERLOW = variables.CRITICALMULTIPLIERLOW[scenario][slots];
                EXTRACRITICALMULTIPLIER = variables.EXTRACRITICALMULTIPLIER[scenario][slots];
                EXTRACRITICALMULTIPLIERLOW = variables.EXTRACRITICALMULTIPLIERLOW[scenario][slots];
                PERCENTHPRECOVERED = variables.PERCENTHPRECOVERED[scenario][slots];
                REVIVERATE = variables.REVIVERATE[scenario][slots];
                COMBORATE = variables.COMBORATE[scenario][slots];
                COMBORATELOW = variables.COMBORATELOW[scenario][slots];
                CRITICALRATE = variables.CRITICALRATE[scenario][slots];
                CRITICALRATELOW = variables.CRITICALRATELOW[scenario][slots];
                FIRSTCRITICALS = variables.FIRSTCRITICALS[scenario][slots];
            }

            public SpecificCalculationVariables(Character player, Enemy enemy, int scenario, int slots)
            {
                SCENARIO = scenario;
                SLOTS = slots;

                Character tester = new Character(player);

                // 0 = No Bonus; 1 = Crit & Combo Bonus; 2 = Half HP Bonus
                bool critComboBonus = (scenario == 1);
                bool halfHpBonus = (scenario == 2);

                tester.ChangeBuild(slots, critComboBonus, halfHpBonus, enemy);

                // Assign health , 3-CritRing, and rates
                HEALTH = (halfHpBonus) ? enemy.HP / 2 : enemy.HP;
                REVIVERATE = tester.ReviveRate;
                COMBORATE = tester.ComboRate(enemy, critComboBonus: critComboBonus, lowHp: false);
                COMBORATELOW = tester.ComboRate(enemy, critComboBonus: critComboBonus, lowHp: true);
                CRITICALRATE = tester.CriticalRate(enemy, critComboBonus: critComboBonus, lowHp: false);
                CRITICALRATELOW = tester.CriticalRate(enemy, critComboBonus: critComboBonus, lowHp: true);
                FIRSTCRITICALS = tester.firstCriticals;

                // Get damages
                long damage = tester.AverageDamage(enemy);
                long critDamage = tester.AverageCriticalDamage(enemy, critComboBonus);
                long critDamageLow = tester.AverageCriticalDamageLow(enemy, critComboBonus);
                double critMult = tester.AverageTrueCriticalMultiplier(enemy, critComboBonus);
                double critMultLow = tester.AverageTrueCriticalMultiplierLow(enemy, critComboBonus);

                // Assign damages
                DAMAGE = damage;
                CRITICALDAMAGE = critDamage;
                CRITICALDAMAGELOW = critDamageLow;
                EXTRACRITICALDAMAGE = critDamage - damage;
                EXTRACRITICALDAMAGELOW = critDamageLow - damage;
                CRITICALMULTIPLIER = critMult;
                CRITICALMULTIPLIERLOW = critMultLow;
                EXTRACRITICALMULTIPLIER = critMult - 1;
                EXTRACRITICALMULTIPLIERLOW = critMultLow - 1;

                PERCENTHPRECOVERED = (double)(damage / 50) / tester.HP;
            }

            public override string ToString()
            {
                string display = "";
                string newLine = "\n";
                string border = "==============================";
                string[] scenarioNames = new string[3] { "N/A Bonus ", "C&C Bonus", "Half HP Bonus" };

                string[] staticsText =
                {
                    $"Scenario = {scenarioNames[SCENARIO]}",
                    $"Starless Slots = {SLOTS}",
                    "",
                    $"Enemy Health = {HEALTH}",
                    $"Average Damage = {DAMAGE}",
                    $"Average Critical Damage (x{CRITICALMULTIPLIER:0.###}) = {CRITICALDAMAGE}",
                    $"Average Low HP Critical Damage (x{CRITICALMULTIPLIERLOW:0.###}) = {CRITICALDAMAGELOW}",
                    "",
                    $"First Criticals = {FIRSTCRITICALS}",
                    $"Average HP% Healed (non-critical) = {100 * PERCENTHPRECOVERED:0.##}%",
                    $"Revival Rate = {100 * REVIVERATE:0}%",
                    $"Combo Rate = {100 * COMBORATE:0}%",
                    $"Low HP Combo Rate = {100 * COMBORATELOW:0}%",
                    $"Critical Rate = {100 * CRITICALRATE:0}%",
                    $"Low HP Critical Rate = {100 * CRITICALRATELOW:0}%",
                    "",
                    $"Win Rate = {100 * RevivalBattle_WinChance_Estimate(this):0.###}%",
                };

                display += border + newLine;
                foreach (string line in staticsText)
                {
                    display += line + newLine;
                }
                display += border;

                return display;
            }
        }

        public readonly struct CalculationVariables
        {
            public long[][] HEALTH { get; }
            public long[][] DAMAGE { get; }
            public long[][] CRITICALDAMAGE { get; }
            public long[][] CRITICALDAMAGELOW { get; }
            public long[][] EXTRACRITICALDAMAGE { get; }
            public long[][] EXTRACRITICALDAMAGELOW { get; }
            public double[][] CRITICALMULTIPLIER { get; }
            public double[][] CRITICALMULTIPLIERLOW { get; }
            public double[][] EXTRACRITICALMULTIPLIER { get; }
            public double[][] EXTRACRITICALMULTIPLIERLOW { get; }
            public double[][] PERCENTHPRECOVERED { get; }
            public double[][] REVIVERATE { get; }
            public double[][] COMBORATE { get; }
            public double[][] COMBORATELOW { get; }
            public double[][] CRITICALRATE { get; }
            public double[][] CRITICALRATELOW { get; }
            public int[][] FIRSTCRITICALS { get; }

            public CalculationVariables(Character player, Enemy enemy)
            {
                Character tester = new Character(player);
                int maxSlots = Character.MAXREVIVALSLOTS;
                int scenarios = 3;
                bool critComboBonus, halfHpBonus;
                long damage, critDamage, critDamageLow;
                HEALTH = new long[scenarios][];
                DAMAGE = new long[scenarios][];
                CRITICALDAMAGE = new long[scenarios][];
                CRITICALDAMAGELOW = new long[scenarios][];
                EXTRACRITICALDAMAGE = new long[scenarios][];
                EXTRACRITICALDAMAGELOW = new long[scenarios][];
                CRITICALMULTIPLIER = new double[scenarios][];
                CRITICALMULTIPLIERLOW = new double[scenarios][];
                EXTRACRITICALMULTIPLIER = new double[scenarios][];
                EXTRACRITICALMULTIPLIERLOW = new double[scenarios][];
                PERCENTHPRECOVERED = new double[scenarios][];
                REVIVERATE = new double[scenarios][];
                COMBORATE = new double[scenarios][];
                COMBORATELOW = new double[scenarios][];
                CRITICALRATE = new double[scenarios][];
                CRITICALRATELOW = new double[scenarios][];
                FIRSTCRITICALS = new int[scenarios][];
                

                // 0 = No Bonus; 1 = Crit & Combo Bonus; 2 = Half HP Bonus
                for (int scenario = 0; scenario < scenarios; scenario++)
                {
                    critComboBonus = (scenario == 1) ? true : false;
                    halfHpBonus = (scenario == 2) ? true : false;

                    HEALTH[scenario] = new long[1 + maxSlots];
                    DAMAGE[scenario] = new long[1 + maxSlots];
                    CRITICALDAMAGE[scenario] = new long[1 + maxSlots];
                    CRITICALDAMAGELOW[scenario] = new long[1 + maxSlots];
                    EXTRACRITICALDAMAGE[scenario] = new long[1 + maxSlots];
                    EXTRACRITICALDAMAGELOW[scenario] = new long[1 + maxSlots];
                    CRITICALMULTIPLIER[scenario] = new double[1 + maxSlots];
                    CRITICALMULTIPLIERLOW[scenario] = new double[1 + maxSlots];
                    EXTRACRITICALMULTIPLIER[scenario] = new double[1 + maxSlots];
                    EXTRACRITICALMULTIPLIERLOW[scenario] = new double[1 + maxSlots];
                    PERCENTHPRECOVERED[scenario] = new double[1 + maxSlots];
                    REVIVERATE[scenario] = new double[1 + maxSlots];
                    COMBORATE[scenario] = new double[1 + maxSlots];
                    COMBORATELOW[scenario] = new double[1 + maxSlots];
                    CRITICALRATE[scenario] = new double[1 + maxSlots];
                    CRITICALRATELOW[scenario] = new double[1 + maxSlots];
                    FIRSTCRITICALS[scenario] = new int[1 + maxSlots];
                    

                    for (int slots = 0; slots <= maxSlots; slots++)
                    {
                        tester.ChangeBuild(slots, critComboBonus, halfHpBonus, enemy);

                        // Assign health , 3-CritRing, and rates
                        HEALTH[scenario][slots] = (halfHpBonus) ? enemy.HP / 2 : enemy.HP;
                        REVIVERATE[scenario][slots] = tester.ReviveRate;
                        COMBORATE[scenario][slots] = tester.ComboRate(enemy, critComboBonus: critComboBonus, lowHp: false);
                        COMBORATELOW[scenario][slots] = tester.ComboRate(enemy, critComboBonus: critComboBonus, lowHp: true);
                        CRITICALRATE[scenario][slots] = tester.CriticalRate(enemy, critComboBonus: critComboBonus, lowHp: false);
                        CRITICALRATELOW[scenario][slots] = tester.CriticalRate(enemy, critComboBonus: critComboBonus, lowHp: true);
                        FIRSTCRITICALS[scenario][slots] = tester.firstCriticals;
                        
                        // Get damages
                        damage = tester.AverageDamage(enemy);
                        critDamage = tester.AverageCriticalDamage(enemy, critComboBonus);
                        critDamageLow = tester.AverageCriticalDamageLow(enemy, critComboBonus);
                        double critMult = tester.AverageTrueCriticalMultiplier(enemy, critComboBonus);
                        double critMultLow = tester.AverageTrueCriticalMultiplierLow(enemy, critComboBonus);

                        //Console.WriteLine(tester.AverageDamage(enemy));
                        // Assign damages
                        DAMAGE[scenario][slots] = damage;
                        CRITICALDAMAGE[scenario][slots] = critDamage;
                        CRITICALDAMAGELOW[scenario][slots] = critDamageLow;
                        EXTRACRITICALDAMAGE[scenario][slots] = critDamage - damage;
                        EXTRACRITICALDAMAGELOW[scenario][slots] = critDamageLow - damage;
                        CRITICALMULTIPLIER[scenario][slots] = critMult;
                        CRITICALMULTIPLIERLOW[scenario][slots] = critMultLow;
                        EXTRACRITICALMULTIPLIER[scenario][slots] = critMult - 1;
                        EXTRACRITICALMULTIPLIERLOW[scenario][slots] = critMultLow - 1;
                        PERCENTHPRECOVERED[scenario][slots] = (double)(damage / 50) / tester.HP;
                    }
                }
            }
        }
    }
}