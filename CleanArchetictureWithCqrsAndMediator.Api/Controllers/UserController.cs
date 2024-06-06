using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Commands.CreateBlog;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Commands.DeleteBlog;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Commands.UpdateBlog;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogBy;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogs;
using CleanArchetictureWithCqrsAndMediator.Application.Users.Commands.CreateUser;
using CleanArchetictureWithCqrsAndMediator.Application.Users.Commands.DeleteUser;
using CleanArchetictureWithCqrsAndMediator.Application.Users.Commands.UpdateUser;
using CleanArchetictureWithCqrsAndMediator.Application.Users.Queries.GetAllUsers;
using CleanArchetictureWithCqrsAndMediator.Application.Users.Queries.GetUserById;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchetictureWithCqrsAndMediator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiBaseController
    {
        [HttpGet("All_Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await Mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await Mediator.Send(new GetUserByIdQuery() {  UserId = id });
            return Ok(result);
        }

        [HttpPost("CreateNewUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommand user)
        {
            var createUser = await Mediator.Send(user);
            if (createUser == null)
            {
                return BadRequest("this Role Not Found");
            }
            var result = CreatedAtAction(nameof(GetUserById), new { id = createUser.Id }, createUser);
            return Ok(result);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel updateUserCommand, int id)
        {
            //if (id != blog.Id)
            //{
            //    return BadRequest();
            //}
            var user = new UpdateUserCommand()
            {
                Id = id,
                Email = updateUserCommand.Email,
                Password = updateUserCommand.Password,
                UserName = updateUserCommand.UserName,
                Role = new Role { Name = updateUserCommand.RoleName } 
            };
            var result = await Mediator.Send(user);
            if (result == 0)
            {
                return NotFound("this Role Not Found");
            }
            return Ok("updated Successfully");
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await Mediator.Send(new DeleteUserCommand() { UserId = id });
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok("Deleted Successfully");
        }
    }
}
