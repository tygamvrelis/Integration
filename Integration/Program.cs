using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Integration
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test();
            //getUserInput1D();
            hardcodedTest_loopedPartitions(100);
        }

        private static void Test()
        {
            double[] bounds = { 0, 4 };
            int numPartitions = 100;
            Func<double, double> function = Functions.quadratic;
            RiemannSum_1D myRiemannSum = new RiemannSum_1D(bounds, numPartitions, function);
            printInfo(bounds, numPartitions, function, myRiemannSum);
        }

        private static void getUserInput1D()
        {
            Func<double, double> function = getFunc();
            int numPartitions = getPartitions();
            double[] bounds = getBounds1D();

            RiemannSum_1D myRiemannSum = new RiemannSum_1D(bounds, numPartitions, function);
            printInfo(bounds, numPartitions, function, myRiemannSum);
        }
        private static double[] getBounds1D()
        {
            Console.WriteLine("Please enter the bounds for integration from left to right, separated by a comma. Example format: -1,2\n");
            double parseResult;
            bool invalid = true;
            char[] delimiterChars = { ',' };
            double[] bounds = new double[2];
            int i = 0;

            while (invalid && i < 2)
            {
                string response = Console.ReadLine();
                response = string.Join("", response.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                string[] entries = response.Split(delimiterChars);
                foreach (string s in entries)
                {
                    if (Double.TryParse(entries[i], out parseResult))
                    {
                        bounds[i] = parseResult;
                        i++;
                        invalid = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                    }
                }
            }
            Array.Sort(bounds);
            return bounds;
        }

        private static void hardcodedTest_loopedPartitions(int numTests)
        {
            int i = 0;
            double[] bounds = { 0, 4 };
            Func<double, double> function = Functions.quadratic;
            int numPartitions = 100;

            string[] lines = new string[2];
            string fileName = "results.txt";

            while (i < numTests*1000)
            {
                RiemannSum_1D myRiemannSum = new RiemannSum_1D(bounds, numPartitions, function);
                Console.WriteLine("Test number: {0}", i / 1000 + 1);

                lines[0] = numPartitions.ToString();
                lines[1] = myRiemannSum.timeElapsed.ToString();
                fileName = logInfo(lines, fileName, i);

                i += 1000;
                numPartitions = i;
            }
            Console.WriteLine("Test complete");
            Console.ReadLine();
        }

        private static int getPartitions()
        {
            Console.WriteLine("Please enter the integer corresponding to the number of partitions you'd like.\n");
            int parseResult = 0;
            bool invalid = true;

            while (invalid)
            {
                string response = Console.ReadLine();
                if (Int32.TryParse(response, out parseResult))
                {
                    invalid = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
            return parseResult;
        }
        private static Func<double, double> getFunc()
        {
            Console.WriteLine("Please enter the integer corresponding to the function you'd like to integrate.\n");

            // Print the names of all the functions in the Functions class, along with a corresponding number
            var values = (Functions.functionNames[])Enum.GetValues(typeof(Functions.functionNames));
            for(int i = 0; i < values.Length; i++)
            {
                Console.WriteLine("{0}: {1}\n", i + 1, values[i]);
            }

            // Initialize variables for looping through the user input and returning the function
            Func<double, double> function;
            int parseResult = 0;
            bool invalid = true;

            while (invalid)
            {
                string response = Console.ReadLine();
                if (Int32.TryParse(response, out parseResult))
                {
                    invalid = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }

            // Maybe we can use dictionaries instead of switch...?
            //
            // Also could possibly use the var values instead of hardcoding this.
            switch (parseResult)
            {
                case 1:
                    function = Functions.quadratic;
                    break;
                case 2:
                    function = Functions.exponential;
                    break;
                case 3:
                    function = Functions.radical;
                    break;
                case 4:
                    function = Functions.arctan;
                    break;
                default: throw new ArgumentException("Invalid function name.");
            }

            return function;
        }

        private static void printInfo(double[] bounds, int numPartitions, Func<double, double> function, IntegrationTechniques myRiemannSum)
        {
            Console.WriteLine(@"Integrating the function ""{0}"" from {1} to {2} using {3} partitions and the {4} method"+"\n",
                            function.Method.Name, bounds[0], bounds[1], numPartitions, myRiemannSum.ToString());
            Console.WriteLine("Using right endpoints: {0}\n", myRiemannSum.result[0]);
            Console.WriteLine("Using left endpoints: {0}\n", myRiemannSum.result[1]);
            Console.WriteLine("Using midpoints: {0}\n", myRiemannSum.result[2]);
            Console.ReadLine();
        }
        private static string logInfo(string[] lines, string name, int uniqueNameFlag)
        {
            string path = @"D:\Users\Tyler\Documents\Visual Studio 2015\Projects\Integration\";
            string filename = name;
            if (uniqueNameFlag == 0)
            {
                filename = GetUniqueFilename(path, "results.txt");
            }
            path = path + filename;

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path, true))
            {
                file.Write("{0}\t{1}", lines[0], lines[1]);
                file.WriteLine("\n");
            }

            return filename;
        }
        public static string GetUniqueFilename(string path, string filename)

        {
            string ext = Path.GetExtension(filename);
            string basename = Path.Combine(Path.GetDirectoryName(filename),
                                           Path.GetFileNameWithoutExtension(filename));
            int num = 0;

            while(File.Exists(path + filename))
            {
                try
                {
                    num = Int32.Parse(Regex.Match(basename, @"\d+").Value);
                }
                catch { }
                finally
                {
                    if (num != 0)
                    {
                        int temp = basename.Length;
                        int intTemp = num.ToString().Length;
                        basename = basename.Remove(temp - intTemp);
                        basename = basename + (num + 1).ToString();
                    }
                    else
                    {
                        basename = basename + "1";
                    }
                    filename = basename + ext;
                }
            }

            basename = filename;

            string uniquefilename = string.Format("{0}",
                                                    basename);
            System.Threading.Thread.Sleep(1); // To really prevent collisions, but usually not needed
            return uniquefilename;
        }
    }
}
