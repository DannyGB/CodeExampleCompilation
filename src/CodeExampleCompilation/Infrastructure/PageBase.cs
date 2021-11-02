using System;
using System.Linq;
using CodeExampleCompilation.Application;
using CodeExampleCompilation.Application.Extensions;
using CodeExampleCompilation.Domain;
using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure.Display;
using Spectre.Console.Rendering;

namespace CodeExampleCompilation.Infrastructure
{
    public abstract class PageBase : IRender
    {
        private Menu _menu;
        private readonly IContentReader _contentReader;
        private readonly ITitle Title;
        protected readonly IScreen Screen;

        protected PageBase(IScreen screen, IContentReader contentReader, ITitle title)
        {
            Screen = screen ?? throw new ArgumentException("screen cannot be null", nameof(screen));
            _contentReader = contentReader ?? throw new ArgumentException("contentReader cannot be null", nameof(contentReader));
            Title = title ?? throw new ArgumentException("title cannot be null", nameof(title));
        }

        public abstract void Render();

        protected Menu GetMenu(string path) 
            => _menu ?? (_menu = (_contentReader.Read(path)).GetAwaiter().GetResult()
                    .Select(x => x.ConvertFromBase64())
                    .ToList()
                    .CreateMenu(_contentReader, Screen, Title))
            ;

        protected IRenderable GetTitle() => Title.GetTitle();
    }
}