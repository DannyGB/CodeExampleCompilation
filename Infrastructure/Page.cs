using System;
using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Partials;
using Spectre.Console;

namespace CodeExampleCompilation.Infrastructure
{
    public abstract class Page : IRender
    {
        private Menu _menu;
        private string _contentHeader;

        public Page(string contentHeader, Menu menu = default(Menu))
        {
            _contentHeader = contentHeader.AddHeaderStyle();
            _menu = menu ?? new Menu();
            _menu.Add(Constants.BACK_KEY, new NavigationItem("Back", () => {}));
        }

        public void Render()
        {
            var selectedOption = string.Empty;

            do
            {
                AnsiConsole.Clear();
                Welcome.Render();
                AnsiConsole.Write(GetGrid());

                selectedOption = AnsiConsole.Ask<string>("Select option:");
                _menu.ExecuteAction(selectedOption);

            } while(!selectedOption.Equals(Constants.BACK_KEY, StringComparison.InvariantCultureIgnoreCase));
        }

        public abstract Markup Content();

        public Grid GetGrid()
        {
            var grid = new Grid();
            grid.AddColumn(new GridColumn());
            grid.AddColumn(new GridColumn());
            grid.AddRow(
                _menu.GetMenuPanel(),
                new Panel(Content())
                .Expand()
                .Header(_contentHeader)
                .HeaderAlignment(Justify.Center)
            );

            return grid;
        }
    }
}