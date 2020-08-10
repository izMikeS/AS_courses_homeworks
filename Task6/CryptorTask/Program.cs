using System;
using System.IO;

namespace CryptorTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath, outputPath;
            do
            {
                Console.WriteLine("Enter a valid file path:");
                inputPath = Console.ReadLine();
            }
            while (!File.Exists(inputPath));

            outputPath = Console.ReadLine();

            var consoleLogger = new ConsoleLoggerWatcher();
            var fileLogger = new FileLoggerWatcher("logs.txt");

            using (var textFileEncryptor = new TextFileEncryptor(inputPath))
            {

                textFileEncryptor.OnProcessComplete += consoleLogger.ProcessCompleteHandler;
                textFileEncryptor.OnProcessError += consoleLogger.ProcessErrorHandler;
                textFileEncryptor.OnProcessStart += consoleLogger.ProcessStartHandler;
                textFileEncryptor.OnProcessStateChange += consoleLogger.ProcessStateChangeHandler;
                textFileEncryptor.OnProcessComplete += fileLogger.ProcessCompleteHandler;
                textFileEncryptor.OnProcessError += fileLogger.ProcessErrorHandler;
                textFileEncryptor.OnProcessStart += fileLogger.ProcessStartHandler;
                textFileEncryptor.OnProcessStateChange += fileLogger.ProcessStateChangeHandler;


                textFileEncryptor.EncryptOrDecryptToFile(outputPath);


                Console.ReadKey();
            }

        }
    }
}
