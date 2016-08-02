using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Test
{
    public class IntegrationViewModel
    {
        public static double[] bounds = { 0, 4 };
        public static int numPartitions = 100;
        public static Func<double, double> function = Functions.quadratic;
        public RiemannSum_1D myRiemannSum = new RiemannSum_1D(bounds, numPartitions, function);
    }

    public class CoordinateViewModel
    {
        public double[] coords0 = { 0 };
        public double[] coords1 = { 1, 1, 1 };
        public double[] coords2 = { 2, 2 };
        public double[] coords010 = { 0, 1, 0 };
        public double[] coords101 = { 1, 0, 1 };
        public double[] coords2_4_44 = { 2, 4, 44 };

        CoordinateViewModel(string coordParam, string functionName)
        {
            double[] res_coordsX;
            double[] answer_coordsX;
            Func<double[], double[]> function;

            switch (functionName)
            {
                case "cartesianToCylindrical": function = CoordinateConverter.cartesianToCylindrical;
                    break;
                case "cartesianToSpherical": function = CoordinateConverter.cartesianToSpherical;
                    break;
                case "cylindricalToCartesian": function = CoordinateConverter.cylindricalToCartesian;
                    break;
                case "cylindricalToSpherical": function = CoordinateConverter.cylindricalToSpherical;
                    break;
                case "sphericalToCartesian": function = CoordinateConverter.sphericalToCartesian;
                    break;
                case "sphericalToCylindrical": function = CoordinateConverter.sphericalToCylindrical;
                    break;
                default:
                    throw new ArgumentException("Invalid function name");
            }

            // Needs work because the answer of course depends on the function...how to organize this?!?!
            //switch (coordParam)
            //{
            //    case "coords0": res_coordsX = function(coords0);
            //        answer_coordsX = new double[] { 0, 0, 0 };
            //        break;
            //    case "coords1":
            //        res_coordsX = function(coords1);
            //        answer_coordsX = new double[] { 0, 0, 0 };
            //        break;
            //    case "coords2":
            //        res_coordsX = function(coords2);
            //        answer_coordsX = new double[] { 0, 0, 0 };
            //        break;
            //    case "coords010":
            //        res_coordsX = function(coords010);
            //        answer_coordsX = new double[] { 0, 0, 0 };
            //        break;
            //    case "coords101":
            //        res_coordsX = function(coords101);
            //        answer_coordsX = new double[] { 0, 0, 0 };
            //        break;
            //    case "coords2_4_44":
            //        res_coordsX = function(coords2_4_44);
            //        answer_coordsX = new double[] { 0, 0, 0 };
            //        break;
            //    default:
            //        throw new ArgumentException("Invalid test coordinates");
            //}
        }
    }
}
