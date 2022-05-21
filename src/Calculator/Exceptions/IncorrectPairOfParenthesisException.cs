namespace Calculator.Exceptions
{
    public class IncorrectPairOfParenthesisException : Exception
    {
        private const string ErrorMessage = "Incorrect number of openning and clossing parenthesis";
        public IncorrectPairOfParenthesisException() : base(ErrorMessage) { }
        public IncorrectPairOfParenthesisException(string message) : base(message) { }
        public IncorrectPairOfParenthesisException(string message, Exception innerException) : base(message, innerException) { }
    }
}
