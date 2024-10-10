using MediatR;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Project.Domain.Notifications
{
    public abstract class Command<T> : IRequest<T>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }
        public string IdCorrelation { get; set; }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
        protected Command()
        {
            ValidationResult = new ValidationResult();
            Timestamp = DateTime.Now;
            IdCorrelation = string.Empty;
        }
    }
}
