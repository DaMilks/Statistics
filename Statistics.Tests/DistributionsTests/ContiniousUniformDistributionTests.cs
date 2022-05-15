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
    }
}
