using System;

namespace Statistics.Distributions
{
    /// <summary>
    /// Normal distribution(Gaussian distribution)
    /// </summary>
    public class LaplaceDistribution : IContiniousDistribution
    {
        private readonly double _location, _scale;

        private readonly Random _random;

        private static bool IsValidParameters(double location, double scale)
        {
            return !double.IsNaN(location) & scale > 0;
        }
        /// <summary>
        /// Initializes a new instance of the Laplace distribution with given location and scale values
        /// </summary>
        public LaplaceDistribution(double location, double scale)
        {
            if (!IsValidParameters(location, scale))
                throw new ArgumentException("Invalid parametrization for the distribution.");
            _location = location;
            _scale = scale;
            _random = new();
        }
        /// <summary>
        /// Initializes a new instance of the Laplace distribution with given scale value and location=0
        /// </summary>
        public LaplaceDistribution(double scale) : this(0, scale)
        {

        }
        /// <summary>
        /// Initializes a new instance of the Laplace distribution with given location, scale values and randomsource
        /// </summary>
        public LaplaceDistribution(double location, double scale, Random random) : this(location, scale)
        {
            _random = random;
        }
        /// <summary>
        /// Initializes a new instance of the Laplace distribution with location=0 and scale=1
        /// </summary>
        public LaplaceDistribution() : this(0, 1) { }
        /// <summary>
        /// Gets the mode of the distribution.
        /// </summary>
        public double Mode => _location;
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
        public Random Random => _random;
        /// <summary>
        /// Gets the mean of the distribution.
        /// </summary>
        public double Mean => _location;
        /// <summary>
        /// Gets the variance of the distribution.
        /// </summary>
        public double Variance => 2 * _scale * _scale;
        /// <summary>
        /// Gets the standard deviation of the distribution.
        /// </summary>
        public double StdDev => Math.Sqrt(Variance);
        /// <summary>
        /// Gets the median of the distribution.
        /// </summary>
        public double Median => _location;
        /// <summary>
        /// Gets the location of the distribution.
        /// </summary>
        public double Location => _location;
        /// <summary>
        /// Gets the scale of the distribution.
        /// </summary>
        public double Scale => _scale;
        /// <summary>
        /// Computes the cumulative distribution (CDF) of the distribution at x
        /// </summary>
        /// /// <param name="x">The location at which to compute the cumulative distribution function.</param>
        /// <returns>the cumulative distribution at location <paramref name="x"/>.</returns>
        public double CumulativeDistribution(double x)
        {
            return 0.5 * (1 + (Math.Sign(x - _location) * (1 - Math.Exp(-Math.Abs(x - _location) / _scale))));
        }
        /// <summary>
        /// Computes the probability density of the distribution (PDF)
        /// </summary>
        /// <param name="x">The location at which to compute the density.</param>
        /// <returns>the density at <paramref name="x"/>.</returns>
        public double Density(double x)
        {
            return Math.Exp(-Math.Abs(x - _location) / _scale) / (2 * _scale);
        }
        /// <summary>
        /// Makes a random sample from Normal distribution.
        /// </summary>
        /// <returns>a sample from Normal distribution.</returns>
        public double MakeSample()
        {
            double basedValue = _random.NextDouble();
            return _location - _scale * Math.Sign(basedValue - 0.5) * Math.Log(1 - (2 * Math.Abs(basedValue - 0.5)));
        }
    }
}
