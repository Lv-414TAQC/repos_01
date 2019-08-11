using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;
using System.Text.RegularExpressions;

namespace OpenCart414Test.Tools
{
    public class RegularExpressions
    {
        public decimal ConvertStringCurrency(string element)
        {
            decimal totalSum = 0;
            string toStringVar = string.Empty;
            Regex regex = new Regex(@"\d+[.|,]\d*");
            MatchCollection matches = regex.Matches(element);

            foreach (Match match in matches)
            {
                toStringVar = Convert.ToString(match.Value);
            }
            //totalSum += decimal.Parse(toStringVar, System.Globalization.CultureInfo.InvariantCulture);
            totalSum += Convert.ToDecimal(toStringVar, System.Globalization.CultureInfo.InvariantCulture);
            return totalSum;
        }
    }
}
