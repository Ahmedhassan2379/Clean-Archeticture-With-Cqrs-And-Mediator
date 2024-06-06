using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Commands.DeleteBlog;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand,int>
    {
        private readonly IMapper _mapper;
        private readonly IRolesRepository _repository;
        public DeleteRoleCommandHandler(IMapper mapper, IRolesRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<int> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _repository.DeleteRole(request.RoleId);
            return role;
        }
    }
}
