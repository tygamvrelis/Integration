using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration
{
    public static class CoordinateConverter
    {
        // 
        // Summary:
        //      Converts cartesian (rectangular) coordinates to cylindrical coordinates
        //
        // Parameters:
        //      Passed as a params array of doubles. The cartesian coordinates x, y, and z.
        //      Must be passed as numbers delimited by commas and/or spaces.
        //
        // Returns:
        //      An Array:
        //          First element: theta (angle between x-coordinate and y-coordinate)
        //
        //          Seconds element: rho (length of the resultant vector obtained by adding the x-vector and y-vector)
        //
        //          Third element: z (z-coordinate)
        public static double[] cartesianToCylindrical(params double[] args)
        {
            // Initialize array to be returned
            double[] res = new double[3];

            // Place passed args into array
            for(int i  = 0; i < args.Length; i++)
            {
                res[i] = args[i];
            }

            // Perform Conversion
            if (res[0] != 0)
            {
                res[0] = Math.Atan(res[1] / res[0]);
            }

            res[1] = Math.Sqrt(Math.Pow(res[0], 2) + Math.Pow(res[1], 1));

            // Return results
            return res;            
        }

        public static double[] cartesianToSpherical(params double[] arg)
        {
            throw new NotImplementedException();
        }

        public static double[] cylindricalToCartesian(params double[] args)
        {
            throw new NotImplementedException();
        }

        public static double[] cylindricalToSpherical(params double[] args)
        {
            throw new NotImplementedException();
        }

        public static double[] sphericalToCartesian(params double[] args)
        {
            throw new NotImplementedException();
        }

        public static double[] sphericalToCylindrical(params double[] args)
        {
            throw new NotImplementedException();
        }
    }
}
