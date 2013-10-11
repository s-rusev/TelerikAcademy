using System;

namespace ConsoleHero
{
    public interface IUserInterface
    {
        event EventHandler A_OnButtonPressed;

        event EventHandler S_OnButtonPressed;

        event EventHandler D_OnButtonPressed;

        event EventHandler Esc_OnButtonPressed;

        void ProcessInput();
    }
}
