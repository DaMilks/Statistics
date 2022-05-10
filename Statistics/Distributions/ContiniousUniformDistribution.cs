using System;

namespace Statistics.Distributions
{
    public class ContiniousUniformDistribution : ICountiniousDistribusion
    {
        private readonly double _min, _max;
        private readonly Random _random;

        public ContiniousUniformDistribution()
        {
            _min = 0;
            _max = 1;
            _random = new();
        }

        public ContiniousUniformDistribution(double min, double max)
        {
            _min = min;
            _max = max;
            _random = new();
        }

        public ContiniousUniformDistribution(double min, double max, Random random) : this(min, max)
        {
            _random = random;
        }

        public double Mode => (_min + _max) / 2.0;

        public double Minimum => _min;

        public double Maximum => _max;

        public double Median => (_min + _max) / 2.0;


        public Random random => _random;

        public double Mean => (_min + _max) / 2.0;

        public double Variance => (_max - _min) * (_max - _min) / 12.0;

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

        public double Density(double x)
        {
            if (x < _min || x > _max)
                return 0.0;
            else return 1.0 / (_max - _min);
        }

        public double MakeSample()
        {
            return random.NextDouble() * (_max - _min) + _min;
        }
    }
}
