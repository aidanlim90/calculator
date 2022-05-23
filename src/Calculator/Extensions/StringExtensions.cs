using Calculator.Enums;

namespace Calculator.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Convert string to array by token
        /// </summary>
        /// <param name="input">string with token. Eg: A B C with token ' '</param>
        /// <param name="token">Separator to split the string into array</param>
        /// <returns>Array of string that separated by token </returns>
        public static string[] SplitStringToArrayByToken(this string input, char token)
        {
            return input.Split(token);
        }

        /// <summary>
        /// Check string is number
        /// </summary>
        /// <param name="input">string input to be checked whether is number</param>
        /// <param name="number">Result that converted to decimal</param>
        /// <returns>Check string whether is number or not</returns>
        public static bool IsNumber(this string input, out decimal number)
        {
            return decimal.TryParse(input, out number);
        }
        
        /// <summary>
        /// Convert string to number
        /// </summary>
        /// <param name="input">number in string</param>
        /// <returns>number</returns>
        public static decimal ToNumber(this string input)
        {
            return Convert.ToDecimal(input);
        }

        /// <summary>
        /// Get operation type enum value from string
        /// </summary>
        /// <param name="operatorType">String operator type</param>
        /// <returns>Value of enum</returns>
        public static OperatorType GetOperatorTypeEnumValue(this string operatorType) =>
            operatorType switch
            {
                "+" => OperatorType.Plus,
                "-" => OperatorType.Minus,
                "*" => OperatorType.Multiply,
                "/" => OperatorType.Divide,
                _ => OperatorType.None
            };
    }
}
