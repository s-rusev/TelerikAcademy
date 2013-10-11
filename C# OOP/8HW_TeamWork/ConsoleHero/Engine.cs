using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleHero
{
    public class Engine
    {
        private const int AddPoint = 5;
        private const int MinusPoint = -2;
        private uint timeSleep;
        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObject> allObjects;
        List<MovingObject> movingObjects;
        List<GameObject> staticObjects;

        public Engine(IRenderer renderer, IUserInterface userInterface, uint timeSleep)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
            this.timeSleep = timeSleep;
        }

        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddMovingObject(MovingObject obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(GameObject obj)
        {
            if (obj is MovingObject)
            {
                this.AddMovingObject(obj as MovingObject);
            }
            else
            {
                this.AddStaticObject(obj);
            }
        }

        private bool PlaySoundIfCorrectButton(int row, int col)
        {
            bool addPoints = false;

            if (this.movingObjects != null)
            {
                foreach (FallingNote obj in this.movingObjects)
                {
                    if (obj.GetTopLeft().Row == row && obj.GetTopLeft().Col == col)
                    {
                        
                        Thread sound = new Thread(delegate()
                        {
                            Console.Beep((int)obj.Note.NoteTone, (int)obj.Note.NoteDuration);
                        });
                        sound.Start();
                        addPoints = true;
                    }
                }
            }
            return addPoints;
        }

        private void CalculatePoints(int value)
        {
            foreach (var res in this.staticObjects)
            {
                if (res.GetType().Name == "Result")
                {
                    if ((res as Result).Points + value >= 0)
                    {
                        (res as Result).Points += value;    
                    }
                    
                }
            }
        }
        public virtual void ProcessButtonA()
        {
            if (PlaySoundIfCorrectButton(22, 4))
            {
                CalculatePoints(AddPoint);
            }
            else
            {
                CalculatePoints(MinusPoint);
            }
        }

        public virtual void ProcessButtonS()
        {
            if (PlaySoundIfCorrectButton(22, 13))
            {
                CalculatePoints(AddPoint);
            }
            else
            {
                CalculatePoints(MinusPoint);
            }
        }

        public virtual void ProcessButtonD()
        {
            if (PlaySoundIfCorrectButton(22, 22))
            {
                CalculatePoints(AddPoint);
            }
            else
            {
                CalculatePoints(MinusPoint);
            }
        }

        public virtual void QuitGame()
        {
            UserInputProccesser.EndGame();
        }

        public virtual void Run()
        {
            for (int i = 0; i < 2 * MainClassConsoleHero.GameSong.Notes.Length + 24; i++)
            {

                this.renderer.RenderAll();

                System.Threading.Thread.Sleep((int)this.timeSleep);

                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }
            }
            

        }
    }
}
