using System;
using CodeExampleCompilation.Infrastructure.Partials;
using Microsoft.Extensions.Logging;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace CodeExampleCompilation.Infrastructure.Display
{
    public class Screen : IScreen
    {
        private readonly ILogger<Screen> _logger;
        private readonly IWelcome _welcome;

        public Screen(ILogger<Screen> logger, IWelcome welcome)
        {
            _logger = logger ?? throw new ArgumentException("logger cannot be null", nameof(logger));
            _welcome = welcome ?? throw new ArgumentException("logger cannot be null", nameof(welcome));
        }

        public void Draw(
            string terminatorKey,
            Func<IRenderable> menu,
            Func<IRenderable> content,
            Action<string> onSelect)
        {
            _logger.LogDebug("Starting drawing");

            var selectedOption = string.Empty;

            do
            {
                _logger.LogDebug("Entered message loop");

                AnsiConsole.Clear();
                _welcome.Render();
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

            _logger.LogDebug("Ending drawing");
        }
    }
}