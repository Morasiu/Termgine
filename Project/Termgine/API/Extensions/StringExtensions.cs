using System.Linq;
using System.Text.RegularExpressions;

namespace Termgine.API.Extensions {

    public static class StringExtensions {
        /// <summary>
        /// Get the number of lines in the string.
        /// </summary>
        /// <returns>Number of lines</returns>
        public static int GetStringHeight(this string str) {
            return Regex.Matches(str, System.Environment.NewLine).Count + 1;
        }

        /// <summary>
        /// Get string width.
        /// </summary>
        /// <remarks>
        /// For example string:
        /// Test\n
        /// Test123
        /// Test
        /// 
        /// Will have width 7.
        /// </remarks>
        /// <returns>Number of lines</returns>
        public static int GetStringWidth(this string str) {
            return Regex.Matches(str, System.Environment.NewLine).Max(l => l.Length);
        }

        /// <summary>
        /// Get all lines of string.
        /// </summary>
        /// <returns>Lines in array</returns>
        public static string[] GetLines(this string str) {
            return str.Split(System.Environment.NewLine);
        }
    }
}

