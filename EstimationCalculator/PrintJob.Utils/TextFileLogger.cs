using System;
using System.IO;

namespace PrintJob.Utils
{
    public class TextFileLogger : IFileLogger
    {
        bool disposed = false;
        public StreamWriter stream { get; set; }

        public void Log(string text, string filePath)
        {
            stream = File.CreateText(filePath);
            stream.WriteLine(text);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                stream.Dispose();
            }
            disposed = true;
        }
    }
}
