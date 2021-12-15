using NorthWind.Entities.Interfaces.Validation;

namespace NorthWind.Entities.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<IFailure> Failures { get; } = null!;
        public ValidationException() { }
        public ValidationException(string message) : base(message) { }
        public ValidationException(string message, Exception inner) : base(message, inner) { }
        public ValidationException(IEnumerable<IFailure> failures) => Failures = failures;
    }
}
