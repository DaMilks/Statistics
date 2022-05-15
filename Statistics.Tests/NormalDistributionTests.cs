using NUnit.Framework;
using Statistics.Distributions;

namespace Statistics.Tests
{
    public class NormalDistributionTests
    {
        [Test]
        /// <summary>
        /// Can create normal distribution
        /// </summary>
        /// <param name="expected">Mean value.</param>
        /// <param name="sigma">Standard deviation value.</param>
        [TestCase(1, 10)]
        [TestCase(1, -5)]
        [TestCase(1, 10)]
        [TestCase(10.0, -5.0)]
        [TestCase(double.PositiveInfinity, 0)]
        public void CanCreateNormal(double sigma, double expected)
        {
            IDistribution n = new NormalDistribution(sigma, expected);
            Assert.Multiple(() =>
            {
                Assert.That(n.Mean, Is.EqualTo(expected));
                Assert.That(n.StdDev, Is.EqualTo(sigma));
            });
        }
    }
}