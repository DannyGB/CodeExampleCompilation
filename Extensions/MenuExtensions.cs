using System.Linq;
using CodeExampleCompilation.Infrastructure;
using Spectre.Console;

namespace CodeExampleCompilation.Extensions
{
    public static class MenuExtensions
    {
        public static Markup GetMenuMarkup(this Menu menu) => new Markup(string.Join('\n', menu.Select(x => x.Value.Text)));
        public static void ExecuteAction(this Menu menu, string name) => (menu.ContainsKey(name) ? menu[name].Action : () => {})();

        public static Panel GetMenuPanel(this Menu menu) => new Panel(menu.GetMenuMarkup().LeftAligned())
                    .Header("[green]Navigation[/]")
                    .HeaderAlignment(Justify.Center);
    }
}