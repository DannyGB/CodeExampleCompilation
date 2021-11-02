using System;
using CodeExampleCompilation.Application;
using CodeExampleCompilation.Domain;
using CodeExampleCompilation.Extensions;
using CodeExampleCompilation.Infrastructure.Display;

using Spectre.Console;

namespace CodeExampleCompilation.Infrastructure
{
    public class Page : PageBase
    {
        private readonly ContentFile _content;

        public Page(ContentFile content, IScreen screen, IContentReader contentReader, ITitle title) 
            : base(screen, contentReader, title) 
                => _content = content ?? throw new ArgumentException("content cannot be null", nameof(content));

        public override void Render() 
            => Screen.Draw(Constants.BACK_KEY,
                () => GetTitle(),
                () => GetMenu(_content.FilePath).AddBackNavigationItem().GetMenuPanel(),
                () => new Panel(_content.ContentItem.Content.ToMarkup())
                    .Expand()
                    .Header(_content.ContentItem.Header.AddHeaderStyle())
                    .HeaderAlignment(Justify.Center),
                (action) => GetMenu(_content.FilePath).ExecuteAction(action))
            ;
    }
}