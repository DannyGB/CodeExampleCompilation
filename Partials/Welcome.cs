using Spectre.Console;

namespace CodeExampleCompilation.Partials
{
    public class Welcome
    {
        public static void Render()
        {
            AnsiConsole.Write(
                    new Panel(@"Welcome to the code examples compilation project")
                        .Expand()
                        .Header("[green]Welcome[/]")
                        .HeaderAlignment(Justify.Center)
                );
        }
    }
}