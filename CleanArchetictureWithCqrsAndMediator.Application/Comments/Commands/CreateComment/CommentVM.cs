using CleanArchetictureWithCqrsAndMediator.Application.Common.Mappings;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.CreateComment
{
    public class CommentVM : IMapForm<Comment>
    {
        public int Id { get; set; }
        public  string BlogName { get; set; }
        public  string UserName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
