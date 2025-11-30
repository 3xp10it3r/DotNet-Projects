
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class ErrorHandlingController : ControllerBase
{
    [HttpGet("division")]

    public IActionResult GetDivision(int numerator, int denominator)
    {
        try
        {
            int result = numerator / denominator;
            return Ok(result);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Division by zero attempted.");
            return BadRequest("Denominator cannot be zero.");
        }
    }
}