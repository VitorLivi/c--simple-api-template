using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> logger = logger;

    async public ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        var traceId = httpContext.TraceIdentifier;
        logger.LogError(
            exception,
            "An unhandled exception has occurred with traceId: {traceId}",
            traceId);

        var statusCode = StatusCodes.Status500InternalServerError;
        var title = "Internal Server Error";

        System.Diagnostics.Debug.WriteLine(exception.Message);

        if (exception is HttpRequestException httpException)
        {

            if (httpException.StatusCode != null)
            {
                statusCode = (int)httpException.StatusCode;
            }

            title = httpException.Message;
        }
        else
        {
            var map = MapException(exception);
            statusCode = map.StatusCode;
            title = map.Title;
        }

        await Results.Problem(
            title: title,
            statusCode: statusCode,
            extensions: new Dictionary<string, object?>
            {
              {"traceId", traceId}
            }
        ).ExecuteAsync(httpContext);

        return true;
    }

    private static (int StatusCode, string Title) MapException(Exception exception)
    {
        return exception switch
        {
            _ => (StatusCodes.Status500InternalServerError, "Internal Server Error"),
        };
    }
}
