using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamF_WeatherAnalysis.Helpers
{
    internal class MoldIndex
    {
        public static void CrunchNumbers()
        {
            double value = 100;
            double increment = 1.05; // high risk
            Cruncher(3, 0, 100, increment, 11);
            increment = 3.8; // risk curve steep
            value = Cruncher(1, 0, 100, increment, 2);
            increment = 2; // risk curve exponential
            value = Cruncher(1, 10, value, increment, 3);
            increment = 1; // risk curve exponential
            Cruncher(1, 25, value, increment, 6);

        }
        public static double Cruncher(int level, int index, double value, double increment, int steps)
        {
            string lvl = "";
            if (level == 0)
            {
                lvl = " No Risk ";
            }
            else if (level == 1)
            {
                lvl = " Risk ";
            }
            else if (level == 3)
            {
                lvl = " High Risk ";
            }
            else
            {
                lvl = " Out of Bounds ";
            }
            double i = 1;
            for (int x = 1; x <= steps; x++)
            {
                Console.WriteLine("Cruncher - " + index + lvl + value);
                if (value > 78)
                {
                    i = i * increment;
                    value -= i;
                }
                else
                {
                    value = 78;
                }
                index += 5;
            }
            return value;
        }
    }
}
