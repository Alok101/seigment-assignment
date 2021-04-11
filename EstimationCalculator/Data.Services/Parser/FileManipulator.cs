using System;
using System.IO;

namespace Data.Services.Parser
{
    public static class FileManipulator
    {
        public static string GetDataFilePath(string fileName)
        {

            string path = Path.Combine($"{GetProjectDirectoryLocation()}/Data", fileName);
            return path;
        }
        public static string GetProjectDirectoryLocation()
        {
            string workDir = Environment.CurrentDirectory;
            return workDir;
        }
        public static string GetTextFileName(string txtFileName)
        {
            string currentFileName = $"{txtFileName}{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.txt";
            string path = Path.Combine($"{GetProjectDirectoryLocation()}/SaveFile", currentFileName);
            return path;
        }
    }
}
