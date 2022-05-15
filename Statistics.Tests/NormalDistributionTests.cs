using NUnit.Framework;
using Statistics.Distributions;

namespace Statistics.Tests
{
    [TestFixture]
    public class NormalDistributionTests
    {
        /// <summary>
        /// Can create standard distribution instance
        /// </summary>
        [Test]
        public void CanCreateStandardNormal()
        {
            IDistribution n = new NormalDistribution();
            Assert.Multiple(() =>
            {
                Assert.That(n.Mean, Is.EqualTo(0.0));
                Assert.That(n.StdDev, Is.EqualTo(1.0));
            });
        }

        [Test]
        /// <summary>
        /// Can create normal distribution instance
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
        /// <summary>
        /// Can make sample of normal distribution
        /// </summary>
        [Test]
        public void MakeSampleTest()
        {
            ICountiniousDistribusion n = new NormalDistribution();
            n.MakeSample();
        }
    }
}