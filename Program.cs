namespace IRPG_Calculator
{
    class Program
    {
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

            int[] validChoices = { 0, 1, 2, 3, 4 };

            while (true)
            {
                // Display Options
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("  (1) Set Stats");
                Console.WriteLine("  (2) Optimize AGI");
                Console.WriteLine("  (3) Simulate Battle");
                Console.WriteLine("  (4) Estimate Revival Win Rate");
                Console.WriteLine("  (0) Exit");

                Console.WriteLine("\nSelect your option (0-4):");
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
                Console.WriteLine("===============================");
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
                        exitProgram = true;
                        break;
                    default:
                        break;
                }
            }

        }
    }
}