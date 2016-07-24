using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Integration;

namespace Integration.Test
{
    [TestClass]
    public class RiemannSum_1d
    {
        [TestMethod]
        public void TestDifferentials()
        {
            double[] bounds = { 0, 4 };
            int numPartitions = 100;
            Func<double, double> function = Functions.quadratic;
            RiemannSum_1D myRiemannSum = new RiemannSum_1D(bounds, numPartitions, function);

            Assert.AreEqual(myRiemannSum.differentials[0], 4 / 100);
        }

        [TestMethod]
        public void TestIntervals()
        {
            double[] bounds = { 0, 4 };
            int numPartitions = 100;
            Func<double, double> function = Functions.quadratic;
            RiemannSum_1D myRiemannSum = new RiemannSum_1D(bounds, numPartitions, function);

            Assert.AreEqual(myRiemannSum.intervals[0], 0);
            Assert.AreEqual(myRiemannSum.intervals[1], 4);
        }

        [TestMethod]
        public void TestPartitions()
        {
            double[] bounds = { 0, 4 };
            int numPartitions = 100;
            Func<double, double> function = Functions.quadratic;
            RiemannSum_1D myRiemannSum = new RiemannSum_1D(bounds, numPartitions, function);

            Assert.AreEqual(myRiemannSum.partitionArray[0, 0], 0 + 4 / 100);
            Assert.AreEqual(myRiemannSum.partitionArray[1, 0], 0);
            Assert.AreEqual(myRiemannSum.partitionArray[2, 0], 0 + (4/100 * 0.5));

            Assert.AreEqual(myRiemannSum.partitionArray[0, myRiemannSum.partitionArray.Length], 4);
            Assert.AreEqual(myRiemannSum.partitionArray[1, myRiemannSum.partitionArray.Length], 4 - 4 / 100);
            Assert.AreEqual(myRiemannSum.partitionArray[2, myRiemannSum.partitionArray.Length], 4 - (4 / 100 * 0.5));
        }

        [TestMethod]
        public void TestResult()
        {
            double[] bounds = { 0, 4 };
            int numPartitions = 100;
            Func<double, double> function = Functions.quadratic;
            RiemannSum_1D myRiemannSum = new RiemannSum_1D(bounds, numPartitions, function);

            Assert.AreEqual(myRiemannSum.result[0], 64/3, 1);
            Assert.AreEqual(myRiemannSum.result[1], 64 / 3, 1);
            Assert.AreEqual(myRiemannSum.result[2], 64 / 3, 1);
        }
    }
}
