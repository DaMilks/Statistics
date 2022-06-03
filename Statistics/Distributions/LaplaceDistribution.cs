using System;

namespace Statistics.Distributions
{
    public class LaplaceDistribution : IContiniousDistribusion
    {
        private readonly double _location, _scale;

        private readonly Random _random;

        private static bool IsValidParameters(double location, double scale)
        {
            return !double.IsNaN(location) & scale > 0;
        }

        public LaplaceDistribution(double location, double scale)
        {
            if (!IsValidParameters(location, scale))
                throw new ArgumentException("Invalid parametrization for the distribution.");
            _location = location;
            _scale = scale;
            _random = new();
        }
        public LaplaceDistribution(double scale) : this(0, scale)
        {

        }

        public LaplaceDistribution(double location, double scale, Random random) : this(location, scale)
        {
            _random = random;
        }

        public LaplaceDistribution() : this(0, 1) { }

        public double Mode => _location;

        public double Minimum => double.NegativeInfinity;

        public double Maximum => double.PositiveInfinity;

        public Random Random => _random;

        public double Mean => _location;

        public double Variance => 2*_scale*_scale;

        public double StdDev => Math.Sqrt(Variance);

        public double Median => _location;

        public double Location => _location;

        public double Scale => _scale;

        public double CumulativeDistribution(double x)
        {
            return 0.5 * (1 + (Math.Sign(x - _location) * (1 - Math.Exp(-Math.Abs(x - _location) / _scale))));
        }

        public double Density(double x)
        {
            return Math.Exp(-Math.Abs(x - _location) / _scale) / (2 * _scale);
        }

        public double MakeSample()
        {
            double basedValue = _random.NextDouble();
            return _location - _scale * Math.Sign(basedValue - 0.5) * Math.Log(1 - (2 * Math.Abs(basedValue - 0.5)));
        }
    }
}
