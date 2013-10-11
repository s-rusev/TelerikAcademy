using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Minesweeper
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] gameField = CreateGameField();
            char[,] minesForGameField = SetMines();
            int playerScore = 0;
            int row = 0;
            int column = 0;
            bool mineIsHit = false;
            bool isNewGame = true;
            bool isGameWon = false;
            List<Score> topScorers = new List<Score>(6);
            const int MaxScore = 35;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Welcome to Minesweeper! Test your luck and try to find all fields without mines.\n" +
                        "Commands:\n" +
                        "top -> shows the highscores\n" +
                        "restart -> starts new game\n" +
                        "exit -> exits the current game\n");
                    DrawGameField(gameField);
                    isNewGame = false;
                }
                Console.Write("Enter row and column: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= gameField.GetLength(0) && column <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                switch (command)
                {
                    case "top":
                        Highscore(topScorers);
                        break;
                    case "restart":
                        gameField = CreateGameField();
                        minesForGameField = SetMines();
                        DrawGameField(gameField);
                        mineIsHit = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye!");
                        break;
                    case "turn":
                        if (minesForGameField[row, column] != '*')
                        {
                            if (minesForGameField[row, column] == '-')
                            {
                                RevealEmptyBlock(gameField, minesForGameField, row, column);
                                playerScore++;
                            }
                            if (MaxScore == playerScore)
                            {
                                isGameWon = true;
                            }
                            else
                            {
                                DrawGameField(gameField);
                            }
                        }
                        else
                        {
                            mineIsHit = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command!\n");
                        break;
                }
                if (mineIsHit)
                {
                    DrawGameField(minesForGameField);
                    Console.Write("\nHrrrrrr! Game over! Your result is: {0} points. " +
                        "Enter your nickname: ", playerScore);
                    string nickname = Console.ReadLine();
                    Score endScore = new Score(nickname, playerScore);
                    if (topScorers.Count < 5)
                    {
                        topScorers.Add(endScore);
                    }
                    else
                    {
                        //if the score of the current player is higher than some topScorer result
                        for (int i = 0; i < topScorers.Count; i++)
                        {
                            if (topScorers[i].Points < endScore.Points)
                            {
                                topScorers.Insert(i, endScore);
                                topScorers.RemoveAt(topScorers.Count - 1);
                                break;
                            }
                        }
                    }
                    topScorers.Sort((Score firstPlayer, Score secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    topScorers.Sort((Score firstPlayer, Score secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));
                    Highscore(topScorers);

                    gameField = CreateGameField();
                    minesForGameField = SetMines();
                    playerScore = 0;
                    mineIsHit = false;
                    isNewGame = true;
                }
                if (isGameWon)
                {
                    Console.WriteLine("\nCongratulations! You opened 35 fields without a single drop of blood!");
                    DrawGameField(minesForGameField);
                    Console.WriteLine("Enter your name: ");
                    string playerNickname = Console.ReadLine();
                    Score highScore = new Score(playerNickname, playerScore);
                    topScorers.Add(highScore);
                    Highscore(topScorers);
                    gameField = CreateGameField();
                    minesForGameField = SetMines();
                    playerScore = 0;
                    isGameWon = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria");
            Console.WriteLine("Goodbye and thanks for playing!");
            Console.Read();
        }

        private static void Highscore(List<Score> points)
        {
            if (points.Count > 0)
            {
                Console.WriteLine("\nPoints:");
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2}",
                        i + 1, points[i].Name, points[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty highscores!\n");
            }
        }

        private static void RevealEmptyBlock(char[,] gameField,
            char[,] mines, int row, int column)
        {
            char neighbourMinesCount = CalculateNeighbourMinesCount(mines, row, column);
            mines[row, column] = neighbourMinesCount;
            gameField[row, column] = neighbourMinesCount;
        }

        private static void DrawGameField(char[,] board)
        {
            int boardRowCount = board.GetLength(0);
            int boardColumnCount = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < boardRowCount; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < boardColumnCount; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            const char UnknownBlockSymbol = '?';
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = UnknownBlockSymbol;
                }
            }

            return board;
        }

        private static char[,] SetMines()
        {
            const char EmptyBlockSymbol = '-';
            const char MineSymbol = '*';
            const int NumberOfMines = 15;

            int fieldRows = 5;
            int fieldColumns = 10;
            char[,] gameField = new char[fieldRows, fieldColumns];

            for (int row = 0; row < fieldRows; row++)
            {
                for (int col = 0; col < fieldColumns; col++)
                {
                    gameField[row, col] = EmptyBlockSymbol;
                }
            }

            List<int> randomMinesNumbers = new List<int>();

            while (randomMinesNumbers.Count < NumberOfMines)
            {
                Random randomGenerator = new Random();
                int randomMineNumber = randomGenerator.Next(50);
                if (!randomMinesNumbers.Contains(randomMineNumber))
                {
                    randomMinesNumbers.Add(randomMineNumber);
                }
            }

            //put some random mines on the field
            foreach (int randomMineCoordinate in randomMinesNumbers)
            {
                int mineCol = (randomMineCoordinate / fieldColumns);
                int mineRow = (randomMineCoordinate % fieldColumns);
                if (mineRow == 0 && randomMineCoordinate != 0)
                {
                    mineCol--;
                    mineRow = fieldColumns;
                }
                else
                {
                    mineRow++;
                }

                gameField[mineCol, mineRow - 1] = MineSymbol;
            }

            return gameField;
        }

        private static char CalculateNeighbourMinesCount(char[,] gameField, int rowCoord, int colCoord)
        {
            int neigbourMinesCount = 0;
            int fieldRows = gameField.GetLength(0);
            int fieldColumns = gameField.GetLength(1);

            if (rowCoord - 1 >= 0)
            {
                if (gameField[rowCoord - 1, colCoord] == '*')
                {
                    neigbourMinesCount++;
                }
            }

            if (rowCoord + 1 < fieldRows)
            {
                if (gameField[rowCoord + 1, colCoord] == '*')
                {
                    neigbourMinesCount++;
                }
            }

            if (colCoord - 1 >= 0)
            {
                if (gameField[rowCoord, colCoord - 1] == '*')
                {
                    neigbourMinesCount++;
                }
            }

            if (colCoord + 1 < fieldColumns)
            {
                if (gameField[rowCoord, colCoord + 1] == '*')
                {
                    neigbourMinesCount++;
                }
            }

            if ((rowCoord - 1 >= 0) && (colCoord - 1 >= 0))
            {
                if (gameField[rowCoord - 1, colCoord - 1] == '*')
                {
                    neigbourMinesCount++;
                }
            }

            if ((rowCoord - 1 >= 0) && (colCoord + 1 < fieldColumns))
            {
                if (gameField[rowCoord - 1, colCoord + 1] == '*')
                {
                    neigbourMinesCount++;
                }
            }

            if ((rowCoord + 1 < fieldRows) && (colCoord - 1 >= 0))
            {
                if (gameField[rowCoord + 1, colCoord - 1] == '*')
                {
                    neigbourMinesCount++;
                }
            }

            if ((rowCoord + 1 < fieldRows) && (colCoord + 1 < fieldColumns))
            {
                if (gameField[rowCoord + 1, colCoord + 1] == '*')
                {
                    neigbourMinesCount++;
                }
            }

            return char.Parse(neigbourMinesCount.ToString());
        }
    }
}
