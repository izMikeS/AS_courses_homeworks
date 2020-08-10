using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class StringExtensions
    {
        public static string[] SentenceEndMarkers { get; } = new string[] { "...", ".", "!", "?" };

        public static string GetOnlyLettersOrDigits(this string str)
        {
            StringBuilder outputStr = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsLetterOrDigit(str[i]))
                {
                    outputStr.Append(str[i]);
                }
            }
            return outputStr.ToString();

        }
    }
}
