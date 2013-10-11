using System;

namespace ConsoleHero
{
    public static class UserInputProccesser
    {
        public static void InitializeGamePoints() 
        {
            Result.Instance.Points = 0;
        }

        public static void EndGame()
        {
            Console.WriteLine("Press a key to continue or Esc to exit!");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine(
"*****************************\n" +
"***─▄█▀▀ ║▄█▀▄║▄█▀▄║██▀▄║─***\n" +
"***─██ ▀█║██ █║██ █║██ █║─***\n" +
"***─▀███▀║▀██▀║▀██▀║███▀║─***\n" +
"***───────────────────────***\n" +
"***───▐█▀▄─ ▀▄─▄▀ █▀▀──█──***\n" +
"***───▐█▀▀▄ ──█── █▀▀──▀──***\n" +
"***───▐█▄▄▀ ──▀── ▀▀▀──▄──***\n" +
"*****************************\n");
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
            }
        }

        public static void DrawTheRoadRunner()
        {
            Console.WriteLine(@" 
      .==,_
        .===,_`\
      .====,_ ` \      .====,__  
---     .==-,`~. \           `:`.__,
 ---      `~~=-.  \           /^^^   
   ---       `~~=. \         /
                `~. \       /     
                  ~. \____./         
                   `.=====)
                ___.--~~~--.__
     ___\.--~~~              ~~~---.._|/_ 
    ~~~""                             

               *****************
               *THE ROAD RUNNER*  
               *   PRESENTS:   *
               ***************** ");
        }
        public static void DrawWelcomeMenu()
        {
            Console.WriteLine(@"
      .'''.
     o|   |o
     o|   |o
      ',_,'
       | |
       |_|   *************************
       | |   ***   CONSOLE HERO    ***
       |_|   *************************
       | |
       |-|   (Use 'A', 'S', 'D' to hit
       |_|    the notes on the bottom
       |,|    line and Esc to quit! )
   .'  |_|   '.        
  ' '  |_|   ' '       *******
 '  '.'|_|'.' '        *ENJOY*
  .    8888  .         *******
   '        '
   :   8888  :    (Press any key to
  '    ____   '      continue...)
 '    (____)   '
 :          o o :
 '.        o o .' 
   '-,_____,.-'  ");
            Console.ReadKey();
        }


        private static void DrawStarLine()
        {
            Console.WriteLine(new string('*', 40));
        }
        private static void DrawSongMenu()
        {
            DrawStarLine();
            Console.WriteLine(new string(' ', 8) + "+++ CHOOSE SONG HERE +++");
            DrawStarLine();
            DrawStarLine();
            Console.WriteLine(" 1. Mila Moq Mamo");
            Console.WriteLine(" 2. Nazad Nazad Mome Kalino");
            Console.WriteLine(" 3. Tragnal Kos");
            DrawStarLine();
            Console.WriteLine("Make your choice: type 1, 2,...");
            DrawStarLine();
        }
        private static void DrawDifficultyMenu()
        {
            DrawStarLine();
            Console.WriteLine(new string(' ', 8) + "+++ CHOOSE DIFFICULTY +++");
            DrawStarLine();
            Console.WriteLine(" 1. Easy");
            Console.WriteLine(" 2. Normal");
            Console.WriteLine(" 3. Hard");
            DrawStarLine();
            Console.WriteLine("Make your choice: type 1, 2,...");
            DrawStarLine();
        }
        private static void ErrorMessage()
        {
            Console.WriteLine("Typing error, press key to continue.");
        }

        public static void GetUserChoiceDifficulty()
        {
            while (true)
            {
                Console.Clear();
                int diffSelector = 0;
                DrawDifficultyMenu();
                bool diffGood = int.TryParse(Console.ReadLine(), out diffSelector);
                if (diffGood)
                {
                    switch (diffSelector)
                    {
                        case 1:
                            {
                                MainClassConsoleHero.UserChoiceDifficulty = 400;
                                break;
                            }
                        case 2:
                            {
                                MainClassConsoleHero.UserChoiceDifficulty = 300;
                                break;
                            }
                        case 3:
                            {
                                MainClassConsoleHero.UserChoiceDifficulty = 200;
                                break;
                            }
                        default:
                            {
                                ErrorMessage();
                                Console.ReadKey();
                                break;
                            }
                    }
                    if (diffSelector == 1 || diffSelector == 2 || diffSelector == 3)
                    {
                        break;
                    }
                }
                else
                {
                    ErrorMessage();
                    Console.ReadKey();
                }
            }
        }

        public static void GetUserChoiceSong()
        {
            bool validSelector = false;
            uint songSelector = 0;
            while (true)
            {
                Console.Clear();
                DrawSongMenu();
                validSelector = uint.TryParse(Console.ReadLine(), out songSelector);
                if (validSelector)
                {
                    switch (songSelector)
                    {
                        case 1:
                            {
                                MainClassConsoleHero.GameSong = new SampleSong(@"..\..\SongTextMilaMoqMamo.txt");
                                break;
                            }
                        case 2:
                            {
                                MainClassConsoleHero.GameSong = new SampleSong(@"..\..\SongTextNazadNazadMomeKalino.txt");
                                break;
                            }
                        case 3:
                            {
                                MainClassConsoleHero.GameSong = new SampleSong(@"..\..\SongTextTragnalKos.txt");
                                break;
                            }
                        default:
                            {
                                ErrorMessage();
                                Console.ReadKey();
                                break;
                            }

                    }
                    if (songSelector == 1 || songSelector == 2 || songSelector == 3)
                    {
                        break;
                    }
                }
                else
                {
                    ErrorMessage();
                    Console.ReadKey();
                }
            }
        }

    }
}
