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
    }
}
