using ClothesStrore.Application.Common.Exceptions;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net;
using System.Security.Policy;
using System.Text.Json;

namespace ClothesStore.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        public ILogger _logger { get; }

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public void GetBody(out ProblemDetails problemDetails, HttpStatusCode statusCode, string type, string title, string details)
        {
            problemDetails = new()
            {
                Status = (int)statusCode,
                Type = type,
                Title = title,
                Detail = details
            };
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ProblemDetails problem = new();
                switch (ex)
                {
                    case NotFoundException notFoundEx:
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        GetBody(out problem, HttpStatusCode.NotFound, "Server Error", "Not Found Exception", ex.Message.ToString());
                        break;
                    case InternalServerError internalServer:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        GetBody(out problem, HttpStatusCode.InternalServerError, "Server Error", "An internal server error has occured", ex.Message.ToString());
                        break;
                    case ConflictException conflictException:
                        context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                        GetBody(out problem, HttpStatusCode.Conflict, "Server Error", "Conflict Error", ex.Message.ToString());
                        break;
                    case BadRequestException badRequestException:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        GetBody(out problem, HttpStatusCode.BadRequest, "Server Error", "Bad Request", ex.Message.ToString());
                        break;
                    case DuplicateEntryException duplicateEntryException:
                        context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        GetBody(out problem, HttpStatusCode.UnprocessableEntity, "Server Error", "Dublicate Entity", ex.Message.ToString());
                        break;
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        GetBody(out problem, HttpStatusCode.InternalServerError, "Server Error", "An internal server error has occured", ex.Message.ToString());
                        break;
                }
                string json = JsonSerializer.Serialize(problem);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
        }
    }
}
