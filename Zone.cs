using System;
using System.Collections.Generic;

namespace IRPG_Calculator
{
    internal class Zone
    {
        private static readonly List<Enemy> ZONE93333 = new List<Enemy>()
        {
            // 93333
            Enemy.CrystalWarrior,
        };

        private static readonly List<Enemy> ZONE100000 = new List<Enemy>()
        {
            // 100000
            /*
            Enemy.BlobFlat100000,
            Enemy.BlobTiny100000,
            Enemy.BlobCube100000,
            Enemy.BlobSphere100000,
            Enemy.AngelLittle100000,
            */
            Enemy.Pony100000,
            //Enemy.Serpent100000,
        };

        private static readonly List<Enemy> ZONE111111 = new List<Enemy>()
        {
            // 111111
            /*
            Enemy.BlobFlat111111,
            Enemy.BlobTiny111111,
            Enemy.BlobCube111111,
            Enemy.BlobSphere111111,
            Enemy.AngelLittle111111,
            */
            Enemy.Pony111111,
            //Enemy.Serpent111111,
        };

        private static readonly List<Enemy> ZONE125000 = new List<Enemy>()
        {
            // 125000
            Enemy.BlobFlat125000,
            Enemy.BlobTiny125000,
            Enemy.BlobCube125000,
            Enemy.BlobSphere125000,
            Enemy.AngelLittle125000,
            Enemy.Pony125000,
            Enemy.Serpent125000,
        };

        private static readonly List<Enemy> ZONE140000 = new List<Enemy>()
        {
            // 140000
            Enemy.BlobFlat140000,
            Enemy.BlobTiny140000,
            Enemy.BlobCube140000,
            Enemy.BlobSphere140000,
            Enemy.AngelLittle140000,
            Enemy.Pony140000,
            Enemy.Serpent140000,
        };

        private static readonly List<Enemy> ZONE158000 = new List<Enemy>()
        {
            // 158000
            Enemy.BlobFlat158000,
            Enemy.BlobTiny158000,
            Enemy.BlobCube158000,
            Enemy.BlobSphere158000,
            Enemy.AngelLittle158000,
            Enemy.Pony158000,
            Enemy.Serpent158000,
        };

        private static readonly List<Enemy> ZONE160000 = new List<Enemy>()
        {
            // 160000
            Enemy.BlobFlat160000,
            Enemy.BlobTiny160000,
            Enemy.BlobCube160000,
            Enemy.BlobSphere160000,
            Enemy.Pony160000,
            Enemy.Serpent160000,
            Enemy.AngelLittle160000,
            Enemy.AngelTeen160000,
            Enemy.AngelAdult160000,
            Enemy.AngelKid160000,
            Enemy.AngelWinged160000,
        };

        private static readonly List<Enemy> ZONE168000 = new List<Enemy>()
        {
            // 168000
            Enemy.BlobFlat168000,
            Enemy.BlobTiny168000,
            Enemy.BlobCube168000,
            Enemy.BlobSphere168000,
            Enemy.Pony168000,
            Enemy.Serpent168000,
            Enemy.AngelLittle168000,
            Enemy.AngelTeen168000,
            Enemy.AngelAdult168000,
            Enemy.AngelKid168000,
            Enemy.AngelWinged168000,
        };

        private static readonly List<Enemy> ZONE175000 = new List<Enemy>()
        {
            // 175000
            Enemy.BlobFlat175000,
            Enemy.BlobTiny175000,
            Enemy.BlobCube175000,
            Enemy.BlobSphere175000,
            Enemy.Pony175000,
            Enemy.Serpent175000,
            Enemy.AngelLittle175000,
            Enemy.AngelTeen175000,
            Enemy.AngelAdult175000,
            Enemy.AngelKid175000,
            Enemy.AngelWinged175000,
        };

        private static readonly List<Enemy> ZONE184000_1 = new List<Enemy>()
        {
            //184000
            /*
            Enemy.BlobFlat184000_1,
            Enemy.BlobTiny184000_1,
            Enemy.BlobCube184000_1,
            Enemy.BlobSphere184000_1,
            Enemy.Pony184000_1,
            Enemy.Serpent184000_1,
            Enemy.AngelLittle184000_1,
            Enemy.AngelTeen184000_1,
            Enemy.AngelAdult184000_1,
            Enemy.AngelKid184000_1,
            Enemy.AngelWinged184000_1,
            */
        };

        private static readonly List<Enemy> ZONE184000_2 = new List<Enemy>()
        {
            //184000
            Enemy.BlobFlat184000_2,
            Enemy.BlobTiny184000_2,
            Enemy.BlobCube184000_2,
            Enemy.BlobSphere184000_2,
            Enemy.Pony184000_2,
            Enemy.Serpent184000_2,
            Enemy.AngelLittle184000_2,
            Enemy.AngelTeen184000_2,
            Enemy.AngelAdult184000_2,
            Enemy.AngelKid184000_2,
            Enemy.AngelWinged184000_2,
        };

        private static readonly List<Enemy> ZONE190000 = new List<Enemy>()
        {
            // 190000
            Enemy.BlobFlat190000,
            Enemy.BlobTiny190000,
            Enemy.BlobCube190000,
            Enemy.BlobSphere190000,
            Enemy.Pony190000,
            Enemy.Serpent190000,
            Enemy.AngelLittle190000,
            Enemy.AngelTeen190000,
            Enemy.AngelAdult190000,
            Enemy.AngelKid190000,
            Enemy.AngelWinged190000,
        };

        private static readonly List<Enemy> ZONE198000 = new List<Enemy>()
        {
            // 198000
            Enemy.BlobFlat198000,
            Enemy.BlobTiny198000,
            Enemy.BlobCube198000,
            Enemy.BlobSphere198000,
            Enemy.Pony198000,
            Enemy.Serpent198000,
            Enemy.AngelLittle198000,
            Enemy.AngelTeen198000,
            Enemy.AngelAdult198000,
            Enemy.AngelKid198000,
            Enemy.AngelWinged198000,
        };

        private static readonly List<Enemy> ZONE200000 = new List<Enemy>()
        {
            // 200000
            Enemy.BlobFlat200000,
            Enemy.BlobTiny200000,
            Enemy.BlobCube200000,
            Enemy.BlobSphere200000,
            Enemy.Pony200000,
            Enemy.Serpent200000,
            Enemy.AngelLittle200000,
            Enemy.AngelTeen200000,
            Enemy.AngelAdult200000,
            Enemy.AngelKid200000,
            Enemy.AngelWinged200000,
        };

        private static readonly List<Enemy> ZONE210000 = new List<Enemy>()
        {
            // 210000
            /*
            Enemy.BlobFlat210000,
            Enemy.BlobTiny210000,
            Enemy.BlobCube210000,
            Enemy.BlobSphere210000,
            Enemy.Pony210000,
            Enemy.Serpent210000,
            Enemy.AngelLittle210000,
            Enemy.AngelTeen210000,
            Enemy.AngelAdult210000,
            Enemy.AngelKid210000,
            Enemy.AngelWinged210000,
            */
        };

        private static readonly List<Enemy> ZONE214000 = new List<Enemy>()
        {
            // 214000
            /*
            Enemy.BlobFlat214000,
            Enemy.BlobTiny214000,
            Enemy.BlobCube214000,
            Enemy.BlobSphere214000,
            Enemy.Pony214000,
            Enemy.Serpent214000,
            Enemy.AngelLittle214000,
            Enemy.AngelTeen214000,
            Enemy.AngelAdult214000,
            Enemy.AngelKid214000,
            Enemy.AngelWinged214000,
            */
        };

        private static readonly List<Enemy> ZONE222000_1 = new List<Enemy>()
        {
            //222000
            /*
            Enemy.BlobFlat222000_1,
            Enemy.BlobTiny222000_1,
            Enemy.BlobCube222000_1,
            Enemy.BlobSphere222000_1,
            Enemy.Pony222000_1,
            Enemy.Serpent222000_1,
            Enemy.AngelLittle222000_1,
            Enemy.AngelTeen222000_1,
            Enemy.AngelAdult222000_1,
            Enemy.AngelKid222000_1,
            Enemy.AngelWinged222000_1,
            */
        };

        private static readonly List<Enemy> ZONE222000_2 = new List<Enemy>()
        {
            //222000
            /*
            Enemy.BlobFlat222000_2,
            Enemy.BlobTiny222000_2,
            Enemy.BlobCube222000_2,
            Enemy.BlobSphere222000_2,
            Enemy.Pony222000_2,
            Enemy.Serpent222000_2,
            Enemy.AngelLittle222000_2,
            Enemy.AngelTeen222000_2,
            Enemy.AngelAdult222000_2,
            */
            Enemy.AngelKid222000_2,
            //Enemy.AngelWinged222000_2,
        };

        private static readonly List<Enemy> ZONE234000 = new List<Enemy>()
        {
            // 234000
            /*
            Enemy.BlobFlat234000,
            Enemy.BlobTiny234000,
            Enemy.BlobCube234000,
            Enemy.BlobSphere234000,
            Enemy.Pony234000,
            Enemy.Serpent234000,
            Enemy.AngelLittle234000,
            Enemy.AngelTeen234000,
            Enemy.AngelAdult234000,
            Enemy.AngelKid234000,
            Enemy.AngelWinged234000,
            */
        };

        private static readonly List<Enemy> ZONE237000 = new List<Enemy>()
        {
            // 237000
            /*
            Enemy.BlobFlat237000,
            Enemy.BlobTiny237000,
            Enemy.BlobCube237000,
            Enemy.BlobSphere237000,
            Enemy.Pony237000,
            Enemy.Serpent237000,
            Enemy.AngelLittle237000,
            Enemy.AngelTeen237000,
            */
            Enemy.AngelAdult237000,
            Enemy.AngelKid237000,
            //Enemy.AngelWinged237000,
        };

        private static readonly List<Enemy> ZONE245000 = new List<Enemy>()
        {
            // 245000
            /*
            Enemy.BlobFlat245000,
            Enemy.BlobTiny245000,
            Enemy.BlobCube245000,
            Enemy.BlobSphere245000,
            Enemy.Pony245000,
            Enemy.Serpent245000,
            Enemy.AngelLittle245000,
            Enemy.AngelTeen245000,
            Enemy.AngelAdult245000,
            Enemy.AngelKid245000,
            Enemy.AngelWinged245000,
            */
        };

        private static readonly List<Enemy> ZONE250000 = new List<Enemy>()
        {
            // 250000
            /*
            Enemy.BlobFlat250000,
            Enemy.BlobTiny250000,
            Enemy.BlobCube250000,
            Enemy.BlobSphere250000,
            Enemy.Pony250000,
            Enemy.Serpent250000,
            Enemy.AngelLittle250000,
            Enemy.AngelTeen250000,
            Enemy.AngelAdult250000,
            Enemy.AngelKid250000,
            Enemy.AngelWinged250000,
            */
        };

        private static readonly List<Enemy> ZONE256000 = new List<Enemy>()
        {
            // 256000
        };

        private static readonly Dictionary<int, List<Enemy>> ZONELIST1 = new Dictionary<int, List<Enemy>>
        {
            {93333, ZONE200000 },
            {100000, ZONE200000 },
            {111111, ZONE200000 },
            {125000, ZONE125000 },
            {140000, ZONE140000 },
            {158000, ZONE158000 },
            {160000, ZONE160000 },
            {168000, ZONE168000 },
            {175000, ZONE175000 },
            {184000, ZONE184000_1 },
            {190000, ZONE190000 },
            {198000, ZONE198000 },
            {200000, ZONE200000 },
            {214000, ZONE214000 },
            {222000, ZONE222000_1 },
            {234000, ZONE234000 },
            {237000, ZONE237000 },
            {245000, ZONE245000 },
            {250000, ZONE250000 },
            {256000, ZONE256000 },
        };

        private static readonly Dictionary<int, List<Enemy>> ZONELIST2 = new Dictionary<int, List<Enemy>>
        {
            {184000, ZONE184000_2 },
            {222000, ZONE222000_2 },
        };

        private static List<Enemy> ZONELIST(int zone, int zoneVersion = 1)
        {
            return (zoneVersion == 1) ? ZONELIST1[zone] : ZONELIST2[zone];
        }

        public List<Enemy> zoneMobs { get; private set; }
        public int zoneLevel { get; private set; }

        public Zone(int zone, int zoneVersion = 1)
        {
            zoneLevel = zone;
            zoneMobs = new List<Enemy>();
            foreach (Enemy enemy in ZONELIST(zone, zoneVersion))
            {
                zoneMobs.Add(enemy);
            }
        }

        public void ChangeZone(int zone, int zoneVersion = 1)
        {
            zoneLevel = zone;
            zoneMobs = new List<Enemy>();
            foreach (Enemy enemy in ZONELIST(zone, zoneVersion))
            {
                zoneMobs.Add(enemy);
            }
        }

        public double ZoneWinChance(Character character, bool critComboBonus = false, bool halfHpBonus = false, bool halfAtkBonus = false, int samples = 10000)
        {
            double winRate = 0.0;

            foreach (Enemy enemy in zoneMobs)
            {
                double mobWinRate = character.AverageBattleWinChance(enemy, critComboBonus, halfHpBonus, halfAtkBonus, simulate: true, useLowCombo:true, samples, display: false);
                winRate += mobWinRate * enemy.SPAWNCHANCE;
            }

            return winRate;
        }

        public void ZoneWinChanceDisplay(Character character, bool critComboBonus = false, bool halfHpBonus = false, bool halfAtkBonus = false, int samples = 10000)
        {
            foreach (Enemy enemy in zoneMobs)
            {
                double mobWinRate = character.AverageBattleWinChance(enemy, critComboBonus, halfHpBonus, halfAtkBonus, simulate: true, useLowCombo: true, samples, display: false);
                Console.WriteLine($"{100 * mobWinRate:0.###}%");
            }
        }
    }
}
