using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure;
using Spectre.Console;

namespace CodeExampleCompilation.CodeComplexity.IfElse
{
    public class IfElseExample : Page
    {
        public IfElseExample() : base("[green]Running if/else example[/]")
        {
        }

        public override Markup Content() => @$"[bold blue]if(x == 1 && y == 2)
    return true;
else
    return false;[/]

Will return [bold green]{IfElse()}[/] for x == 1 && y == 2

but can be replaced with:
    [bold blue]return (x == 1 && y == 2)[/]
which also returns [bold green]{CanBeReplacedWith()};[/]
".ToMarkup();

        public bool IfElse(int x = 1, int y = 2)
        {
           if(x == 1 && y == 2)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool CanBeReplacedWith(int x = 1, int y = 2) => (x == 1 && y == 2);
    }
}