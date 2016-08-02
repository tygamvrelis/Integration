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

            DateTime time = DateTime.Now;

            partitionArray = partition(intervals, numPartitions, differentials);
            result = (technique(partitionArray, function));

            TimeSpan timeSpan = DateTime.Now - time;
            timeElapsed = timeSpan.TotalMilliseconds;
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

        private double getLastPosition(int i, int j, double lastPosition)
        {
            switch (i)
            {
                case 0: // Sampling right endpoints
                    lastPosition += differentials[0];
                    break;
                case 1: // Sampling left endpoints
                    if (j == 0) { break; }
                    else
                    { 
                        lastPosition += differentials[0];
                        break;
                    }
                case 2: //Sampling midpoints
                    if (j == 0) { lastPosition += differentials[0] / 2; break; }
                    else
                    {
                        lastPosition += differentials[0];
                        break;
                    }
                default:
                    throw new ArgumentException("i is out of range");
            }
            return lastPosition;
        }

        public override double[,] partition(double[] intervals, int numPartitions, double[] differentials)
        {
            double[,] partitionArray = new double[3, numPartitions];
            double lastPosition = intervals[0];

            int i = 0, j = 0;

            for (i = 0; i < partitionArray.GetLength(0); i++)
            {
                lastPosition = intervals[0];
                for (j = 0; j < partitionArray.GetLength(1); j++)
                {
                    lastPosition = getLastPosition(i, j, lastPosition);
                    partitionArray[i, j] = lastPosition;
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
                for (j = 0; j < partitionArray.GetLength(1); j++)
                {
                    result[i] += function(partitionArray[i, j]) * differentials[0];
                }
            }
            return result;
        }
    }
}
