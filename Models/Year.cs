using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamF_WeatherAnalysis.Models
{
    internal class Year
    {
        public int YearInt { get; set; }
        public List<Month> Months { get; set; }
        public int AvgTemp { get; set; }
        public int AvgMoist { get; set; }
    }
}
