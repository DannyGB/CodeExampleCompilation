using System;
using CodeExampleCompilation.Application;
using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure.Display;
using Spectre.Console;

namespace CodeExampleCompilation.Infrastructure
{
    public class Page : PageBase
    {
        private readonly ContentFile _content;

        public Page(ContentFile content, IScreen screen, IContentReader contentReader) 
            : base(screen, contentReader) 
                => _content = content ?? throw new ArgumentException("content cannot be null", nameof(content));

        public override void Render() 
            => Screen.Draw(Constants.BACK_KEY,
                () => GetMenu(_content.ContentFilePath).AddBackNavigationItem().GetMenuPanel(),
                () => new Panel(_content.Markup)
                    .Expand()
                    .Header(_content.Header.AddHeaderStyle())
                    .HeaderAlignment(Justify.Center),
                (action) => GetMenu(_content.ContentFilePath).ExecuteAction(action))
            ;
    }
}