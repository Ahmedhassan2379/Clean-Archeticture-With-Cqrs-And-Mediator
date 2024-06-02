using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandValidator :AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(v=>v.Name)
                .NotEmpty().WithMessage("Name IS Required")
                .MaximumLength(200).WithMessage("name must not exceed 200 charachters");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description Is Required");

            RuleFor(v => v.Author)
                .NotEmpty().WithMessage("Author Is Required")
                .MaximumLength(50).WithMessage("Author Must Not Exceed 50 Charachter");
        }
    }
}
