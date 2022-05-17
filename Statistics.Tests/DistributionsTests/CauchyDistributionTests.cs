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
                Assert.That(n.Minimum, Is.EqualTo(0.0));
                Assert.That(n.Maximum, Is.EqualTo(1.0));
            });
        }
    }
}
