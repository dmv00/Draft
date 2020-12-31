using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Models
{
  public static class Response
  {
    public static Response<object> Fail(string message, IEnumerable<string> error) =>
      new Response<object>(default, message, error);

    public static Response<object> Fail(string message, string error) =>
      new Response<object>(default, message, error);

    public static Response<T> Ok<T>(T data, string message) =>
      new Response<T>(data, message);

    public static Task<Response<T>> OkFromTask<T>(T data, string message) =>
      Task.FromResult(new Response<T>(data, message));
  }

  public class Response<T>
  {
    private Response()
    {
      Errors = new List<string>();
    }

    public Response(T data, string msg, IEnumerable<string> errors)
      : this()
    {
      Data = data;
      Message = msg;
      Errors.AddRange(errors);
    }

    public Response(T data, string msg, string error = null)
      : this()
    {
      Data = data;
      Message = msg;
      if (error != null) Errors.Add(error);
    }

    public T Data { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; }
  }
}