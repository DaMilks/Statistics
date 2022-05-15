using System;
using System.Linq;

namespace Statistics.Distributions
{
    /// Discrete Univariate Categorical distribution(also Discrete distribution)
    public class CategorialDistribution : IDiscreteDistribution
    {
        private readonly double[] _probabilities;
        private readonly Random _random;
        private static bool IsValidParameters(double[] probabilities)
        {
            return probabilities.Sum() == 1.0&&probabilities.Min()>0;
        }
        private static double[] SearchCDF(double[] probabilities)
        {
            double[] CDF = new double[probabilities.Length];
            CDF[0] = probabilities[0];
            for (int i = 1; i < CDF.Length; i++)
            {
                CDF[i] += probabilities[i];
            }
            return CDF;
        }
        /// <summary>
        /// Initializes a new instance of the Categorical class
        /// </summary>
        /// <param name="n">Number of equiprobable outcomes</param>
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
        /// <summary>
        /// Initializes a new instance of the Categorical class.
        /// </summary>
        /// <param name="probabilities">An array of nonnegative values</param>
        public CategorialDistribution(double[] probabilities)
        {
            if (!IsValidParameters(probabilities))
                throw new ArgumentException("Invalid parametrization for the distribution.");
            _probabilities = probabilities;
            _random = new();
        }
        /// <summary>
        /// Initializes a new instance of the Categorical class.
        /// </summary>
        /// <param name="probabilities">An array of nonnegative values</param>
        /// <param name="random">randomsource</param>
        public CategorialDistribution(double[] probabilities, Random random) : this(probabilities)
        {
            _random = random;
        }
        /// <summary>
        /// Gets the mode of the distribution.
        /// </summary>
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
        /// <summary>
        /// Gets the smallest element in the domain of the distribution.
        /// </summary>
        public int Minimum => 0;
        /// <summary>
        /// Gets the largest element in the domain of the distribution.
        /// </summary>
        public int Maximum => _probabilities.Length - 1;
        /// <summary>
        /// Gets the random number generator which is used to make random samples.
        /// </summary>
        public Random Random => _random;
        /// <summary>
        /// Gets the mean of the distribution.
        /// </summary>
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
        /// <summary>
        /// Gets the variance of the distribution.
        /// </summary>
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
        /// <summary>
        /// Gets the standard deviation of the distribution.
        /// </summary>
        public double StdDev => Math.Sqrt(Variance);
        /// <summary>
        /// Gets the median of the distribution.
        /// </summary>
        /// <exception cref="InvalidOperationException">Median of this distribution is undefined"</exception>
        public double Median
        {
            get
            {
                double[] CDF = SearchCDF(_probabilities);
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
        /// <summary>
        /// Gets the array of probabilities of the distribution.
        /// </summary>
        public double[] Probabilities => _probabilities;

        /// <summary>
        /// Computes the cumulative distribution (CDF) of the distribution at x
        /// </summary>
        /// /// <param name="x">The location at which to compute the cumulative distribution function.</param>
        /// <returns>the cumulative distribution at location <paramref name="x"/>.</returns>
        public double CumulativeDistribution(double x)
        {
            if (x < 0)
            {
                return 0;
            }

            if (x >= _probabilities.Length)
            {
                return 1;
            }
            double[] CDF = SearchCDF(_probabilities);
            return CDF[(int)Math.Floor(x)];
        }
        /// <summary>
        /// Make a random sample from the distribution.
        /// </summary>
        /// <returns>a sample from the distribution.</returns>
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
        /// <summary>
        /// Computes the probability mass function
        /// </summary>
        /// <param name="x">The location in the domain where we want to evaluate the probability mass function.</param>
        /// <returns>the probability mass at location <paramref name="x"/>.</returns>
        public double Probability(int x)
        {
            if (x < 0 || x >= _probabilities.Length)
                return 0;
            else return (_probabilities[x]);
        }
    }
}
