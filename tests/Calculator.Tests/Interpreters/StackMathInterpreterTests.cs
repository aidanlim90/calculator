using System;
using Calculator.Abstractions;
using Calculator.Exceptions;
using Calculator.Interpreters;
using Calculator.Strategies;
using FluentAssertions;
using Xunit;

namespace Calculator.Tests.Interpreters
{
    public class StackMathInterpreterTests
    {
        [Theory]
        [InlineData("1 + 1", 2)]
        [InlineData("2 * 2", 4)]
        [InlineData("1 + 2 + 3", 6)]
        [InlineData("6 / 2", 3)]
        [InlineData("11 + 23", 34)]
        [InlineData("11.1 + 23", 34.1)]
        [InlineData("1 + 1 * 3", 4)]
        [InlineData("( 11.5 + 15.4 ) + 10.1", 37)]
        [InlineData("23 - ( 29.3 - 12.5 )", 6.2)]
        [InlineData("( 1 / 2 ) - 1 + 1", 0.5)]
        [InlineData("10 - ( 2 + 3 * ( 7 - 5 ) )", 2)]
        public void Evaluate_WithInfixStringInput_ReturnsResult(string infixString, decimal expectedResult)
        {
            //Arrange
            IParserStrategy infixToPostfixParserStrategy = new InfixToPostfixParserStrategy();
            IInterpreter sut = new StackMathInterpreter(infixToPostfixParserStrategy);

            //Act
            var result = sut.Evaluate(infixString);

            //Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("7 @ 5 ")]
        [InlineData("7 # 5 ")]
        public void Evaluate_IncorrectOperator_ThrowInvalidOperatorTypeException(string infixString)
        {
            //Arrange
            IParserStrategy infixToPostfixParserStrategy = new InfixToPostfixParserStrategy();
            IInterpreter sut = new StackMathInterpreter(infixToPostfixParserStrategy);

            //Act
            Action act = () => sut.Evaluate(infixString);

            //Assert
            act.Should().Throw<InvalidOperatorTypeException>();
        }
    }
}
