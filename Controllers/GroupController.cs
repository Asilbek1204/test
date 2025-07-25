using Microsoft.AspNetCore.Mvc;
using WebApi.Logic.DTO;
using WebApplication1.DTO;
using WebApplication1.Services;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController(GroupService groupService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll([FromQuery] int? limit, int? offset)
        {
            var groups = groupService.GetAllGroups(limit, offset);
            return Ok(groups);
        }


        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var group = groupService.GetById(id);
            return Ok(group);

        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody] GroupCreateDto groupCreateDto)
        {
            var group = groupService.Create(groupCreateDto);
            return Ok(group);
        }

        [HttpPut]
        public IActionResult UpdateGroup([FromBody] GroupReadDto groupUpdateDto)
        {
            var group = groupService.Update(groupUpdateDto);
            return Ok(group);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGroup([FromRoute] int id)
        {
            groupService.Delete(id);
            return NoContent();
        }
        
    } 
}

