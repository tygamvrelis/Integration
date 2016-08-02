using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration
{
    public static class Functions
    {
        public enum functionNames
        {
            quadratic,
            exponential,
            radical,
            arctan
        }

        public static double quadratic(double x)
        {
            return Math.Pow(x, 2);
        }

        public static double exponential(double x)
        {
            return Math.Exp(x);
        }

        public static double radical(double x)
        {
            return Math.Sqrt(x);
        }

        public static double arctan(double x)
        {
            return Math.Atan(x);
        }
    }
}
