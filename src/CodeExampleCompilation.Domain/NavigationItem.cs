using System;

namespace CodeExampleCompilation.Domain
{
    public class NavigationItem
    {
        public string Text { get; }
        public Action Action { get; }

        public NavigationItem(string text, Action action)
        {
            Text = text;
            Action = action;
        }
    }
}