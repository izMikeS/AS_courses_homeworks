using System;
using System.IO;
using System.Text;
using System.Threading;

namespace CryptorTask
{
    public class TextFileEncryptor : IDisposable
    {
        private FileManager _fileManager;
        private int _key;
        private bool _disposed = false;

        public TextFileEncryptor(string filePath, Func<string, int, string> cryptAlg = null, int key = 100)
        {
            if (String.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                throw new ArgumentException("The value is not correct.", nameof(filePath));
            }

            _key = key;
            CryptAlgotithm = cryptAlg;
            _fileManager = new FileManager(filePath);
        }

        public event EventHandler<ProcessStartEventArgs> OnProcessStart;
        public event EventHandler<ProcessStateChangeEventArgs> OnProcessStateChange;
        public event EventHandler<ProcessErrorEventArgs> OnProcessError;
        public event EventHandler<ProcessCompleteEventArgs> OnProcessComplete;

        public Func<string, int, string> CryptAlgotithm { get; set; }

        public void EncryptOrDecryptToFile(string outputFilePath)
        { 
            try
            {
                if (CryptAlgotithm == null)
                {
                    CryptAlgotithm = DefaultCryptAlgorithm;
                }

                OnProcessStart?.Invoke(this, new ProcessStartEventArgs());

                string lines = null;
                while (_fileManager.LinePosition < _fileManager.LinesCount)
                {
                    lines = CryptAlgotithm(_fileManager.GetLines(10), _key);

                    FileManager.SaveString(lines, outputFilePath);

                    OnProcessStateChange?.Invoke(this, new ProcessStateChangeEventArgs(Math.Round(_fileManager.LinePosition / (double)_fileManager.LinesCount * 100, 2)));
                    
                    // Delay
                    Thread.Sleep(1000);
                }
                
                OnProcessComplete?.Invoke(this, new ProcessCompleteEventArgs());
            }
            catch(Exception ex)
            {
                OnProcessError?.Invoke(this, new ProcessErrorEventArgs(ex));
            }
        }

        private static string DefaultCryptAlgorithm(string str, int key)
        {
            var output = new StringBuilder(str.Length);
            char tempSymb;
            for (int i = 0; i < str.Length; i++)
            {
                tempSymb = (char)(str[i] ^ key);
                output.Append(tempSymb);
            }
            return output.ToString();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _fileManager.Dispose();
            }

            _disposed = true;
        }
    }
}
