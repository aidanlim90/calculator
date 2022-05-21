# Calculator

This repository contains the solution for calculator interview assessment. It is converting **infix to postfix** to make it machine readable then evalute the postfix expression with **stack parser**. Example-PostfixToInfixExample.png and StackParserExample.png in the repository.

# Time Taken
6 hours 10 min.

# Requirement

.net 6

# To check the solution

1. Clone the repo.
2. Open solution.
3. Open tests->Calculator.Tests->Calculator.Tests.cs
4.  Right click->Debug Tests inside `Evaluate_WithInfixStringInput_ReturnsResult` method.

# Design Patterns Used

1. **Strategy pattern** - to allow selecting the strategy for converting the infix string. Eg infix to postfix string .
2. **Interpreter pattern** - to allow evaluating the  expression in postfix format. 

# Nuget Package Used In Tests
1. xunit
2. fluent assertion 





