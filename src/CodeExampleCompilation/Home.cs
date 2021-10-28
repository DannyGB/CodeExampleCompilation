using Spectre.Console;
using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure;
using System.Linq;
using Microsoft.Extensions.Options;
using System;
using CodeExampleCompilation.Infrastructure.Display;
using CodeExampleCompilation.Application;

namespace CodeExampleCompilation
{
    public class Home : IRender
    {
        private Menu _menu;
        private readonly IScreen _screen;

        public Home(IScreen screen, IContentReader contentReader, IOptions<AppSettings> options)
        { 
            options = options ?? throw new ArgumentException("options cannot be null", nameof(options));
            contentReader = contentReader ?? throw new ArgumentException("contentReader cannot be null", nameof(contentReader));
            _screen = screen ?? throw new ArgumentException("screen cannot be null", nameof(screen));

            _menu = contentReader.Read(options.Value.Root)
                .ToList()
                .CreateMenu(contentReader, screen)
                .AddQuitNavigationItem();
        }

        public void Render() => 
            _screen.Draw(Constants.QUIT_KEY, () => _menu.GetMenuPanel(), () => new Panel(string.Empty), (action) => _menu.ExecuteAction(action));
    }
}