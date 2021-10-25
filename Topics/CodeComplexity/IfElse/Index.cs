using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure;
using Spectre.Console;

namespace CodeExampleCompilation.Topics.CodeComplexity.IfElse
{
    public class Index : Page
    {
        public Index() : base("Replacing if/else", new Menu
            {
                { "1", new NavigationItem("Run example", () => new IfElseExample().Render()) },
            })
        {
        }

        public override Markup Content() => @"An if/else statement can be replaced by an inline statement reducing the complexity of the code and making it easier to read and maintain.
        
So a construct like:
    
    [bold blue]if(x == 1 && y == 2)
    {
        return true;                
    }

    else
    {
        return false;
    }[/]

can be replaced with something like this:

    [bold blue]return (x == 1 && y == 2);[/]

It is possible to replace further if/else structures.
Consider the below example:
    
    [bold blue]if(x == 1 && y == 2)
    {        
        return true;
    }

    else if(x > 1)
    {
        return true;
    }

    else
    {
        return false;
    }[/]

This could be replaced with the statement given below but as the number of conditions grows the readability of the code begins to decrease so this should be considered before use:

    [bold blue]return (x == 1 && y == 2) || x > 1;[/]

if/else statements can also be replaced using the ternary operator when the result is not a boolean for instance:

    [bold blue]return (x == 1 && y == 2) ? ""Foo"" : ""Bar"";[/]

Nested ternarys should be used sparingly as they can reduce readability

    [bold blue]return (x == 1 && y == 2) ? ""Foo"" : x > 1 ? ""Bar"" : ""Bee"";[/]
    ".ToMarkup();
    }
}