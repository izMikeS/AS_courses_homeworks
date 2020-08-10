using System;
using System.IO;
using System.Text;

namespace CryptorTask
{
    public class FileManager : IDisposable
    {
        private string _path;
        private StreamReader _streamReader;

        public int LinesCount { get; }
        public int LinePosition { get; private set; }

        public FileManager(string path, int position = 0)
        {
            _path = !String.IsNullOrEmpty(path) && File.Exists(path) ? path :
                throw new ArgumentException("Incorrect path.", nameof(path));
            LinePosition = position >= 0 ? position :
                throw new ArgumentException("Incorrect position.", nameof(position));
            _streamReader = new StreamReader(_path);

            LinesCount = CountLines();
        }

        public string GetLines(int linesCount)
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < linesCount && !_streamReader.EndOfStream; i++)
            {
                stringBuilder.Append($"{_streamReader.ReadLine()}{Environment.NewLine}");
                ++LinePosition;
            }
            return stringBuilder.ToString();
        }

        public static void SaveString(string str, string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Incorrect path.", nameof(path));
            }

            if(!File.Exists(path))
            {
                using (File.CreateText(path)) { }
            }

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(str);
            }
        }

        private int CountLines()
        {
            var lineCounter = 0;
            using (var reader = new StreamReader(_path))
            {
                while (reader.ReadLine() != null)
                {
                    lineCounter++;
                }
                return lineCounter;
            }
        }

        public void Dispose()
        {
            _streamReader.Dispose();
        }
    }
}
