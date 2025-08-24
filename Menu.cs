namespace IRPG_Calculator
{
    internal static class MainMenu
    {
        public static int Run()
        {
            string response;
            int choice;

            int[] validChoices = { 0, 1, 2, 3, 4, 5, 6, 7 };

            while (true)
            {
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
                    if (validChoices.Contains(choice))
                    {
                        break;
                    }
                }
                catch { }

                // Will run if invalid input is given
                Console.WriteLine("\nInvalid option!");
            }

            return choice;
        }
    }

    internal static class SetStatsMenu
    {
        public static void Run(Character player)
        {
            player.statAtk = 328764720;
        }
    }
}