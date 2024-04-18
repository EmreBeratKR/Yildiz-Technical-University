using System.Text.RegularExpressions;

namespace SimpleApp
{
    public static partial class StringExtensions
    {
        [GeneratedRegex("(\\B[A-Z])")]
        private static partial Regex RegexPascalCaseToDisplayString();


        public static string PascalCaseToDisplayString(this string str) 
        {
            return RegexPascalCaseToDisplayString()
                .Replace(str, " $1")
                .Trim();
        }
    }
}
