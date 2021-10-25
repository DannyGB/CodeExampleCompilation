using System.Text;
using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure;
using Spectre.Console;

namespace CodeExampleCompilation.Topics.CodeComplexity.DictionaryLookup
{
    public class Index : Page
    {
        public Index() : base("Replacing switch with a map", new Menu
        {
            { "1", new NavigationItem("Run example", () => new DictionaryLookupExample().Render()) }
        })
        {
        }

        public override Markup Content() => @$"A switch statement can be replaced with a dictionary lookup that will make the code much less complex and prone to bugs and easier to read and maintain.
Considering the below example:
    
    switch(x)
    {{
        case 1:
            return ""One"";
        case 2:
            return ""Two"";
        case 3:
            return ""Three"";
        default:
            return ""Not found"";
    }}

This can be replaced with a dictionary lookup such as below:

    [bold blue]var _dict = new Dictionary<int, string>()
    {{
        {{1, ""One""}},
        {{2, ""Two""}},
        {{3, ""Three""}}
    }};

    return _dict.ContainsKey(x) ? _dict[[x]] : ""Not found"";[/]

We need to be careful when using this pattern that the intent of the code is not lost, one way to do this would be to add an extension method that has a suitable name that accurately portrays the intent of the code:

    [bold blue]public static string GetNumberAsString(this IEnumerable<int> _dictionary) => dict[[x]];[/]

This pattern can be quite powerful when the value in the dictionary lookup is a Func or Action:

    [bold blue]var _dict = new Dictionary<int, Func<int>>()
    {{
        {{Gold, CalculateGoldMemberBenefits}},
        {{Silver, CanculateSilverMemberBenefits}},
        {{Bronze, CalculateBronzeMemberBenefits}}
    }};

    return (_dict.ContainsKey(x) ? _dict[[x]] : CalculateBaseMemberBenefits)();[/]
".ToMarkup();

    }
}