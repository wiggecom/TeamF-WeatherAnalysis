using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using TeamF_WeatherAnalysis.Models;

namespace TeamF_WeatherAnalysis.Helpers
{
    internal class ReadWrite
    {
        public static string path = "../../../Files/";
        public static void ReadAll(string fileName)
        {
            using (StreamReader reader = new StreamReader(path + fileName))
            {
                string line = reader.ReadLine();
                int rowCount = 0;
                //for (int i = 0; i < 11;  i++)
                //{
                //    // 2016-05-31 13:58:30,Inne,24.8,42
                //    // string pattern = "(?<year>\\d{4})-(?<month>\\d{2})-(?<day>\\d{1,2})";
                //    string pattern = "(?<year>\\d2017)-(?<month>\\d05)-(?<day>\\d29)";
                //    TextAnalyser.Test(line, pattern);
                //    //Console.WriteLine(rowCount + " " + line);
                //    rowCount++;
                //    line = reader.ReadLine();
                //}

                while (line != null)
                {
                    string pattern = "(?<year>\\d{4})-(?<month>\\d{2})-(?<day>\\d{2}).(?<hour>\\d{2}):(?<minute>\\d{2}):(?<second>\\d{2}),(?<indoor>(Inne|Ute)),(?<temp>\\d{1,2}.\\d).(?<moist>\\d{2})";
                    TextAnalyser.Test(line, pattern, "2016", "10", "06");
                    line = reader.ReadLine();
                }
            }
        }
        public static void WriteAll(string fileName, string text)
        {
            using (StreamWriter writer = new StreamWriter(path + fileName, true))
            {
                writer.WriteLine(text);
            }
        }
    }
}
