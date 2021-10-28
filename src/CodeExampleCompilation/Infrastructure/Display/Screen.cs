using System;
using CodeExampleCompilation.Infrastructure.Partials;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace CodeExampleCompilation.Infrastructure.Display
{
    public class Screen : IScreen
    {
        public void Draw(
            string terminatorKey,
            Func<IRenderable> menu,
            Func<IRenderable> content,
            Action<string> onSelect)
        {
            var selectedOption = string.Empty;

            do
            {
                AnsiConsole.Clear();
                Welcome.Render();
                AnsiConsole.Write(new Grid()
                    .AddColumn(new GridColumn())
                    .AddColumn(new GridColumn())
                    .AddRow(
                        menu(),
                        content())
                );
                
                selectedOption = AnsiConsole.Ask<string>("Select option:");
                onSelect(selectedOption);

            } while(!selectedOption.Equals(terminatorKey, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}