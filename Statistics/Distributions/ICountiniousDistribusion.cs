namespace Statistics.Distributions
{
    /// <summary>
    /// Countinious Probability Distribution.
    /// </summary>
    public interface ICountiniousDistribusion : IDistribution
    {
        /// <summary>
        /// Gets the mode of the distribution.
        /// </summary>
        double Mode { get; }
        /// <summary>
        /// Gets the smallest element which can be maked
        /// </summary>
        double Minimum { get; }
        /// <summary>
        /// Gets the largest element which can be maked
        /// </summary>
        double Maximum { get; }
        /// <summary>
        /// Computes the probability density of the distribution (PDF)
        /// </summary>
        /// <param name="x">The location at which to compute the density.</param>
        /// <returns>the density at <paramref name="x"/>.</returns>
        double Density(double x);
        /// <summary>
        /// Makes a random sample from the distribution.
        /// </summary>
        /// <returns>a sample from the distribution.</returns>
        double MakeSample();

    }
}
