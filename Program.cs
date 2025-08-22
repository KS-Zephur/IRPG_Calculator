namespace IRPG_Calculator
{
    class Program
    {
        static void SeparateSection()
        {
            string separation = "====================================================";
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
            Console.WriteLine(borderLine);
        }

        static int MainMenu()
        {
            string response;
            int choice;

            int[] validChoices = { 0, 1, 2, 3, 4, 5, 6, 7 };

            while (true)
            {
                // Display Options
                Console.WriteLine("\n[Main Menu]\n");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("  (1) Set Stats");
                Console.WriteLine("  (2) Set Gear");
                Console.WriteLine("  (3) Set Items");
                Console.WriteLine("  (4) Optimize AGI to Boss");
                Console.WriteLine("  (5) Simulate Boss Battle");
                Console.WriteLine("  (6) Estimate Boss Revival Battle Win Rate");
                Console.WriteLine("  (7) More Info about Calculator");
                Console.WriteLine("  (0) Exit");

                Console.WriteLine($"\nSelect your option (0-{validChoices.Length - 1}):");
                Console.Write("> ");

                // Get response
                response = Console.ReadLine();

                try
                {
                    // Validate Input
                    choice = Convert.ToInt32(response);

                    // Break once option is selected
                    if (validChoices.Contains(choice))
                    {
                        break;
                    }
                }
                catch { }

                // Will run if invalid input is given
                Console.WriteLine("\nInvalid option!");
                SeparateSection();
            }

            return choice;
        }

        static void Main(string[] args)
        {
            int funcID;
            bool exitProgram = false;

            // Run startup sequence
            Startup();

            // Breaks when funcID = 0
            while (!exitProgram)
            {
                // Get selection
                funcID = MainMenu();

                // Match selection to function/exit
                switch (funcID)
                {
                    case 0:
                        // Exit Program
                        exitProgram = true;
                        break;
                    case 1:
                        // Set stats
                        Console.WriteLine("(Currently not implemented, swry uwu)");
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
                        break;
                }
                SeparateSection();
            }

        }
    }
}