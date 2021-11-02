namespace CodeExampleCompilation.Domain
{
    public class ContentFile
    {
        public ContentItem ContentItem { get; init; }
        public string FilePath { get; init; }

        public ContentFile(string filePath, ContentItem contentItem)
        {
            FilePath = filePath;
            ContentItem = contentItem;
        }
    }
}