using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleSnake
{
    class ScoreKeeper
    {
        public int CurrentScore = 0;

        public static void GetAllTimeHighScore()
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader("c:\\test\\Highscore.txt");
            List<string> higscore = new List<string>();
            Console.SetCursorPosition(15, 13);
            Console.WriteLine("--HighScore--");
            while ((line = file.ReadLine()) != null)
            {
                Console.SetCursorPosition(15, 15+counter);
                Console.WriteLine(line);
                higscore.Add(line);
                counter++;
                
            }

            file.Close();
            
                    
            
        }

    
}
}
