using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Root.Handlers.V1.Hello
{
    public class HelloValidator : IPipelineBehavior<HelloCommand, HelloResult>
    {
        public Task<HelloResult> Handle(HelloCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<HelloResult> next)
        {
            throw new System.NotImplementedException();
        }
    }
}