namespace Clinic.Api.Controllers;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Base controller with common functionality
/// </summary>
[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    /// <summary>
    /// Returns a 200 OK response with data
    /// </summary>
    protected IActionResult OkResponse<T>(T data, string message = "Success")
    {
        return Ok(new { success = true, message, data });
    }

    /// <summary>
    /// Returns a 400 Bad Request response
    /// </summary>
    protected IActionResult BadRequestResponse(string message)
    {
        return BadRequest(new { success = false, message });
    }

    /// <summary>
    /// Returns a 404 Not Found response
    /// </summary>
    protected IActionResult NotFoundResponse(string message)
    {
        return NotFound(new { success = false, message });
    }

    /// <summary>
    /// Returns a 201 Created response
    /// </summary>
    protected IActionResult CreatedResponse<T>(string location, T data, string message = "Created")
    {
        return Created(location, new { success = true, message, data });
    }
}