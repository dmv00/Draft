using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace Application.Common.Behaviours
{
  class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
  {
    private readonly Stopwatch _timer;

    public PerformanceBehaviour()
    {
      _timer = new Stopwatch();
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
       RequestHandlerDelegate<TResponse> next)
    {
      _timer.Start();

      var response = await next();

      _timer.Stop();

      var elapsedMilliseconds = _timer.ElapsedMilliseconds;

      if (elapsedMilliseconds > 500)
      {
        var requestName = typeof(TRequest).Name;


        Log.Warning("Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
           requestName, elapsedMilliseconds, request);
      }

      return response;
    }
  }
}