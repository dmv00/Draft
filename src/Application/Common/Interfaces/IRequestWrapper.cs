using Application.Common.Models;
using MediatR;

namespace Application.Common.Interfaces
{
   public interface IRequestWrapper<T> : IRequest<Response<T>>
   {
   }
   public interface IHandlerWrapper<in TIn, TOut> : IRequestHandler<TIn, Response<TOut>>
      where TIn : IRequestWrapper<TOut>
   {
   }
}