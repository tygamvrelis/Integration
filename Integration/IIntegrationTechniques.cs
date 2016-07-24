using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration
{
    interface IIntegrationTechniques
    {
        double[] intervals { get; set; } // start and end points for intervals along x-axis, y-axis, z-axis, etc.
        double[] differentials { get; set; } // dx, dy, dz, etc...
        double[,] partition(double[] intervals, int numPartitions, double[] differentials); // creates partitions

        double[] technique(double[,] partition, Func<double, double> function);
    }
}
