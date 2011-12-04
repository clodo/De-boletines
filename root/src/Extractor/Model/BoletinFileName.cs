using System;
using System.IO;

namespace Extractor.Model
{
    internal class BoletinFileName
    {
        private readonly string fileName;
        public string FilePath { get; private set; }

        public BoletinFileName(string filePath)
        {
            this.fileName = Path.GetFileName(filePath);
            FilePath = filePath;
        }

        public DateTime GetDate()
        {
            string year = fileName.Substring(2, 4);
            string month = fileName.Substring(6, 2);
            string day = fileName.Substring(8, 2);

            return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
        }
    }
}