using Calculator.Abstractions;
using Calculator.Constants;
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
            var operatorDictionary = Operator.GetOperationDictionary();

            if (_strategy is InfixToPostfixParserStrategy)
            {
                foreach (string token in tokens)
                {
                    var tokenEnumValue = token.GetOperatorTypeEnumValue();
                    
                    if (operatorDictionary.ContainsKey(tokenEnumValue))
                    {
                        var right = result.Pop();
                        var left = result.Pop();
                        result.Push((decimal)operatorDictionary[tokenEnumValue].DynamicInvoke(left, right)!);
                        continue;
                    }
                    
                    result.Push(token.ToNumber());
                }
            }

            return result.Pop();
        }
    }
}
