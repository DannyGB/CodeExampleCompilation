using System.Collections.Generic;
using CodeExampleCompilation.Application;
using CodeExampleCompilation.Domain;
using CodeExampleCompilation.Infrastructure;
using CodeExampleCompilation.Infrastructure.Display;


namespace CodeExampleCompilation.Extensions
{
    public static class ListExtensions
    {
        public static Menu CreateMenu(this IList<ContentFile> list, IContentReader contentReader, IScreen screen, ITitle title)
        {
            var menu = new Menu();
            var i = 1;

            foreach(var item in list)
            {
                menu.Add
                (
                    (i++).ToString(),
                    new NavigationItem(item.ContentItem.Header, new Page(item, screen, contentReader, title).Render)
                );
            }

            return menu;
        }
    }
}