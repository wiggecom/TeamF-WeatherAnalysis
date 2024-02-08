using System.Text.RegularExpressions;
using System.Linq;
using TeamF_WeatherAnalysis.Helpers;
using System.Transactions;

namespace TeamF_WeatherAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string year = "2016";
            string month = "09";
            string day = "26";
            
            ReadWrite.ReadAllNoLinq(Statics.file, Patterns.matchAll, year, month, day);
            Console.WriteLine("--- Press any key to continue ---");
            Console.ReadKey();
            ReadWrite.ReadAll(Statics.file);
            Console.WriteLine("---------- END OF FILE ----------");
            Console.WriteLine("--- Press any key to continue ---");
            Console.ReadKey();
            #region check formula
            //while (true)
            //{
            //    Console.Write("Enter temperature: ");
            //    double temp = double.Parse(Console.ReadLine());

            //    Console.Write("Enter moisture: ");
            //    double moist = double.Parse(Console.ReadLine());

            //    double moldRisk = TextAnalyser.MoldRiskCalc(temp, moist);
            //}

            //MoldIndex.CrunchNumbers();
            #endregion
        }

    }
}