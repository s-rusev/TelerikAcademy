using System;

namespace ConsoleHero
{
    public interface IRenderer
    {
        void EnqueueForRendering(IRenderable obj);

        void RenderAll();

        void ClearQueue();
    }
}
