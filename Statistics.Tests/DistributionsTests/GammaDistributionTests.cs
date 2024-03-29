﻿using NUnit.Framework;
using Statistics.Distributions;

namespace Statistics.Tests.DistributionsTests
{
    [TestFixture]
    public class GammaDistributionTests
    {
        /// <summary>
        /// Can create standard Gamma distribution instance
        /// </summary>
        [Test]
        public void CanCreateStandardGammaDistribution()
        {
            GammaDistribution n = new();
            Assert.Multiple(() =>
            {
                Assert.That(n.Shape, Is.EqualTo(1d));
                Assert.That(n.Scale, Is.EqualTo(1d));
            });
        }
        [Test]
        /// <summary>
        /// Can create Gamma distribution instance
        /// </summary>
        /// <param name="shape">location of distribution.</param>
        /// <param name="scale">scale of distribution.</param>
        [TestCase(1, 1)]
        [TestCase(1.0, 5.0)]
        [TestCase(2, double.PositiveInfinity)]
        public void CanCreateGamma(double shape, double scale)
        {
            GammaDistribution n = new(shape, scale);
            Assert.Multiple(() =>
            {
                Assert.That(n.Shape, Is.EqualTo(shape));
                Assert.That(n.Scale, Is.EqualTo(scale));
            });
        }
        /// <summary>
        /// Gamma distribution throw exception with invalid parameters.
        /// </summary>
        /// <param name="shape">location of distribution value.</param>
        /// <param name="scale">scale of distribution value.</param>
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        public void GammaDistributionInvalidParameters(double shape, double scale)
        {
            Assert.That(() => new GammaDistribution(shape, scale), Throws.ArgumentException);
        }
        /// <summary>
        /// Can make sample of Gamma distribution
        /// </summary>
        [Test]
        public void MakeSampleTest()
        {
            GammaDistribution n = new();
            Assert.That(double.IsNaN(n.MakeSample()), Is.False);
        }
    }
}
