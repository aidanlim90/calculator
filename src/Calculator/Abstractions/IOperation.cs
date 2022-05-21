using Calculator.Interpreters;

namespace Calculator.Abstractions
{
    public interface IOperation
    {
        /// <summary>
        /// Calculate the value left with right
        /// </summary>
        /// <param name="left">decimal value</param>
        /// <param name="right">decimal value</param>
        /// <returns>Calculated value of left and right</returns>
        decimal Evaluate(decimal left, decimal right);
    }
}
