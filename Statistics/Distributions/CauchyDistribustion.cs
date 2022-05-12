using System;

namespace Statistics.Distributions
{
    /// <summary>
    /// Cauchy distribution
    /// </summary>
    public class CauchyDistribustion : ICountiniousDistribusion
    {
        private readonly double _location, _scale;
        private readonly Random _random;
        private static bool IsValidParameters(double location, double scale)
        {
            return scale > 0 && double.IsNaN(location);
        }
        /// <summary>
        /// Initializes a new instance of the Cauchy class with the location(X0)=0 and the scale(γ)=1
        /// </summary>
        public CauchyDistribustion() : this(0, 1)
        {
        }
        /// <summary>
        /// Initializes a new instance of the Cauchy class with given location(X0) and scale(γ) values
        /// </summary>
        public CauchyDistribustion(double location, double scale)
        {
            if (!IsValidParameters(location, scale))
                throw new ArgumentException("Invalid parametrization for the distribution.");
            _location = location;
            _scale = scale;
            _random = new();
        }
        /// <summary>
        /// Initializes a new instance of the Cauchy class with given location(X0) and scale(γ) values and randomsourse
        /// </summary>
        public CauchyDistribustion(double location, double scale, Random random) : this(location, scale)
        {
            _random = random;
        }
        /// <summary>
        /// Gets the mode of the distribution.
        /// </summary>
        public double Mode => _location;
        /// <summary>
        /// Gets the smallest element which can be maked
        /// </summary>
        public double Minimum => double.PositiveInfinity;
        /// <summary>
        /// Gets the largest element which can be maked
        /// </summary>
        public double Maximum => double.NegativeInfinity;
        /// <summary>
        /// Gets the random number generator which is used to make random samples.
        /// </summary>
        public Random Random => _random;
        /// <summary>
        /// Gets the mean of the distribution.
        /// </summary>
        public double Mean => throw new InvalidOperationException("Mean of this distribution is undefined");
        /// <summary>
        /// Gets the variance of the distribution.
        /// </summary>
        public double Variance => throw new InvalidOperationException("Variance of this distribution is undefined");
        /// <summary>
        /// Gets the standard deviation of the distribution.
        /// </summary>
        public double StdDev => throw new InvalidOperationException("Sandard seviation of this distribution is undefined");
        /// <summary>
        /// Gets the median of the distribution.
        /// </summary>
        public double Median => _location;
        /// <summary>
        /// Computes the cumulative distribution (CDF) of the distribution at x, i.e. P(X ≤ x).
        /// </summary>
        /// /// <param name="x">The location at which to compute the cumulative distribution function.</param>
        /// <returns>the cumulative distribution at location <paramref name="x"/>.</returns>
        public double CumulativeDistribution(double x)
        {
            return (1/Math.PI) * Math.Atan((x - _location) / _scale) + 0.5;
        }
        /// <summary>
        /// Computes the probability density of the distribution (PDF)
        /// </summary>
        /// <param name="x">The location at which to compute the density.</param>
        /// <returns>the density at <paramref name="x"/>.</returns>
        public double Density(double x)
        {
            double a = (x - _location) / _scale;
            return 1 / (Math.PI * _scale * (1 + a * a));
        }
        ///<summary>
        /// Makes a random sample from Cauchy distribution.
        /// </summary>
        /// <returns>a sample from Cauchy distribution.</returns>
        public double MakeSample()
        {
            return _location + _scale * Math.Tan(Math.PI * _random.NextDouble() - 0.5);
        }
    }
}
