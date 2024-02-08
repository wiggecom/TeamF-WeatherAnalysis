using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamF_WeatherAnalysis.Helpers
{
    internal class Patterns
    {
        public static string matchAll = "(?<year>\\d{4})-(?<month>\\d{2})-(?<day>\\d{2}).(?<hour>\\d{2}):(?<minute>\\d{2}):(?<second>\\d{2}),(?<indoor>(Inne|Ute)),(?<temp>\\d{1,2}.\\d).(?<moist>\\d{2})";
    }
}
