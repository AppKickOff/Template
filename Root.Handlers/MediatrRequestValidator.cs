using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR.Pipeline;

namespace Root.Handlers.V1.InsertEvent
{
    public abstract class MediatrRequestValidator<T> : AbstractValidator<T>, IRequestPreProcessor<T>
    {
        public MediatrRequestValidator()
        {
            ConfigureValidation();
        }

        protected abstract void ConfigureValidation();        

        public Task Process(T request, CancellationToken cancellationToken)
        {
            return ValidateAsync(request, cancellationToken);
        }
    }
}