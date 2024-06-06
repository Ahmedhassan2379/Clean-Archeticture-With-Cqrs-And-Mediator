using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Commands.CreateBlog;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Commands.DeleteBlog;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Commands.UpdateBlog;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogBy;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogs;
using CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.CreateRole;
using CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.DeleteRole;
using CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.UpdateRole;
using CleanArchetictureWithCqrsAndMediator.Application.Roles.Queries.GetAllRoles;
using CleanArchetictureWithCqrsAndMediator.Application.Roles.Queries.GetRoleById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchetictureWithCqrsAndMediator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ApiBaseController
    {
        [HttpGet("All_Roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await Mediator.Send(new GetAllRolesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var result = await Mediator.Send(new GetRoleByIdQuery() { RoleId = id });
            return Ok(result);
        }

        [HttpPost("CreateNewRole")]
        public async Task<IActionResult> CreateRole(CreateRoleCommand role)
        {
            var createdRole = await Mediator.Send(role);
            var result = CreatedAtAction(nameof(GetRoleById), new { id = createdRole.Id }, createdRole);
            return Ok(result);
        }

        [HttpPut("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleCommand, int id)
        {
            //if (id != blog.Id)
            //{
            //    return BadRequest();
            //}
            var role = new UpdateRoleCommand()
            {
                Id = id,
                Name = updateRoleCommand.Name,
            };
            var result = await Mediator.Send(role);
            if (result == 0)
            {
                return NotFound("this Id Not Found");
            }
            return Ok("updated Successfully");
        }

        [HttpDelete("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await Mediator.Send(new DeleteRoleCommand() { RoleId = id });
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok("Deleted Successfully");
        }
    }
}
