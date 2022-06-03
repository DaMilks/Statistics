using System;

namespace Statistics.Distributions
{
    public class LaplaceDistribution : IContiniousDistribusion
    {
        private readonly double _location, _scale;

        private readonly Random _random;
        public double Mode => throw new NotImplementedException();

        public double Minimum => throw new NotImplementedException();

        public double Maximum => throw new NotImplementedException();

        public Random Random => throw new NotImplementedException();

        public double Mean => throw new NotImplementedException();

        public double Variance => throw new NotImplementedException();

        public double StdDev => throw new NotImplementedException();

        public double Median => throw new NotImplementedException();

        public double Location => _location;

        public double Scale => _scale;

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
