using CodeExampleCompilation.Domain;

namespace CodeExampleCompilation.Application.Extensions
{
    public static class ContentFileExtensions
    {
        public static ContentFile ConvertFromBase64(this ContentFile file) 
            => new ContentFile(file.FilePath, new ContentItem() { Header = file.ContentItem.Header, Content = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(file.ContentItem.Content))});
    }
}