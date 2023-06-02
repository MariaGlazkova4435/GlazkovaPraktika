using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OplataTruda
{
    public class Proverka
    {
        public bool NullStr(string a)
        {
            return String.IsNullOrWhiteSpace(a);
        }

        public double SchetPoOkladu(string a, string b, string c)
        {
            if (double.TryParse(a, out double f) && double.TryParse(b, out f) && double.TryParse(c, out f))
            {
                double Oklad = Convert.ToDouble(a);
                double Plan = Convert.ToDouble(b);
                double Fact = Convert.ToDouble(c);
                return Oklad / Plan * Fact;
            }
            else
                return 0;
        }

        public double SchetPoOChasam(string a, string b)
        {
            if (double.TryParse(a, out double f) && double.TryParse(b, out f))
            {
                double stavka = Convert.ToDouble(a);
                double chas = Convert.ToDouble(b);
                return stavka*chas;
            }
            else
                return 0;
        }
    }
}
