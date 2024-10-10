using Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{
    protected static IActionResult HandleFailure(Result result)
    {
        throw new NotImplementedException();
    }

    private static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        Error error) =>
        new()
        {
            Title = title,
            Type = error.Key,
            Detail = error.Message,
            Status = status
        };
}
