using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: fix bugs with moving when taking presents and fix ability to destroy presents


namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            //add ceiling
            for (int i = startCol - 1; i <= endCol; i++)
            {
                Block ceilingBlock = new IndestructibleBlock(new MatrixCoords(startRow - 1, i));

                engine.AddObject(ceilingBlock);
            }
            //add side walls
            for (int row = startRow; row < WorldRows; row++)
            {
                Block leftSideBlock = new IndestructibleBlock(new MatrixCoords(row, 1));
                engine.AddObject(leftSideBlock);
            }
            for (int row = startRow; row < WorldRows; row++)
            {
                Block rightSideBlock = new IndestructibleBlock(new MatrixCoords(row, WorldCols - 2));

                engine.AddObject(rightSideBlock);
            }
            //add popcorn blocks
            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock;
                if (i % 5 == 0)
                {
                    currBlock = new UnpassableBlock(new MatrixCoords(startRow , i));
                }
                else
                {
                    currBlock = new Block(new MatrixCoords(startRow, i));
                }
                engine.AddObject(currBlock);
            }
            //add some gift blocks
            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock;
                if (i % 3 == 0)
                {
                    currBlock = new GiftBlock(new MatrixCoords(startRow + 1, i));
                    //gifts make the racket a shooting racket 
                }
                else if (i % 5 == 0)
                {
                    currBlock = new ExplodingBlock(new MatrixCoords(startRow + 1, i));
                    //they destroy everything around them
                }
                else
                {
                    currBlock = new Block(new MatrixCoords(startRow + 1, i));
                }
                engine.AddObject(currBlock);
            }


            Ball theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 4),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            //should be only racket in the begining
            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            //  Engine gameEngine = new Engine(renderer, keyboard , 300);
            EngineShootingRocket gameEngine = new EngineShootingRocket(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
