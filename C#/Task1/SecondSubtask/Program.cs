using System;
using System.IO;
using System.Linq;

using Utilities;

namespace SecondSubtask
{
    class Program
    {
        static void Main()
        {
            const string FILE_PATH = "textSample.txt";
            string[] wordsArr;
            try
            {
                wordsArr = TextUtils.GetAllWords(File.ReadAllText(FILE_PATH));
            }
            catch (IOException ex)
            {
                ConsoleUtils.CloseProgramWithMessage(ex.Message);
                throw;
            }
            Console.WriteLine($"Words count: {wordsArr.Length}");
            Console.WriteLine("Every tenth word: ");
            var tenthsWords = wordsArr.Where((w, i) => (i + 1) % 10 == 0).ToArray();

            var tenthsWordsStr = TextUtils.JoinOnlyWordsWithSplitter(tenthsWords, ", ", ".");

            Console.WriteLine(tenthsWordsStr);
            ConsoleUtils.CloseProgramWithMessage();

        }
    }
}
