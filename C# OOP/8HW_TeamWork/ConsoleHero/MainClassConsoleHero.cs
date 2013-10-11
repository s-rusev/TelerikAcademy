using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleHero
{
    class MainClassConsoleHero
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        public static uint UserChoiceSong { get; set; }
        public static uint UserChoiceDifficulty { get; set; }
        public static int UserResult { get; set; }
        public static Song GameSong { get; set; }

        static void InitializeGame()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WindowHeight = 24;
            Console.WindowWidth = 41;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            UserInputProccesser.DrawTheRoadRunner();
            Console.ReadKey();
            UserInputProccesser.DrawWelcomeMenu();
            UserInputProccesser.GetUserChoiceDifficulty();
            UserInputProccesser.GetUserChoiceSong();
            UserInputProccesser.InitializeGamePoints();
        }

        static void InitializeEngine(Engine engine, Song gameSong)
        {
            int startRow = 3;
            int startCol = 2;

            int counter = startRow;
            foreach (Note noteInSong in gameSong.Notes)
            {
                char[,] noteSongRepresentation = { { '(', noteInSong.NoteTone.ToString()[0], ')' } };
                FallingNote fallingNoteSong;
                if (noteInSong.NoteTone == NoteFrequencyToneEnum.A ||
                    noteInSong.NoteTone == NoteFrequencyToneEnum.G)
                {
                    fallingNoteSong = new FallingNote(new MatrixCoords(counter = counter - 2, 4), noteSongRepresentation, noteInSong);
                    engine.AddObject(fallingNoteSong);
                }
                else if (noteInSong.NoteTone == NoteFrequencyToneEnum.C ||
                        noteInSong.NoteTone == NoteFrequencyToneEnum.F ||
                        noteInSong.NoteTone == NoteFrequencyToneEnum.E)
                {
                    fallingNoteSong = new FallingNote(new MatrixCoords(counter = counter - 2, 13), noteSongRepresentation, noteInSong);
                    engine.AddObject(fallingNoteSong);
                }
                else
                //if (noteInSong.NoteTone == NoteFrequencyToneEnum.D ||
                //    noteInSong.NoteTone == NoteFrequencyToneEnum.B ||
                //    noteInSong.NoteTone == NoteFrequencyToneEnum.A4)
                {
                    fallingNoteSong = new FallingNote(new MatrixCoords(counter = counter - 2, 22), noteSongRepresentation, noteInSong);
                    engine.AddObject(fallingNoteSong);
                }

            }
            for (int i = startRow; i < WorldRows - 1; i++)
            {
                GameObject leftLineElement = new FieldElement(new MatrixCoords(i, startCol + 1), new char[,] { { '|' } });
                engine.AddObject(leftLineElement);
                GameObject rightLineElement = new FieldElement(new MatrixCoords(i, startCol + 5), new char[,] { { '|' } });
                engine.AddObject(rightLineElement);
            }
            GameObject leftInput = new FieldElement(new MatrixCoords(WorldRows - 1, startCol + 1), new char[,] { { '<' } });
            engine.AddObject(leftInput);
            GameObject rightInput = new FieldElement(new MatrixCoords(WorldRows - 1, startCol + 5), new char[,] { { '>' } });
            engine.AddObject(rightInput);

            for (int i = startRow; i < WorldRows - 1; i++)
            {
                GameObject leftLineElement = new FieldElement(new MatrixCoords(i, startCol + 10), new char[,] { { '|' } });
                engine.AddObject(leftLineElement);
                GameObject rightLineElement = new FieldElement(new MatrixCoords(i, startCol + 14), new char[,] { { '|' } });
                engine.AddObject(rightLineElement);
            }

            leftInput = new FieldElement(new MatrixCoords(WorldRows - 1, startCol + 10), new char[,] { { '<' } });
            engine.AddObject(leftInput);
            rightInput = new FieldElement(new MatrixCoords(WorldRows - 1, startCol + 14), new char[,] { { '>' } });
            engine.AddObject(rightInput);
            for (int i = startRow; i < WorldRows - 1; i++)
            {
                GameObject leftLineElement = new FieldElement(new MatrixCoords(i, startCol + 19), new char[,] { { '|' } });
                engine.AddObject(leftLineElement);
                GameObject rightLineElement = new FieldElement(new MatrixCoords(i, startCol + 23), new char[,] { { '|' } });
                engine.AddObject(rightLineElement);
            }

            leftInput = new FieldElement(new MatrixCoords(WorldRows - 1, startCol + 19), new char[,] { { '<' } });
            engine.AddObject(leftInput);
            rightInput = new FieldElement(new MatrixCoords(WorldRows - 1, startCol + 23), new char[,] { { '>' } });
            engine.AddObject(rightInput);

            GameObject result = Result.Instance;//new Result(new MatrixCoords(2, 27), new char[,] { { } }, 0);
            engine.AddObject(result);
        }

        static void Main(string[] args)
        {

            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();
            while (true) //player wants to play 
            {
                InitializeGame();
                Engine gameEngine = new Engine(renderer, keyboard, UserChoiceDifficulty); //for increased speed decrease the last number

                Thread userInputThread = new Thread(delegate()
                {
                    keyboard.A_OnButtonPressed += (sender, eventInfo) =>
                    {
                        gameEngine.ProcessButtonA();
                    };

                    keyboard.S_OnButtonPressed += (sender, eventInfo) =>
                    {
                        gameEngine.ProcessButtonS();
                    };

                    keyboard.D_OnButtonPressed += (sender, eventInfo) =>
                    {
                        gameEngine.ProcessButtonD();
                    };

                    keyboard.Esc_OnButtonPressed += (sender, eventInfo) =>
                    {
                        gameEngine.QuitGame();
                    };
                });
                userInputThread.Start();
                InitializeEngine(gameEngine, GameSong);
                gameEngine.Run();
                UserInputProccesser.EndGame();
            }

        }

    }
}
