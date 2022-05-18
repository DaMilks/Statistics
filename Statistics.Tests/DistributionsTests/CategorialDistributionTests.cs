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
                Assert.That(n.Probabilities[0], Is.EqualTo(1d / numberOfOptions));
            });
        }
        [Test]
        /// <summary>
        /// Can create categorial distribution instance by array of probabilities
        /// </summary>
        [TestCase(new double[] {0.5, 0.5})]
        [TestCase(new double[] { 0.2, 0.1,0.7 })]
        [TestCase(new double[] { 1d })]
        public void CanCreateByProbabylitiesCategorialDistribution(double[] probabilities)
        {
            CategorialDistribution n = new(probabilities);
            Assert.Multiple(() =>
            {
                Assert.That(n.Probabilities, !Is.Null);
                Assert.That(n.Probabilities, Is.EqualTo(probabilities));
            });
        }
        [Test]
        /// <summary>
        /// Categorial distribution throw exception with invalid array of probabilities
        /// </summary>
        /// <param name="probabilities">array of probabilities of distribution</param>
        [TestCase(new double[] { 0d, 1d })]
        [TestCase(new double[] { -1d, 2d })]
        [TestCase(new double[] { 0.2d, 0.3d })]
        [TestCase(new double[] { 0.7d, 0.6d })]
        public void CategorialDistributionByProbabilitiesInvalid(double[] probabilities)
        {
            Assert.That(() => new CategorialDistribution(probabilities), Throws.ArgumentException);
        }
        [Test]
        /// <summary>
        /// Categorial distribution throw exception with invalid number of options
        /// </summary>
        /// <param name="numberOfOptions">number of options value</param>
        [TestCase(-1)]
        [TestCase(0)]
        public void CategorialDistributionByNumberInvalid(int numberOfOptions)
        {
            Assert.That(() => new CategorialDistribution(numberOfOptions), Throws.ArgumentException);
        }
        [Test]
        /// <summary>
        /// Categorial can make sample test
        /// </summary>
        public void CategorialDistributionMakeSample()
        {
            CategorialDistribution n = new(new double[] {0.5,0.5}, new Random(0));
            Assert.That(n.MakeSample(), Is.InRange(0, 1));
        }
    }
}
