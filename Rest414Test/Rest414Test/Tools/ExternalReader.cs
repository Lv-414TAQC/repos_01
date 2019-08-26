using System;
using System.Collections.Generic;

namespace Rest414Test.Tools
{
    public abstract class ExternalReader
    {
        public const int PathPrefix = 6;
        //public const string PathSeparator = "\\";
        //protected const string FolderData = "Assets";
        //protected const string FolderBin = "bin";
        //
        //public static Logger log = LogManager.GetCurrentClassLogger(); // for NLog

        public string Filename { get; private set; }
        public string Path { get; protected set; }

        //protected ExternalReader(string filename)
        public ExternalReader(string filename)
        {
            Filename = filename;
            Path = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("Path = " + Path);
            //Path = Path.Remove(Path.IndexOf(FOLDER_BIN)) + FOLDER_DATA + PATH_SEPARATOR + filename;
            Path = Path + filename;
            Console.WriteLine("Final Path = " + Path);
        }

        public IList<IList<string>> GetAllCells()
        {
            return GetAllCells(Path);
        }

        public abstract IList<IList<string>> GetAllCells(string path);
    }
}
