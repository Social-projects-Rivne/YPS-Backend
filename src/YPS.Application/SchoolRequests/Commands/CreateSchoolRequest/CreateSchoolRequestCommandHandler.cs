using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YPS.Application.Auth.Command.Login;
using YPS.Application.Auth.Helpers;
using YPS.Application.Exceptions;
using YPS.Application.Interfaces;

namespace YPS.Application.SchoolRequests.Commands.CreateSchoolRequest
{
    public sealed class CreateSchoolRequestCommandHandler : IRequestHandler<CreateSchoolRequestCommand, long>
    {
        private readonly IYPSDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateSchoolRequestCommandHandler(IYPSDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateSchoolRequestCommand request, CancellationToken cancellationToken)
        {

            if (await _dbContext.SchoolRequests
                .AnyAsync(x => x.Email.ToUpper() == request.Email.ToUpper() || x.Address.ToUpper() == request.Address.ToUpper(), cancellationToken)
                .ConfigureAwait(false))
            {
                throw new ValidationException(new List<ValidationFailure>
                {
                    new ValidationFailure("name", "YPS.ExpenseTransactionCategory.Exist")
                });
            }

            var schoolRequest = new Domain.Entities.SchoolRequest
            {
                Name = request.Name,
                ShortName = request.ShortName,
                Locality = request.Locality,
                Address = request.Address,
                Email = request.Email,
                PhoneNumb = request.PhoneNumb,
                Confirmation = request.Confirmation
            };

            await _dbContext.SchoolRequests.AddAsync(schoolRequest, cancellationToken)
                .ConfigureAwait(false);

            await _dbContext.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return schoolRequest.Id;
        }
    }
}
