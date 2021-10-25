using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure;
using Spectre.Console;

namespace CodeExampleCompilation.Topics.CodeComplexity.PreSelect
{
    public class Index : Page
    {
         public Index() : base("IEnumerable pre-selection", new Menu
            {
                { "1", new NavigationItem("Run example", () => new PreSelectExample().Render()) },
            })
        {
        }

        public override Markup Content() =>
            @"If you have an enumerable you can pre-select the items that you want to work on using linq statements such as Where. 
Considering the below example:
    
    [bold blue]IEnumerable<int> result = new List<int>();
    foreach(var x in _list)
    {
        if(x.Item2)
        {
            result.Append(x.Item1);
        }
    }
    
    return result;[/]

This can be replaced with a pre-selection such as:

    [bold blue]return _list.Where(x => x.Item2)
            .Select(x => x.Item1);[/]

Linq has many methods that remove a lot of the need for branching and conditional logic. for instance if you wanted to return a boolean based on the whole collection you can use Any or All such as:

    [bold blue]return _list.All(x => x.Item2);[/] [green]// Checks all items in the collection have true in the Item2 property[/]
    [bold blue]return _list.Any(x => x.Item2);[/] [green]// Checks any item in the collection has a true in the Item2 property[/]
".ToMarkup();

    }
}