using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] bounds = { 0, 4 };
            int numPartitions = 100;
            Func<double, double> function = Functions.quadratic;
            RiemannSum_1D myRiemannSum = new RiemannSum_1D(bounds, numPartitions, function);
            printInfo(bounds, numPartitions, function, myRiemannSum);
        }

        private static void printInfo(double[] bounds, int numPartitions, Func<double, double> function, IntegrationTechniques myRiemannSum)
        {
            Console.WriteLine("Integrating the function '\"{0}'\" from {1} to {0} using {3} partitions and the {4} method\n",
                            function.ToString(), bounds[0], bounds[1], numPartitions, myRiemannSum.GetType().ToString());
            Console.WriteLine("Using right endpoints: {0}\n", myRiemannSum.result[0]);
            Console.WriteLine("Using left endpoints: {0}\n", myRiemannSum.result[1]);
            Console.WriteLine("Using midpoints: {0}\n", myRiemannSum.result[2]);
            Console.ReadLine();
        }
    }
}
