using Calculator.Enums;
using Calculator.Exceptions;

namespace Calculator.Extensions
{
    public static class SymbolTypeExtensions
    {
        /// <summary>
        /// Get string value from symbol type enum
        /// </summary>
        /// <param name="operatorType">Enum</param>
        /// <returns>string value of symbol type enum</returns>
        public static string GetString(this SymbolType symbolType) =>
            symbolType switch
            {
                SymbolType.LeftParenthesis => "(",
                SymbolType.RightParenthesis => ")",
                _ => throw new InvalidOperatorTypeException()
            };
    }
}
