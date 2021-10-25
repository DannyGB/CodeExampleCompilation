using System.Collections.Generic;
using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure;
using Spectre.Console;

namespace CodeExampleCompilation.CodeComplexity.DictionaryLookup
{
    public class DictionaryLookupExample : Page
    {
        private IDictionary<int, string> _dict;

        public DictionaryLookupExample() : base("[green]Running switch to map example[/]")
        {
            _dict = new Dictionary<int, string>()
            {
                {1, "One"},
                {2, "Two"},
                {3, "Three"}
            };
        }

        public string Switch(int x = 1)
        {
            switch(x)
            {
                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                default:
                    return "Not found";
            }
        }

        public string CanBeReplacedWith(int x = 1) => _dict[x];

        public override Markup Content() =>
        
            @$"[bold blue]switch(x)
{{
    case 1:
        return ""One"";
    case 2:
        return ""Two"";
    case 3:
        return ""Three"";
    default:
        return ""Not found"";
}}[/]

will return [bold green]{Switch(2)}[/] for the input [bold green]2[/]

This can be replaced with:

[bold blue]return _dict[[x]];[/]

where _dict is

[bold blue] _dict = new Dictionary<int, string>()
{{
    {{1, ""One""}},
    {{2, ""Two""}},
    {{3, ""Three""}}
}};[/]

which also returns [bold green]{CanBeReplacedWith(2)}[/] for an input of [bold green]2[/]
            
".ToMarkup();

    }
}