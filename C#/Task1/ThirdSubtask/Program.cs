using System;
using System.IO;
using Utilities;

namespace ThirdSubtask
{
    class Program
    {
        static void Main()
        {
            const string FILE_PATH = "textSample.txt";
            string fileText;
            try
            {
                fileText = File.ReadAllText(FILE_PATH);
            }
            catch (IOException ex)
            {
                ConsoleUtils.CloseProgramWithMessage(ex.Message);
                throw;
            }

            var thirdSentenceWords = TextUtils.GetAllWords(TextUtils.GetNthSentence(fileText, 3));
            Console.WriteLine(String.Join(" ", TextUtils.ReverseWords(thirdSentenceWords))); 


            ConsoleUtils.CloseProgramWithMessage();
        }

    }
}
