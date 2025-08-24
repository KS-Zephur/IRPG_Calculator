namespace IRPG_Calculator
{


    internal class Character
    {
        public static int MAXREVIVALSLOTS = 2;
        public static double LOWHPCRITICALBONUS = 0.05;
        public static double LOWHPCOMBOBONUS = 0.13;

        public string characterBuild;

        public int runLevel;
        public int abilityLevel;
        public int characterLevel;

        public int kHp;
        public int kAtk;
        public int kDef;
        public int kAgi;
        public int kLuc;
        public double bonusHpPercent;
        public double bonusAtkPercent;
        public double bonusDefPercent;
        public double bonusAgiPercent;
        public double bonusLucPercent;

        public int weaponFlat;
        public double weaponPercent;
        public int weaponCopies;

        public int armourFlat;
        public double armourPercent;
        public int armourCopies;

        public int statHp;
        public int statAtk;
        public int statDef;
        public int statAgi;
        public int statLuc;

        public int recoveryNecklace;
        public int reviveNecklaces;
        public int firstCriticals;
        public int critDmgRings;
        public int critRateRings;
        public bool comboRing;
        public int FGG1;
        public int PotH;
        public int HG;
        public int HG1;
        public int HG2;
        public int GOWG;

        public double ReviveRate
        {
            get
            {
                switch (reviveNecklaces)
                {
                    case 6:
                        return 0.795;
                    case 5:
                        return 0.79;
                    case 4:
                        return 0.785;
                    case 3:
                        return 0.78;
                    case 2:
                        return 0.65;
                    case 1:
                        return 0.47;
                    default:
                        return 0.0;
                }
            }
        }

        public long HealthRecovered(long damageDealt) { return damageDealt * recoveryNecklace / 50; }

        public int WEAPONBONUSMULTIPLIER { get { return (weaponCopies > 1) ? weaponCopies : 0; } }
        public int WEAPONFLATBONUS { get { return ((weaponFlat / 100) * 5 + (int)weaponPercent * 10) * WEAPONBONUSMULTIPLIER; } }
        public int WEAPONPERCENTBONUS { get { return (int)weaponPercent * WEAPONBONUSMULTIPLIER; } }

        public int ARMOURBONUSMULTIPLIER { get { return (armourCopies > 1) ? armourCopies : 0; } }
        public int ARMOURFLATBONUS { get { return ((armourFlat / 100) * 5 + (int)armourPercent * 10) * ARMOURBONUSMULTIPLIER; } }
        public int ARMOURPERCENTBONUS { get { return (int)armourPercent * ARMOURBONUSMULTIPLIER; } }

        public double LEVELBONUS { get { return 0.75 + 0.25 * (characterLevel + abilityLevel); } }
        public double HPBONUS { get { return (1.0 + bonusHpPercent) * (1 + LEVELBONUS * 0.06 * kHp * (1 + 0.5 * PotH)); } }
        public double ATKBONUS { get { return (1.0 + bonusAtkPercent) * (weaponPercent + WEAPONPERCENTBONUS / 100.0 + LEVELBONUS * 0.07 * kAtk * (1 + 0.5 * PotH)); } }
        public double DEFBONUS { get { return (1.0 + bonusDefPercent) * (armourPercent + ARMOURPERCENTBONUS / 100.0 + LEVELBONUS * 0.07 * kDef * (1 + 0.5 * PotH)); } }
        public double AGIBONUS {  get { return (1.0 + bonusAgiPercent) * (1.0 + LEVELBONUS * 0.075 * kAgi * (1.0 + 0.5 * PotH)); } }
        public double LUCBONUS {  get { return (1.0 + bonusLucPercent) * (1.0 + LEVELBONUS * 0.08 * kLuc * (1.0 + 0.5 * PotH)); } }

        public int EXTRABASEHP { get { return (360000 * FGG1 + 30000 * HG + 60000 * HG1 + 120000 * HG2); } }
        public int EXTRABASEATK { get { return (weaponFlat + WEAPONFLATBONUS + 360000 * FGG1 + 30000 * HG + 60000 * HG1 + 120000 * HG2 + 50000 * GOWG); } }
        public int EXTRABASEDEF { get { return (armourFlat + ARMOURFLATBONUS + 360000 * FGG1 + 30000 * HG + 60000 * HG1 + 120000 * HG2 + 50000 * GOWG); } }
        public int EXTRABASEAGI { get { return (360000 * FGG1 + 30000 * HG + 50000 * GOWG); } }
        public int EXTRABASELUC { get { return (30000 * HG + 60000 * HG1 + 120000 * HG2); } }

        public long HP { get { return (long)((statHp + EXTRABASEHP) * HPBONUS); } }
        public int ATK { get { return (int)((statAtk + EXTRABASEATK) * ATKBONUS); } }
        public int DEF { get { return (int)((statDef + EXTRABASEDEF) * DEFBONUS); } }
        public int AGI { get { return (int)((statAgi + EXTRABASEAGI) * AGIBONUS); } }
        public int LUC { get { return (int)((statLuc + EXTRABASELUC) * LUCBONUS); } }

        public double WARUI { get { return HP / 5.0 + ATK / 3.0 + DEF / 3.0 + AGI / 2.0 + LUC; } }
        public double AGIWARUI { get { return AGI / 2.0 / WARUI; } }
        public double LUCWARUI { get { return LUC / WARUI; } }

        public Character()
        {
            characterBuild = "";
            runLevel = 1;
            abilityLevel = 0;
            characterLevel = 0;
            kHp = 1;
            kAtk = 2;
            kDef = 0;
            kAgi = 1;
            kLuc = 0;
            bonusHpPercent = 0.0;
            bonusAtkPercent = 0.0;
            bonusDefPercent = 0.0;
            bonusAgiPercent = 0.0;
            bonusLucPercent = 0.0;
            weaponFlat = 5;
            weaponPercent = 1.0;
            weaponCopies = 1;
            armourFlat = 5;
            armourPercent = 1.0;
            armourCopies = 1;
            statHp = 100;
            statAtk = 10;
            statDef = 10;
            statAgi = 5;
            statLuc = 1;
            recoveryNecklace = 0;
            reviveNecklaces = 0;
            firstCriticals = 0;
            critDmgRings = 0;
            critRateRings = 0;
            comboRing = false;
            FGG1 = 0;
            PotH = 0;
            HG = 0;
            HG1 = 0;
            HG2 = 0;
            GOWG = 0;
        }

        public Character(int level, string build = "", int characterAbilityLevel = 20)
        {
            characterBuild = build;
            runLevel = level;
            abilityLevel = 17;
            characterLevel = characterAbilityLevel;
            kHp = 1;
            kAtk = 2;
            kDef = 0;
            kAgi = 1;
            kLuc = 0;
            bonusHpPercent = 0.0;
            bonusDefPercent = 0.0;
            bonusAgiPercent = 0.0;
            bonusLucPercent = 0.0;
            weaponFlat = 5000;
            weaponPercent = 6.4;
            weaponCopies = 2;
            armourFlat = 5;
            armourPercent = 1.0;
            armourCopies = 1;
            statHp = 2000000;
            statDef = 1999999;
            statAgi = 5;
            statLuc = 1;
            recoveryNecklace = 0;
            reviveNecklaces = 0;
            firstCriticals = 0;
            critDmgRings = 0;
            critRateRings = 0;
            comboRing = false;
            FGG1 = 0;
            PotH = 0;
            HG = 0;
            HG1 = 0;
            HG2 = 0;
            GOWG = 0;

            statAtk = 10;
            SetAtkToLevel();

            bonusAtkPercent = 0.0;
            EstimateBonusPercent();

            ChangeBuild(restrictStatChanges: false);
        }

        public Character(Character character)
        {
            characterBuild = character.characterBuild;
            runLevel= character.runLevel;
            abilityLevel = character.abilityLevel;
            characterLevel = character.characterLevel;
            kHp = character.kHp;
            kAtk = character.kAtk;
            kDef = character.kDef;
            kAgi = character.kAgi;
            kLuc = character.kLuc;
            bonusHpPercent = character.bonusHpPercent;
            bonusAtkPercent = character.bonusAtkPercent;
            bonusDefPercent = character.bonusDefPercent;
            bonusAgiPercent = character.bonusAgiPercent;
            bonusLucPercent = character.bonusLucPercent;
            weaponFlat = character.weaponFlat;
            weaponPercent = character.weaponPercent;
            weaponCopies = character.weaponCopies;
            armourFlat = character.armourFlat;
            armourPercent = character.armourPercent;
            armourCopies = character.armourCopies;
            statHp = character.statHp;
            statAtk = character.statAtk;
            statDef = character.statDef;
            statAgi = character.statAgi;
            statLuc = character.statLuc;
            recoveryNecklace = character.recoveryNecklace;
            reviveNecklaces = character.reviveNecklaces;
            firstCriticals = character.firstCriticals;
            critDmgRings = character.critDmgRings;
            critRateRings = character.critRateRings;
            comboRing = character.comboRing;
            FGG1 = character.FGG1;
            PotH = character.PotH;
            HG = character.HG;
            HG1 = character.HG1;
            HG2 = character.HG2;
            GOWG = character.GOWG;
        }

        private void OptimizeDef(Enemy enemy, double defMult = 2.1, bool halfAtkBonus = false)
        {
            // HMK HH = 1.85
            double neededTotalDef = defMult * enemy.ATK / (halfAtkBonus ? 2 : 1);
            int neededDef = (int)(neededTotalDef / DEFBONUS);
            statDef = Math.Max(10, neededDef - EXTRABASEDEF);
        }

        private void OptimizeHp(Enemy enemy, double hpMult = 3.75, bool halfAtkBonus = false)
        {
            // HMK Reg = 5
            // HMK C&C = 5
            // HMK HH = 3.4
            double neededTotalHp = hpMult * enemy.AverageDamage(this, halfAtkBonus);
            int neededHp = (int)(neededTotalHp / HPBONUS);
            statHp = Math.Max(100, neededHp - EXTRABASEHP);
        }

        private void OptimizeAtk(Enemy enemy, double atkMult = 2)
        {
            double neededTotalAtk = atkMult * enemy.POINT;
            int neededAtk = (int)(neededTotalAtk / ATKBONUS);
            statAtk = Math.Max(10, neededAtk - EXTRABASEATK);
        }

        public void OptimizeHpAtkDef(Enemy enemy, double wantedWinRate = 0.98, bool critComboBonus = false, bool halfHpBonus = false, bool halfAtkBonus = false, bool alterHP = true, bool alterATK = true, bool alterDEF = true, int nonStatGemLevels = 15000, int simulatedRuns = 10000)
        {
            int originalLevel = runLevel;
            int originalDef = statDef;
            int originalHp = statHp;
            int originalAtk = statAtk;
            
            int bestLevel = -1;
            int bestDefMult = 400;
            int bestHpMult = 375;
            int bestAtkMargin = 75;

            int minDefMult = 210;
            int minHpMult = 300;
            int minAtkMult = 1;

            int defMult = minDefMult;
            int hpMult = minHpMult;
            int atkMult = minAtkMult;

            int maxDefMult = (alterDEF) ? 210 : minDefMult;
            int maxHpMult = (alterHP) ? 1500 : minHpMult;
            int maxAtkMult = (alterATK) ? 300 : minAtkMult;

            int defJump = (alterATK || alterHP) ? 10 : 1;
            int hpJump = (alterATK) ? 10 : 1;

            for (defMult = minDefMult; defMult <= maxDefMult; defMult += defJump)
            {
                Console.WriteLine($"DefMult = {100.0 * (defMult - minDefMult) / (maxDefMult - minDefMult):0.#}% ({defMult})");
                if (alterDEF) OptimizeDef(enemy, defMult / 100.0, halfAtkBonus);

                bool breakHp = false;
                double previousBreakPercent = -1;
                int previousBreakLevel = -1;
                for (hpMult = minHpMult; hpMult <= maxHpMult; hpMult += hpJump)
                {
                    Console.WriteLine("=====================================");
                    Console.WriteLine(hpMult);
                    Console.WriteLine("=====================================");
                    if (alterHP) OptimizeHp(enemy, hpMult / 100.0, halfAtkBonus);

                    if (!alterATK)
                    {
                        int neededLevel = ExtractLevel(nonStatGemLevels: nonStatGemLevels);

                        if ((bestLevel != -1) && (neededLevel > bestLevel))
                        {
                            breakHp = true;
                            break;
                        }

                        runLevel = neededLevel;
                        EstimateBonusPercent();
                        double winChance = AverageBattleWinChance(enemy, critComboBonus, halfHpBonus, halfAtkBonus, simulate: true, samples: simulatedRuns, display: false);

                        if (winChance >= wantedWinRate)
                        {
                            bestLevel = neededLevel;
                            bestDefMult = defMult;
                            bestHpMult = hpMult;
                            bestAtkMargin = atkMult;

                            break;
                        }
                    }
                    else
                    {
                        int jump = 80;
                        minAtkMult = 80;
                        double winChance;
                        while (true)
                        {
                            Console.WriteLine(minAtkMult);
                            OptimizeAtk(enemy, minAtkMult / 100.0);


                            runLevel = ExtractLevel(nonStatGemLevels: nonStatGemLevels);
                            EstimateBonusPercent();
                            winChance = AverageBattleWinChance(enemy, critComboBonus, halfHpBonus, halfAtkBonus, simulate: true, samples: simulatedRuns, display: false);

                            if (winChance >= wantedWinRate)
                            {
                                if (jump == 5)
                                {
                                    maxAtkMult = minAtkMult + 3;
                                    minAtkMult -= 7;
                                    /*
                                    if (previousBreakPercent != 0)
                                    {
                                        OptimizeAtk(enemy, minAtkMult / 100.0, critComboBonus, halfHpBonus, halfAtkBonus);
                                        runLevel = ExtractLevel(nonStatGemLevels: nonStatGemLevels);
                                        if (runLevel > bestLevel)
                                        {
                                            breakHp = true;
                                        }
                                    }
                                    */
                                    break;
                                }
                                else
                                {
                                    minAtkMult -= jump;
                                    jump /= 4;
                                }
                            }
                            else if (minAtkMult >= 400)
                            {
                                maxAtkMult = -1;
                                break;
                            }

                            minAtkMult += jump;
                        }

                        winChance = -1;
                        for (atkMult = minAtkMult; atkMult <= maxAtkMult; atkMult += 1)
                        {
                            OptimizeAtk(enemy, atkMult / 100.0);

                            int neededLevel = ExtractLevel(nonStatGemLevels: nonStatGemLevels);

                            if ((bestLevel != -1) && (neededLevel >= bestLevel))
                            {
                                if (winChance != -1)
                                {
                                    previousBreakLevel = -1;
                                    if ((winChance < wantedWinRate) && (winChance >= previousBreakPercent))
                                    {
                                        previousBreakPercent = winChance;
                                    }
                                    else if (winChance < wantedWinRate - 0.05)
                                    {
                                        breakHp = true;
                                    }
                                }
                                else
                                {
                                    if (previousBreakLevel == -1)
                                    {
                                        previousBreakLevel = neededLevel;
                                    }
                                    else if (neededLevel > previousBreakLevel + 1000)
                                    {
                                        breakHp = true;
                                    }
                                }
                                break;
                            }

                            runLevel = neededLevel;
                            EstimateBonusPercent();
                            winChance = AverageBattleWinChance(enemy, critComboBonus, halfHpBonus, halfAtkBonus, simulate: true, samples: simulatedRuns, display: false);

                            Console.WriteLine(atkMult);
                            Console.WriteLine(winChance);

                            if (winChance >= wantedWinRate)
                            {
                                bestLevel = neededLevel;
                                bestDefMult = defMult;
                                bestHpMult = hpMult;
                                bestAtkMargin = atkMult;

                                break;
                            }
                            else if (wantedWinRate - winChance <= 0.01)
                            {
                                winChance = AverageBattleWinChance(enemy, critComboBonus, halfHpBonus, halfAtkBonus, simulate: true, samples: simulatedRuns, display: false);
                                if (winChance >= wantedWinRate)
                                {
                                    bestLevel = neededLevel;
                                    bestDefMult = defMult;
                                    bestHpMult = hpMult;
                                    bestAtkMargin = atkMult;

                                    break;
                                }
                            }
                        }
                    }
                    if (breakHp) break;
                }
                Console.WriteLine(bestDefMult);
                Console.WriteLine(bestHpMult);
                Console.WriteLine(bestAtkMargin);
            }

            if (bestLevel == -1)
            {
                statDef = originalDef;
                statHp = originalHp;
                statAtk = originalAtk;
                runLevel = originalLevel;
            }
            else
            {
                if (alterDEF) OptimizeDef(enemy, bestDefMult / 100.0, halfAtkBonus);
                if (alterHP) OptimizeHp(enemy, bestHpMult / 100.0, halfAtkBonus);
                if (alterATK) OptimizeAtk(enemy, bestAtkMargin / 100.0);
                runLevel = ExtractLevel(nonStatGemLevels: nonStatGemLevels);
            }
        }

        public int ExtractStatPoints(int excessStatPoints = 0)
        {
            int statPoints, statedHp, statedAtk, statedDef, statedAgi, statedLuc;
            statedHp = (int)Math.Ceiling((statHp - 100) / 5.0);
            statedAtk = (int)Math.Ceiling((statAtk - 10) / 3.0);
            statedDef = (int)Math.Ceiling((statDef - 10) / 3.0);
            statedAgi = (int)Math.Ceiling((statAgi - 5) / 2.0);
            statedLuc = statLuc - 1;

            statPoints = excessStatPoints + statedHp + statedAtk + statedDef + statedAgi + statedLuc;
            return statPoints;
        }

        public int ExtractLevel(int excessStatPoints = 0, int nonStatGemLevels = 15000)
        {
            return 1 + (ExtractStatPoints(excessStatPoints) + 2 * nonStatGemLevels) / 6;
        }

        private void SetCriticalComboRates_WithLUC(Enemy enemy, int statPoints, double minimumRawCriticalRate = 0.17, double minimumRawComboRate = 0.22, bool restrictStatChanges = true)
        {
            int stattedAgi = (int)Math.Ceiling((statAgi - 5) / 2.0);
            int neededStattedAgi = (int)Math.Ceiling((1500000 / AGIBONUS - EXTRABASEAGI - 5) / 2.0);
            int usedAgiStatPoints = neededStattedAgi - stattedAgi;
            statAgi = 5 + 2 * neededStattedAgi;
            
            int remainingStatPoints = statPoints - usedAgiStatPoints;
            int stattedLuc = 0;

            if (!restrictStatChanges)
            {
                stattedLuc = statLuc - 1;
                statLuc = 1;
            }
            else if (remainingStatPoints <= 0)
            {
                statAgi = 5 + 2 * (stattedAgi + statPoints);
                return;
            }

            int critRings = critRateRings;
            bool comboRings = comboRing;
            critRateRings = 0;
            comboRing = false;

            int originalAtk = statAtk;
            int originalLuc = statLuc;
            statAtk += 3 * (remainingStatPoints + stattedLuc);

            while ((CriticalRate(enemy) < minimumRawCriticalRate) || (ComboRate(enemy) < minimumRawComboRate))
            {
                statLuc += 1;
                statAtk -= 3;
            }

            if (restrictStatChanges)
            {
                if (statLuc < originalLuc)
                {
                    statLuc = originalLuc;
                    statAtk = originalAtk + 3 * remainingStatPoints;
                }
                else if (statAtk < originalAtk)
                {
                    statAtk = originalAtk;
                    statLuc = originalLuc + remainingStatPoints;
                }
            }

            critRateRings = critRings;
            comboRing = comboRings;
        }

        public void SetCriticalComboRates(Enemy enemy, int statPoints, double minimumRawCriticalRate = 0.16, double minimumRawComboRate = 0.21, bool restrictStatChanges = true, bool useLUC = false)
        {
            int backupAtk = statAtk;
            int backupAgi = statAgi;
            int backupLuc = statLuc;

            int stattedAgi = 0;
            int stattedLuc = 0;

            if (!restrictStatChanges)
            {
                stattedAgi = (int)Math.Ceiling((statAgi - 5) / 2.0);
                statAgi = 5;
                if (useLUC)
                {
                    stattedLuc = statLuc - 1;
                    statLuc = 1;
                }
            }
            else if (statPoints == 0)
            {
                return;
            }

            int critRings = critRateRings;
            bool comboRings = comboRing;
            critRateRings = 0;
            comboRing = false;

            int originalAtk = statAtk;
            int originalAgi = statAgi;

            statAtk += 3 * (statPoints + stattedAgi + stattedLuc);

            while ((CriticalRate(enemy) < minimumRawCriticalRate) || (ComboRate(enemy) < minimumRawComboRate))
            {
                statAgi += 2;
                statAtk -= 3;
            }

            critRateRings = critRings;
            comboRing = comboRings;

            if (restrictStatChanges)
            {
                if (statAgi < originalAgi)
                {
                    statAgi = originalAgi;
                    statAtk = originalAtk + 3 * statPoints;
                }
                else if (statAtk < originalAtk)
                {
                    statAtk = originalAtk;
                    statAgi = originalAgi + 2 * statPoints;
                }
            }

            if ((AGI > 1500000) && useLUC)
            {
                statAtk = backupAtk;
                statAgi = backupAgi;
                statLuc = backupLuc;
                SetCriticalComboRates_WithLUC(enemy, statPoints, minimumRawCriticalRate, minimumRawComboRate, restrictStatChanges);
            }
        }

        public void SetAtkToLevel(int nonStatGemLevels = 20000, int level = -1)
        {
            int setLevel = (level == -1) ? runLevel : level;
            int maximumStatPoints = (setLevel - 1) * 6 - 2 * nonStatGemLevels;
            int stattedHp, stattedDef, stattedAgi, stattedLuc, remainingStatPoints;
            stattedHp = (int)Math.Ceiling((statHp - 100) / 5.0);
            stattedDef = (int)Math.Ceiling((statDef - 10) / 3.0);
            stattedAgi = (int)Math.Ceiling((statAgi - 5) / 2.0);
            stattedLuc = statLuc - 1;
            remainingStatPoints = maximumStatPoints - (stattedHp + stattedDef + stattedAgi + stattedLuc);
            statHp = 100 + 5 * stattedHp;
            statAtk = 10 + 3 * remainingStatPoints;
            statDef = 10 + 3 * stattedDef;
            statAgi = 5 + 2 * stattedAgi;
            statLuc = 1 + stattedLuc;
        }

        public void SetAtkToLevel(int level, int hp, int def, int agi, int luc, int nonStatGemLevels = 20000)
        {
            int maximumStatPoints = (level - 1) * 6 - 2 * nonStatGemLevels;
            int statedHp, statedDef, statedAgi, statedLuc, remainingStatPoints;
            statedHp = (int)Math.Ceiling((hp - 100) / 5.0);
            statedDef = (int)Math.Ceiling((def - 10) / 3.0);
            statedAgi = (int)Math.Ceiling((agi - 5) / 2.0);
            statedLuc = luc - 1;
            remainingStatPoints = maximumStatPoints - (statedHp + statedDef + statedAgi + statedLuc);
            statHp = 100 + 5 * statedHp;
            statAtk = 10 + 3 * remainingStatPoints;
            statDef = 10 + 3 * statedDef;
            statAgi = 5 + 2 * statedAgi;
            statLuc = 1 + statedLuc;
        }

        public void OptimizeAtkHP(Enemy enemy, int statPoints, bool critComboBonus = false, bool halfHpBonus = false, bool halfAtkBonus = false, bool restrictStatChanges = true, int startingDef = 100)
        {
            // Change from DEF -> HP
            int originalAtk = statAtk;
            int originalDef = statDef;

            double currentDifference;
            long myDamage;
            long enemyDamage;
            double bestDifference = 100.0;

            int stattedDef = 0;
            int stattedDefUsed = 0;

            if (!restrictStatChanges)
            {
                stattedDef = (int)Math.Ceiling((statDef - 10) / 3.0);
                stattedDefUsed = (int)Math.Ceiling((startingDef - 10) / 3.0);
                statDef = 10 + 3 * stattedDefUsed;
                stattedDef -= stattedDefUsed;
            }

            statAtk += 3 * (statPoints + stattedDef);

            int bestAtk = statAtk;
            int bestDef = statDef;

            while (statAtk > 10)
            {
                myDamage = this.EstimatedDamagePerTurn(enemy, critComboBonus, halfHpBonus, false);
                enemyDamage = enemy.AverageDamage(this, halfAtkBonus);
                currentDifference = (double)(enemyDamage - HealthRecovered(myDamage)) / this.HP * enemy.HP / myDamage;
                Console.WriteLine(currentDifference);
                if ((currentDifference < bestDifference) || ((double)enemyDamage / this.HP >= 1.0))
                {
                    bestDifference = currentDifference;
                    bestAtk = statAtk;
                    bestDef = statDef;
                }
                else if (currentDifference > bestDifference)
                {
                    break;
                }
                statAtk -= 9999;
                statDef += 9999;
            }

            if (restrictStatChanges)
            {
                if (originalAtk > bestAtk)
                {
                    statAtk = originalAtk;
                    statDef = originalDef + 3 * statPoints;
                    return;
                }
                else if (originalDef > bestDef)
                {
                    statDef = originalDef;
                    statAtk = originalAtk + 3 * statPoints;
                    return;
                }
            }

            statAtk = bestAtk;
            statDef = bestDef;
            Console.WriteLine("===========================================");
        }

        public void Aegis1(int copies = 1)
        {
            armourPercent = 5.2;
            armourFlat = 80000;
            armourCopies = copies;
        }

        public void Dagger()
        {
            weaponPercent = 1.0;
            weaponFlat = 10;
            weaponCopies = 1;
        }

        public void LeatherArmour()
        {
            armourPercent = 1.0;
            armourFlat = 5;
            armourCopies = 1;
        }

        public void Longinus1(int copies = 1)
        {
            weaponPercent = 6.4;
            weaponFlat = 5000;
            weaponCopies = copies;
        }

        public void WingSword1(int copies = 1)
        {
            weaponPercent = 6.6;
            weaponFlat = 30000;
            weaponCopies = copies;
        }

        public void ChangeBuild(int slots = 0, bool critComboBonus = false, bool halfHpBonus = false, Enemy enemy = null, int statPoints = 0, bool restrictStatChanges = true, double crit = 0.16, double combo = 0.21)
        {
            bool modifyAGI = false;

            if (characterBuild.ToLower() == "")
            {
                // No build assigned
                //Console.WriteLine("///////// NO BUILD ASSIGNED /////////")
            }
            else if (characterBuild.ToLower() == "custom")
            {
                ChangeCC(slots, critComboBonus, halfHpBonus);
                modifyAGI = true;
            }
            else if (characterBuild.ToLower() == "test")
            {
                ChangeTest(slots, critComboBonus, halfHpBonus);
                modifyAGI = true;
            }
            else if (characterBuild.ToLower() == "custom2")
            {
                ChangeCC2(slots, critComboBonus, halfHpBonus);
                modifyAGI = true;
            }
            else if (characterBuild.ToLower() == "regular")
            {
                ChangeReg(slots, critComboBonus, halfHpBonus);
            }
            else if (characterBuild.ToLower() == "regular2")
            {
                ChangeReg2(slots, critComboBonus, halfHpBonus);
            }
            else
            {
                Console.WriteLine("///////// WRONG BUILD NAME /////////");
            }

            if (modifyAGI)
            {
                if (enemy == null)
                {
                    enemy = Enemy.Gabriel;
                }
                //SetCriticalComboRates(enemy, statPoints, crit, combo, restrictStatChanges: restrictStatChanges);
            }
            else
            {
                statAtk += 3 * statPoints;
            }
        }

        public void BattleGear()
        {
            //WingSword1(3);
            Longinus1(3);
            Aegis1(7);
            recoveryNecklace = 2;
        }

        public void ReviveGear()
        {
            // x2 Wing Sword+1 == x6 Longinus+1
            //WingSword1(2);
            Longinus1(3);
            LeatherArmour();
            //Aegis1(7);
            reviveNecklaces = 3;
            recoveryNecklace = 1;
        }

        public void RemoveGear()
        {
            Dagger();
            LeatherArmour();
        }

        public void RemoveSlots()
        {
            recoveryNecklace = 0;
            reviveNecklaces = 0;
            firstCriticals = 0;
            critDmgRings = 0;
            critRateRings = 0;
            comboRing = false;
            FGG1 = 0;
            PotH = 0;
            GOWG = 0;
            HG = 0;
            HG1 = 0;
            HG2 = 0;
        }

        public void ChangeToExpSet(int fgg1 = 2, int poth = 0, bool useHeroGem = false)
        {
            RemoveSlots();
            BattleGear();
            FGG1 = fgg1;
            PotH = poth;

            if (useHeroGem)
            {
                HG = 2;
                GOWG = 0;
            }
            else
            {
                HG = 0;
                GOWG = 2;
            }
        }

        public void ChangeToLuckSet(int hg2 = 0, int poth = 0, int fgg1 = 2)
        {
            RemoveSlots();
            BattleGear();
            HG = 2;
            HG2 = hg2;
            PotH = poth;
            FGG1 = fgg1;
        }

        public void ChangeToStatSet(bool useComboRing = false, bool useHeroGem = false, bool critComboBonus = false, bool halfHpBonus = false)
        {
            RemoveSlots();
            BattleGear();
            FGG1 = 3;
            PotH = 3;

            if (useComboRing) { comboRing = true; }
            else { firstCriticals = 3; }

            if (useHeroGem) { HG = 2; }
            else { GOWG = 2; }
        }

        public void ChangeReg(int slots = 2, bool critComboBonus = false, bool halfHpBonus = false)
        {
            characterBuild = "regular";
            RemoveSlots();
            ReviveGear();
            firstCriticals = (slots > 0) ? 3 : 0;
            critDmgRings = (slots > 1) ? 1 : 0;
            critRateRings = 0;
            comboRing = false;
            HG = 2;
            GOWG = 0;

            if (critComboBonus)
            {
                FGG1 = 0;
                PotH = 2;
            }
            else
            {
                FGG1 = 2;// (slots > 0) ? 1 : 2;
                PotH = 0;// (slots > 0) ? 1 : 0;
            }
        }

        public void ChangeReg2(int slots = 2, bool critComboBonus = false, bool halfHpBonus = false)
        {
            characterBuild = "regular2";
            RemoveSlots();
            ReviveGear();
            GOWG = 2;

            if (critComboBonus)
            {
                critDmgRings = slots;
                FGG1 = 0;
                PotH = 2;
            }
            else
            {
                FGG1 = 2;
                PotH = slots;
            }
        }

        public void ChangeCC(int slots = 2, bool critComboBonus = false, bool halfHpBonus = false)
        {
            characterBuild = "custom";
            RemoveSlots();
            ReviveGear();
            FGG1 = 0;
            PotH = 0;
            HG = 2;
            GOWG = 0;
            critRateRings = 2;
            comboRing = false;

            if (critComboBonus)
            {
                if ((slots > 1) && (ATK >= 99500000))
                {
                    firstCriticals = (slots > 1) ? 3 : 0;
                    critDmgRings = (slots > 0) ? 1 : 0;
                }
                else
                {
                    firstCriticals = 0;
                    critDmgRings = slots;
                }
            }
            else if (halfHpBonus)
            {
                firstCriticals = (slots > 0) ? 3 : 0;
                critDmgRings = (slots > 1) ? 1 : 0;
                if (slots == 0)
                {
                    critRateRings = 1;
                    comboRing = true;
                }
            }
            else
            {
                // Has something to do with "hits to kill", but basically below 8.731m ATK this setup has a better chance with 2 Crit Dmg Rings
                if ((slots > 1) && (ATK >= 87000000))
                {
                    firstCriticals = (slots > 1) ? 3 : 0;
                    critDmgRings = (slots > 0) ? 1 : 0;
                }
                else
                {
                    firstCriticals = 0;
                    critDmgRings = slots;
                }
            }
        }

        public void ChangeTest(int slots = 2, bool critComboBonus = false, bool halfHpBonus = false)
        {
            characterBuild = "test";
            RemoveSlots();
            ReviveGear();
            bool twoCritRateRings = critComboBonus || (slots > 0);
            GOWG = 2;
            HG = 0;
            critDmgRings = slots;
            critRateRings = twoCritRateRings ? 2 : 1;
            comboRing = !twoCritRateRings;
        }

        public void ChangeCC2(int slots = 2, bool critComboBonus = false, bool halfHpBonus = false)
        {
            characterBuild = "custom2";
            RemoveSlots();
            ReviveGear();
            bool twoCritRateRings = critComboBonus || (slots > 0);
            GOWG = 2;
            critDmgRings = slots;
            critRateRings = twoCritRateRings ? 2 : 1;
            comboRing = !twoCritRateRings;
        }

        public void SetCustomGabrielBuild(int statPoints = 0, bool restrictStatChanges = true)
        {
            Enemy gabriel = Enemy.Gabriel;
            ChangeCC();
            SetCriticalComboRates(gabriel, statPoints, 0.16, 0.21, restrictStatChanges: restrictStatChanges);
        }

        public void SetCustomTwilightBuild(int statPoints = 0, bool restrictStatChanges = true)
        {
            Enemy TP = Enemy.TwilightPortal;
            ChangeCC2();
            SetCriticalComboRates(TP, statPoints, 0.16, 0.21, restrictStatChanges: restrictStatChanges);
        }

        public void SetCustomTwilightGabrielBuild(int statPoints = 0, bool restrictStatChanges = true)
        {
            if (restrictStatChanges && (statPoints != 0))
            {
                SetCustomGabrielBuild(statPoints, restrictStatChanges);
                return;
            }

            int originalHp = statHp;
            int originalAtk = statAtk;
            int originalAgi = statAgi;

            SetCustomTwilightBuild(statPoints, restrictStatChanges: false);

            int usedStatPoints = (statHp - originalHp) / 5;
            statAtk = originalAtk;
            statAgi = originalAgi;

            if (restrictStatChanges)
            {
                if (statHp < originalHp)
                {
                    // Overstatted HP
                    statHp = originalHp;
                    usedStatPoints = 0;
                }
                else if (usedStatPoints > statPoints)
                {
                    // Not enough HP; give up LowHp
                    statHp = originalHp;
                    usedStatPoints = 0;
                }
            }

            int remainingStatPoints = statPoints - usedStatPoints;
            SetCustomGabrielBuild(remainingStatPoints, restrictStatChanges);
        }

        public void SetTestBuild(Enemy enemy, int statPoints = 0, bool restrictStatChanges = true, bool setLowHp = false)
        {
            ChangeTest();
            SetCriticalComboRates(enemy, statPoints, minimumRawCriticalRate: 0.16, minimumRawComboRate: 0.21, restrictStatChanges: restrictStatChanges);
        }

        public double ComboRate(Enemy enemy, bool critComboBonus = false, bool lowHp = false)
        {
            double rate = 0.06 + 0.52 * AGI / enemy.BEIT;
            rate += 0.14 * Math.Min(AGI / 1500000.0, 1);
            rate += 0.02 * Math.Min(LUC / 1000000.0, 1);
            rate += 0.24 * AGIWARUI;
            rate = Math.Min(rate, 0.5);
            rate += 0.24 * AGIWARUI;
            rate = Math.Floor(rate * 100) / 100;
            if (comboRing)
            {
                rate += 0.09;
            }
            rate = Math.Min(rate, 0.7);
            rate = Math.Floor(rate * 100) / 100;
            if (critComboBonus)
            {
                rate = rate * 1.1 + 0.075;
                rate = Math.Min(Math.Max(rate, 0.45), 0.72);
                rate = Math.Floor(rate * 100) / 100;
            }
            if (lowHp)
            {
                rate += LOWHPCOMBOBONUS;
                rate = Math.Min(rate, 0.8);
            }
            return rate;
        }

        public double CriticalRate(Enemy enemy, bool critComboBonus = false, bool lowHp = false)
        {
            double rate = 0.06 + 0.07 * AGI / enemy.BEIT + 0.22 * LUC / enemy.BEIT;
            rate += 0.1 * Math.Min(AGI / 1500000.0, 1);
            rate += 0.02 * Math.Min(LUC / 1000000.0, 1);
            rate += 0.11 * AGIWARUI;
            rate += 0.14 * LUCWARUI;
            rate = Math.Min(rate, 0.35);
            rate += 0.11 * AGIWARUI;
            rate += 0.14 * LUCWARUI;
            rate = Math.Floor(rate * 100) / 100;
            rate += 0.08 * critRateRings;
            rate = Math.Min(rate, 0.6);
            if (critComboBonus)
            {
                rate = rate * 1.05 + 0.075;
                rate = Math.Min(Math.Max(rate, 0.2), 0.6);
                rate = Math.Floor(rate * 100) / 100;
            }
            if (lowHp)
            {
                rate += LOWHPCRITICALBONUS;
                rate = Math.Min(rate, 0.7);
            }
            return rate;
        }

        public long DamageCalculation(Enemy enemy, double odds1, double odds2, double odds3, bool critical = false, double odds4 = 0, double criticalRate = 0.06)
        {
            double damage = ATK;
            double defense = 1.1 * enemy.POINT;
            if (critical)
            {
                double crit = Math.Min(Math.Floor(odds4 * (18.0 * criticalRate + 1.2)), 5.0);
                damage = (damage + 1) * (1.75 + crit / 5.0) * (1.0 + 0.2 * critDmgRings) + 4;
            }
            if (defense > damage)
            {
                defense = (defense * 3.0 + damage * 2.0) / 5.0;
            }
            defense *= 0.3;
            if (defense >= 0.32 * damage)
            {
                defense = (defense + 0.32 * damage * 99.0) / 100.0;
            }
            defense = defense + enemy.POINT * (0.02 + 0.02 * odds1);
            if (defense >= 0.44 * damage)
            {
                defense = (defense + 0.44 * damage * 199.0) / 200.0;
            }
            damage -= defense;
            damage *= 0.88;
            damage *= 0.9 + 0.2 * odds2;
            damage += 4.0 * odds3 - 2;
            return (long)damage;
        }

        public long AverageDamage(Enemy enemy)
        {
            long total = 0;

            for (int odds1 = 0; odds1 <= 100; odds1 += 1)
            {
                total += DamageCalculation(enemy, odds1 / 100.0, 0.5, 0.5);
            }

            return total / 101;
        }

        public long AverageCriticalDamage(Enemy enemy, bool critComboBonus = false)
        {
            long total = 0;
            double criticalRate = CriticalRate(enemy, critComboBonus, false);

            for (int odds1 = 0; odds1 <= 100; odds1 += 1)
            {
                long subtotal1 = 0;
                for (int odds4 = 0; odds4 <= 100; odds4 += 1)
                {
                    subtotal1 += DamageCalculation(enemy, odds1 / 100.0, 0.5, 0.5, true, odds4 / 100.0, criticalRate);
                }
                total += subtotal1 / 101;
            }

            return total / 101;
        }

        public long AverageCriticalDamageLow(Enemy enemy, bool critComboBonus = false)
        {
            long total = 0;
            double criticalRateLow = CriticalRate(enemy, critComboBonus, true);

            for (int odds1 = 0; odds1 <= 100; odds1 += 1)
            {
                long subtotal1 = 0;
                for (int odds4 = 0; odds4 <= 100; odds4 += 1)
                {
                    subtotal1 += DamageCalculation(enemy, odds1 / 100.0, 0.5, 0.5, true, odds4 / 100.0, criticalRateLow);
                }
                total += subtotal1 / 101;
            }

            return total / 101;
        }

        public double AverageBaseCriticalMultiplier(Enemy enemy, bool critComboBonus)
        {
            double total = 0;
            double criticalRate = CriticalRate(enemy, critComboBonus, false);

            for (int odds = 0; odds <= 100; odds += 1)
            {
                int crit = Math.Min((int)Math.Floor(odds / 100.0 * (18.0 * criticalRate + 1.2)), 5);
                total += crit;
            }
            total /= 101;

            return (1.75 + total / 5.0) * (1.0 + 0.2 * critDmgRings);
        }

        public double AverageBaseCriticalMultiplierLow(Enemy enemy, bool critComboBonus)
        {
            double total = 0;
            double criticalRateLow = CriticalRate(enemy, critComboBonus, true);

            for (int odds = 0; odds <= 100; odds += 1)
            {
                int crit = Math.Min((int)Math.Floor(odds / 100.0 * (18.0 * criticalRateLow + 1.2)), 5);
                total += crit;
            }
            total /= 101;

            return (1.75 + total / 5.0) * (1.0 + 0.2 * critDmgRings);
        }

        public double AverageTrueCriticalMultiplier(Enemy enemy, bool critComboBonus)
        {
            double total = 0;
            double subtotal1;
            double criticalRate = CriticalRate(enemy, critComboBonus, false);

            for (int odds1 = 0; odds1 <= 100; odds1 += 1)
            {
                subtotal1 = 0;
                long damage = DamageCalculation(enemy, odds1 / 100.0, 0.5, 0.5, false);
                for (int odds4 = 0; odds4 <= 100; odds4 += 1)
                {
                    subtotal1 += DamageCalculation(enemy, odds1 / 100.0, 0.5, 0.5, true, odds4 / 100.0, criticalRate);
                }
                subtotal1 /= 101;
                total += subtotal1 / damage;
            }

            return total / 101.0;
        }

        public double AverageTrueCriticalMultiplierLow(Enemy enemy, bool critComboBonus)
        {
            double total = 0;
            double subtotal1;
            double criticalRateLow = CriticalRate(enemy, critComboBonus, true);

            for (int odds1 = 0; odds1 <= 100; odds1 += 1)
            {
                subtotal1 = 0;
                long damage = DamageCalculation(enemy, odds1 / 100.0, 0.5, 0.5, false);
                for (int odds4 = 0; odds4 <= 100; odds4 += 1)
                {
                    subtotal1 += DamageCalculation(enemy, odds1 / 100.0, 0.5, 0.5, true, odds4 / 100.0, criticalRateLow);
                }
                subtotal1 /= 101;
                total += subtotal1 / damage;
            }

            return total / 101.0;
        }

        public double EstimatedMultiplierPerTurn(int turns, Enemy enemy, bool critComboBonus, bool halfHpBonus)
        {
            double comboRate = ComboRate(enemy, critComboBonus, false);
            double critRate = CriticalRate(enemy, critComboBonus, false);
            double critRateLow = CriticalRate(enemy, critComboBonus, true);
            double critMult = AverageTrueCriticalMultiplier(enemy, critComboBonus);
            double critMultLow = AverageTrueCriticalMultiplierLow(enemy, critComboBonus);

            double estimatedAttempts = turns / (1 -  comboRate);
            double lowTurnPercentage = (turns - 1) / estimatedAttempts;

            double regCritFactor = (1.0 - lowTurnPercentage) * (1.0 + critRate * (critMult - 1.0));
            double lowCritFactor = lowTurnPercentage * (1.0 + critRateLow * (critMultLow - 1.0));

            double result = (regCritFactor + lowCritFactor) / (1.0 - comboRate);
            if (firstCriticals == 3)
            {
                double adjustment1 = comboRate * comboRate * critMult;
                double adjustment2 = 2 * comboRate * (1.0 - comboRate) * (2 * critMult + critMultLow) / 3;
                double adjustment3 = (1.0 - comboRate) * (1.0 - comboRate) * (critMult + 2 * critMultLow) / 3;
                double adjustment = adjustment1 + adjustment2 + adjustment3;
                long avgDamage = AverageDamage(enemy);

                double tripleCritHits = 3 + ((halfHpBonus ? enemy.HP / 2 : enemy.HP) - 3 * avgDamage * adjustment) / (avgDamage * result);
                double tripleCritMult = (halfHpBonus ? enemy.HP / 2 : enemy.HP) / (avgDamage * tripleCritHits);

                result = tripleCritMult;
            }

            return result;
        }

        public double EstimatedMultiplierPerTurnLimit(Enemy enemy, bool critComboBonus, bool halfHpBonus, bool lowCrit = true)
        {
            double result;

            double comboRate = ComboRate(enemy, critComboBonus, false);
            double critRate = CriticalRate(enemy, critComboBonus, false);
            double critMult = AverageTrueCriticalMultiplier(enemy, critComboBonus);

            if (lowCrit == false)
            {
                result = (1 + critRate * (critMult - 1)) / (1 - comboRate);
                return result;
            }

            double critRateLow = CriticalRate(enemy, critComboBonus, true);
            double critMultLow = AverageTrueCriticalMultiplierLow(enemy, critComboBonus);

            double regCritFactor = 1.0 + critRate * (critMult - 1.0);
            double lowCritFactor = 1.0 + critRateLow * (critMultLow - 1.0);

            result = lowCritFactor + regCritFactor * (1.0 / (1.0 - comboRate) - 1.0);
            if (firstCriticals == 3)
            {
                double adjustment1 = comboRate * comboRate * (critMult);
                double adjustment2 = 2 * comboRate * (1.0 - comboRate) * ((2 * critMult + critMultLow) / 3);
                double adjustment3 = (1.0 - comboRate) * (1.0 - comboRate) * ((critMult + 2 * critMultLow) / 3);
                double adjustment = adjustment1 + adjustment2 + adjustment3;
                long avgDamage = AverageDamage(enemy);

                double tripleCritHits = 3 + ((halfHpBonus ? enemy.HP / 2 : enemy.HP) - 3 * avgDamage * adjustment) / (avgDamage * result);
                double tripleCritMult = (halfHpBonus ? enemy.HP / 2 : enemy.HP) / (avgDamage * tripleCritHits);

                result = tripleCritMult;
            }

            return result;
        }

        public long EstimatedDamagePerTurn(Enemy enemy, bool critComboBonus, bool halfHpBonus, bool lowCrit = true)
        {
            return (long)(AverageDamage(enemy) * EstimatedMultiplierPerTurnLimit(enemy, critComboBonus, halfHpBonus, lowCrit));
        }

        //array[scenario][slots]
        public double[][] RevivalWinRates(Enemy enemy)
        {
            // 0 = No Bonus; 1 = Crit & Combo Bonus; 2 = Half HP Bonus
            double[][] results = CritComboCalculator.RevivalBattle_WinChances_Precise(this, enemy);
            return results;
        }

        public double BossWinRate(Enemy enemy, int startingBP = 7, int startingSlots = 2)
        {
            var rateList = RevivalWinRates(enemy);
            return BossWinRate(rateList, startingBP, startingSlots);
        }

        // 0 = No Bonus; 1 = C&C; 2 = Half HP; 3 = Weighted Average
        public static double BossWinRate(double[][] rateList, int startingBP, int startingSlots = 2)
        {
            double result;

            double regularResult, critComboResult, halfHpResult, halfAtkResult;
            double[] regularRates, critComboRates, halfHpRates, halfAtkRates;
            double regularFail, critComboFail, halfHpFail, halfAtkFail;

            int BP = startingBP;
            int[] slotAttempts = new int[1 + MAXREVIVALSLOTS];
            int currentSlot;
            int regularAttempts, bonusAttempts, remainingBonus;

            regularRates = rateList[0];
            critComboRates = rateList[1];
            halfHpRates = rateList[2];
            halfAtkRates = rateList[3];

            // Get the attempts for each slot
            currentSlot = startingSlots;
            while (BP > 0)
            {
                slotAttempts[currentSlot]++;
                BP -= 5;

                if ((BP < 6) && (currentSlot > 0))
                {
                    currentSlot--;
                    BP += 7;
                }
            }

            regularFail = 1;
            // "No bonus" fail chance
            for (int i = 0; i <= MAXREVIVALSLOTS; i++)
            {
                regularFail *= Math.Pow(1 - regularRates[i], slotAttempts[i]);
            }
            regularResult = 1 - regularFail;

            critComboResult = 0;
            halfHpResult = 0;
            halfAtkResult = 0;

            double bonusChance;
            // Total 10 combat bonus scenarios (5 per bonus)
            for (int bonus = 2; bonus <= 6; bonus++)
            {
                if ((bonus == 2) || (bonus == 6)) { bonusChance = 0.125; }
                else { bonusChance = 0.250; }

                // Amount of bonus attempts left
                remainingBonus = bonus;

                critComboFail = 1;
                halfHpFail = 1;
                halfAtkFail = 1;
                for (int slots = MAXREVIVALSLOTS; slots >= 0; slots--)
                {
                    // Bonus attempts for the slot
                    bonusAttempts = Math.Min(remainingBonus, slotAttempts[slots]);
                    // "No bonus" attempts for the slots, due to bonus running out
                    regularAttempts = slotAttempts[slots] - bonusAttempts;
                    // Bonus attemots left after this slot
                    remainingBonus -= bonusAttempts;

                    // Fail chance of the "no bonus" attempts for this slot
                    regularFail = Math.Pow(1 - regularRates[slots], regularAttempts);
                    // Fail chance for the slot in this scenario
                    critComboFail *= Math.Pow(1 - critComboRates[slots], bonusAttempts) * regularFail;
                    halfHpFail *= Math.Pow(1 - halfHpRates[slots], bonusAttempts) * regularFail;
                    halfAtkFail *= Math.Pow(1 - halfAtkRates[slots], bonusAttempts) * regularFail;
                }
                // Success% = 1 - Fail%
                critComboResult += (1 - critComboFail) * bonusChance;
                halfHpResult += (1 - halfHpFail) * bonusChance;
                halfAtkResult += (1 - halfAtkFail) * bonusChance;
            }

            // 60.50% No Bonus chance; 17.28% C&C chance; 11.11% Half HP chance; 11.11% Half ATK chance
            result = 0.6050 * regularResult + 0.1728 * critComboResult + 0.1111 * halfHpResult + 0.1111 * halfAtkResult;

            return result;
        }

        public double RunWinRate(string twilight_buildName = "custom2", int startingBP = 9, int startingSlots = 2, int gabrielGainedLevels = 20000, int statPoints = 0, bool restrictStatChanges = true)
        {
            Enemy Gabriel = Enemy.Gabriel;
            Enemy Twilight = Enemy.TwilightPortal;

            Character tester1 = new Character(this);

            tester1.ChangeBuild(enemy: Gabriel, statPoints: statPoints, restrictStatChanges: restrictStatChanges, crit:0.16, combo:0.21);
            double[][] gabrielWinRates = tester1.RevivalWinRates(Gabriel);

            tester1.characterBuild = twilight_buildName;
            tester1.ChangeBuild(enemy: Twilight, statPoints: 4 * gabrielGainedLevels, restrictStatChanges: true, crit: 0.16, combo: 0.21);
            double[][] twilightWinRates = tester1.RevivalWinRates(Twilight);

            return RunWinRate(gabrielWinRates, twilightWinRates, startingBP, startingSlots);
        }

        public static double RunWinRate(double[][] gabrielWinRates, double[][] twilightWinRates, int startingBP = 9, int startingSlots = 2)
        {
            // 0 = None; 1 = C&C; 2 = HalfHP
            const int SCENARIOS = 3;

            double result = 0;

            if (startingBP <= 0)
            {
                return result;
            }

            double[] SCENARIOCHANCE = { 0.7161, 0.1728, 0.1111 };
            double[] ROUNDSCHANCE = { 0.000, 0.000, 0.125, 0.250, 0.250, 0.250, 0.125 };

            int gabrielSlots = startingSlots;
            int gabrielBP = startingBP;



            if ((gabrielBP <= 5) && (gabrielSlots > 0))
            {
                gabrielBP += 7;
                gabrielSlots--;
            }


            int min_rolledRounds = 2;
            int max_rolledRounds = 6;
            for (int rolledRounds = min_rolledRounds; rolledRounds <= max_rolledRounds; rolledRounds++)
            {
                double roundChance = ROUNDSCHANCE[rolledRounds];

                double rolledScenario_total = 0;
                for (int rolledScenario = 0; rolledScenario < SCENARIOS; rolledScenario++)
                {
                    double scenarioChance = SCENARIOCHANCE[rolledScenario];
                    int currentScenario = rolledScenario;
                    int currentSlots = startingSlots;
                    int currentBP = startingBP;
                    int remainingBonusRounds = (currentScenario == 0) ? 0 : rolledRounds;

                    double accumulatedChance = 1;
                    double gabriel_total = 0;
                    while (currentBP > 0)
                    {
                        int twilightBP = currentBP + 3 - 5;
                        int twilightSlots = currentSlots;
                        if ((twilightBP <= 5) && (twilightSlots > 0))
                        {
                            twilightBP += 7;
                            twilightSlots--;
                        }

                        if (twilightBP <= 0)
                        {
                            // Will not be able to fight Twilight in latter situations [0% remaining win chance]
                            break;
                        }

                        double gabrielWinChance = gabrielWinRates[currentScenario][currentSlots];
                        double situationChance = accumulatedChance * gabrielWinChance;

                        double situationRate = Character.BossWinRate(twilightWinRates, twilightBP, twilightSlots);

                        gabriel_total += situationChance * situationRate;

                        accumulatedChance *= (1 - gabrielWinChance);

                        currentBP -= 5;
                        if ((currentBP <= 5) && (currentSlots > 0))
                        {
                            currentBP += 7;
                            currentSlots--;
                        }

                        if (remainingBonusRounds > 0)
                        {
                            remainingBonusRounds--;
                            if (remainingBonusRounds == 0)
                            {
                                currentScenario = 0;
                            }
                        }

                    }

                    rolledScenario_total += scenarioChance * gabriel_total;
                }

                result += roundChance * rolledScenario_total;
            }

            return result;
        }

        private bool IsPercentLowHp(double hpPercentLeft) { return (hpPercentLeft < 0.25); }

        // True if won, else false
        public (bool, int) SimulateBattle(Enemy enemy, bool critComboBonus = false, bool halfHpBonus = false, bool halfAtkBonus = false, bool useComboLow = true)
        {
            Random RNG = new Random(Guid.NewGuid().GetHashCode());
            long myHpLeft = this.HP;
            long enemyHpLeft = enemy.HP / (halfHpBonus ? 2 : 1);
            long damageDealt;
            int firstCritsLeft = firstCriticals;
            int turnsTaken = 0;
            double critRate;
            bool didCrit;
            double rng1, rng2, rng3, rng4, rng5, rng6, rng7;

            while (true)
            {
                turnsTaken++;
                //
                rng1 = RNG.NextDouble();
                rng2 = RNG.NextDouble();
                rng3 = RNG.NextDouble();
                rng4 = RNG.NextDouble();
                critRate = CriticalRate(enemy, critComboBonus, myHpLeft < (this.HP / 4));
                didCrit = (firstCritsLeft > 0) || (critRate > RNG.NextDouble());
                damageDealt = this.DamageCalculation(enemy, rng1, rng2, rng3, didCrit, rng4, critRate);
                enemyHpLeft -= damageDealt;
                myHpLeft += HealthRecovered(damageDealt);
                if (myHpLeft > this.HP)
                {
                    myHpLeft = this.HP;
                }
                if (firstCriticals > 0)
                {
                    firstCritsLeft--;
                }
                if (enemyHpLeft <= 0)
                {
                    return (true, turnsTaken);
                }
                while (ComboRate(enemy, critComboBonus, useComboLow && (myHpLeft < (this.HP / 4))) > RNG.NextDouble())
                {
                    rng1 = RNG.NextDouble();
                    rng2 = RNG.NextDouble();
                    rng3 = RNG.NextDouble();
                    rng4 = RNG.NextDouble();
                    critRate = CriticalRate(enemy, critComboBonus, myHpLeft < (this.HP / 4));
                    didCrit = (firstCritsLeft > 0) || (critRate > RNG.NextDouble());
                    damageDealt = this.DamageCalculation(enemy, rng1, rng2, rng3, didCrit, rng4, critRate);
                    enemyHpLeft -= damageDealt;
                    myHpLeft += HealthRecovered(damageDealt);
                    if (myHpLeft > this.HP)
                    {
                        myHpLeft = this.HP;
                    }
                    if (firstCriticals > 0)
                    {
                        firstCritsLeft--;
                    }
                    if (enemyHpLeft <= 0)
                    {
                        return (true, turnsTaken);
                    }
                }
                myHpLeft = Math.Min(myHpLeft, this.HP);
                //
                rng5 = RNG.NextDouble();
                rng6 = RNG.NextDouble();
                rng7 = RNG.NextDouble();
                bool canRevive = (myHpLeft > 1);
                myHpLeft -= enemy.DamageCalculation(this, rng5, rng6, rng7, halfAtkBonus);
                //
                if (myHpLeft <= 0)
                {
                    if ((canRevive) && (ReviveRate > RNG.NextDouble()))
                    {
                        myHpLeft = 1;
                    }
                    else
                    {
                        return (false, turnsTaken);
                    }
                }
            }
        }

        public double AverageBattleWinChance(Enemy enemy, bool critComboBonus = false, bool halfHpBonus = false, bool halfAtkBonus = false, bool simulate = true, bool useLowCombo = true, int samples = 10000, bool display = false)
        {

            long averageDamageDealt = this.AverageDamage(enemy);
            long averageDamageReceived = enemy.AverageDamage(this, halfAtkBonus);
            double HpPercentHealed = (double)HealthRecovered(averageDamageDealt) / HP;
            double HpPercentLost = (double)averageDamageReceived / HP;

            int wonBattles = 0;
            int battleLength = 0;
            int wonBattleLength = 0;
            if ((HpPercentLost <= HpPercentHealed) && (HpPercentLost < 1.0))
            {
                wonBattles = samples;
            }
            else if (simulate)
            {
                for (int i = 0; i < samples; i++)
                {
                    var results = SimulateBattle(enemy, critComboBonus, halfHpBonus, halfAtkBonus, useLowCombo);
                    bool winner = results.Item1;
                    int turns = results.Item2;
                    if (winner)
                    {
                        wonBattles += 1;
                        wonBattleLength += turns;
                    }
                    battleLength += turns;
                }
            }

            if (display)
            {

                bool lowHp = (reviveNecklaces > 0) ? true : false;
                double DmgPercentHealed = (double)HealthRecovered(averageDamageDealt) / averageDamageReceived;
                double neededHits = (double)enemy.HP / averageDamageDealt * (halfHpBonus ? 0.5 : 1);
                double estimatedHits = neededHits / EstimatedMultiplierPerTurnLimit(enemy, critComboBonus, halfHpBonus, lowHp);
                double reviveRate = ReviveRate;
                double comboRate = ComboRate(enemy, critComboBonus, false);
                double critRate = CriticalRate(enemy, critComboBonus, false);
                double critMult = AverageTrueCriticalMultiplier(enemy, critComboBonus);

                Console.WriteLine($"Level = {runLevel}");
                Console.WriteLine($"Rank Bonus = {100 * bonusAtkPercent}%");
                Console.WriteLine($"Revive Rate = {100 * reviveRate:0}%");
                Console.WriteLine($"Combo Rate = {100 * comboRate:0}%");
                Console.WriteLine($"Critical Rate = {100 * critRate:0}%");
                Console.WriteLine($"Average Critical Multiplier = x{critMult:0.###}");
                Console.WriteLine($"HP = {statHp} => {HP}");
                Console.WriteLine($"ATK = {statAtk} => {ATK}");
                Console.WriteLine($"DEF = {statDef} => {DEF}");
                Console.WriteLine($"AGI = {statAgi} => {AGI}");
                Console.WriteLine($"LUC = {statLuc} => {LUC}");
                Console.WriteLine($"Average Damage Dealt = {averageDamageDealt}");
                Console.WriteLine($"Average %HP Healed = {100 * HpPercentHealed:0.#####}%");
                Console.WriteLine($"Average Damage Received = {averageDamageReceived}");
                Console.WriteLine($"Average %HP Lost = {100 * HpPercentLost:0.#####}%");
                Console.WriteLine($"Average %Dmg Healed = {100 * DmgPercentHealed:0.###}%");
                Console.WriteLine($"Average Hits Healed Per Combo = {HpPercentHealed / (HpPercentLost - HpPercentHealed):0.###}");
                Console.WriteLine($"Average Hits Healed Per Crit = {HpPercentHealed * (critMult - 1) / (HpPercentLost - HpPercentHealed):0.###}");
                Console.WriteLine($"Needed Hits Minimum = {neededHits:0.###}");
                Console.WriteLine($"Estimated Turns Needed = {estimatedHits:0.###}");
                Console.WriteLine($"Average Turns Needed = {(double)wonBattleLength / Math.Max(1, wonBattles):0.###}");
                Console.WriteLine($"Average Turns Taken = {(double)battleLength / samples:0.###}");
                Console.WriteLine($"Average Win Rate = {100.0 * wonBattles / samples:0.###}%");
            }

            return (double)wonBattles / samples;
        }

        public void EstimateBonusPercent()
        {
            if (runLevel > 800000) { bonusAtkPercent = 0.15; }
            else if (runLevel > 700000) { bonusAtkPercent = 0.149; }
            else if (runLevel > 600000) { bonusAtkPercent = 0.147; }
            else if (runLevel > 450000) { bonusAtkPercent = 0.143; }
            else if (runLevel > 400000) { bonusAtkPercent = 0.14; }
            else if (runLevel > 375000) { bonusAtkPercent = 0.136; }
            else if (runLevel > 350000) { bonusAtkPercent = 0.132; }
            else if (runLevel > 325000) { bonusAtkPercent = 0.126; }
            else if (runLevel > 300000) { bonusAtkPercent = 0.118; }
            else if (runLevel > 275000) { bonusAtkPercent = 0.113; }
            else if (runLevel > 250000) { bonusAtkPercent = 0.097; }
            else if (runLevel > 225000) { bonusAtkPercent = 0.086; }
            else if (runLevel > 190000) { bonusAtkPercent = 0.077; }
            else if (runLevel > 170000) { bonusAtkPercent = 0.074; }
            else if (runLevel > 150000) { bonusAtkPercent = 0.072; }
            else if (runLevel > 130000) { bonusAtkPercent = 0.07; }
            else { bonusAtkPercent = 0.04; }
        }

        public void DisplayRevivalCombatStatistics(Enemy enemy)
        {
            const int SCENARIOS = 3;
            string[] scenarioNames = new string[SCENARIOS] { "No Bonus", "Crit & Combo", "Half HP" };

            var statistics = new CritComboCalculator.CalculationVariables(this, enemy);

            for (int scenario = 0; scenario < SCENARIOS; scenario++)
            {
                for( int slots = MAXREVIVALSLOTS; slots >= 0; slots--)
                {
                    string statisticsText = new CritComboCalculator.SpecificCalculationVariables(statistics, scenario, slots).ToString();
                    Console.WriteLine(statisticsText);
                }
            }
        }

        public override string ToString()
        {
            Enemy gabriel = Enemy.Gabriel;
            string result = "";

            result += $"Level = {runLevel}\n";
            result += $"HP = {HP}\n";
            result += $"ATK = {ATK}\n";
            result += $"DEF = {DEF}\n";
            result += $"AGI = {AGI}\n";
            result += $"LUC = {LUC}\n\n";

            result += $"Statted HP = {statHp}\n";
            result += $"Statted ATK = {statAtk}\n";
            result += $"Statted DEF = {statDef}\n";
            result += $"Statted AGI = {statAgi}\n";
            result += $"Statted LUC = {statLuc}\n\n";

            result += $"Combo Rate (HMG) = {ComboRate(gabriel)}\n";
            result += $"Critical Rate (HMG) = {CriticalRate(gabriel)}";

            return result;
        }
    }
}
