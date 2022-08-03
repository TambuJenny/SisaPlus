using System.ComponentModel.DataAnnotations;
using DomainService.Models.Interface;
using DomainService.Request;
using DomainService.Response;
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
        public async Task<ActionResult> Create([FromBody] PersonRequest request)
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
                        return BadRequest(execeptionPerson);
                }
            }
        }

        [HttpGet("GetbyId")]
        public async Task<ActionResult<PersonResponse>> GetbyId ( [Required][FromHeader(Name ="IdPerson")] Guid IdPerson)
        {
                try
                {
                    var getperson = await _IPerson.GetbyId(IdPerson);
                    return Ok(getperson);
                }
                catch (NotImplementedException execeptionPerson)
                {
                    switch (execeptionPerson.Message)
                    {
                        case "Pessoa não existe":
                            return NotFound(execeptionPerson.Message);
                        default:
                            return BadRequest(execeptionPerson);
                    }
                }
        }

        [HttpPut]
        public async Task<ActionResult> Update ([Required][FromBody] PersonResponse request)
        {
            try
            {
                await _IPerson.Update(request);
                return Ok();
            }
            catch (NotImplementedException execeptionPerson)
            {
                 switch (execeptionPerson.Message)
                    {
                        case "Pessoa não existe":
                            return NotFound(execeptionPerson.Message);
                        default:
                            return BadRequest(execeptionPerson);
                    }
            }
        }

        [HttpDelete("{idPessoa}")]
        public async Task<ActionResult> Delete (Guid idPessoa)
        {
            try
            {
                await _IPerson.Delete(idPessoa);
                return Ok();
            }
            catch (NotImplementedException execeptionPerson)
            {
                 switch (execeptionPerson.Message)
                    {
                        case "Pessoa não existe":
                            return NotFound(execeptionPerson.Message);
                        default:
                            return BadRequest(execeptionPerson);
                    }
            }
        }
    }
}
