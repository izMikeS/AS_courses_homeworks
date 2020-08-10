using System;

namespace Utilities
{
    public static class ConsoleUtils
    {
        public static string GetUserInputWithMessage(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }
        public static void CloseProgramWithMessage()
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
        public static void CloseProgramWithMessage(string msg)
        {
            Console.WriteLine(msg);
            CloseProgramWithMessage();
        }
    }
}
