using NUnit.Framework;
using Statistics.Distributions;

namespace Statistics.Tests.DistributionsTests
{
    [TestFixture]
    public class CauchyDistributionTests
    {
        /// <summary>
        /// Can create standard cauchy distribution instance
        /// </summary>
        [Test]
        public void CanCreateStandardCauchyDistribution()
        {
            CauchyDistribution n = new();
            Assert.Multiple(() =>
            {
                Assert.That(n.Location, Is.EqualTo(0.0));
                Assert.That(n.Scale, Is.EqualTo(1.0));
            });
        }
        [Test]
        /// <summary>
        /// Can create cauchy distribution instance
        /// </summary>
        /// <param name="location">location of distribution.</param>
        /// <param name="scale">scale of distribution.</param>
        [TestCase(1, 1)]
        [TestCase(-5, 1)]
        [TestCase(1.0, 5.0)]
        [TestCase(0, double.PositiveInfinity)]
        public void CanCreateCauchy(double location, double scale)
        {
            CauchyDistribution n = new(location, scale);
            Assert.Multiple(() =>
            {
                Assert.That(n.Location, Is.EqualTo(location));
                Assert.That(n.Scale, Is.EqualTo(scale));
            });
        }
        /// <summary>
        /// Cauchy distribution throw exception with invalid parameters.
        /// </summary>
        /// <param name="location">location of distribution value.</param>
        /// <param name="scale">scale of distribution value.</param>
        [TestCase(double.NaN, 1)]
        [TestCase(1, double.NaN)]
        [TestCase(double.NaN, double.NaN)]
        [TestCase(0, -1)]
        public void CauchyDistributionInvalidParameters(double location, double scale)
        {
            Assert.That(() => new CauchyDistribution(location, scale), Throws.ArgumentException);
        }
        /// <summary>
        /// Can make sample of cauchy distribution
        /// </summary>
        [Test]
        public void MakeSampleTest()
        {
            CauchyDistribution n = new();
            Assert.That(double.IsNaN(n.MakeSample()), Is.False);
        }
    }
}
