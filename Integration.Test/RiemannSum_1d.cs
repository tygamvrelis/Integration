using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Integration;

namespace Integration.Test
{
    [TestClass]
    public class RiemannSum_1d
    {
        [TestMethod]
        public void Differentials_FirstEntry_IsCorrect()
        {
            var viewModel = new IntegrationViewModel();
            Assert.AreEqual(viewModel.myRiemannSum.differentials[0], 4f / 100, 0.001);
        }

        [TestMethod]
        public void Intervals_Entries_AreCorrect()
        {
            var viewModel = new IntegrationViewModel();

            Assert.AreEqual(viewModel.myRiemannSum.intervals[0], 0);
            Assert.AreEqual(viewModel.myRiemannSum.intervals[1], 4);
        }

        [TestMethod]
        public void Partitions_FirstAndLastEnries_AreCorrect()
        {
            var viewModel = new IntegrationViewModel();

            Assert.AreEqual(viewModel.myRiemannSum.partitionArray[0, 0], 0 + 4f / 100, 0.01);
            Assert.AreEqual(viewModel.myRiemannSum.partitionArray[1, 0], 0, 0.01);
            Assert.AreEqual(viewModel.myRiemannSum.partitionArray[2, 0], 0 + (4f / 100 * 0.5), 0.01);
                            
            Assert.AreEqual(viewModel.myRiemannSum.partitionArray[0, viewModel.myRiemannSum.partitionArray.GetLength(1) - 1], 4, 0.01);
            Assert.AreEqual(viewModel.myRiemannSum.partitionArray[1, viewModel.myRiemannSum.partitionArray.GetLength(1) - 1], 4 - (4f / 100), 0.01);
            Assert.AreEqual(viewModel.myRiemannSum.partitionArray[2, viewModel.myRiemannSum.partitionArray.GetLength(1) - 1], 4 - (4f / 100 * 0.5), 0.01);
        }

        [TestMethod]
        public void Result_Value_IsWithinDesiredRange()
        {
            var viewModel = new IntegrationViewModel();

            Assert.AreEqual(viewModel.myRiemannSum.result[0], 64 / 3f, 0.5);
            Assert.AreEqual(viewModel.myRiemannSum.result[1], 64 / 3f, 0.5);
            Assert.AreEqual(viewModel.myRiemannSum.result[2], 64 / 3f, 0.5);
        }
    }
}
