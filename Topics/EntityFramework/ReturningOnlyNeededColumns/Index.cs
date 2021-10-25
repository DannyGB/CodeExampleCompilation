using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure;
using Spectre.Console;

namespace CodeExampleCompilation.Topics.EntityFramework.ReturningOnlyNeededColumns
{
    public class Index : Page
    {
        public Index() : base("Only return the columns you need")
        {
        }

        public override Markup Content() => @"Significant resources can be saved if you only return the columns you need as part of your EF query

Consider the below example:

    [bold blue]public IQueryable GetWidgets() => dbContext.Widget;[/]

This will result in an entity with all of its columns populated and whilst this is perfectly OK it can have a performance impact where there is a significant numbers of columns on the table and/or a significant number of rows being returned from the query. A better way would be to return just the columns you need for the operation you are performing.

For example:

    [bold blue]public IQueryable GetWidgets() => dbContent.Widget.Select(w => new { w.Id, w.Name })[/]

This will perform the select at the server rather than in the application and will only return the Id and Name columns.

".ToMarkup();
    }
}