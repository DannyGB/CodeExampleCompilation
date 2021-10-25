using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure;
using Spectre.Console;

namespace CodeExampleCompilation.Topics.CodeComplexity
{
    public class Index : Page
    {
        public Index() : base("Code Complexity", new Menu
            {
                { "1", new NavigationItem("Replacing if/else.", () => new IfElse.Index().Render()) },
                { "2", new NavigationItem("Using IEnumerable Pre-select.", () => new PreSelect.Index().Render()) },
                { "3", new NavigationItem("Replacing switch with a map.", () => new DictionaryLookup.Index().Render()) }
            })
        {
        }

        public override Markup Content() => @"Overly complex conditional logic in a method (as well as having large amounts of code in a single method) is a good 
hiding place for bugs and makes unit testing more difficult and time consuming (have a look at the [Link=https://en.wikipedia.org/wiki/Cyclomatic_complexity]Cyclomatic complexity - Wikipedia metric[/])
and also reduces the readability and maintainability of a codebase. Consider how easy you think this method would be to test and maintain for instance or this one.".ToMarkup();

    }
}