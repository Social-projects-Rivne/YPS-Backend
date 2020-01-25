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


namespace YPS.Application.Auth.Command.CreateHeadMaster
{
    public sealed class CreateHeadMasterCommandHandler : IRequestHandler<CreateHeadMasterCommand, User>
    {
        private readonly IYPSDbContext _dbContext;
        private readonly IMapper _mapper;



        public CreateHeadMasterCommandHandler(IYPSDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public async Task<User> Handle(CreateHeadMasterCommand request, CancellationToken cancellationToken)
        {


           var user = new User
           {
            Email = request.Email,
            };
            _dbContext.Add(user);

            await _dbContext.SaveChangesAsync();

            return user;

        }
     }

    }

   
    

