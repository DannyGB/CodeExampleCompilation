using CodeExampleCompilation.Application;
using CodeExampleCompilation.Domain;

namespace CodeExampleCompilation.Extensions
{
    public static class MenuExtensions
    {
        public static void ExecuteAction(this Menu menu, string name)
            => (menu.ContainsKey(name) ? menu[name].Action : () => {})();

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
            if(!menu.ContainsKey(Constants.QUIT_KEY))
            {
                menu.Add(Constants.QUIT_KEY, new NavigationItem("Quit.", () => {}));
            }
            
            return menu;
        }
    }
}