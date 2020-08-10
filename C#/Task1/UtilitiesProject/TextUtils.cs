using System;
using System.Linq;
using System.Text;

namespace Utilities
{
    public static class TextUtils
    {
        public static string[] ReverseWords(string[] words)
        {
            char[] firstTemp;
            return words.Select((w, i) =>
            {
                if (!String.IsNullOrWhiteSpace(w))
                {
                    firstTemp = w.Trim().ToCharArray();
                    Array.Reverse(firstTemp);
                    return new string(firstTemp);
                }
                return null;
            }).Where(w => w != null).ToArray();
        }

        public static string[] GetAllWords(string text)
        {
            return text.Split(' ');
        }

        public static string GetNthSentence(string text, int sentenceNumber)
        {
            var sentences = text.Split(StringExtensions.SentenceEndMarkers,
                                         StringSplitOptions.RemoveEmptyEntries);
            try
            {
                return sentences[sentenceNumber - 1];
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException("There is no sentence with this number in the text.");
            }
        }

        public static string JoinOnlyWordsWithSplitter(string[] words, string splitter, string endString = null)
        {
            StringBuilder stringBuilderResult = new StringBuilder();
            int wordsCount = words.Count();
            for (int i = 0; i < wordsCount; i++)
            {
                stringBuilderResult.Append(words.ElementAt(i).GetOnlyLettersOrDigits());
                stringBuilderResult.Append(i != wordsCount - 1 ? splitter : endString);
            }

            return stringBuilderResult.ToString();
        }
    }
}
