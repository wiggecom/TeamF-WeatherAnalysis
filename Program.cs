using System.Text.RegularExpressions;
using System.Linq;
using TeamF_WeatherAnalysis.Helpers;
using System.Transactions;
using TeamF_WeatherAnalysis.Models;
using System.Runtime.InteropServices;

namespace TeamF_WeatherAnalysis
{
    internal class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleOutputCP(uint wCodePageID);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCP(uint wCodePageID);
        static void Main(string[] args)
        {
            SetConsoleOutputCP(65001);
            SetConsoleCP(65001);
            List<DayMeasure> dayList = new List<DayMeasure>();
            List<MeasurePoint> measurePoints = new List<MeasurePoint>();
            bool contMenu = true;
            Gfx.InitGfxFirst();
            measurePoints = Lab.ReadAll(measurePoints);
            dayList = Lab.GetAllAverages(dayList, measurePoints);
            Gfx.SwitchFromGray();
            Menu.DrawMenu();

            while (contMenu)
            {
                contMenu = Menu.MenuKeys(measurePoints, dayList);
            }
            
            Gfx.FillJapanese2();
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