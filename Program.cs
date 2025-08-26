using System.Reflection;

namespace IRPG_Calculator
{
    internal class Program
    {
        internal static string DIRECTORY_PATH = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static void SeparateSection()
        {
            string separation = "\n====================================================\n";
            Console.WriteLine(separation);
        }

        public static void NotImplementedMessage()
        {
            Console.WriteLine("(Currently not implemented, swry uwu)");
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
            Program.Startup();

            // Breaks when funcID = 0
            while (!exitProgram)
            {
                // Get selection
                funcID = MainMenu.Run();

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
                        Program.NotImplementedMessage();
                        break;
                    case 3:
                        // Set items
                        Program.NotImplementedMessage();
                        break;
                    case 4:
                        // Optimize AGI
                        Program.NotImplementedMessage();
                        break;
                    case 5:
                        // Simulate Boss Battles
                        Program.NotImplementedMessage();
                        break;
                    case 6:
                        // Estimate Revival
                        Program.NotImplementedMessage();
                        break;
                    case 7:
                        // More Info about Calculator
                        Program.NotImplementedMessage();
                        break;
                    default:
                        Console.WriteLine("\nInvalid option!");
                        break;
                }
                Program.SeparateSection();
            }

        }
    }
}