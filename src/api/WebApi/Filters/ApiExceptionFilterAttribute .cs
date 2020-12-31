using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Exceptions;
using Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
  public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
  {
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public ApiExceptionFilterAttribute()
    {
      // Register known exception types and handlers.
      _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
      {
        {typeof(ValidationException), HandleValidationException},
        {typeof(NotFoundException), HandleNotFoundException},
      };
    }

    public override void OnException(ExceptionContext context)
    {
      HandleException(context);

      base.OnException(context);
    }

    private void HandleException(ExceptionContext context)
    {
      Type type = context.Exception.GetType();
      if (_exceptionHandlers.ContainsKey(type))
      {
        _exceptionHandlers[type].Invoke(context);
        return;
      }

      if (!context.ModelState.IsValid)
      {
        HandleInvalidModelStateException(context);
        return;
      }

      HandleUnknownException(context);
    }

    private void HandleUnknownException(ExceptionContext context)
    {
      var response = Response.Fail(
        "An error occurred while processing your request."
        , "Internal server error");

      context.Result = new ObjectResult(response)
      {
        StatusCode = StatusCodes.Status500InternalServerError
      };

      context.ExceptionHandled = true;
    }

    private void HandleValidationException(ExceptionContext context)
    {
      var exception = context.Exception as ValidationException;

      var errors = exception.Errors.SelectMany(err => err.Value);

      var response = Response.Fail(
        "Validation error",
        errors);

      context.Result = new BadRequestObjectResult(response);

      context.ExceptionHandled = true;
    }

    private void HandleInvalidModelStateException(ExceptionContext context)
    {
      var response = Response.Fail(
        string.Empty,
        "Invalid model state");

      context.Result = new BadRequestObjectResult(response);

      context.ExceptionHandled = true;
    }

    private void HandleNotFoundException(ExceptionContext context)
    {
      var exception = context.Exception as NotFoundException;

      var response = Response.Fail(
        "The specified resource was not found.",
        exception.Message);

      context.Result = new NotFoundObjectResult(response);

      context.ExceptionHandled = true;
    }
  }
}