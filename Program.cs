using System.ComponentModel.Design;

namespace IRPG_Calculator
{
    class Program
    {
        static void SeparateSection()
        {
            string separation = "\n====================================================\n";
            Console.WriteLine(separation);
        }

        static void Startup()
        {
            // Startup Message
            string msg = "Inflation RPG Calculator by KS-Zephur";
            msg = " " + msg + " ";

            string filler = "";
            for (int i = 0; i < msg.Length; i++)
            {
                filler += "=";
            }

            string border = "=======";
            string borderLine = border + filler + border;
            string msgLine = border + msg + border;

            Console.WriteLine(borderLine);
            Console.WriteLine(msgLine);
            Console.WriteLine(borderLine + "\n");
        }

        static void Main(string[] args)
        {
            int funcID;
            bool exitProgram = false;
            Character player = new Character();

            // Run startup sequence
            Startup();

            // Breaks when funcID = 0
            while (!exitProgram)
            {
                // Get selection
                funcID = MainMenu.Run();
                if (funcID > 0) SeparateSection();

                // Match selection to function/exit
                switch (funcID)
                {
                    case 0:
                        // Exit Program
                        exitProgram = true;
                        break;
                    case 1:
                        // Set stats
                        SetStatsMenu.Run(player);
                        break;
                    case 2:
                        // Set gear
                        Console.WriteLine("(Currently not implemented, swry uwu)");
                        break;
                    case 3:
                        // Set items
                        Console.WriteLine("(Currently not implemented, swry uwu)");
                        break;
                    case 4:
                        // Optimize AGI
                        Console.WriteLine("(Currently not implemented, swry uwu)");
                        break;
                    case 5:
                        // Simulate Boss Battles
                        Console.WriteLine("(Currently not implemented, swry uwu)");
                        break;
                    case 6:
                        // Estimate Revival
                        Console.WriteLine("(Currently not implemented, swry uwu)");
                        break;
                    case 7:
                        // More Info about Calculator
                        Console.WriteLine("(Currently not implemented, swry uwu)");
                        break;
                    default:
                        Console.WriteLine("\nInvalid option!");
                        break;
                }
                SeparateSection();
            }

        }
    }
}