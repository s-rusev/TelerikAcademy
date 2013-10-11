using System;

namespace ConsoleHero
{
    public interface IRenderable
    {
        MatrixCoords GetTopLeft();

        char[,] GetImage();
    }
}
