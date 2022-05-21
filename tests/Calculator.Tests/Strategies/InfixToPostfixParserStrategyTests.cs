using System;
using Calculator.Abstractions;
using Calculator.Exceptions;
using Calculator.Strategies;
using FluentAssertions;
using Xunit;

namespace Calculator.Tests.Strategies
{
    public class InfixToPostfixParserStrategyTests
    {
        [Theory]
        [InlineData("1 + 1", "1 1 +")]
        [InlineData("2 * 2", "2 2 *")]
        [InlineData("1 + 2 + 3", "1 2 + 3 +")]
        [InlineData("6 / 2", "6 2 /")]
        [InlineData("11 + 23", "11 23 +")]
        [InlineData("11.1 + 23", "11.1 23 +")]
        [InlineData("1 + 1 * 3", "1 1 3 * +")]
        [InlineData("( 11.5 + 15.4 ) + 10.1", "11.5 15.4 + 10.1 +")]
        [InlineData("23 - ( 29.3 - 12.5 )", "23 29.3 12.5 - -")]
        [InlineData("( 1 / 2 ) - 1 + 1", "1 2 / 1 - 1 +")]
        [InlineData("10 - ( 2 + 3 * ( 7 - 5 ) )", "10 2 3 7 5 - * + -")]
        public void Convert_WithInfixStringInput_ReturnsPostfixString(string infixString, string expectedResult)
        {
            //Arrange
            IParserStrategy sut = new InfixToPostfixParserStrategy();

            //Act
            var result = sut.Convert(infixString);

            //Assert
            result.Should().Be(expectedResult);
        }


        [Theory]
        [InlineData("10 - 2 + 3 * ( 7 - 5 ) )")]
        [InlineData("( 1 + 2 ) )")]
        [InlineData("( ( ( 1 + 2 ) )")]
        public void Convert_IncorrectPairOfParenthesis_ThrowIncorrectPairOfParenthesisException(string infixString)
        {
            //Arrange
            IParserStrategy sut = new InfixToPostfixParserStrategy();

            //Act
            Action act = () => sut.Convert(infixString);

            //Assert
            act.Should().Throw<IncorrectPairOfParenthesisException>();
        }
    }
}
