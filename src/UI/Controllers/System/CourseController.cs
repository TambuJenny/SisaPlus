using DomainService.Interface;
using DomainService.Request;
using DomainService.Response;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/system/course")]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _ICourse;

        public CourseController(ICourse ICourse)
        {
            _ICourse = ICourse;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CourseRequest request)
        {
            try
            {
                await _ICourse.Create(request);
                return Ok();
            }
            catch (NotImplementedException execeptionCourse)
            {
                switch (execeptionCourse.Message)
                {
                    case "Curso já existe":
                        return BadRequest();
                    default:
                        return BadRequest();
                }
            }
        }

        [HttpGet("[Action]")]
        public async Task<ActionResult<List<CourseResponse>>> GetAll()
        {
            try 
            { 
                return Ok(await _ICourse.GetAll()); 
            }
             catch (NotImplementedException execeptionCourse)
            {
                switch (execeptionCourse.Message)
                {
                    case "Curso não existe":
                        return NotFound(execeptionCourse.Message);
                    default:
                        return BadRequest();
                }
            }
        }

        [HttpDelete("{idCourse}")]
        public async Task<ActionResult> Delete(Guid idCourse)
        {
            try 
            { 
                await _ICourse.Delete(idCourse);
                return Ok(); 
            }
             catch (NotImplementedException execeptionCourse)
            {
                switch (execeptionCourse.Message)
                {
                    case "Curso não existe":
                        return NotFound(execeptionCourse.Message);
                    default:
                        return BadRequest();
                }
            }
        }
    }
}
