using Calculator.Enums;
using Calculator.Exceptions;

namespace Calculator.Extensions
{
    public static class OperatorTypeExtensions
    {
        /// <summary>
        /// Get string value from operator type enum
        /// </summary>
        /// <param name="operatorType">Enum</param>
        /// <returns>string value of operator type enum</returns>
        public static string GetString(this OperatorType operatorType) =>
            operatorType switch
            {
                OperatorType.Plus => "+",
                OperatorType.Minus => "-",
                OperatorType.Multiply => "*",
                OperatorType.Divide => "/",
                OperatorType.LeftParenthesis => "(",
                OperatorType.RightParenthesis => ")",
                _ => throw new InvalidOperatorTypeException()
            };
    }
}
