using Microsoft.AspNetCore.Mvc;
using WebApi.Logic.DTO;
using WebApi.Logic.Services;
using WebApplication1.DTO;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController(TeacherService teacherService) : ControllerBase
    {
        [HttpGet]   
        public IActionResult GetAll([FromQuery] int? limit, int? offset)
        {
            var teachers = teacherService.GetAllTeachers(limit, offset);
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var teacher = teacherService.GetById(id);
            return Ok(teacher);

        }

        [HttpPost]
        public IActionResult Create([FromBody] TeacherCreateDto teacherCreateDto)
        {
            var teacher = teacherService.Create(teacherCreateDto);
            return Ok(teacher);
           
        }

        [HttpPut]
        public IActionResult Update([FromBody] TeacherReadDto teacherUpdateDto)
        {
            var teacher = teacherService.Update(teacherUpdateDto);
            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            teacherService.Delete(id);
            return NoContent();
        }




    }
}
