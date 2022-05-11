using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics.Distributions
{
    /// <summary>
    /// Normal distribution.
    /// </summary>
    public class NormalDistribution : ICountiniousDistribusion
    {
        private readonly double _sigma, _expected;
        private readonly Random _random;
        public NormalDistribution()
        {
            _sigma = 1;
            _expected = 0;
        }

        public NormalDistribution(double sigma)
        {
            _sigma = sigma;
        }

        public NormalDistribution(double sigma, double expected) : this(sigma)
        {
            _expected = expected;
        }
        /// <summary>
        /// Gets the mode of the distribution.
        /// </summary>
        public double Mode => throw new NotImplementedException();
        /// <summary>
        /// Gets the smallest element which can be maked
        /// </summary>
        public double Minimum => throw new NotImplementedException();
        /// <summary>
        /// Gets the largest element which can be maked
        /// </summary>
        public double Maximum => throw new NotImplementedException();
        /// <summary>
        /// Gets the random number generator which is used to make random samples.
        /// </summary>
        public Random Random => throw new NotImplementedException();
        /// <summary>
        /// Gets the mean of the distribution.
        /// </summary>
        public double Mean => throw new NotImplementedException();
        /// <summary>
        /// Gets the variance of the distribution.
        /// </summary>
        public double Variance => throw new NotImplementedException();
        /// <summary>
        /// Gets the standard deviation of the distribution.
        /// </summary>
        public double StdDev => throw new NotImplementedException();
        /// <summary>
        /// Gets the median of the distribution.
        /// </summary>
        public double Median => throw new NotImplementedException();
        /// <summary>
        /// Computes the cumulative distribution (CDF) of the distribution at x, i.e. P(X ≤ x).
        /// </summary>
        /// /// <param name="x">The location at which to compute the cumulative distribution function.</param>
        /// <returns>the cumulative distribution at location <paramref name="x"/>.</returns>
        public double CumulativeDistribution(double x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Computes the probability density of the distribution (PDF)
        /// </summary>
        /// <param name="x">The location at which to compute the density.</param>
        /// <returns>the density at <paramref name="x"/>.</returns>
        public double Density(double x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Makes a random sample from Normal distribution.
        /// </summary>
        /// <returns>a sample from Normal distribution.</returns>
        public double MakeSample()
        {
            throw new NotImplementedException();
        }
    }
}
