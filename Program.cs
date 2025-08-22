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

        static void Main(string[] args)
        {
            Startup();
            
        }
    }
}