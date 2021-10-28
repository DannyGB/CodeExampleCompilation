using CodeExampleCompilation.Domain;
using CodeExampleCompilation.Extensions;
using Spectre.Console;

namespace CodeExampleCompilation.Infrastructure
{
    public class ContentFile
    {
        public ContentItem ContentItem { get; init; }
        private readonly string _filePath;

        public ContentFile(string filePath, ContentItem content)
        {
            _filePath = filePath;
            ContentItem = content;
        }

        public string ContentFilePath => _filePath;

        public Markup Markup => ContentItem.Content.ToMarkup();
        public string Header => ContentItem.Header;
    }
}