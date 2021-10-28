using Spectre.Console;
using CodeExampleCompilation.Extensions;
using Microsoft.Extensions.Options;
using System;
using CodeExampleCompilation.Infrastructure.Display;
using CodeExampleCompilation.Application;

namespace CodeExampleCompilation
{
    public class Home : PageBase
    {
        private readonly AppSettings _settings;

        public Home(IScreen screen, IContentReader contentReader, IOptions<AppSettings> options)
            : base(screen, contentReader)
        {             
            options = options ?? throw new ArgumentException("options cannot be null", nameof(options));
            _settings = options.Value;
        }

        public override void Render() 
            => Screen.Draw(Constants.QUIT_KEY,
                () => GetMenu(_settings.Root).AddQuitNavigationItem().GetMenuPanel(),
                () => new Panel("Thanks for using this app, I hope you find it both entertaining and useful. Feel free to add your feedback to the [link=https://github.com/DannyGB/CodeExampleCompilation]GitHub repo[/] or add a Pull Request for any issues you might find."),
                (action) => GetMenu(_settings.Root).ExecuteAction(action))
            ;
    }
}