using Calculator.Enums;
using Calculator.Extensions;

namespace Calculator
{
    public class Operator
    {
        /// <summary>
        /// Return the priority of operator
        /// higher number has higher priority
        /// </summary>
        /// <param name="operatorType">Operator</param>
        /// <returns>priority of operator</returns>
        public static int GetPriority(string operatorType) =>
            operatorType.GetOperatorTypeEnumValue() switch
            {
                OperatorType.Plus => 1,
                OperatorType.Minus => 1,
                OperatorType.Multiply => 2,
                OperatorType.Divide => 2,
                _ => -1
            };
    }
}
