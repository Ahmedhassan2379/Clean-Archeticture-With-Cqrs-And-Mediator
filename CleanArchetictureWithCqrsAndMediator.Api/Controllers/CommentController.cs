using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogBy;
using CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.CreateComment;
using CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.DeleteComment;
using CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.UpdateComment;
using CleanArchetictureWithCqrsAndMediator.Application.Comments.Queries.GetAllComments;
using CleanArchetictureWithCqrsAndMediator.Application.Comments.Queries.GetCommentByBlog;
using CleanArchetictureWithCqrsAndMediator.Application.Comments.Queries.GetCommentById;
using CleanArchetictureWithCqrsAndMediator.Application.Comments.Queries.GetCommentByUser;
using CleanArchetictureWithCqrsAndMediator.Application.Users.Commands.DeleteUser;
using CleanArchetictureWithCqrsAndMediator.Application.Users.Commands.UpdateUser;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace CleanArchetictureWithCqrsAndMediator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ApiBaseController
    {

        [HttpGet("All_Comments")]
        public async Task<IActionResult> GetAllComments()
        {
            var result = await Mediator.Send(new GetAllCommentsQuery());
            return Ok(result);
        }

        [HttpGet("Comment_By_Id/{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var result = await Mediator.Send(new GetCommentByIdQuery() { commentId = id });
            return Ok(result);
        }

        [HttpGet("Comment_By_User/{name}")]
        public async Task<IActionResult> GetCommentByUser(string name)
        {
            var result = await Mediator.Send(new GetCommentByUserQuery() { UserName = name});
            return Ok(result);
        }

        [HttpGet("Comment_By_Blog/{name}")]
        public async Task<IActionResult> GetCommentByBlog(string name)
        {
            var result = await Mediator.Send(new GetCommentByBlogQuery() { BlogName = name });
            return Ok(result);
        }

        [HttpPost("Create_New_Comment")]
        public async Task<IActionResult> CreateComment(CreateCommentCommand comment)
        {
            var createdComment = await Mediator.Send(comment);
            var result = CreatedAtAction(nameof(GetComment), new { id = createdComment.Id }, createdComment);
            return Ok(result);
        }

        [HttpPut("Update_Comment/{id}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentVM Updatedcomment,int id)
        {
            var comment = new UpdateCommentCommand()
            {
                Id = id,
                Content = Updatedcomment.Content,
                CreatedDate = Updatedcomment.CreatedDate,
                UpdatedDate = Updatedcomment.UpdatedDate,
                Blog = new Blog { Name = Updatedcomment.BlogName },
                User = new User { UserName = Updatedcomment.UserName }
            };
            var result = await Mediator.Send(comment);
            if (result == 0)
            {
                return NotFound("this User Or Blog Not Found");
            }
            return Ok("updated Successfully");
        }

        [HttpDelete("Delete_Comment/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var result = await Mediator.Send(new DeleteCommentCommand() { CommentId = id });
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok("Deleted Successfully");
        }
    }
}
