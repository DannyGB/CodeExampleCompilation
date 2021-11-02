namespace CodeExampleCompilation.Domain
{
    public class ContentItem
    {
        private string _content;
        public string Header { get; set; }
        public string Content
        { 
            get => _content;
            set => _content = value; 
        }
    }
}