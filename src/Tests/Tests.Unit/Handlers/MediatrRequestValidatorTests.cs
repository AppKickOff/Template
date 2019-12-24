using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using Root.Handlers;
using Xunit;

namespace Tests.Unit.Handlers
{
    public class MediatrRequestValidatorTests
    {
        readonly CancellationToken token = CancellationToken.None;
        readonly MediatrRequestValidator<object> validator = Substitute.ForPartsOf<MediatrRequestValidator<object>>();

        [Fact]
        public async Task Process_CallsValidation()
        {
            await validator.Process(new object(), token);

            await validator.ReceivedWithAnyArgs(1).ValidateAsync(default(ValidationContext) !, token);
        }

        [Fact]
        public async Task Process_ThrowsIfInvalid()
        {
            validator.RuleFor(s => s)
                .Must(o => false);

            await FluentActions.Invoking(() => validator.Process(new object(), token))
                .Should().ThrowAsync<ValidationException>();
        }
    }
}
