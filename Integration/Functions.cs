using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration
{
    public static class Functions
    {
        public delegate double del(double x);

        public static double quadratic(double x)
        {
            return Math.Pow(x, 2);
        }
    }
}
