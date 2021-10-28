using System.Linq;
using CodeExampleCompilation.Extensions;
using Spectre.Console;

namespace CodeExampleCompilation.Infrastructure
{
    public class Page : IRender
    {
        private Menu _menu;
        private readonly ContentFile _content;
        private readonly IScreen _screen;
        private readonly IContentReader _contentReader; 

        public Page(ContentFile content, IScreen screen, IContentReader contentReader) 
        {
            _content = content;
            _screen = screen;
            _contentReader = contentReader;
        } 

        public void Render() =>
            _screen.Draw(Constants.BACK_KEY,
                () => Menu.GetMenuPanel(),
                () => new Panel(_content.Markup)
                    .Expand()
                    .Header(_content.Header.AddHeaderStyle())
                    .HeaderAlignment(Justify.Center),
                (action) => Menu.ExecuteAction(action));

        private Menu Menu => 
            _menu ?? (_menu = _contentReader.Read(_content.ContentFilePath)
                .ToList()
                .CreateMenu(_contentReader, _screen)
                .AddBackNavigationItem())
        ;
    }
}