using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using Root.Handlers;
using NSubstitute;
using Xunit;

namespace Tests.Unit.Handlers
{
    public class MediatrRequestValidatorTests
    {
        readonly CancellationToken token = CancellationToken.None;
        MediatrRequestValidator<object> validator = Substitute.ForPartsOf<MediatrRequestValidator<object>>();

        public MediatrRequestValidatorTests()
        {
            validator.RuleFor(s => s)
                .Must(o => true);
        }

        [Fact]
        public async Task Process_CallsValidation()
        {
            var obj = new object();

            await validator.Process(obj, token);

            await validator.ReceivedWithAnyArgs(1).ValidateAsync(default(ValidationContext)!, token);
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