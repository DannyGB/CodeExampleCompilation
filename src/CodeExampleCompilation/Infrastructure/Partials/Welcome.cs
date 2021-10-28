using System.Threading.Tasks;
using Spectre.Console;

namespace CodeExampleCompilation.Infrastructure.Partials
{
    public class Welcome : IWelcome
    {
        public void Render()
        {
            var grid = new Grid()
                .AddColumn()
                .AddRow(new Panel(new FigletText("Welcome")
                    .Centered()
                    .Color(Color.Green)))
                .AddRow(new Panel(new Markup(@"Welcome to the code examples compilation project, this project aims to provide coding tips for C# programmers")
                    .Centered())
                    .Expand())
            ;

            AnsiConsole.Write(grid);
        }
    }
}