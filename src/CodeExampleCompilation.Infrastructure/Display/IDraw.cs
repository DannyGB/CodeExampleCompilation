using System;
using Spectre.Console.Rendering;

namespace CodeExampleCompilation.Infrastructure.Display
{
    public interface IDraw
    {
        void Draw(
            string terminatorKey,
            Func<IRenderable> header,
            Func<IRenderable> menu,
            Func<IRenderable> content,
            Action<string> onSelect);
    }
}