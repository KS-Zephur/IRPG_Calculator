using CsvHelper;
using System;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;

namespace IRPG_Calculator
{
    class Test
    {
        static void MainScript(string[] args)
        {
            Enemy gabriel = Enemy.Gabriel;
            Enemy TP = Enemy.TwilightPortal;

            double atkBonus;
            int HP, ATK, DEF, AGI, LUC, statPoints, BP, slots, charLevel, weaponCopies;
            string response, temp;
            bool confirm, fightTP;

            Character build = new Character();

            while (true)
            {
                Console.Write("Character Level (Ability) = ");
                charLevel = Convert.ToInt32(Console.ReadLine());
                Console.Write("Remaining Starless Slots = ");
                slots = Convert.ToInt32(Console.ReadLine());
                Console.Write("Remaining BP = ");
                BP = Convert.ToInt32(Console.ReadLine());
                Console.Write("Remaining Stat Points = ");
                statPoints = Convert.ToInt32(Console.ReadLine());
                Console.Write("Statted HP = ");
                HP = Convert.ToInt32(Console.ReadLine());
                Console.Write("Statted ATK = ");
                ATK = Convert.ToInt32(Console.ReadLine());
                Console.Write("Statted DEF = ");
                DEF = Convert.ToInt32(Console.ReadLine());
                Console.Write("Statted AGI = ");
                AGI = Convert.ToInt32(Console.ReadLine());
                Console.Write("Statted LUC = ");
                LUC = Convert.ToInt32(Console.ReadLine());
                Console.Write("ATK% Rank Bonus = ");
                atkBonus = Convert.ToDouble(Console.ReadLine()) / 100;

                while (true)
                {
                    Console.Write("\nConfirm? (Y/N) : ");
                    temp = Console.ReadLine().ToLower();
                    if ((temp == "y") || (temp == "n"))
                    {
                        break;
                    }
                }
                confirm = ("y" == temp);
                if (confirm)
                {
                    break;
                }
                Console.WriteLine("========================");
            }
            /*
            Console.Write("# Weapon Copies = ");
            weaponCopies = Convert.ToInt32(Console.ReadLine());
            Console.Write("Weapon is Wing Sword+1? (Y/N) : ");
            response = Console.ReadLine().ToLower();
            if (response == "y")
            {

            }
            */

            Console.WriteLine("========================");

            build.characterLevel = charLevel;
            build.statHp = HP;
            build.statAtk = ATK;
            build.statDef = DEF;
            build.statAgi = AGI;
            build.statLuc = LUC;
            build.bonusAtkPercent = atkBonus;
            build.SetCustomGabrielBuild(statPoints, restrictStatChanges: true);

            Console.WriteLine("At Gabriel...");
            Console.WriteLine(build);
            Console.WriteLine($"{100 * build.BossWinRate(gabriel, BP, slots):0.###}%"); // Go at 14 BP

            Console.WriteLine("========================");

            while (true)
            {
                Console.Write("Fighting Twilight Portal? (Y/N) = ");
                temp = Console.ReadLine().ToLower();
                fightTP = ("y" == temp);

                while (true)
                {
                    Console.Write("\nConfirm? (Y/N) : ");
                    temp = Console.ReadLine().ToLower();
                    if ((temp == "y") || (temp == "n"))
                    {
                        break;
                    }
                }
                confirm = ("y" == temp);
                if (confirm)
                {
                    break;
                }
                Console.WriteLine("========================");
            }

            if (fightTP)
            {
                while (true)
                {
                    Console.Write("Remaining Starless Slots = ");
                    slots = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Remaining BP = ");
                    BP = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Remaining Stat Points = ");
                    statPoints = Convert.ToInt32(Console.ReadLine());
                    Console.Write("ATK% Rank Bonus = ");
                    atkBonus = Convert.ToDouble(Console.ReadLine()) / 100;

                    while (true)
                    {
                        Console.Write("\nConfirm? (Y/N) : ");
                        temp = Console.ReadLine().ToLower();
                        if ((temp == "y") || (temp == "n"))
                        {
                            break;
                        }
                    }
                    confirm = ("y" == temp);
                    if (confirm)
                    {
                        break;
                    }
                }

                Console.WriteLine("========================");

                build.bonusAtkPercent = atkBonus;
                build.SetCustomTwilightBuild(statPoints, restrictStatChanges: true);

                Console.WriteLine("At Twilight Portal...");
                Console.WriteLine(build);
                Console.WriteLine($"{100 * build.BossWinRate(TP, BP, slots):0.###}%"); // RUN!!! Will get there at 12 BP (no encounter), or 16 BP (no encounter) if you won stairway mob fight
            }
        }

        // Drop Optimization for Longinus+1
        static void Longinus1DropScript(string[] args)
        {
            Enemy awwas = Enemy.Awwas;
            Enemy cloudQueen = Enemy.CloudQueen;

            int level = 200000;
            Character player = new Character(level);
            //player.EstimateBonusPercent();
            player.characterLevel = 14;
            player.bonusAtkPercent = 0.0;
            player.bonusLucPercent = 0.12;
            player.kHp = 1;
            player.kAtk = 1;
            player.kDef = 0;
            player.kAgi = 0;
            player.kLuc = 2;
            
            int hg2 = 0;
            int poth = 0;
            int fgg1 = 3;
            player.ChangeToLuckSet(hg2, poth, fgg1);

            player.statHp = 1000000;
            player.statDef = 900000;
            player.statAgi = 5;
            player.statLuc = 1;
            player.SetAtkToLevel(level);
            int wantedAtk = 1600000 + 99999 * 0;
            player.statLuc += (player.statAtk - wantedAtk) / 3;
            player.statAtk = wantedAtk;

            //player.OptimizeAtkDef(awwas, 0, restrictStatChanges: false, startingDef: 850000);

            player.AverageBattleWinChance(cloudQueen, samples: 100000, display: true);
        }

        // Writes the stats to a CSV file, along with the chance of winning the run
        static void GraphScript1(string[] args)
        {
            Enemy gabriel = Enemy.Gabriel;

            Character CB = new Character(level: 700000, build: "custom", characterAbilityLevel: 18);
            CB.ChangeCC();

            double chance;
            int startingBP = 9;
            bool breakNext = false;
            int jump = 10000;

            string stats = $"Lv{CB.characterLevel}Hp{CB.kHp}Atk{CB.kAtk}Def{CB.kDef}Agi{CB.kAgi}Luc{CB.kLuc}";
            string docPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/For Fun/IRPG Stuff/Gabriel Build/{stats}";

            if (!Directory.Exists(docPath))
            {
                Directory.CreateDirectory(docPath);
            }

            //for (CB.statDef = 1600000; CB.statDef < 1810000;  CB.statDef += 30000)
            //{
            using (StreamWriter file = new StreamWriter(Path.Combine(docPath, $"IRPG_C&Cbuild_Gabriel_{CB.statDef}DEF.csv")))
            {
                using (CsvWriter csv = new CsvWriter(file, CultureInfo.InvariantCulture))
                {
                    csv.WriteField("Level");
                    csv.WriteField("ATK");
                    csv.WriteField("AGI");
                    csv.WriteField("LUC");
                    csv.WriteField($"Gabriel Chance ({startingBP} BP)");
                    csv.NextRecord();

                    CB.runLevel = 700000;
                    CB.SetAtkToLevel(0);
                    CB.SetCustomGabrielBuild(0, restrictStatChanges: false);
                    CB.bonusAtkPercent = 0.15;
                    while (true)
                    {
                        //CB.UpdateCC(gabriel);
                        if (CB.runLevel >= 1000000) { breakNext = true; }

                        Console.WriteLine($"At Level {CB.runLevel} with {CB.statDef} DEF");
                        Console.WriteLine(CB);
                        Console.WriteLine("================");
                        chance = 100 * CB.BossWinRate(gabriel, startingBP: startingBP);

                        csv.WriteField(CB.runLevel);
                        csv.WriteField(CB.statAtk);
                        csv.WriteField(CB.statAgi);
                        csv.WriteField(CB.statLuc);
                        csv.WriteField($"{chance:0.###}%");
                        csv.NextRecord();

                        if (breakNext) { break; }

                        CB.runLevel += jump;
                        CB.SetCustomGabrielBuild(6 * jump, restrictStatChanges: false);
                    }
                }
            }
            Console.WriteLine("======================");
            //}

            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey(true);
        }

        // Writes the stats to a CSV file, along with the chance of winning the run
        static void GraphScript2(string[] args)
        {
            Enemy enemy = Enemy.TwilightPortal;

            Character CB = new Character(level: 800000, build: "custom2");
            CB.ChangeCC2();

            double chance;
            int startingBP = 7;
            bool breakNext = false;
            int jump = 10000;

            string stats = $"Lv{CB.characterLevel}Hp{CB.kHp}Atk{CB.kAtk}Def{CB.kDef}Agi{CB.kAgi}Luc{CB.kLuc}";
            string docPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/For Fun/IRPG Stuff/Twilight Build/{stats}";

            if (!Directory.Exists(docPath))
            {
                Directory.CreateDirectory(docPath);
            }

            //for (CB.statDef = 1600000; CB.statDef < 1810000;  CB.statDef += 30000)
            //{
            using (StreamWriter file = new StreamWriter(Path.Combine(docPath, $"IRPG_C&Cbuild_Twilight3_{CB.statDef}DEF.csv")))
            {
                using (CsvWriter csv = new CsvWriter(file, CultureInfo.InvariantCulture))
                {
                    csv.WriteField("Level");
                    csv.WriteField("HP");
                    csv.WriteField("AGI");
                    csv.WriteField("ATK");
                    csv.WriteField($"Twilight Chance ({startingBP} BP)");
                    csv.NextRecord();

                    CB.runLevel = 700000;
                    CB.SetAtkToLevel(20000);
                    CB.SetCustomTwilightBuild(0, restrictStatChanges: false);
                    while (true)
                    {
                        //CB.UpdateCC(gabriel);
                        if (CB.runLevel >= 1000000) { breakNext = true; }

                        Console.WriteLine($"At Level {CB.runLevel} with {CB.statDef} DEF");
                        chance = 100 * CB.BossWinRate(enemy, startingBP: startingBP);

                        csv.WriteField(CB.runLevel);
                        csv.WriteField(CB.statHp);
                        csv.WriteField(CB.statAgi);
                        csv.WriteField(CB.statAtk);
                        csv.WriteField($"{chance:0.###}%");
                        csv.NextRecord();

                        if (breakNext) { break; }

                        CB.runLevel += jump;
                        CB.SetCustomTwilightBuild(6 * jump, restrictStatChanges: false);
                    }
                }
            }
            Console.WriteLine("======================");
            //}

            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey(true);
        }

        // Bonus Rates
        static void TestScript1(string[] args)
        {
            Character character = new Character();
            Enemy gabriel = Enemy.Gabriel;
            Enemy TP = Enemy.TwilightPortal;

            Enemy enemy;
            // 0 =  Gabriel; 1 = TP
            int bossNum = 0;
            int BP = 9;

            double chance;
            int jump = 10000;

            character.runLevel = 750000;
            character.SetAtkToLevel(12500);

            if (bossNum == 0)
            {
                enemy = gabriel;
                character.SetCustomGabrielBuild(statPoints: 0, restrictStatChanges: false);
            }
            else
            {
                enemy = TP;
                character.SetCustomTwilightBuild(statPoints: 0, restrictStatChanges: false);
            }
            for (character.runLevel = character.runLevel; character.runLevel <= 900000; character.runLevel += jump)
            {
                Console.WriteLine("======================================================");
                Console.WriteLine($"Level {character.runLevel} = {character.statAtk} ATK & {character.statAgi} AGI\n");

                var winRate = Character.BossWinRate(character.RevivalWinRates(enemy), BP);

                chance = 100 * winRate;
                Console.WriteLine($"Win Rate = {chance:0.####}%");

                character.ChangeBuild(enemy: enemy, statPoints: jump * 6, restrictStatChanges: true);
            }
            Console.WriteLine("======================================================");
        }

        // Build Comparison
        static void TestScript2(string[] args)
        {
            Enemy gabriel = Enemy.Gabriel;
            Enemy twilight = Enemy.TwilightPortal;

            Enemy enemy = Enemy.AngelAdult237000;

            int BP = 7;
            int remainingSlots = 1;
            int level = 800000;

            Character current = new Character(level: level, "custom");
            current.characterLevel = 18;
            current.kHp = 1;
            current.kAtk = 2;
            current.statHp = 2000000;
            current.statAtk = 9312415;
            current.statDef = 1999999;
            current.statAgi = 5;
            current.statLuc = 1;
            current.bonusAtkPercent = 0.15;
            current.SetAtkToLevel(000);
            current.SetCustomGabrielBuild(statPoints: 0, restrictStatChanges: false);
            //current.SetCustomTwilightBuild(0, restrictStatChanges: false);
            //current.SetCustomTwilightBuild(statPoints: 80000, restrictStatChanges: true);

            if (false)
            {
                Console.WriteLine($"{current.firstCriticals}");
                Console.WriteLine($"HP = {current.statHp} => {current.HP}");
                Console.WriteLine($"ATK = {current.statAtk} => {current.ATK}");
                Console.WriteLine($"DEF = {current.statDef} => {current.DEF}");
                Console.WriteLine($"AGI = {current.statAgi} => {current.AGI}");
                return;
            }

            //Character potential = new Character(current);
            //potential.ChangeCC();
            //potential.ChangeTest();
            //potential.SetCriticalComboRates(enemy, 0, 0.16, 0.21, false, false);

            Console.WriteLine("Starting...");
            var currentRates = current.RevivalWinRates(enemy);
            Console.WriteLine("Current Done.");
            //var potentialRates = potential.RevivalWinRates(enemy);
            //Console.WriteLine("Potential Done.");

            double chance1, chance2;

            Character tester = new Character(current);

            Console.WriteLine("==============================");
            string[] bonuses = new string[4] { "No Bonus", "Crit & Combo", "Half HP", "Half ATK" };
            for (int i = 0; i < bonuses.Length-1; i += 1)
            {
                Console.WriteLine(bonuses[i]);

                for (int j = 2; j >= 0; j--)
                {
                    chance1 = 100 * currentRates[i][j];
                    //chance2 = 100 * potentialRates[i][j];

                    tester.ChangeBuild(j, i==1, i==2);
                    //potential.ChangeCC(j, i==1, i==2);
                    chance2 = 100 * tester.AverageBattleWinChance(enemy, i==1, i==2, i==3, true, true, 400000, false);
                    //chance2 = 100 * potential.AverageBattleWinChance(enemy, i==1, i==2, false, true, true, 100000, false);
                    //currentRates[i][j] = chance1 / 100;
                    //potentialRates[i][j] = chance2 / 100;

                    /*
                    int runs = 1000000;
                    int total = 0;
                    current.ChangeCC(j, i == 1, i == 2);
                    for (int k = 0; k < runs; k++)
                    {
                        if (current.SimulateBattle(enemy, i==1, i==2, false, false).Item1)
                        {
                            total++;
                        }
                    }
                    chance1 = 100.0 * total / runs;
                    */
                    Console.WriteLine();
                    Console.WriteLine($"  Current {j} Slot = {chance1:0.##########}% Win Rate");
                    Console.WriteLine($"Potential {j} Slot = {chance2:0.##########}% Win Rate");
                    Console.WriteLine($" Increase {j} Slot = {chance2 - chance1:0.##########}% Better");
                }
                Console.WriteLine("==============================");
            }
            //return;
            Console.WriteLine($"Avg. Boss Win Rate starting at {BP} BP (Level {level})");
            chance1 = 100 * Character.BossWinRate(currentRates, startingBP: BP, startingSlots: remainingSlots);
            //chance2 = 100 * Character.BossWinRate(potentialRates, startingBP: BP);
            Console.WriteLine($"  Custom = {chance1:0.##########}%");
            //Console.WriteLine($"New Build = {chance2:0.##########}%");
            //Console.WriteLine($"Increase = {chance2 - chance1:0.##########}%");
            Console.WriteLine("==============================");
        }

        //DPS Comparison
        public static void TestScript3(string[] args)
        {

            long pureAverageDamage, agiAverageDamage;
            double pureMult, agiMult;
            double pureDPS, agiDPS;


            Enemy gabriel = Enemy.Gabriel;
            Enemy twilight = Enemy.TwilightPortal;

            Enemy enemy = gabriel;

            int level = 800000;
            int slots = 2;
            bool critComboBonus = true;
            bool halfHpBonus = false;

            Character pureDmg = new Character(level: level, build: "regular2");
            pureDmg.ChangeBuild(slots, critComboBonus, halfHpBonus, enemy);

            Character agiDmg = new Character(level: level, build: "custom2");
            agiDmg.ChangeBuild(slots, critComboBonus, halfHpBonus, enemy, restrictStatChanges: false);

            int agiGoal = agiDmg.statAgi;

            pureDmg.statAtk = agiDmg.statAtk;
            agiDmg.statAgi = 5;

            agiAverageDamage = agiDmg.AverageDamage(enemy);

            Console.WriteLine($"Base ATK = {agiDmg.statAtk}");
            Console.WriteLine("============================");
            for (agiDmg.statAgi = 5; agiDmg.statAgi <= agiGoal; agiDmg.statAgi += 2)
            {
                if ((agiDmg.statAgi-5)%25000 == 0)
                {
                    pureDmg.ChangeBuild(slots, critComboBonus, halfHpBonus, enemy);
                    agiDmg.ChangeBuild(slots, critComboBonus, halfHpBonus, enemy);

                    pureAverageDamage = pureDmg.AverageDamage(enemy);
                    pureMult = pureDmg.EstimatedMultiplierPerTurnLimit(enemy, critComboBonus, halfHpBonus);
                    agiMult = agiDmg.EstimatedMultiplierPerTurnLimit(enemy, critComboBonus, halfHpBonus);

                    Console.WriteLine($"Regular Limit Multiplier = x{pureMult:0.####}; ATK = {pureDmg.ATK} & AGI = {pureDmg.AGI}");
                    Console.WriteLine($"Agility Limit Multiplier = x{agiMult:0.####}; ATK = {agiDmg.ATK} AGI = {agiDmg.AGI}");
                    Console.WriteLine($"Agility/Regular Multiplier = x{agiMult / pureMult:0.####}\n");

                    pureDPS = pureAverageDamage * pureMult;
                    agiDPS = agiAverageDamage * agiMult;

                    Console.WriteLine($"Regular DPS = {pureDPS:0.##}");
                    Console.WriteLine($"Agility DPS = {agiDPS:0.##}");
                    Console.WriteLine($"Agility/Regular DPS = x{agiDPS / pureDPS:0.####}");
                    Console.WriteLine("============================");
                }

                pureDmg.statAtk += 3;
            }
        }

        static void TestScript4(string[] args)
        {
            Enemy suzaku = Enemy.Suzaku;
            Enemy byakko = Enemy.Byakko;
            Enemy seiryuu = Enemy.Seiryuu;
            Enemy genbu = Enemy.Genbu;
            Enemy cloudQueen = Enemy.CloudQueen;
            Enemy crystalWarrior = Enemy.CrystalWarrior;
            Enemy kouryuu = Enemy.Kouryuu;
            Enemy pony100000 = Enemy.Pony100000;
            Enemy pony111111 = Enemy.Pony111111;
            Enemy angelLittle125000 = Enemy.AngelLittle125000;
            Enemy serpent125000 = Enemy.Serpent125000;
            Enemy pony125000 = Enemy.Pony125000;
            Enemy angelLittle140000 = Enemy.AngelLittle140000;
            Enemy serpent140000 = Enemy.Serpent140000;
            Enemy pony140000 = Enemy.Pony140000;
            Enemy angelLittle158000 = Enemy.AngelLittle158000;
            Enemy serpent158000 = Enemy.Serpent158000;
            Enemy pony158000 = Enemy.Pony158000;
            Enemy angelKid160000 = Enemy.AngelKid160000;
            Enemy angelWinged160000 = Enemy.AngelWinged160000;
            Enemy angelAdult160000 = Enemy.AngelAdult160000;
            Enemy angelKid168000 = Enemy.AngelKid168000;
            Enemy angelAdult168000 = Enemy.AngelAdult168000;
            Enemy pony175000 = Enemy.Pony175000;
            Enemy angelWinged175000 = Enemy.AngelWinged175000;
            Enemy angelKid175000 = Enemy.AngelKid175000;
            Enemy angelAdult175000 = Enemy.AngelAdult175000;
            Enemy angelAdult184000_2 = Enemy.AngelAdult184000_2;
            Enemy angelKid190000 = Enemy.AngelKid190000;
            Enemy angelAdult190000 = Enemy.AngelAdult190000;
            Enemy angelKid200000 = Enemy.AngelKid200000;
            Enemy angelAdult200000 = Enemy.AngelAdult200000;
            Enemy angelKid222000_2 = Enemy.AngelKid222000_2;
            Enemy angelKid237000 = Enemy.AngelKid237000;
            Enemy angelAdult237000 = Enemy.AngelAdult237000;
            //Enemy angelAdult237000 = Enemy.AngelAdult237000;
            Enemy michael = Enemy.Michael;
            Enemy gabriel = Enemy.Gabriel;
            Enemy twilight = Enemy.TwilightPortal;

            int zoneLevel = 200000;
            Enemy enemy = angelAdult200000;
            Enemy statHpDefLimiter = enemy;
            int simulations = 10000;

            // Crystal Warrior (heaven end) = 0.8
            // Pony (1st map) = 0.45
            // Adult Angel (2nd+ map) = 0.8
            double statHpMaxLimiterWinRate = 0.8;

            bool critComboBonus = false;
            bool halfHpBonus = false;
            bool halfAtkBonus = false;

            int level = 523164;
            Character current = new Character(level: level, build: "");
            current.characterLevel = 20;
            current.kHp = 2;
            current.kAtk = 1;
            current.kDef = 0;

            current.statHp = 1630000;
            current.statAtk = 4100000;
            current.statDef = 570000;
            current.statAgi = 40001;
            current.statLuc = 1;
            current.EstimateBonusPercent();
            //current.bonusAtkPercent = 0;
            //current.bonusDefPercent = 0.15;

            int nonStatGemLevels = 20000;
            bool alterHP = true;
            bool alterATK = true;
            bool alterDEF = true;
            
            //current.ChangeToStatSet(useComboRing: true, useHeroGem: false);
            current.ChangeToExpSet(fgg1: 3, poth: 1, useHeroGem: false);
            current.Longinus1(10);
            current.Aegis1(10);
            //current.GOWG = 2;
            //current.SetCustomGabrielBuild(0, false);
            //current.SetCustomTwilightBuild(0, false);
            //current.ChangeCC2(2, critComboBonus, halfHpBonus);

            //current.comboRing = true;
            //current.critRateRings = 1;
            //current.critDmgRings = 2;
            //current.firstCriticals = 3;
            //current.ChangeBuild(slots: 0, enemy: enemy, restrictStatChanges: false);

            //current.recoveryNecklace = 0;
            //current.reviveNecklaces = 1;
            //current.HG = 0;
            //current.GOWG = 2;

            //current.PotH = 2;
            //current.FGG1 = 1;
            //current.critRateRings = 1;
            //current.comboRing = false;
            //current.critDmgRings = 1;
            //current.firstCriticals = 3;

            current.OptimizeHpAtkDef(enemy, statHpMaxLimiterWinRate, critComboBonus, halfHpBonus, halfAtkBonus, alterHP, alterATK, alterDEF, nonStatGemLevels, simulations);
            Console.WriteLine();
            current.runLevel = current.ExtractLevel(nonStatGemLevels: nonStatGemLevels);

            /*
            current.SetAtkToLevel(nonStatGemLevels);
            if (level > current.runLevel)
            {
                int statPoints = 6 * (level - current.runLevel);
                current.statDef += 3 * statPoints;
                current.runLevel = level;
            }
            */
            current.EstimateBonusPercent();

            /*
            Character temp = new Character(current);

            temp.statHp = 1947440;
            temp.statAtk = 2639431;
            temp.statDef = 1931290;
            temp.statAgi = current.statAgi;
            temp.statLuc = current.statLuc;

            temp.SetAtkToLevel(nonStatGemLevels, current.runLevel);

            
            if (current.statDef > temp.statDef)
            {
                current.statHp += 5 * (current.statDef - temp.statDef) / 3;
                current.statDef = temp.statDef;
            }
            
            if (current.statHp > temp.statHp)
            {
                current.statAtk += 3 * (current.statHp - temp.statHp) / 5;
                current.statHp = temp.statHp;
            }
            */

            int wantedATK = 10999999;
            //current.statHp += (current.statAtk - wantedATK) / 3 * 5;
            //current.statDef += (current.statAtk - wantedATK);
            //current.statAgi += (current.statAtk - wantedATK) / 3 * 2;
            //current.statAtk = wantedATK;
            //Console.WriteLine(current.bonusAtkPercent);
            current.AverageBattleWinChance(statHpDefLimiter, critComboBonus, halfHpBonus, halfAtkBonus, simulate: true, samples: simulations, display: true);
            /*Console.WriteLine("===================================================");
            Console.WriteLine("ADULT ANGEL DATA\n");
            current.AverageBattleWinChance(angelAdult175000, critComboBonus, halfHpBonus, halfAtkBonus, simulate: true, samples: 100000, display: true);
            Console.WriteLine("===================================================");*/
            return;

            Console.WriteLine($"HP = {current.statHp} => {current.HP}");
            Console.WriteLine($"ATK = {current.statAtk} => {current.ATK}");
            Console.WriteLine($"DEF = {current.statDef} => {current.DEF}");
            Console.WriteLine($"AGI = {current.statAgi} => {current.AGI}");
            Console.WriteLine("===================================================");

            Zone zone = new Zone(zoneLevel);
            double winrate = zone.ZoneWinChance(current, critComboBonus, halfHpBonus, halfAtkBonus, samples: 40000);
            Console.WriteLine($"Lv{zone.zoneLevel} Zone Win Rate @ {current.runLevel} Levels = ~{100 * winrate:0.###}%");
            Console.WriteLine("====================");
            zone.ZoneWinChanceDisplay(current, critComboBonus, halfHpBonus, halfAtkBonus, samples: 40000);
        }

        static void TestScript5(string[] args)
        {
            Enemy gabriel = Enemy.Gabriel;
            Enemy twilight = Enemy.TwilightPortal;

            Enemy enemy = gabriel;

            int startLevel = 750000;
            int endLevel = 900000;
            int jump = 10000;

            string buildname_gabriel = "custom";
            string buildname_twilight = "custom2";
            int startingBP = 9;
            int startingSlots = 2;

            Character character = new Character(startLevel, buildname_gabriel);
            //character.statHp = 1455000;
            //character.kHp = 2;
            //character.kAtk = 1;
            character.SetAtkToLevel(12500);

            string[] bonuses = new string[4] { "No Bonus ", "C&C Bonus", "Half HP  ", "Average  " };

            Console.WriteLine("KILL DA TOILET PAPER!!!");
            for (character.runLevel = character.runLevel; character.runLevel <= endLevel; character.runLevel += jump)
            {
                character.EstimateBonusPercent();
                if (character.runLevel != startLevel)
                {
                    character.ChangeBuild(enemy: enemy, statPoints: 6 * jump, restrictStatChanges: false, crit: 0.17, combo: 0.22);
                }
                else
                {
                    character.ChangeBuild(enemy: enemy, statPoints: 0, restrictStatChanges: false, crit: 0.17, combo: 0.22);
                }

                Console.WriteLine("======================================================");
                //double winRate = character.BossWinRate(gabriel, startingBP, startingSlots);
                double winRate = character.RunWinRate(twilight_buildName: buildname_twilight, startingBP: startingBP, startingSlots: startingSlots, restrictStatChanges: false);

                Console.WriteLine($"Level {character.runLevel} (ATK: {character.statAtk}) (AGI: {character.statAgi})");
                Console.WriteLine($"Win Rate = ~{100 * winRate:0.######}%");
                Console.WriteLine($"Estimated Runs = ~{1 / winRate:0}");
            }
        }

        static void TestScript6(string[] args)
        {
            Enemy kouryuu = Enemy.Kouryuu;

            Enemy enemy = kouryuu;

            bool critComboBonus = false;
            bool halfHpBonus = false;
            bool halfAtkBonus = false;

            int level = 30 * 1000;
            Character current = new Character(level: level, build: "");
            current.characterLevel = 20;
            current.kHp = 1;
            current.kAtk = 2;

            current.statHp = 2100000;
            current.statAtk = 4900000;
            current.statDef = 755000;
            current.statAgi = 5;// 37143;
            current.statLuc = 1;
            current.EstimateBonusPercent();

            int noStatGemLevels = 10000;

            //current.SetAtkToLevel(noStatGemLevels);
            //current.statAtk -= 3 * 2 * (10000 + 12500 * 1); // 2ATK = 11160; 2hp = 12110
            int wantedATK = 1000000;
            //current.statHp += (current.statAtk - wantedATK) / 3 * 5;
            //current.statDef += (current.statAtk - wantedATK);
            //current.statAgi += (current.statAtk - wantedATK) / 3 * 2;
            //current.statAtk = wantedATK;

            //current.ChangeToStatSet(useComboRing: true, useHeroGem: false);
            //current.ChangeToExpSet(fgg1: 2, poth: 0, useHeroGem: false);
            current.RemoveSlots();
            current.Longinus1(10);
            current.Aegis1(10);
            current.recoveryNecklace = 2;
            current.GOWG = 2;

            current.firstCriticals = 3;
            current.critDmgRings = 2;
            current.FGG1 = 3;
            current.PotH = 1;


            long bestDEF = 10;
            long bestHP = 100;
            long bestSP = 0;
            for (current.statDef = 499999; current.statDef < 2500000;  current.statDef += 9999)
            {
                long maxDmg = enemy.DamageCalculation(current, 1, 1, 1, false);
                long neededHP = 5 + ((long)(maxDmg / current.HPBONUS - 360000 * 3) / 5) * 5;
                long statPoints = (neededHP - 100) / 5 + (current.statDef - 10) / 3;

                if (bestDEF == 10)
                {
                    bestDEF = current.statDef;
                    bestHP = neededHP;
                    bestSP = statPoints;
                }
                else if (statPoints <= bestSP)
                {
                    bestDEF = current.statDef;
                    bestHP = neededHP;
                    bestSP = statPoints;
                }
            }

            Console.WriteLine($"Statted HP = {bestHP}");
            Console.WriteLine($"Statted DEF = {bestDEF}");
            Console.WriteLine($"Used Stat Points = {bestSP}");
        }

        static void TestScript7(string[] args)
        {
            Enemy gabriel = Enemy.Gabriel;
            Enemy twilight = Enemy.TwilightPortal;
            Enemy serpent140000 = Enemy.Serpent140000;

            Enemy enemy = gabriel;

            int level = 700000;
            Character player = new Character(level: level, build: "custom");

            player.characterLevel = 18;
            player.kHp = 1;
            player.kAtk = 2;

            player.statHp = 2000000;
            player.statAtk = 10;
            player.statDef = 1999999;
            player.statAgi = 5;
            player.statLuc = 1;
            player.EstimateBonusPercent();

            //player.ChangeToExpSet();
            //player.OptimizeDef(serpent140000);
            player.SetAtkToLevel(12500);
            player.SetCustomGabrielBuild(0, false);

            int jump = 10000;
            for (player.runLevel = player.runLevel; player.runLevel <= 900000;  player.runLevel += jump)
            {
                player.EstimateBonusPercent();
                if (player.runLevel != 700000)
                {
                    player.SetCustomGabrielBuild(6 * jump, false);
                }
                Console.WriteLine($"Level {player.runLevel}; ATK = {player.statAtk}; AGI = {player.statAgi} ({player.AGI}); LUC = {player.statLuc} ({player.LUC})");
                if (player.runLevel == 800000)
                {
                    Console.WriteLine(100 * Enemy.WingSword1DropChance(player, 0));
                    Console.WriteLine(100 * player.BossWinRate(enemy, 9, 2));
                }
            }
        }
    }
}
