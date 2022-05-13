namespace Statistics.Distributions
{
    /// <summary>
    /// Discrete Probability Distribution.
    /// </summary>
    public interface IDiscreteDistribution : IDistribution
    {
        /// <summary>
        /// Gets the mode of the distribution.
        /// </summary>
        int Mode { get; }
        /// <summary>
        /// Gets the smallest element in the domain of the distribution.
        /// </summary>
        int Minimum { get; }
        /// <summary>
        /// Gets the largest element in the domain of the distribution.
        /// </summary>
        int Maximum { get; }
        /// <summary>
        /// Computes the probability mass function
        /// </summary>
        /// <param name="x">The location in the domain where we want to evaluate the probability mass function.</param>
        /// <returns>the probability mass at location <paramref name="x"/>.</returns>
        double Probability(int x);
        /// <summary>
        /// Make a random sample from the distribution.
        /// </summary>
        /// <returns>a sample from the distribution.</returns>
        int MakeSample();
    }
}
