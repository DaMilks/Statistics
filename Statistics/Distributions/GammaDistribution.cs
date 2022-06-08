using System;

namespace Statistics.Distributions
{
    public class GammaDistribution : IContiniousDistribusion
    {
        private readonly double _shape, _scale;
        private readonly Random _random;

        private static bool IsValidIsValidParameters(double shape, double scale)
        {
            return shape > 0 && scale > 0;
        }

        public GammaDistribution(double shape, double scale)
        {
            if (!IsValidIsValidParameters(shape, scale))
                throw new ArgumentException("Invalid parametrization for the distribution.");
            _shape = shape;
            _scale = scale;
            _random = new();
        }

        public GammaDistribution(double shape, double scale, Random random) : this(shape, scale)
        {
            _random = random;
        }

        public GammaDistribution(double shape) : this(shape, 1) { }

        public GammaDistribution()
        {
            _shape = 1;
            _scale = 1;
            _random = new();
        }

        public double Mode
        {
            get
            {
                if (_scale == double.Epsilon)
                    return _shape;
                return (_shape - 1) * _scale;
            }
        }

        public double Minimum => 0;

        public double Maximum => double.PositiveInfinity;

        public Random Random => _random;

        public double Mean
        {
            get
            {
                if (_scale == double.Epsilon)
                    return _shape;
                return _shape* _scale;
            }
        }

        public double Variance
        {
            get
            {
                if (_scale == double.Epsilon)
                    return 0;
                return _shape* _scale*_scale;
            }
        }

        public double StdDev
        {
            get
            {
                if (_scale == double.Epsilon)
                    return 0;
                return Math.Sqrt(_shape) * _scale;
            }
        }

        public double Median => throw new InvalidOperationException("Median of this distribution is undefined");

        public double Shape => _shape;

        public double Scale => _scale;

        public double Rate => 1 / _scale;

        public double CumulativeDistribution(double x)
        {
            //need Gamma function
            throw new NotImplementedException();
        }

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
