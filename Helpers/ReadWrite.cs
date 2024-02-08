using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TeamF_WeatherAnalysis.Helpers
{
    internal class ReadWrite
    {
        
        public static void ReadAllNoLinq(string fileName, string pattern, string year, string month, string day)
        {
            using (StreamReader reader = new StreamReader(Statics.path + fileName))
            {
                string line = reader.ReadLine();
                int rowCount = 0;
                while (line != null)
                {
                    TextAnalyser.NoLinq(line, pattern, year, month, day);
                    line = reader.ReadLine();
                }
            }
        }
        public static void ReadAll(string fileName)
        {
            using (StreamReader reader = new StreamReader(Statics.path + fileName))
            {
                string line = reader.ReadLine();
                int rowCount = 0;
                while (line != null)
                {
                    Console.WriteLine(rowCount + " " + line);
                    rowCount++;
                    line = reader.ReadLine();
                }
            }
        }
        public static void WriteAll(string fileName, string text)
        {
            using (StreamWriter writer = new StreamWriter(Statics.path + fileName, true))
            {
                writer.WriteLine(text);
            }
        }
    }
}
