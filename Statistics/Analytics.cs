using System;

namespace Statistics
{
    public static class Analytics
    {
        /// <summary>
        /// Returns the smallest value from the unsorted data array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static int Minimum(int[] values)
        {
            int min = values[0];
            foreach (int value in values)
                if (value < min)
                    min = value;
            return min;
        }
        /// <summary>
        /// Returns the smallest absolute value from the unsorted data array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static int MinimumAbs(int[] values)
        {
            int min = 0;
            foreach (int value in values)
            {
                int v = Math.Abs(value);
                if (v < min)
                    min = v;
            }
            return min;
        }
        /// <summary>
        /// Returns the smallest value from the unsorted data array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static double Minimum(double[] values)
        {
            double min = values[0];
            foreach (double value in values)
                if (value < min)
                    min = value;
            return min;
        }
        /// <summary>
        /// Returns the smallest absolute value from the unsorted data array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static double MinimumAbs(double[] values)
        {
            double min = 0;
            foreach (double value in values)
            {
                double v = Math.Abs(value);
                if (v < min)
                    min = v;
            }
            return min;
        }
        /// <summary>
        /// Returns the largest value from the unsorted data array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static double Maximum(double[] values)
        {
            double max = values[0];
            foreach (double value in values)
                if (value > max)
                    max = value;
            return max;
        }
        /// <summary>
        /// Returns the largest absolute value from the unsorted data array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static double MaximumAbs(double[] values)
        {
            double max = Math.Abs(values[0]);
            foreach (double value in values)
            {
                double v = Math.Abs(value);
                if (v > max)
                    max = v;
            }
            return max;
        }
        /// <summary>
        /// Returns the largest value from the unsorted data array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static int Maximum(int[] values)
        {
            int max = values[0];
            foreach (int value in values)
                if (value > max)
                    max = value;
            return max;
        }
        /// <summary>
        /// Returns the largest absolute value from the unsorted data array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static int MaximumAbs(int[] values)
        {
            int max = Math.Abs(values[0]);
            foreach (int value in values)
            {
                int v = Math.Abs(value);
                if (v > max)
                    max = v;
            }
            return max;
        }
        /// <summary>
        /// Estimates the arithmetic sample mean from the unsorted data array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static double Mean(double[] values)
        {
            double sum = 0;
            foreach (double value in values)
                sum += value;
            return sum / values.Length;
        }
        /// <summary>
        /// Estimates the arithmetic sample mean from the unsorted data array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static double Mean(int[] values)
        {
            double sum = 0d;
            foreach (int value in values)
                sum += value;
            return sum / values.Length;
        }
        /// <summary>
        /// Estimates the variance from unsorted array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static double Variance(double[] values)
        {
            double variance = 0;
            double temp = values[0];
            double diff;
            for (int i = 1; i < values.Length; i++)
            {
                temp += values[i];
                diff = ((i + 1) * values[i]) - temp;
                variance += (diff * diff) / ((i + 1d) * i);
            }

            return variance / (values.Length - 1);
        }
        /// <summary>
        /// Estimates the variance from unsorted array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static double Variance(int[] values)
        {
            double variance = 0;
            double temp = values[0];
            double diff;
            for (int i = 1; i < values.Length; i++)
            {
                temp += values[i];
                diff = ((i + 1) * values[i]) - temp;
                variance += (diff * diff) / ((i + 1d) * i);
            }

            return variance / (values.Length - 1);
        }
        /// <summary>
        /// Estimates the standard deviation from unsorted array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static double StdDev(double[] values)
        {
            return Math.Sqrt(Variance(values));
        }
        /// <summary>
        /// Estimates the standard deviation from unsorted array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static double StdDev(int[] values)
        {
            return Math.Sqrt(Variance(values));
        }
        /// <summary>
        /// Estimates the median value from the unsorted data array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static double Median(double[] values)
        {
            //TODO:Realize faster method https://ru.wikipedia.org/wiki/Алгоритм_выбора
            double[] valuesSorted = new double[values.Length];
            Array.Copy(values,valuesSorted, values.Length);
            Array.Sort(valuesSorted);
            return MedianSorted(valuesSorted);
        }
        /// <summary>
        /// Estimates the median value from the sorted data array.
        /// </summary>
        /// <param name="values">Sample sorted array</param>
        public static double MedianSorted(double[] values)
        {
            int k = values.Length / 2;
            if ((values.Length & 1) == 0x1)
                return values[k];
            else return (values[k - 1] + values[k]) / 2d;
        }
        /// <summary>
        /// Estimates the median value from the unsorted data array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static double Median(int[] values)
        {
            int[] valuesSorted = new int[values.Length];
            Array.Copy(values, valuesSorted, values.Length);
            Array.Sort(valuesSorted);
            return MedianSorted(valuesSorted);
        }
        /// <summary>
        /// Estimates the median value from the sorted data array.
        /// </summary>
        /// <param name="values">Sample sorted array</param>
        public static double MedianSorted(int[] values)
        {
            int k = values.Length / 2;
            if ((values.Length & 1) == 0x1)
                return values[k];
            else return (values[k - 1] + values[k]) / 2d;
        }
        /// <summary>
        /// Estimates the median value from the unsorted data array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        public static int Mode(int[] values)
        {
            int min = Minimum(values),
            max = Maximum(values),
            n = max - min + 1;
            int[] histogram = new int[n],
            possibleValues = new int[n];
            for (int i = 0; i < max - min; i++)
            {
                possibleValues[i] = min + i;
                histogram[i] = 0;
            }
            foreach (int v in values)
                for (int i = 0; i < max - min; i++)
                {
                    if (v == possibleValues[i])
                        histogram[i]++;
                }
            max = histogram[0];
            int k = 0;
            for (int i = 0; i < histogram.Length; i++)
            {
                if (histogram[i] > max)
                {
                    max = histogram[i];
                    k = i;
                }
            }
            return possibleValues[k];
        }
        /// <summary>
        /// Estimates the median value from the unsorted data array.
        /// </summary>
        /// <param name="values">Sample array, no sorting is assumed.</param>
        /// <param name="possibleValues">Values ​​that can be contained in an sample array</param>
        public static int Mode(int[] values, int[] possibleValues)
        {
            int[] histogram = new int[possibleValues.Length];
            for (int i = 0; i < possibleValues.Length; i++)
            {
                histogram[i] = 0;
            }
            foreach (int v in values)
                for (int i = 0; i < possibleValues.Length; i++)
                {
                    if (v == possibleValues[i])
                        histogram[i]++;
                }
            int max = histogram[0];
            int k = 0;
            for (int i = 0; i < histogram.Length; i++)
            {
                if (histogram[i] > max)
                {
                    max = histogram[i];
                    k = i;
                }
            }
            return possibleValues[k];
        }

    }
}
