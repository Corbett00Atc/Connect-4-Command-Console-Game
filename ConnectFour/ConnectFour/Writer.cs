using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConnectFour
{
    static class Writer
    {
        private static StreamReader reader;
        static string path = "C:\\Users\\Andrew\\Documents\\_Coding\\Connect 4 Revise\\ConnectFour\\ConnectFour\\Text";
        static string instructions = "\\instructions.txt";
        static string welcome = "\\Welcome.txt";
        static string log = "C:\\Users\\Andrew\\Documents\\_Coding\\Connect 4 Revise\\ConnectFour\\ConnectFour\\Text\\Log.txt";

        // read file to output instructions
        public static void WriteInstructions()
        {
            // clear user view
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine();
            }

            try
            {
                using (reader = new StreamReader(path + instructions))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

                // pause for user input
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        // read file for welcome message
        public static void WriteWelcome()
        {
            using (reader = new StreamReader(path + welcome))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            
        }

        public static void LogToFile(Player winner, Player loser)
        {
            try
            {
                StreamWriter write = new StreamWriter(log, true);

                write.WriteLine("Winnter: " + winner.GetPlayerNum());
                write.WriteLine("Loser: " + loser.GetPlayerNum());
                write.WriteLine("-----------");
                write.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: \n" + e);
            }
        }
    }
}
