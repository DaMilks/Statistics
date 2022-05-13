using System;
using System.Linq;

namespace Statistics.Distributions
{
    public class CategorialDistribution : IDiscreteDistribution
    {
        private readonly double[] _probabilities;
        private readonly Random _random;
        private static bool IsValidParameters(double[] probabilities)
        {
            return probabilities.Sum() == 1.0;
        }

        public CategorialDistribution(int n)
        {
            if (n <= 0)
                throw new ArgumentException("Invalid parametrization for the distribution.");
            _random = new();
            _probabilities = new double[n];
            double k = 1 / n;
            for (int i = 0; i < n; i++)
                _probabilities[i] = k;
        }

        public CategorialDistribution(double[] probabilities)
        {
            if (!IsValidParameters(probabilities))
                throw new ArgumentException("Invalid parametrization for the distribution.");
            _probabilities = probabilities;
            _random = new();
        }

        public CategorialDistribution(double[] probabilities, Random random) : this(probabilities)
        {
            _random = random;
        }

        public int Mode
        {
            get
            {
                double max = _probabilities[0];
                int num=0;
                for (int i = 0; i < _probabilities.Length; i++)
                {
                    if (_probabilities[i]>max)
                    {
                        max= _probabilities[i];
                        num = i;
                    }
                }
                return num;
            }
        }

        public int Minimum => 0;

        public int Maximum => _probabilities.Length - 1;

        public Random Random => _random;

        public double Mean
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < _probabilities.Length; i++)
                {
                    sum += i * _probabilities[i];
                }
                return sum;
            }
        }

        public double Variance
        {
            get
            {
                double m = Median, sum = 0, r;
                for (int i = 0; i < _probabilities.Length; i++)
                {
                    r = i - m;
                    sum += r * r * _probabilities[i];
                }
                return sum;
            }
        }
        public double StdDev => Math.Sqrt(Variance);

        public double Median
        {
            get
            {
                double[] CDF = new double[_probabilities.Length];
                double sum = 0;
                for (int i = 0; i < CDF.Length; i++)
                {
                    sum += _probabilities[i];
                    CDF[i] = sum;
                }
                for (int i = 1; i < CDF.Length; i++)
                {
                    if (CDF[i - 1] < 0.5 && CDF[i] > 0.5)
                        return i;
                    if (CDF[i] == 0.5)
                        return 2 * i + 1;
                }
                throw new InvalidOperationException("Median of this distribution is undefined");
            }
        }

        public double CumulativeDistribution(double x)
        {
            throw new NotImplementedException();
            //TODO
        }

        public int MakeSample()
        {
            double r = _random.NextDouble();
            double d = 0;
            for (int i = 0; i < _probabilities.Length - 1; i++)
            {
                d += _probabilities[i];
                if (r <= d)
                    return i;
            }
            return _probabilities.Length - 1;
        }

        public double Probability(int x)
        {
            if (x < 0 || x >= _probabilities.Length)
                return 0;
            else return (_probabilities[x]);
        }
    }
}
