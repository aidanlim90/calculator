namespace Calculator.Exceptions
{
    public class InvalidOperatorTypeException : Exception
    {
        private const string ErrorMessage = "Invalid Operator Type";
        public InvalidOperatorTypeException() : base(ErrorMessage) { }
        public InvalidOperatorTypeException(string message) : base(message) { }
        public InvalidOperatorTypeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
