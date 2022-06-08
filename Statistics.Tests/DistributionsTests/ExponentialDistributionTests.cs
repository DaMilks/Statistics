using NUnit.Framework;
using Statistics.Distributions;

namespace Statistics.Tests.DistributionsTests
{
    [TestFixture]
    public class ExponentialDistributionTests
    {
        /// <summary>
        /// Can create standard Exponential distribution instance
        /// </summary>
        [Test]
        public void CanCreateStandardExponentialDistribution()
        {
            ExponentialDistribution n = new();
            Assert.That(n.Rate, Is.EqualTo(1d));
        }
        [Test]
        /// <summary>
        /// Can create Exponential distribution instance
        /// </summary>
        /// <param name="rate">location of distribution.</param>
        [TestCase(10)]
        [TestCase(1d)]
        [TestCase(double.PositiveInfinity)]
        public void CanCreateExponential(double rate)
        {
            ExponentialDistribution n = new(rate);
            Assert.That(n.Rate, Is.EqualTo(rate));
        }
        /// <summary>
        /// Exponential distribution throw exception with invalid parameters.
        /// </summary>
        /// <param name="rate">location of distribution value.</param>
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(double.NaN)]
        public void ExponentialDistributionInvalidParameters(double rate)
        {
            Assert.That(() => new ExponentialDistribution(rate), Throws.ArgumentException);
        }
        /// <summary>
        /// Can make sample of Exponential distribution
        /// </summary>
        [Test]
        public void MakeSampleTest()
        {
            ExponentialDistribution n = new();
            Assert.That(double.IsNaN(n.MakeSample()), Is.False);
        }
    }
}
