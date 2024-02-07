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
            ReadWrite.ReadAll("tempdata_src.txt");

            Console.WriteLine("---------- END OF FILE ----------");
            Console.ReadKey();
        }
        
    }
}