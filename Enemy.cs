using System;
using System.Collections.Generic;

namespace IRPG_Calculator
{
    internal class Enemy
    {
        //WBA
        public static Enemy Awwas { get { return new Enemy(300000000, 2550000, 10572135, -5, 1.0/3.0); } }
        //Heaven
        public static Enemy Suzaku { get { return new Enemy(114540000, 2402100, 4393618, 50000, 0.0); } }
        public static Enemy Byakko { get { return new Enemy(165360000, 2748900, 6135584, 58000, 0.0); } }
        public static Enemy Seiryuu { get { return new Enemy(209250000, 3907110, 7851573, 67000, 0.0); } }
        public static Enemy Genbu { get { return new Enemy(300120000, 3988200, 10820289, 75000, 0.0); } }
        public static Enemy CloudQueen { get { return new Enemy(214200000, 3592525, 7194122, 86000, 0.1); } }
        public static Enemy CrystalWarrior { get { return new Enemy(225000000, 5105100, 8519557, 93333, 0.1); } }
        public static Enemy Kouryuu { get { return new Enemy(400000000, 8772000, 17677814, 93333, 0.0); } }
        //100000
        public static Enemy Pony100000 { get { return new Enemy(303600000, 5508000, 10776787, 100000, 0.029); } }
        //111111
        public static Enemy Pony111111 { get { return new Enemy(356500000, 6540750, 12725535, 111111, 0.029); } }
        //125000
        public static Enemy BlobTiny125000 { get { return new Enemy(380000000, 5329500, 13541795, 125000, 0.2174); } }
        public static Enemy BlobFlat125000 { get { return new Enemy(399000000, 5329500, 14073795, 125000, 0.2174); } }
        public static Enemy BlobCube125000 { get { return new Enemy(399000000, 5049000, 14014890, 125000, 0.2174); } }
        public static Enemy BlobSphere125000 { get { return new Enemy(399000000, 5049000, 14014890, 125000, 0.2174); } }
        public static Enemy AngelLittle125000 { get { return new Enemy(433200000, 6058800, 15952741, 125000, 0.0725); } }
        public static Enemy Serpent125000 { get { return new Enemy(551000000, 6283200, 19231465, 125000, 0.029); } }
        public static Enemy Pony125000 { get { return new Enemy(437000000, 7573500, 16310428, 125000, 0.029); } }
        //140000
        public static Enemy BlobTiny140000 { get { return new Enemy(470000000, 6379250, 16913739, 140000, 0.2174); } }
        public static Enemy BlobFlat140000 { get { return new Enemy(493500000, 6379250, 17571739, 140000, 0.2174); } }
        public static Enemy BlobCube140000 { get { return new Enemy(493500000, 6043500, 17501232, 140000, 0.2174); } }
        public static Enemy BlobSphere140000 { get { return new Enemy(493500000, 6043500, 17501232, 140000, 0.2174); } }
        public static Enemy AngelLittle140000 { get { return new Enemy(535800000, 7252200, 19988182, 140000, 0.0725); } }
        public static Enemy Serpent140000 { get { return new Enemy(681500000, 7520800, 24032995, 140000, 0.029); } }
        public static Enemy Pony140000 { get { return new Enemy(540500000, 9065250, 20409329, 140000, 0.029); } }
        //158000
        public static Enemy BlobTiny158000 { get { return new Enemy(586000000, 7671250, 20520018, 158000, 0.2174); } }
        public static Enemy BlobFlat158000 { get { return new Enemy(615300000, 7671250, 21340418, 158000, 0.2174); } }
        public static Enemy BlobCube158000 { get { return new Enemy(615300000, 7267500, 21255631, 158000, 0.2174); } }
        public static Enemy BlobSphere158000 { get { return new Enemy(615300000, 7267500, 21255631, 158000, 0.2174); } }
        public static Enemy AngelLittle158000 { get { return new Enemy(668040000, 8721000, 24120412, 158000, 0.0725); } }
        public static Enemy Serpent158000 { get { return new Enemy(849700000, 9044000, 29180563, 158000, 0.029); } }
        public static Enemy Pony158000 { get { return new Enemy(673900000, 10901250, 24648186, 158000, 0.029); } }
        //160000
        public static Enemy BlobTiny160000 { get { return new Enemy(595000000, 7832750, 20678461, 160000, 0.05); } }
        public static Enemy BlobFlat160000 { get { return new Enemy(624750000, 7832750, 21511461, 160000, 0.05); } }
        public static Enemy BlobCube160000 { get { return new Enemy(624750000, 7420500, 21424889, 160000, 0.05); } }
        public static Enemy BlobSphere160000 { get { return new Enemy(624750000, 7420500, 21424889, 160000, 0.05); } }
        public static Enemy Serpent160000 { get { return new Enemy(862750000, 9234400, 29405468, 160000, 0.0875); } }
        public static Enemy Pony160000 { get { return new Enemy(684250000, 11130750, 24805701, 160000, 0.0875); } }
        public static Enemy AngelLittle160000 { get { return new Enemy(678300000, 8904600, 24260720, 160000, 0.1875); } }
        public static Enemy AngelTeen160000 { get { return new Enemy(702100000, 9069500, 25229081, 160000, 0.125); } }
        public static Enemy AngelWinged160000 { get { return new Enemy(803250000, 10718500, 28585792, 160000, 0.125); } }
        public static Enemy AngelKid160000 { get { return new Enemy(714000000, 11130750, 26084254, 160000, 0.125); } }
        public static Enemy AngelAdult160000 { get { return new Enemy(773500000, 11955250, 29506706, 160000, 0.0625); } }
        //168000
        public static Enemy BlobTiny168000 { get { return new Enemy(650000000, 8317250, 22417017, 168000, 0.05); } }
        public static Enemy BlobFlat168000 { get { return new Enemy(682500000, 8317250, 23327017, 168000, 0.05); } }
        public static Enemy BlobCube168000 { get { return new Enemy(682500000, 7879500, 23235089, 168000, 0.05); } }
        public static Enemy BlobSphere168000 { get { return new Enemy(682500000, 7879500, 23235089, 168000, 0.05); } }
        public static Enemy Serpent168000 { get { return new Enemy(942500000, 9805600, 31893018, 168000, 0.0875); } }
        public static Enemy Pony168000 { get { return new Enemy(747500000, 11819250, 26855885, 168000, 0.0875); } }
        public static Enemy AngelLittle168000 { get { return new Enemy(741000000, 9455400, 26270185, 168000, 0.1875); } }
        public static Enemy AngelTeen168000 { get { return new Enemy(767000000, 9630500, 27313084, 168000, 0.125); } }
        public static Enemy AngelWinged168000 { get { return new Enemy(877500000, 11381500, 30960213, 168000, 0.125); } }
        public static Enemy AngelKid168000 { get { return new Enemy(780000000, 11819250, 28229431, 168000, 0.125); } }
        public static Enemy AngelAdult168000 { get { return new Enemy(845000000, 12694750, 31939645, 168000, 0.0625); } }
        //175000
        public static Enemy BlobTiny175000 { get { return new Enemy(699000000, 8882500, 24639315, 175000, 0.05); } }
        public static Enemy BlobFlat175000 { get { return new Enemy(733950000, 8882500, 25617915, 175000, 0.05); } }
        public static Enemy BlobCube175000 { get { return new Enemy(733950000, 8415000, 25519740, 175000, 0.05); } }
        public static Enemy BlobSphere175000 { get { return new Enemy(733950000, 8415000, 25519740, 175000, 0.05); } }
        public static Enemy Serpent175000 { get { return new Enemy(1013550000, 10472000, 35053388, 175000, 0.0875); } }
        public static Enemy Pony175000 { get { return new Enemy(803850000, 12622500, 29633393, 175000, 0.0875); } }
        public static Enemy AngelLittle175000 { get { return new Enemy(796860000, 10098000, 29028755, 175000, 0.1875); } }
        public static Enemy AngelTeen175000 { get { return new Enemy(824820000, 10285000, 30214584, 175000, 0.125); } }
        public static Enemy AngelWinged175000 { get { return new Enemy(943650000, 12155000, 34176977, 175000, 0.125); } }
        public static Enemy AngelKid175000 { get { return new Enemy(838800000, 12622500, 31218125, 175000, 0.125); } }
        public static Enemy AngelAdult175000 { get { return new Enemy(908700000, 13557500, 35294840, 175000, 0.0625); } }
        //184000
        public static Enemy BlobTiny184000_2 { get { return new Enemy(774000000, 9609250, 26804640, 184000, 0.05); } }
        public static Enemy BlobFlat184000_2 { get { return new Enemy(812700000, 9609250, 27888240, 184000, 0.05); } }
        public static Enemy BlobCube184000_2 { get { return new Enemy(812700000, 9103500, 27782033, 184000, 0.05); } }
        public static Enemy BlobSphere184000_2 { get { return new Enemy(812700000, 9103500, 27782033, 184000, 0.05); } }
        public static Enemy Serpent184000_2 { get { return new Enemy(1122300000, 11328800, 38152745, 184000, 0.0875); } }
        public static Enemy Pony184000_2 { get { return new Enemy(890100000, 13655250, 32139699, 184000, 0.0875); } }
        public static Enemy AngelLittle184000_2 { get { return new Enemy(882360000, 10924200, 31467039, 184000, 0.1875); } }
        public static Enemy AngelTeen184000_2 { get { return new Enemy(913320000, 11126500, 32729145, 184000, 0.125); } }
        public static Enemy AngelWinged184000_2 { get { return new Enemy(1044900000, 13149500, 37073377, 184000, 0.125); } }
        public static Enemy AngelKid184000_2 { get { return new Enemy(928800000, 13655250, 33811203, 184000, 0.125); } }
        public static Enemy AngelAdult184000_2 { get { return new Enemy(1006200000, 14666750, 38247284, 184000, 0.0625); } }
        //190000
        public static Enemy BlobTiny190000 { get { return new Enemy(822000000, 10174500, 28912141, 190000, 0.0392); } }
        public static Enemy BlobFlat190000 { get { return new Enemy(863100000, 10174500, 30062941, 190000, 0.0392); } }
        public static Enemy BlobCube190000 { get { return new Enemy(863100000, 9639000, 29950486, 190000, 0.0392); } }
        public static Enemy BlobSphere190000 { get { return new Enemy(863100000, 9639000, 29950486, 190000, 0.0392); } }
        public static Enemy Serpent190000 { get { return new Enemy(1191900000, 11995200, 41150235, 190000, 0.0784); } }
        public static Enemy Pony190000 { get { return new Enemy(945300000, 14458500, 34762728, 190000, 0.0784); } }
        public static Enemy AngelLittle190000 { get { return new Enemy(937080000, 11566800, 34068030, 190000, 0.1961); } }
        public static Enemy AngelTeen190000 { get { return new Enemy(969960000, 11781000, 35461809, 190000, 0.1471); } }
        public static Enemy AngelWinged190000 { get { return new Enemy(1109700000, 13923000, 40109786, 190000, 0.1471); } }
        public static Enemy AngelKid190000 { get { return new Enemy(986400000, 14458500, 36627122, 190000, 0.1471); } }
        public static Enemy AngelAdult190000 { get { return new Enemy(1068600000, 15529500, 41411029, 190000, 0.049); } }
        //198000
        public static Enemy BlobTiny198000 { get { return new Enemy(887000000, 10820500, 31183414, 198000, 0.0392); } }
        public static Enemy BlobFlat198000 { get { return new Enemy(931350000, 10820500, 32425214, 198000, 0.0392); } }
        public static Enemy BlobCube198000 { get { return new Enemy(931350000, 10251000, 32305619, 198000, 0.0392); } }
        public static Enemy BlobSphere198000 { get { return new Enemy(931350000, 10251000, 32305619, 198000, 0.0392); } }
        public static Enemy Serpent198000 { get { return new Enemy(1286150000, 12756800, 44392667, 198000, 0.0784); } }
        public static Enemy Pony198000 { get { return new Enemy(1020050000, 15376500, 37492004, 198000, 0.0784); } }
        public static Enemy AngelLittle198000 { get { return new Enemy(1011180000, 12301200, 36752729, 198000, 0.1961); } }
        public static Enemy AngelTeen198000 { get { return new Enemy(1046660000, 12529000, 38258702, 198000, 0.1471); } }
        public static Enemy AngelWinged198000 { get { return new Enemy(1197450000, 14807000, 43268998, 198000, 0.1471); } }
        public static Enemy AngelKid198000 { get { return new Enemy(1064400000, 15376500, 39508295, 198000, 0.1471); } }
        public static Enemy AngelAdult198000 { get { return new Enemy(1153100000, 16515500, 44667930, 198000, 0.049); } }
        //200000
        public static Enemy BlobTiny200000 { get { return new Enemy(903000000, 10982000, 33023875, 200000, 0.0392); } }
        public static Enemy BlobFlat200000 { get { return new Enemy(948150000, 10982000, 34288075, 200000, 0.0392); } }
        public static Enemy BlobCube200000 { get { return new Enemy(948150000, 10404000, 34166695, 200000, 0.0392); } }
        public static Enemy BlobSphere200000 { get { return new Enemy(948150000, 10404000, 34166695, 200000, 0.0392); } }
        public static Enemy Serpent200000 { get { return new Enemy(1309350000, 12947200, 46999680, 200000, 0.0784); } }
        public static Enemy Pony200000 { get { return new Enemy(1038450000, 15606000, 39972828, 200000, 0.0784); } }
        public static Enemy AngelLittle200000 { get { return new Enemy(1029420000, 12484800, 39272661, 200000, 0.1961); } }
        public static Enemy AngelTeen200000 { get { return new Enemy(1065540000, 12716000, 40956948, 200000, 0.1471); } }
        public static Enemy AngelWinged200000 { get { return new Enemy(1219050000, 15028000, 46156998, 200000, 0.1471); } }
        public static Enemy AngelKid200000 { get { return new Enemy(1083600000, 15606000, 42277653, 200000, 0.1471); } }
        public static Enemy AngelAdult200000 { get { return new Enemy(1173900000, 16762000, 47738322, 200000, 0.049); } }
        //222000
        public static Enemy AngelKid222000_2 { get { return new Enemy(1315200000, 18360000, 50542910, 222000, 0.1894); } }
        //237000
        public static Enemy AngelKid237000 { get { return new Enemy(1473600000, 20081250, 57141082, 237000, 0.1894); } }
        public static Enemy AngelAdult237000 { get { return new Enemy(1596400000, 21568750, 64526168, 237000, 0.0379); } }
        //Wiki wrong Point value: public static Enemy Gabriel { get { return new Enemy(2052000000, 46410000, 101012702); } }
        public static Enemy Gabriel { get { return new Enemy(2052000000, 46410000, 102257576, 250000, 0); } }
        public static Enemy Michael { get { return new Enemy(3267500000, 29720250, 133068311, 245000, 0); } }
        public static Enemy TwilightPortal { get { return new Enemy(5875000000, 46835000, 368222204, 450000, 0); } }

        public static readonly double[] DROPMULTIPLIER = new double[10] { 1.0, 0.55, 0.55, 0.60, 0.65, 0.75, 0.75, 0.375, 0.75, 0.75 };

        public long HP;
        public int ATK;
        public int POINT;
        public int SPAWNZONE;
        public double SPAWNCHANCE;

        public double BEIT
        {
            get
            {
                double result;

                if (POINT <= 500) { result = (POINT * 4 + 1000) / 6.0; }
                else if (POINT <= 1000) { result = (POINT * 4 + 2000) / 6.0; }
                else if (POINT <= 2000) { result = (POINT * 4 + 4000) / 6.0; }
                else { result = (POINT * 3 + 4000) / 5.0; }

                return result;
            }
        }

        public Enemy(long hP, int aTK, int pOINT, int sPAWNZONE, double sPAWNCHANCE)
        {
            HP = hP;
            ATK = aTK;
            POINT = pOINT;
            SPAWNZONE = sPAWNZONE;
            SPAWNCHANCE = sPAWNCHANCE;
        }

        public void Init(long hp, int atk, int point, int sPAWNZONE, double sPAWNCHANCE)
        {
            HP = hp;
            ATK = atk;
            POINT = point;
            SPAWNZONE = sPAWNZONE;
            SPAWNCHANCE = sPAWNCHANCE;
        }

        public long AverageDamage(Character character, bool halfAtkBonus = false)
        {
            return DamageCalculation(character, 0.5, 0.5, 0.5, halfAtkBonus);
        }

        public long DamageCalculation(Character character, double odds5, double odds6, double odds7, bool halfAtkBonus = false)
        {
            double attack = (halfAtkBonus) ? ATK / 2 : ATK;
            double damage = (attack * 2 + (attack - character.DEF * 0.5) * 12) / 14;
            if (damage < attack * 0.5)
            {
                damage = (attack * 0.5 + damage) / 2;
            }
            if (damage < attack * 0.3)
            {
                damage = (attack * 0.9 + damage) / 4;
            }
            if (damage < attack * 0.2)
            {
                damage = (attack * 1.0 + damage) / 6;
            }
            if (damage < attack * 0.1)
            {
                damage = (attack * 0.7 + damage) / 8;
            }
            damage += odds5 * damage * 0.2 - damage * 0.1 + odds6 * 4 - 2;
            damage += odds7 * attack * 0.0225 + attack * 0.0025;
            return (long) damage;
        }

        public static double ApproxDropChance(int luck, int[] milestones, Dictionary<int, double> milestoneChances, bool isAccessory, int amountOwned = 0)
        {
            if (amountOwned >= 10) { return 0; }
            if (isAccessory && amountOwned >= 3) { return 0; }
            if (amountOwned < 0) { amountOwned = 0; }

            double rate = 0;

            // Get approximate Base Drop Rate up to 10m LUC
            if (luck >= 10000000) { return milestoneChances[10000000]; }
            else
            {
                for (int i = milestones.Length - 2; i >= 0; i--)
                {
                    int currentMile = milestones[i];
                    if (luck >= currentMile)
                    {
                        int nextMile = milestones[i + 1];
                        double currentMileChance = milestoneChances[currentMile];
                        double nextMileChance = milestoneChances[nextMile];

                        rate = currentMileChance + (nextMileChance - currentMileChance) / (nextMile - currentMile) * (luck - currentMile);
                        break;
                    }
                }
            }

            // Apply drop reduction for non-accessory drops (based on amount owned)
            if (!isAccessory)
            {
                for (int i = 1; i <= amountOwned; i++)
                {
                    rate *= DROPMULTIPLIER[i];
                }
                if ((amountOwned > 0) && (rate > 0.15)) { rate = 0.15; }
            }

            return rate;
        }

        public static double Longinus1DropChance(Character player, int amountOwned)
        {
            bool isAccessory = false;
            int[] milestones = new int[22] { 1, 1000, 1600, 2500, 4000, 6300, 10000, 16000, 25000, 40000, 63000, 100000, 160000, 250000, 400000, 630000, 1000000, 1600000, 2500000, 4000000, 6300000, 10000000 };
            double[] chances = new double[22] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.00008, 0.00069, 0.00094, 0.00138, 0.00205, 0.00331, 0.00457, 0.00541, 0.00603, 0.00654, 0.00680, 0.00732, 0.00799, 0.00921, 0.01119 };
            Dictionary<int, double> milestoneChances = new Dictionary<int, double>();
            for (int i = 0; i < milestones.Length; i++)
            {
                milestoneChances.Add(milestones[i], chances[i]);
            }

            double rate = ApproxDropChance(player.LUC, milestones, milestoneChances, isAccessory, amountOwned);

            return rate;
        }

        public static double WingSword1DropChance(Character player, int amountOwned)
        {
            bool isAccessory = false;
            int[] milestones = new int[22] { 1, 1000, 1600, 2500, 4000, 6300, 10000, 16000, 25000, 40000, 63000, 100000, 160000, 250000, 400000, 630000, 1000000, 1600000, 2500000, 4000000, 6300000, 10000000 };
            double[] chances = new double[22] { 0.00600, 0.00760, 0.00860, 0.00940, 0.00980, 0.01000, 0.01060, 0.01160, 0.01320, 0.01380, 0.01460, 0.01600, 0.01820, 0.02060, 0.02200, 0.02280, 0.02340, 0.02340, 0.02340, 0.02360, 0.02380, 0.02420 };
            Dictionary<int, double> milestoneChances = new Dictionary<int, double>();
            for (int i = 0; i < milestones.Length; i++)
            {
                milestoneChances.Add(milestones[i], chances[i]);
            }

            double rate = ApproxDropChance(player.LUC, milestones, milestoneChances, isAccessory, amountOwned);

            return rate;
        }
    }
}
