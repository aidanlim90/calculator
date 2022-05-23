using Calculator.Enums;
using Calculator.Extensions;
using Calculator.Interpreters;

namespace Calculator
{
    public class Operator
    {
        public Operator(
            Func<decimal, decimal, decimal> operation, 
            OperatorType operatorType)
        {
            Operation = operation;
            OperatorType = operatorType;
        }

        public Func<decimal, decimal, decimal> Operation { get; }

        public OperatorType OperatorType { get; }

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

        /// <summary>
        /// Return dictionary of operator
        /// </summary>
        /// <returns></returns>
        public static Dictionary<OperatorType, Func<decimal, decimal, decimal>> GetOperationDictionary() =>
            new()
            {
                {
                    OperatorType.Plus, 
                    (left, right) => new AddOperation().Evaluate(left, right)
                },
                {
                    OperatorType.Minus,
                    (left, right) => new MinusOperation().Evaluate(left, right)
                },
                {
                    OperatorType.Multiply,
                    (left, right) => new MultiplyOperation().Evaluate(left, right)
                },
                {
                    OperatorType.Divide,
                    (left, right) => new DivideOperation().Evaluate(left, right)
                }
            };
    }
}
