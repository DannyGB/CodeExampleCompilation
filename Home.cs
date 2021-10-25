using System;
using CodeExampleCompilation.Partials;
using Spectre.Console;
using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure;

namespace CodeExampleCompilation
{
    public class Home : IRender
    {
        private Menu _menu;

        public Home()
        {
            _menu = new Menu
            {
                { "1", new NavigationItem(@"[bold blue]1:[/] Code complexity.", () => (new CodeComplexity.Index()).Render()) },
                { Constants.QUIT_KEY, new NavigationItem("[bold blue]Q:[/] Quit.", () => {}) }
            };
        }

        public void Render()
        {
            var selectedOption = string.Empty;

            do
            {
                AnsiConsole.Clear();

                RenderWelcome();
                RenderNavigation();
                selectedOption = AnsiConsole.Ask<string>("Select option:");
                ExecuteAction(selectedOption);

            } while(!selectedOption.Equals(Constants.QUIT_KEY, StringComparison.InvariantCultureIgnoreCase));
        }

        private void ExecuteAction(string selectedOption) => _menu.ExecuteAction(selectedOption);

        private void RenderWelcome() => Welcome.Render();

        private void RenderNavigation() =>  AnsiConsole.Write(_menu.GetMenuPanel());
    }
}