using System;

namespace Statistics.Distributions
{
    public class GammaDistribution : IContiniousDistribusion
    {
        private readonly double _shape, _scale;
        private readonly Random _random;
        public double Mode => throw new NotImplementedException();

        public double Minimum => throw new NotImplementedException();

        public double Maximum => throw new NotImplementedException();

        public Random Random => _random;

        public double Mean => throw new NotImplementedException();

        public double Variance => throw new NotImplementedException();

        public double StdDev => throw new NotImplementedException();

        public double Median => throw new NotImplementedException();

        public double Shape => _shape;

        public double Scale => _scale;

        public double Rate => 1 / _scale;

        public double CumulativeDistribution(double x)
        {
            throw new NotImplementedException();
        }

        public double Density(double x)
        {
            throw new NotImplementedException();
        }

        public double MakeSample()
        {
            throw new NotImplementedException();
        }
    }
}
