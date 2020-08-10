using System;
using System.IO;
using Utilities;

namespace FirstSubtask
{
    class Program
    {
        static void Main()
        {
            const string FILE_PATH = "textSample.txt";
            string fileText, textForDelete;
            try
            {
                textForDelete = ConsoleUtils.GetUserInputWithMessage($"Enter text to remove from {FILE_PATH}...");

                if (String.IsNullOrEmpty(textForDelete))
                {
                    ConsoleUtils.CloseProgramWithMessage("The value cannot be empty.");
                }

                fileText = File.ReadAllText(FILE_PATH);

                if (!fileText.Contains(textForDelete))
                {
                    ConsoleUtils.CloseProgramWithMessage("The text does not contain the entered value.");
                }

                fileText = fileText.Replace(textForDelete, String.Empty);

                File.WriteAllText(FILE_PATH, fileText);

                ConsoleUtils.CloseProgramWithMessage($"Successfully removed value \"{textForDelete}\".");
            }
            catch (IOException ex)
            {
                ConsoleUtils.CloseProgramWithMessage(ex.Message);
            }
        }

    }
}
