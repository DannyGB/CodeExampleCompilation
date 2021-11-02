using Spectre.Console;
using Spectre.Console.Rendering;

namespace CodeExampleCompilation.Infrastructure
{
    public class Title : ITitle
    {
        public IRenderable GetTitle()
        {
            return new Grid()
                .AddColumn()
                .AddRow(new Panel(new FigletText("Welcome")
                    .Centered()
                    .Color(Color.Green)))
                .AddRow(new Panel(new Markup(@"Welcome to the code examples compilation project, this project aims to provide coding tips for C# programmers")
                    .Centered())
                    .Expand())
            ;
        }
    }
}