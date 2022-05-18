using System;

namespace Statistics.Distributions
{
    /// <summary>
    /// Continuous Uniform distribution.
    /// </summary>
    public class ContiniousUniformDistribution : IContiniousDistribusion
    {
        private readonly double _min, _max;
        private readonly Random _random;
        private static bool IsValidParameters(double min, double max)
        {
            return min < max;
        }
        /// <summary>
        /// Initializes a new instance of the ContinuousUniform with min=0, max=1
        /// </summary>
        public ContiniousUniformDistribution()
        {
            _min = 0;
            _max = 1;
            _random = new();
        }
        /// <summary>
        /// Initializes a new instance of the ContinuousUniform with given min max values
        /// </summary>
        public ContiniousUniformDistribution(double min, double max)
        {
            if (!IsValidParameters(min, max))
                throw new ArgumentException("Invalid parametrization for the distribution.");
            _min = min;
            _max = max;
            _random = new();
        }
        /// <summary>
        /// Initializes a new instance of the ContinuousUniform with given min max values and randomsourse
        /// </summary>
        public ContiniousUniformDistribution(double min, double max, Random random) : this(min, max)
        {
            _random = random;
        }
        /// <summary>
        /// Gets the mode of the distribution.
        /// </summary>
        public double Mode => (_min + _max) / 2.0;
        /// <summary>
        /// Gets the smallest element which can be maked
        /// </summary>
        public double Minimum => _min;
        /// <summary>
        /// Gets the largest element which can be maked
        /// </summary>
        public double Maximum => _max;
        /// <summary>
        /// Gets the median of the distribution.
        /// </summary>
        public double Median => (_min + _max) / 2.0;

        /// <summary>
        /// Gets the random number generator which is used to make random samples.
        /// </summary>
        public Random Random => _random;
        /// <summary>
        /// Gets the mean of the distribution.
        /// </summary>
        public double Mean => (_min + _max) / 2.0;
        /// <summary>
        /// Gets the variance of the distribution.
        /// </summary>
        public double Variance => (_max - _min) * (_max - _min) / 12.0;
        /// <summary>
        /// Gets the standard deviation of the distribution.
        /// </summary>
        public double StdDev => (_max - _min) / Math.Sqrt(12.0);

        /// <summary>
        /// Computes the cumulative distribution (CDF) of the distribution at x, i.e. P(X ≤ x).
        /// </summary>
        /// /// <param name="x">The location at which to compute the cumulative distribution function.</param>
        /// <returns>the cumulative distribution at location <paramref name="x"/>.</returns>
        public double CumulativeDistribution(double x)
        {
            if (x < _min)
                return 0.0;
            if (x > _max)
                return 1.0;
            return (x - _min) / (_max - _min);
        }
        /// <summary>
        /// Computes the probability density of the distribution (PDF)
        /// </summary>
        /// <param name="x">The location at which to compute the density.</param>
        /// <returns>the density at <paramref name="x"/>.</returns>
        public double Density(double x)
        {
            if (x < _min || x > _max)
                return 0.0;
            else return 1.0 / (_max - _min);
        }
        /// <summary>
        /// Makes a random sample from the distribution.
        /// </summary>
        /// <returns>a sample from the distribution.</returns>
        public double MakeSample()
        {
            return _random.NextDouble() * (_max - _min) + _min;
        }
    }
}
