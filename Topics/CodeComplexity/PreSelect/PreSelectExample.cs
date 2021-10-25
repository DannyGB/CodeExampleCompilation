using System.Collections.Generic;
using System.Linq;
using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure;
using Spectre.Console;

namespace CodeExampleCompilation.Topics.CodeComplexity.PreSelect
{
    public class PreSelectExample : Page
    {
        private IEnumerable<(int, bool)> _list;

        public PreSelectExample() : base("[green]Running pre-select example[/]")
        {
            _list = new List<(int, bool)>
            {
                (1, true),
                (2, false),
                (3, true)
            };
        }

        public IEnumerable<int> Loop()
        {
            IList<int> result = new List<int>();
            foreach(var x in _list)
            {
                if(x.Item2)
                {
                    result.Add(x.Item1);
                }
            }
            
            return result;
        }

        public IEnumerable<int> CanBeReplacedWith() => _list.Where(x => x.Item2).Select(x => x.Item1);

        public override Markup Content() => @$"[bold blue]IList<int> result = new List<int>();
foreach(var x in _list)
{{
    if(x.Item2)
    {{
        result.Add(x.Item1);
    }}
}}

return result;[/]

Will return [bold green]{string.Join(',', Loop())}[/] given the input

    [bold blue]_list = new List<(int, bool)>
    {{
        (1, true),
        (2, false),
        (3, true)
    }};[/]

but can be replaced with:
    [bold blue]_list.Where(x => x.Item2).Select(x => x.Item1);[/]
which also returns [bold green]{string.Join(',', CanBeReplacedWith())};[/]
".ToMarkup();
            
    }
}