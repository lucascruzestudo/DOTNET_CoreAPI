using FluentValidation.Results;

namespace Project.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public IEnumerable<string> Errors { get; }

    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = [];
    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures.Select(f => f.ErrorMessage);
    }
}
