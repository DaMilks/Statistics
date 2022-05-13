using System;
using System.Linq;

namespace Statistics.Distributions
{
    public class CategorialDistribution : IDiscreteDistribution
    {
        private readonly double[] _probabilities;
        private readonly Random _random;
        private static bool IsValidParameters(double[] probabilities)
        {
            return probabilities.Sum() == 1.0;
        }

        public CategorialDistribution(int n)
        {
            if(n <= 0)
                throw new ArgumentException("Invalid parametrization for the distribution.");
            _random = new();
            _probabilities=new double[n];
            double k = 1 / n;
            for (int i = 0; i < n; i++)
                _probabilities[i] = k;
        }

        public CategorialDistribution(double[] probabilities)
        {
            if(!IsValidParameters(probabilities))
                throw new ArgumentException("Invalid parametrization for the distribution.");
            _probabilities = probabilities;
            _random = new();
        }

        public CategorialDistribution(double[] probabilities, Random random) : this(probabilities)
        {
            _random = random;
        }

        public int Mode => throw new NotImplementedException();

        public int Minimum => 0;

        public int Maximum => _probabilities.Length-1;

        public Random Random => _random;

        public double Mean => throw new NotImplementedException();

        public double Variance => throw new NotImplementedException();

        public double StdDev => throw new NotImplementedException();

        public double Median => throw new NotImplementedException();

        public double CumulativeDistribution(double x)
        {
            throw new NotImplementedException();
        }

        public int MakeSample()
        {
            throw new NotImplementedException();
        }

        public double Probability(int x)
        {
            throw new NotImplementedException();
        }
    }
}
