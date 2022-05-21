namespace Calculator.Abstractions
{
    public interface IInterpreter
    {
        /// <summary>
        /// Evaluate the inflix string expression
        /// </summary>
        /// <param name="infixString">inflix string with space separator</param>
        /// <returns>Calculated value based on the expression</returns>
        decimal Evaluate(string infixString);
    }
}
