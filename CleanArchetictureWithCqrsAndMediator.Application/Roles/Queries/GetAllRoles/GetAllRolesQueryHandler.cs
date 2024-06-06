using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogs;
using CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.CreateRole;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RoleVM>>
    {
        private readonly IRolesRepository _repository;
        private readonly IMapper _mapper;
        public GetAllRolesQueryHandler(IRolesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<RoleVM>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _repository.GetAllRoles();
            //var result =  blogs.Select(b => new BlogVM
            // {
            //     Author = b.Author,
            //     Description = b.Description,
            //     Name = b.Name,
            //     Id = b.Id,
            // }).ToList();
            var result = _mapper.Map<List<RoleVM>>(roles);
            return result;
        }
    }
}
