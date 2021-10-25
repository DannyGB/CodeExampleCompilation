using Spectre.Console;

namespace CodeExampleCompilation.Extensions
{
    public static class StringExtensions
    {
        public static Markup ToMarkup(this string str) => new Markup(str);

        public static string AddHeaderStyle(this string str) => $"[green]{str}[/]";

        public static string AddExampleStyle(this string str) => $"[bold blue]{str}[/]";

        public static string AddMenuStyle(this string str) => $"[bold blue]{str}[/]";
    }
}