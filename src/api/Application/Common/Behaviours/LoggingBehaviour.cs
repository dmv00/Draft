using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace Application.Common.Behaviours
{
   public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
   {

      public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
       RequestHandlerDelegate<TResponse> next)
      {
         var requestName = typeof(TRequest).Name;

         Log.Information("Request: {Name}  {@Request}",
             requestName, request);

         return await next();
      }
   }
}