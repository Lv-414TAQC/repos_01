using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rest414Test.Tools
{
    public class CSVReader : ExternalReader
    {
        private const char CSV_SPLIT_BY = ';';

        public CSVReader(string filename) : base(filename)
        {
        }

        public override IList<IList<string>> GetAllCells(string path)
        {
            IList<IList<string>> allCells = new List<IList<string>>();
            string row;
            //
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    while ((row = streamReader.ReadLine()) != null)
                    {
                        allCells.Add(row.Split(CSV_SPLIT_BY).ToList());
                    }
                }
            }
            catch
            {
                //log.Error("File " + path + " not Found");
            }
            return allCells;
        }

    }
}
