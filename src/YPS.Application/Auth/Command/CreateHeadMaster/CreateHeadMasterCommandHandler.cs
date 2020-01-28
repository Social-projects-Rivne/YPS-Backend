using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MediatR;
using YPS.Application.Auth.Helpers;
using YPS.Application.Exceptions;
using YPS.Application.Interfaces;
using YPS.Domain.Entities;

namespace YPS.Application.Auth.Command.CreateHeadMaster
{
    public sealed class CreateHeadMasterCommandHandler : IRequestHandler<CreateHeadMasterCommand, CreateHeadMasterViewModel>
    {
        private readonly IYPSDbContext _dbContext;
        private readonly IMapper _mapper;



        public CreateHeadMasterCommandHandler(IYPSDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CreateHeadMasterViewModel> Handle(CreateHeadMasterCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth,
                RoleId = 2

            };

            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();

            //return _mapper.Map<CreateUserViewModel>(user);
            return new CreateHeadMasterViewModel
            {
                Email = request.Email,
                FisrtName = request.FirstName,
                MiddleName = request.MiddleName,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth,
                RoleId = 2
            };


        }

    }
}
