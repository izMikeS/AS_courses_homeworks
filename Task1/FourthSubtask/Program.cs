using System;
using System.IO;
using System.Linq;
using Utilities;

namespace FourthSubtask
{
    class Program
    {
        static void Main()
        {
            string path;
            while (true)
            {
                path = ConsoleUtils.GetUserInputWithMessage("Enter full folder name...");
                try
                {
                    foreach (string fileSystemEntry in Directory.GetFileSystemEntries(path).OrderBy(f => f))
                    {
                        Console.WriteLine(fileSystemEntry);
                    }
                }
                catch (Exception ex)
                {
                    ConsoleUtils.CloseProgramWithMessage(ex.Message);
                }
            }
        }
    }
}
