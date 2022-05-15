using NUnit.Framework;
using Statistics.Distributions;

namespace Statistics.Tests.DistributionsTests
{
    [TestFixture]
    public class ContiniousUniformDistributionTests
    {
            /// <summary>
            /// Can create standard uniform distribution instance
            /// </summary>
            [Test]
            public void CanCreateStandardUniformDistribution()
            {
            ContiniousUniformDistribution n = new();
                Assert.Multiple(() =>
                {
                    Assert.That(n.Minimum, Is.EqualTo(0.0));
                    Assert.That(n.Maximum, Is.EqualTo(1.0));
                });
            }
        [Test]
        /// <summary>
        /// Can create uniform distribution instance
        /// </summary>
        /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        [TestCase(-1, 1)]
        [TestCase(-5, -1)]
        [TestCase(1, 10)]
        [TestCase(1.0, 5.0)]
        [TestCase(0, double.PositiveInfinity)]
        public void CanCreateNormal(double min, double max)
        {
            ContiniousUniformDistribution n = new(min, max);
            Assert.Multiple(() =>
            {
                Assert.That(n.Minimum, Is.EqualTo(min));
                Assert.That(n.Maximum, Is.EqualTo(max));
            });
        }
        /// <summary>
        /// Can make sample of uniform distribution
        /// </summary>
        /// /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        [Test]
        [TestCase(-1, 1)]
        public void MakeSampleTest(double min, double max)
        {
            ContiniousUniformDistribution n = new(min, max);
            double sample = n.MakeSample();
            Assert.Multiple(() =>
            {
                Assert.That(double.IsNaN(sample), Is.False);
                Assert.That(sample <= max && sample >= min, Is.True);
            });
        }
    }
}
