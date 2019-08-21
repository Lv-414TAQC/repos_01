using System;
using System.Collections.Generic;
using System.Linq;//C:\Users\yharasym\source\repos\OpenCart414Test\Rest414Test\Tools\CSVReader.cs
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Tools
{
    public abstract class ExternalReader
    {
        public const int PATH_PREFIX = 6;
        //public const string PATH_SEPARATOR = "\\";
        //protected const string FOLDER_DATA = "Assets";
        //protected const string FOLDER_BIN = "bin";
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
