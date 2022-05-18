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
        
    }
}
