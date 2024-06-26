﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<CommentVM>
    {
        public string BlogName { get; set; }
        public string UserNmae { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
