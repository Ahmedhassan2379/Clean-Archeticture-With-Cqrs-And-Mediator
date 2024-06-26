﻿using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Blog Blog { get; set; }
        public User User { get; set; }
    }
}
