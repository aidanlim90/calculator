using Calculator.Abstractions;

namespace Calculator.Interpreters
{
    public class MinusOperation : IOperation
    {
        /// <summary>
        /// Minus the left and right
        /// </summary>
        /// <param name="left">left number in decimal</param>
        /// <param name="right">right number in decimal</param>
        /// <returns>Minus of the left and right</returns>
        public decimal Evaluate(decimal left, decimal right)
        {
            return left - right;
        }
    }
}

