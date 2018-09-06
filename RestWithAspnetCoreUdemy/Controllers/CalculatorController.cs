using Microsoft.AspNetCore.Mvc;
using static RestWithAspnetCoreUdemy.Utils.InputValidator;
namespace RestWithAspnetCoreUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET api/values
        [HttpGet("add/{a}/{b}")]
        public IActionResult Add(string a, string b)
        {
            if (!(IsNumeric(a, out var n1) && IsNumeric(b, out var n2))) return BadRequest("invalid input");

            return Ok(n1 + n2);
        }

        [HttpGet("sub/{a}/{b}")]
        public IActionResult Sub(string a, string b)
        {
            if (!(IsNumeric(a, out var n1) && IsNumeric(b, out var n2))) return BadRequest("invalid input");

            return Ok(n1 - n2);
        }

        [HttpGet("div/{a}/{b}")]
        public IActionResult Div(string a, string b)
        {
            if (!(IsNumeric(a, out var n1) && IsNumeric(b, out var n2))) return BadRequest("invalid input");

            if (n1 <= 0 || n2 <= 0) return BadRequest("you can not divide zeros");

            return Ok(n1 / n2);
        }

        [HttpGet("mult/{a}/{b}")]
        public IActionResult Mult(string a, string b)
        {
            if (!(IsNumeric(a, out var n1) && IsNumeric(b, out var n2))) return BadRequest("invalid input");

            return Ok(n1 * n2);
        }
    }
}
