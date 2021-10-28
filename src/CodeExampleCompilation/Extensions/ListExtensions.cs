using System.Collections.Generic;
using System.Linq;
using CodeExampleCompilation.Application;
using CodeExampleCompilation.Infrastructure;
using CodeExampleCompilation.Infrastructure.Display;

namespace CodeExampleCompilation.Extensions
{
    public static class ListExtensions
    {
        public static Menu CreateMenu(this IList<ContentMetaData> list, IContentReader contentReader, IScreen screen)
        {
            var menu = new Menu();

            for (int i = 0; i < list.Count(); i++)
            {
                var item = list[i];
                menu.Add((i+1).ToString(), new NavigationItem(list[i].ContentItem.Header, new Page(new ContentFile(item.FilePath, item.ContentItem), screen, contentReader).Render));
            }

            return menu;
        }
    }
}