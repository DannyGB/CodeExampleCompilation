using System.Linq;
using CodeExampleCompilation.Domain;
using Spectre.Console;

namespace CodeExampleCompilation.Extensions
{
    public static class MenuExtensions
    {
        public static Markup GetMenuMarkup(this Menu menu)
            => new Markup(string.Join('\n', menu.Select(x => $"{(x.Key + ":").AddMenuStyle()} {x.Value.Text}")));
        
        public static Panel GetMenuPanel(this Menu menu)
            => new Panel(menu.GetMenuMarkup().LeftAligned())
                    .Header("Navigation".AddHeaderStyle())
                    .HeaderAlignment(Justify.Center);        
    }
}