using Calculator.Abstractions;
using Calculator.Constants;
using Calculator.Enums;
using Calculator.Exceptions;
using Calculator.Extensions;

namespace Calculator.Strategies
{
    /// <summary>
    /// Convert infix to postfix. As postfix is machine readable compare to infix which is machine non readable. 
    /// Eg: 1 + 1
    /// Result: 1 1 +
    /// </summary>
    public class InfixToPostfixParserStrategy : IParserStrategy
    {
        public string Convert(string expression)
        {
            var result = String.Empty;
            var stack = new Stack<string>();
            var tokens = expression.SplitStringToArrayByToken(TokenConstants.SpaceSeparator);

            foreach (var token in tokens)
            {
                if (token.IsNumber(out var number))
                {
                    result += string.IsNullOrEmpty(result) ? number : $" {number}"; //ensure do not have any space for the first number assign to result
                    continue;
                }
                
                if (token.Equals(SymbolType.LeftParenthesis.GetString()))
                {
                    stack.Push(token);
                    continue;
                }
       
                if (token.Equals(SymbolType.RightParenthesis.GetString()))
                {
                    result = AddOperatorFromStackToResultUntilLeftParenthesis(stack, result);
                    continue;
                }

                result = AddOperatorToResultFromStackIfLowerOrEqualPriorityThanTopOfStack(stack, token, result);
                stack.Push(token); //add to stack if higher priority
            }

            result = AddRemainOperatorFromStackToResult(stack, result);

            return result;
        }

        private static string AddRemainOperatorFromStackToResult(Stack<string> stack, string result)
        {
            while (stack.Count > 0)
            {
                if (stack.Peek().Equals(SymbolType.LeftParenthesis.GetString()))
                {
                    throw new IncorrectPairOfParenthesisException();
                }

                result += $" {stack.Pop()}";
            }

            return result;
        }

        private static string AddOperatorToResultFromStackIfLowerOrEqualPriorityThanTopOfStack(
            Stack<string> stack, 
            string token,
            string result)
        {
            while (stack.Count > 0 
                   && Operator.GetPriority(token) <= Operator.GetPriority(stack.Peek()))
            {
                result += $" {stack.Pop()}";
            }

            return result;
        }

        private static string AddOperatorFromStackToResultUntilLeftParenthesis(
            Stack<string> stack, 
            string result)
        {
            while (stack.Count > 0 
                   && !stack.Peek().Equals(SymbolType.LeftParenthesis.GetString()))
            {
                result += $" {stack.Pop()}";
            }

            //check incorrect pair of parenthesis eg. (()))) which is invalid
            //count must more than one as still exist left parenthesis
            if (stack.Count == 0 || !stack.Peek().Equals(SymbolType.LeftParenthesis.GetString()))
            {
                throw new IncorrectPairOfParenthesisException();
            }

            stack.Pop(); //remove left parenthesis

            return result;
        }
    }
}
