using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration
{
    public abstract class IntegrationTechniques : IIntegrationTechniques
    {
        #region Methods
        public double[] differentials { get; set; }

        public double[] intervals { get; set; }

        public abstract double[,] partition(double[] intervals, int numPartitions, double[] differentials);

        public abstract double[] technique(double[,] partition, Func<double, double> function);
    #endregion

        #region Fields
        public double[] result { get; set; }
        public double[,] partitionArray { get; set; }
        #endregion
    }
}
