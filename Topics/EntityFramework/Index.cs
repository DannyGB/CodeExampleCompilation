using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure;
using Spectre.Console;

namespace CodeExampleCompilation.Topics.EntityFramework
{
    public class Index : Page
    {
        public Index() : base("[green]Code Complexity[/]", new Menu
            {
                { "1", new NavigationItem("[bold blue]1:[/] Materialising queries.", () => new ReturningIQueryable.Index().Render()) },
            })
        {
        }

        public override Markup Content() => @"Knowing how and when to use which Entity Framework methods can avoid issues around memory consumption and performance".ToMarkup();

    }
}