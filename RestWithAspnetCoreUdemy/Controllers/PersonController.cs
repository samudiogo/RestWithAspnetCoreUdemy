using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestWithAspnetCoreUdemy.Model;
using RestWithAspnetCoreUdemy.Services;

namespace RestWithAspnetCoreUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/Person
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var person = _personService.FindByid(id);
            if (person == null) return BadRequest("usuário não encontrado");
            return Ok(person);
        }

        // POST: api/Person
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest("invalid object");

            return new OkObjectResult(_personService.Create(person));
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest("invalid object");

            return new OkObjectResult(_personService.Update(person));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
