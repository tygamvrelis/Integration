using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration
{
    public class RiemannSum_1D : IntegrationTechniques
    {
        public RiemannSum_1D(double[] bounds, int numPartitions, Func<double, double> function)
        {
            setintervalsAndDifferentials(bounds, numPartitions);
            partitionArray = partition(intervals, numPartitions, differentials);
            result = (technique(partitionArray, function));
        }

        private void setintervalsAndDifferentials(double[] bounds, int numPartitions)
        {
            int i = 0, size = bounds.Length;

            intervals = new double[size];
            differentials = new double[size / 2];

            for (i = 0; i < size; i++)
            {
                intervals[i] = bounds[i];
            }

            for (i = 0; i < (size / 2); i++)
            {
                differentials[i] = (intervals[1 + 2 * i] - intervals[2 * i]) / numPartitions;
            }
        }

        public override double[,] partition(double[] intervals, int numPartitions, double[] differentials)
        {
            double[,] partitionArray = new double[3, numPartitions];
            double lastPosition = intervals[0];

            int i = 0, j = 0;

            for (i = 0; i < partitionArray.GetLength(0); i++)
            {
                lastPosition = intervals[0];

                for (j = 0; j < partitionArray.GetLength(1); i++)
                {
                    if (i == 0) { lastPosition += differentials[0]; } // Sampling right endpoints
                    else if (i == 2) { lastPosition = differentials[0] / 2; } // Sampling midpoints

                    partitionArray[i, j] = lastPosition;

                    if (i == 2) { lastPosition += differentials[0];  } // Sampling midpoints
                    else if(i == 1) { lastPosition += differentials[0]; } // Sampling left endpoints
                }
            }
            return partitionArray;
        }

        public override double[] technique(double[,] partitionArray, Func<double, double> function)
        {
            double[] result = new double[3];
            int i = 0, j = 0;

            for (i = 0; i < partitionArray.GetLength(0); i++)
            {
                for (j = 0; j < partitionArray.GetLength(1); i++)
                {
                    result[i] += function(partitionArray[i, j]) * differentials[0];
                }
            }
            return result;
        }
    }
}
