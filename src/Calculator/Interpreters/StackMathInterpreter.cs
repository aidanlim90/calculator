using Calculator.Abstractions;
using Calculator.Constants;
using Calculator.Enums;
using Calculator.Strategies;
using Calculator.Extensions;

namespace Calculator.Interpreters
{
    public class StackMathInterpreter : IInterpreter
    {
        private readonly IParserStrategy _strategy;

        /// <summary>
        /// Constructor of StackMathInterpreter
        /// </summary>
        /// <param name="strategy">Choose to strategy to convert infix string. Eg infix to postfix</param>
        public StackMathInterpreter(IParserStrategy strategy)
        {
            _strategy = strategy;
        }

        /// <summary>
        /// Evaluate the infix string expression
        /// </summary>
        /// <returns>Calculated value of infix string</returns>
        public decimal Evaluate(string infixString)
        {
            string machineReadableString = _strategy.Convert(infixString);
            var tokens = machineReadableString.SplitStringToArrayByToken(TokenConstants.SpaceSeparator);
            Stack<decimal> result = new Stack<decimal>();
            decimal left, right;
            if (_strategy is InfixToPostfixParserStrategy)
            {
                foreach (string token in tokens)
                {
                    switch (token.GetOperatorTypeEnumValue())
                    {
                        case OperatorType.Plus:
                            right = result.Pop();
                            left = result.Pop();
                            result.Push(new AddOperation()
                                .Evaluate(left, right));
                            break;
                        case OperatorType.Minus:
                            right = result.Pop();
                            left = result.Pop();
                            result.Push(new MinusOperation()
                                .Evaluate(left, right));
                            break;
                        case OperatorType.Divide:
                            right = result.Pop();
                            left = result.Pop();
                            result.Push(new DivideOperation()
                                .Evaluate(left, right));
                            break;
                        case OperatorType.Multiply:
                            right = result.Pop();
                            left = result.Pop();
                            result.Push(new MultiplyOperation()
                                .Evaluate(left, right));
                            break;
                        default:
                            result.Push(token.ToNumber());
                            break;
                    }
                }
            }

            return result.Pop();
        }
    }
}
