using Spectre.Console.Rendering;

namespace CodeExampleCompilation.Infrastructure
{
    public interface ITitle
    {
        IRenderable GetTitle();
    }
}