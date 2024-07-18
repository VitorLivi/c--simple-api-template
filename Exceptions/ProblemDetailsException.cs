using Microsoft.AspNetCore.Mvc;

namespace SimpleApi.Exceptions
{
    public class ProblemDetailsException : HttpRequestException
    {
        public ValidationProblemDetails ProblemDetails { get; }

        public ProblemDetailsException(
            string message,
            System.Net.HttpStatusCode statusCode,
            ValidationProblemDetails ProblemDetails
        ) : base(message, statusCode)
        {
            this.ProblemDetails = problemDetails;
        }
    }
}
