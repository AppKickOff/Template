using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Root.Handlers.V1.Hello
{
    public class HelloHandler : IRequestHandler<HelloCommand, HelloResult>
    {
        public Task<HelloResult> Handle(HelloCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
