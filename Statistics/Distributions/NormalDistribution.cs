using System;

namespace Statistics.Distributions
{
    /// <summary>
    /// Normal distribution(Gaussian distribution)
    /// </summary>
    public class NormalDistribution : IContiniousDistribusion
    {
        private readonly double _sigma, _expected;
        private readonly Random _random;
        private double NormalValue()
        {
            IContiniousDistribusion d = new ContiniousUniformDistribution(-1, 1, _random);
            double v, u = 0, s = 2;
            while (s < 0 | s > 1)
            {
                v = d.MakeSample();
                u = d.MakeSample();
                s = u * u + v * v;
            }
            return u * Math.Sqrt((-2 * Math.Log(s)) / s);
        }
        private static bool IsValidParameters(double sigma, double expected)
        {
            return sigma > 0 && !double.IsNaN(expected);
        }
        /// <summary>
        /// Initializes a new instance of the Normal with sigma=1, expected=0
        /// </summary>
        public NormalDistribution()
        {
            _sigma = 1;
            _expected = 0;
            _random = new();
        }
        /// <summary>
        /// Initializes a new instance of the Normal given sigma vlue and expected=0
        /// </summary>
        public NormalDistribution(double sigma)
        {
            if (!IsValidParameters(sigma, 0))
                throw new ArgumentException("Invalid parametrization for the distribution.");
            _sigma = sigma;
            _expected = 0;
            _random = new();
        }
        /// <summary>
        /// Initializes a new instance of the Normal with given sigma and expected values
        /// </summary>
        public NormalDistribution(double sigma, double expected)
        {
            if (!IsValidParameters(sigma, expected))
                throw new ArgumentException("Invalid parametrization for the distribution.");
            _sigma = sigma;
            _expected = expected;
            _random = new();
        }
        /// <summary>
        /// Initializes a new instance of the ContinuousUniform with given sigma and expected values and randomsourse
        /// </summary>
        public NormalDistribution(double sigma, double expected, Random random) : this(sigma, expected)
        {
            _random = random;
        }

        /// <summary>
        /// Gets the mode of the distribution.
        /// </summary>
        public double Mode => _expected;
        /// <summary>
        /// Gets the smallest element which can be maked
        /// </summary>
        public double Minimum => double.NegativeInfinity;
        /// <summary>
        /// Gets the largest element which can be maked
        /// </summary>
        public double Maximum => double.PositiveInfinity;
        /// <summary>
        /// Gets the random number generator which is used to make random samples.
        /// </summary>
        public Random Random => throw new NotImplementedException();
        /// <summary>
        /// Gets the mean of the distribution.
        /// </summary>
        public double Mean => _expected;
        /// <summary>
        /// Gets the variance of the distribution.
        /// </summary>
        public double Variance => _sigma * _sigma;
        /// <summary>
        /// Gets the standard deviation of the distribution.
        /// </summary>
        public double StdDev => _sigma;
        /// <summary>
        /// Gets the median of the distribution.
        /// </summary>
        public double Median => _expected;
        /// <summary>
        /// Computes the cumulative distribution (CDF) of the distribution at x, i.e. P(X ≤ x).
        /// </summary>
        /// /// <param name="x">The location at which to compute the cumulative distribution function.</param>
        /// <returns>the cumulative distribution at location <paramref name="x"/>.</returns>
        public double CumulativeDistribution(double x)
        {
            throw new NotImplementedException();
            //TODO:Implement a CDF function
            //TODO:Implement a erf() function

        }
        /// <summary>
        /// Computes the probability density of the distribution (PDF)
        /// </summary>
        /// <param name="x">The location at which to compute the density.</param>
        /// <returns>the density at <paramref name="x"/>.</returns>
        public double Density(double x)
        {
            double d = (x - _expected) / _sigma;
            return Math.Exp(-0.5 * d * d) / (Math.Sqrt(2 * Math.PI) * _sigma);
        }
        /// <summary>
        /// Makes a random sample from Laplace distribution.
        /// </summary>
        /// <returns>a sample from Laplace distribution.</returns>
        public double MakeSample()
        {
            return _expected + _sigma * NormalValue();
        }
    }
}
