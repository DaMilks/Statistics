using System;

namespace Statistics.Distributions
{
    /// <summary>
    /// Gamma distribution
    /// </summary>
    public class GammaDistribution : IContiniousDistribution
    {
        private readonly double _shape, _scale;
        private readonly Random _random;

        private static bool IsValidIsValidParameters(double shape, double scale)
        {
            return shape > 0 && scale > 0;
        }
        /// <summary>
        /// Initializes a new instance of the Gamma class with given shape and scale values
        /// </summary>
        public GammaDistribution(double shape, double scale)
        {
            if (!IsValidIsValidParameters(shape, scale))
                throw new ArgumentException("Invalid parametrization for the distribution.");
            _shape = shape;
            _scale = scale;
            _random = new();
        }
        /// <summary>
        /// Initializes a new instance of the Gamma class with given shape, scale values and randomsource
        /// </summary>
        public GammaDistribution(double shape, double scale, Random random) : this(shape, scale)
        {
            _random = random;
        }
        /// <summary>
        /// Initializes a new instance of the Gamma class with given shape value and scale=1
        /// </summary>
        public GammaDistribution(double shape) : this(shape, 1) { }
        /// <summary>
        /// Initializes a new instance of the Gamma class with the shape=1 and the scale=1
        /// </summary>
        public GammaDistribution()
        {
            _shape = 1;
            _scale = 1;
            _random = new();
        }
        /// <summary>
        /// Gets the mode of the distribution.
        /// </summary>
        public double Mode
        {
            get
            {
                if (_scale == double.Epsilon)
                    return _shape;
                return (_shape - 1) * _scale;
            }
        }
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
        public double Mean
        {
            get
            {
                if (_scale == double.Epsilon)
                    return _shape;
                return _shape* _scale;
            }
        }
        /// <summary>
        /// Gets the variance of the distribution.
        /// </summary>
        public double Variance
        {
            get
            {
                if (_scale == double.Epsilon)
                    return 0;
                return _shape* _scale*_scale;
            }
        }
        /// <summary>
        /// Gets the standard deviation of the distribution.
        /// </summary>
        public double StdDev
        {
            get
            {
                if (_scale == double.Epsilon)
                    return 0;
                return Math.Sqrt(_shape) * _scale;
            }
        }
        /// <summary>
        /// Gets the median of the distribution.
        /// </summary>
        public double Median => throw new InvalidOperationException("Median of this distribution is undefined");
        /// <summary>
        /// Gets the shape of the Gamma distribution.
        /// </summary>
        public double Shape => _shape;
        /// <summary>
        /// Gets the scale of the Gamma distribution.
        /// </summary>
        public double Scale => _scale;
        /// <summary>
        /// Gets the rate of the Gamma distribution.
        /// </summary>
        public double Rate => 1 / _scale;
        /// <summary>
        /// Computes the cumulative distribution (CDF) of the distribution at x, i.e. P(X ≤ x).
        /// </summary>
        /// /// <param name="x">The location at which to compute the cumulative distribution function.</param>
        /// <returns>the cumulative distribution at location <paramref name="x"/>.</returns>
        public double CumulativeDistribution(double x)
        {
            //need Gamma function
            throw new NotImplementedException();
        }
        /// <summary>
        /// Computes the probability density of the distribution (PDF)
        /// </summary>
        /// <param name="x">The location at which to compute the density.</param>
        /// <returns>the density at <paramref name="x"/>.</returns>
        public double Density(double x)
        {
            if (_scale==double.Epsilon)
            {
                return double.PositiveInfinity;
            }

            if (_shape == 1.0)
            {
                return 1/_scale * Math.Exp(-1/_scale * x);
            }
            //TODO: Realized Gamma fuction
            return 0;
        }
        ///<summary>
        /// Makes a random sample from Gamma distribution.
        /// </summary>
        /// <returns>a sample from Gamma distribution.</returns>
        public double MakeSample()
        {
            if (_scale==double.Epsilon)
            {
                return _shape;
            }
            double y = 0, v, x;
            bool c;
            do
            {
                x = -1;
                while (x <= 0)
                {
                    y = Math.Tan(Math.PI * _random.NextDouble());
                    x = Math.Sqrt(2 * _shape - 1) * y + _shape - 1;
                }
                v = _random.NextDouble();
                c = v > (1 + y * y) * Math.Exp((_shape - 1) * Math.Log(x / (_shape - 1)) - Math.Sqrt(2 * _shape - 1) * y);
            } while (c);
            return x*_scale;
        }
    }
}
