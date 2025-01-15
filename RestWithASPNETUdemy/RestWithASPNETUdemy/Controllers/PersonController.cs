using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;
using System.Globalization;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        //[HttpGet("sum/{firstNumber}/{secondNumber}")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindByID(id);
            return Ok(person == null ? NotFound() : person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            return Ok(person == null ? BadRequest() : _personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            return Ok(person == null ? BadRequest() : _personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
             _personService.Delete(id);
            return NoContent();
        }
    }
}