using DomainService.DTO;
using DomainService.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        private readonly IPerson _IPerson;

        public PersonController(IPerson IPerson)
        {
            _IPerson = IPerson;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PersonDTO request)
        {
            try
            {
                await _IPerson.Create(request);
                return Ok();
            }
            catch (NotImplementedException execeptionPerson)
            {
                switch (execeptionPerson.Message)
                {
                    case "Pessoa já existe":
                        return NotFound(execeptionPerson.Message);
                    default:
                        return BadRequest();
                }
            }
        }
    }
}
