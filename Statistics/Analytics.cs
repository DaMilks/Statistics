using System;

namespace Statistics
{
    public static class Analytics
    {
        public static int Minimum(int[] values)
        {
            int min = values[0];
            foreach (int value in values)
                if (value < min)
                    min = value;
            return min;
        }

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

        public static double Minimum(double[] values)
        {
            double min = values[0];
            foreach (double value in values)
                if (value < min)
                    min = value;
            return min;
        }

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

        public static double Maximum(double[] values)
        {
            double max = values[0];
            foreach (double value in values)
                if (value > max)
                    max = value;
            return max;
        }

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

        public static int Maximum(int[] values)
        {
            int max = values[0];
            foreach (int value in values)
                if (value > max)
                    max = value;
            return max;
        }

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

        public static double Mean(double[] values)
        {
            double sum = 0;
            foreach (double value in values)
                sum += value;
            return sum / values.Length;
        }

        public static double Mean(int[] values)
        {
            double sum = 0d;
            foreach (int value in values)
                sum += value;
            return sum / values.Length;
        }

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

        public static double StdDev(double[] values)
        {
            return Math.Sqrt(Variance(values));
        }
        public static double StdDev(int[] values)
        {
            return Math.Sqrt(Variance(values));
        }
    }
}
