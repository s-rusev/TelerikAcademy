using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleHero
{
    public class KeyboardInterface : IUserInterface
    {
        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key.Equals(ConsoleKey.A))
                {
                    if (this.A_OnButtonPressed != null)
                    {
                        this.A_OnButtonPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.S))
                {
                    if (this.S_OnButtonPressed != null)
                    {
                        this.S_OnButtonPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.D))
                {
                    if (this.D_OnButtonPressed != null)
                    {
                        this.D_OnButtonPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.Escape))
                {
                    if (this.Esc_OnButtonPressed != null)
                    {
                        this.Esc_OnButtonPressed(this, new EventArgs());
                    }
                }
            }
        }

        public event EventHandler A_OnButtonPressed;

        public event EventHandler S_OnButtonPressed;

        public event EventHandler D_OnButtonPressed;

        public event EventHandler Esc_OnButtonPressed;
    }
}
