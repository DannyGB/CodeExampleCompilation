using System.Collections.Generic;

namespace CodeExampleCompilation.Domain
{
    public class Menu : Dictionary<string, NavigationItem>
    {
        public new void Add(string name, NavigationItem item)
        {
            base.Add(name.ToUpperInvariant(), item);
        }

        public new bool ContainsKey(string key)
        {
            return base.ContainsKey(key.ToUpperInvariant());
        }

        public new NavigationItem this[string key]
        {
            get { return base[key.ToUpperInvariant()]; }
            set { base[key.ToUpperInvariant()] = value; }
        }
    }
}