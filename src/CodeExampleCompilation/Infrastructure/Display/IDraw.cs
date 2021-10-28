using System;
using Spectre.Console.Rendering;

namespace CodeExampleCompilation.Infrastructure
{
    public interface IDraw
    {
        void Draw(
            string terminatorKey,
            Func<IRenderable> menu,
            Func<IRenderable> content,
            Action<string> onSelect);
    }
}