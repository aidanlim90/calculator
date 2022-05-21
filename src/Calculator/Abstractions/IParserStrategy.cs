namespace Calculator.Abstractions
{
    /// <summary>
    /// interface for parser strategy
    /// </summary>
    public interface IParserStrategy
    {
        /// <summary>
        /// Convert the input to expected result
        /// </summary>
        /// <param name="expression">Expression string that need to be converted to specific format</param>
        /// <returns>Output as string based on the strategy selected</returns>
        string Convert(string expression);
    }
}
