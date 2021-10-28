using System.Linq;
using CodeExampleCompilation.Application;
using CodeExampleCompilation.Infrastructure;
using Spectre.Console;

namespace CodeExampleCompilation.Extensions
{
    public static class MenuExtensions
    {
        public static Markup GetMenuMarkup(this Menu menu) => new Markup(string.Join('\n', menu.Select(x => $"{(x.Key + ":").AddMenuStyle()} {x.Value.Text}")));
        public static void ExecuteAction(this Menu menu, string name) => (menu.ContainsKey(name) ? menu[name].Action : () => {})();

        public static Panel GetMenuPanel(this Menu menu) => new Panel(menu.GetMenuMarkup().LeftAligned())
                    .Header("Navigation".AddHeaderStyle())
                    .HeaderAlignment(Justify.Center);

        public static Menu AddBackNavigationItem(this Menu menu) 
        {
            if(!menu.ContainsKey(Constants.BACK_KEY))
            {
                menu.Add(Constants.BACK_KEY, new NavigationItem("Back", () => {}));
            }
            
            return menu;
        }

        public static Menu AddQuitNavigationItem(this Menu menu) 
        {
             menu.Add(Constants.QUIT_KEY, new NavigationItem("Quit.", () => {}));

             return menu;
        }
    }
}