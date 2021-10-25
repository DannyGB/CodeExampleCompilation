using Spectre.Console;

namespace CodeExampleCompilation.Extensions
{
    public static class StringExtensions
    {
        public static Markup ToMarkup(this string str) => new Markup(str);
    }
}