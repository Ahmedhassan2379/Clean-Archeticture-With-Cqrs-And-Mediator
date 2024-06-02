using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Commands.CreateBlog;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Commands.DeleteBlog;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Commands.UpdateBlog;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogBy;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogs;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchetictureWithCqrsAndMediator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            var result = await Mediator.Send(new GetAllBlogsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var result = await Mediator.Send(new GetBlogByIdQuer() { blogId=id});
            return Ok(result);
        }

        [HttpPost("CreateNewBlog")]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand blog)
        {
            var createdBlod = await Mediator.Send(blog);
            var result =  CreatedAtAction(nameof(GetBlogById), new { id = createdBlod.Id }, createdBlod);
            return Ok(result);
        }

        [HttpPut("UpdateBlog/{id}")]
        public async Task<IActionResult> UpdateBlog(UpdateViewModel updateBlogCommand, int id)
        {
            //if (id != blog.Id)
            //{
            //    return BadRequest();
            //}
            var blog = new UpdateBlogCommand()
            {
                Id = id,
                Author = updateBlogCommand.Author,
                Description = updateBlogCommand.Description,
                Name = updateBlogCommand.Name
            };
            var result = await Mediator.Send(blog);
            if (result == 0)
            {
                return NotFound("this Id Not Found");
            }
            return Ok("updated Successfully");
        }

        [HttpDelete("DeleteBlog/{id}")]
        public async Task<IActionResult> deleteblog(int id)
        {
            var result = await Mediator.Send(new DeleteBlogCommand(){  BlogId=id});
            if(result == 0)
            {
                return BadRequest();
            }
            return Ok("Deleted Successfully");
        }
    }
}
