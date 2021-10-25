using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure;
using Spectre.Console;

namespace CodeExampleCompilation.Topics.EntityFramework
{
    public class Index : Page
    {
        public Index() : base("Entity Framework Best Practices", new Menu
            {
                { "1", new NavigationItem("Materialising queries.", () => new ReturningIQueryable.Index().Render()) },
                { "2", new NavigationItem("Select only the needed columns.", () => new ReturningOnlyNeededColumns.Index().Render()) },
            })
        {
        }

        public override Markup Content() => @"Knowing how and when to use which Entity Framework methods can avoid issues around memory consumption and performance.".ToMarkup();

    }
}