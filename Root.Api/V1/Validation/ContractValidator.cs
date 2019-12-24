using Contracts;
using FluentValidation;

namespace Root.Api.V1.Validation
{
    public class ContractValidator : AbstractValidator<Request>
    {
        public ContractValidator()
        {
            RuleFor(r => r)
                .NotNull();
        }
    }
}
