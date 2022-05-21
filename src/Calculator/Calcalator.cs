using Calculator.Abstractions;
using Calculator.Interpreters;
using Calculator.Strategies;

namespace Calculator
{
    public class Calculator
    {
        //Solution for calculator interview question
        public static double Calculate(string sum)
        {
            IParserStrategy infixToPostfixParserStrategy = new InfixToPostfixParserStrategy();
            IInterpreter sut = new StackMathInterpreter(infixToPostfixParserStrategy);

            var result = sut.Evaluate(sum); //use decimal than double for accurate answer to avoid wrong decimal problem due to 64 bit

            return (double)result;

        }
    }
}
