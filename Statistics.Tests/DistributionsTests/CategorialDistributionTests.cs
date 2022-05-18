using NUnit.Framework;
using Statistics.Distributions;

namespace Statistics.Tests.DistributionsTests
{
    [TestFixture]
    public class CategorialDistributionTests
    {
        /// <summary>
        /// Can create standard categorial distribution instance
        /// </summary>
        [Test]
        public void CanCreateStandardCategorialDistribution()
        {
            CategorialDistribution n = new();
            double[] prob = { 0.5, 0.5 };
            Assert.That(n.Probabilities, Is.EqualTo(prob));
        }
        [Test]
        /// <summary>
        /// Can create categorial distribution instance by number of options
        /// </summary>
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public void CanCreateByNumberCategorialDistribution(int numberOfOptions)
        {
            CategorialDistribution n = new(numberOfOptions);
            Assert.Multiple(() =>
            {
                Assert.That(n.Probabilities, !Is.Null);
                Assert.That(n.Probabilities[0], Is.EqualTo(1.0/numberOfOptions));
            });
        }

    }
}
