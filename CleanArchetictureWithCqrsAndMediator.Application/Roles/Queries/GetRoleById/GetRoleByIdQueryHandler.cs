using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogBy;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogs;
using CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.CreateRole;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery,RoleVM>
    {
        private readonly IMapper _mapper;
        private readonly IRolesRepository _repository;
        public GetRoleByIdQueryHandler(IRolesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<RoleVM> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetRoleById(request.RoleId);
            var result = _mapper.Map<RoleVM>(role);
            return result;
        }
    }
}
