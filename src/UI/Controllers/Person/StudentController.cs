using DomainService.Interface;
using DomainService.Request;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/Person/Student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _IStudent;

        public StudentController(IStudent IStudent)
        {
            _IStudent = IStudent;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StudentRequest request)
        {
            try
            {
                await _IStudent.Create(request);
                return Ok();
            }
            catch (NotImplementedException execeptionStudent)
            {
                switch (execeptionStudent.Message)
                {
                    case "Pessoa não existe":
                        return NotFound(execeptionStudent.Message);
                    case "Estudante já existe":
                        return BadRequest(execeptionStudent.Message);
                    default:
                        return BadRequest();
                }
            }
        }
    }
}
