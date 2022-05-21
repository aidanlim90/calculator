using Calculator.Abstractions;

namespace Calculator.Interpreters
{
    internal class DivideOperation : IOperation
    {
        /// <summary>
        /// Divide the left and right
        /// </summary>
        /// <param name="left">left number in decimal</param>
        /// <param name="right">right number in decimal</param>
        /// <returns>Divide the left and right</returns>
        public decimal Evaluate(decimal left, decimal right)
        {
            return left / right;
        }
    }
}
