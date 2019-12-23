using System;
using System.Threading.Tasks;
using Contracts;

namespace Root.Api.Services
{
    public class HomeService : Service.ServiceBase
    {
        public override Task<Response> Method(Request request, Grpc.Core.ServerCallContext context)
        {
            throw new NotImplementedException();
        }
    }
}