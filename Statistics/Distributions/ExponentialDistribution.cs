using System;

namespace Statistics.Distributions
{
    /// <summary>
    /// Exponential distribution
    /// </summary>
    public class ExponentialDistribution : IContiniousDistribusion

    {
        private readonly double _rate;
        private readonly Random _random;
        private static bool IsValidParameters(double rate)
        {
            return rate > 0;
        }
        /// <summary>
        /// Initializes a new instance of the Exponential with rate(λ)=1
        /// </summary>
        public ExponentialDistribution()
        {
            _rate = 1;
            _random = new();
        }
        /// <summary>
        /// Initializes a new instance of the Exponential with given rate (λ)
        /// </summary>
        public ExponentialDistribution(double rate)
        {
            if (!IsValidParameters(rate))
                throw new ArgumentException("Invalid parametrization for the distribution.");
            _rate = rate;
            _random = new();
        }
        /// <summary>
        /// Initializes a new instance of the Exponential with given rate (λ) and randomsourse
        /// </summary>
        public ExponentialDistribution(double rate, Random random) : this(rate)
        {
            _random = random;
        }
        /// <summary>
        /// Gets the mode of the distribution.
        /// </summary>
        public double Mode => 0;
        /// <summary>
        /// Gets the smallest element which can be maked
        /// </summary>
        public double Minimum => 0;
        /// <summary>
        /// Gets the largest element which can be maked
        /// </summary>
        public double Maximum => double.PositiveInfinity;
        /// <summary>
        /// Gets the random number generator which is used to make random samples.
        /// </summary>
        public Random Random => _random;
        /// <summary>
        /// Gets the mean of the distribution.
        /// </summary>
        public double Mean => 1 / _rate;
        /// <summary>
        /// Gets the variance of the distribution.
        /// </summary>
        public double Variance => 1 / (_rate * _rate);
        /// <summary>
        /// Gets the standard deviation of the distribution.
        /// </summary>
        public double StdDev => 1 / _rate;
        /// <summary>
        /// Gets the median of the distribution.
        /// </summary>
        public double Median => Math.Log(2) / _rate;
        /// <summary>
        /// Gets the rate of the exponential distribution.
        /// </summary>
        public double Rate => _rate;

        /// <summary>
        /// Computes the cumulative distribution (CDF) of the distribution at x, i.e. P(X ≤ x).
        /// </summary>
        /// /// <param name="x">The location at which to compute the cumulative distribution function.</param>
        /// <returns>the cumulative distribution at location <paramref name="x"/>.</returns>
        public double CumulativeDistribution(double x)
        {
            if (x < 0)
                return 0;
            else return 1 - Math.Exp(-_rate * x);
        }
        /// <summary>
        /// Computes the probability density of the distribution (PDF)
        /// </summary>
        /// <param name="x">The location at which to compute the density.</param>
        /// <returns>the density at <paramref name="x"/>.</returns>
        public double Density(double x)
        {
            if (x < 0)
                return 0;
            else return _rate * Math.Exp(-_rate * x);
        }
        ///<summary>
        /// Makes a random sample from Exponential distribution.
        /// </summary>
        /// <returns>a sample from Exponential distribution.</returns>
        public double MakeSample()
        {
            return -Math.Log(1 - _random.NextDouble()) / _rate;
        }
    }
}
