namespace CodeExampleCompilation.Domain
{
    public class ContentItem
    {
        private string _content;

        public string Header { get; set; }
        public string Content{ get => System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(_content)); set => _content = value; }
    }
}