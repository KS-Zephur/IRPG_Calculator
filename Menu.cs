namespace IRPG_Calculator
{
    internal static class MainMenu
    {
        public static int Run()
        {
            string response;
            int choice;

            int[] validChoices = { 0, 1, 2, 3, 4, 5, 6, 7 };

            // Display Options
            Console.WriteLine("[Main Menu]\n");
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
                if (!validChoices.Contains(choice))
                {
                    choice = -1;
                }
                else if (choice != 0)
                {
                    Program.SeparateSection();
                }
            }
            catch { choice = -1; }

            return choice;
        }
    }

    internal static class SetStatsMenu
    {
        public static void Run(Character player)
        {
            string response;
            int choice;
            bool exitSetStatsMenu = false;

            int[] validChoices = { 0, 1, 2, 3 };

            while (!exitSetStatsMenu)
            {
                // Display Options
                Console.WriteLine("[Set Stats Menu]\n");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("  (1) New Stats");
                Console.WriteLine("  (2) Save Stats");
                Console.WriteLine("  (3) Load Stats");
                Console.WriteLine("  (0) Main Menu");

                Console.WriteLine($"\nSelect your option (0-{validChoices.Length - 1}):");
                Console.Write("> ");

                // Get response
                response = Console.ReadLine();

                try
                {
                    // Validate Input
                    choice = Convert.ToInt32(response);

                    // Break once option is selected
                    if (!validChoices.Contains(choice))
                    {
                        choice = -1;
                    }
                    else if (choice != 0)
                    {
                        Program.SeparateSection();
                    }
                }
                catch { choice = -1; }

                switch (choice)
                {
                    case 0:
                        exitSetStatsMenu = true;
                        return;
                    case 1:
                        NewPlayerStats(player);
                        break;
                    case 2:
                        SavePlayerStats(player);
                        break;
                    case 3:
                        LoadPlayerStats(player);
                        break;
                    default:
                        Console.WriteLine("\nInvalid option!");
                        break;
                }
                Program.SeparateSection();
            }
        }

        private static void NewPlayerStats(Character player)
        {
            Program.NotImplementedMessage();
        }

        private static void SavePlayerStats(Character player)
        {
            Program.NotImplementedMessage();
        }

        private static void LoadPlayerStats(Character player)
        {
            Program.NotImplementedMessage();
        }
    }
}