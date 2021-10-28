using System;
using System.Linq;
using CodeExampleCompilation.Application;
using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure;
using CodeExampleCompilation.Infrastructure.Display;

namespace CodeExampleCompilation
{
    public abstract class PageBase : IRender
    {
        private Menu _menu;
        protected readonly IScreen Screen;
        private readonly IContentReader _contentReader;

        protected PageBase(IScreen screen, IContentReader contentReader)
        {
            Screen = screen ?? throw new ArgumentException("screen cannot be null", nameof(screen));
            _contentReader = contentReader ?? throw new ArgumentException("contentReader cannot be null", nameof(contentReader));
        }

        public abstract void Render();

        protected Menu GetMenu(string path) 
            => _menu ?? (_menu = (_contentReader.Read(path)).GetAwaiter().GetResult()
                    .ToList()
                    .CreateMenu(_contentReader, Screen))
            ;
    }
}