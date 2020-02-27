using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YPS.Application.Exceptions;
using YPS.Application.Interfaces;
using YPS.Domain.Entities;

namespace YPS.Application.Classes.Commands.CreateClass
{
    public sealed class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, long>
    {
        private readonly IYPSDbContext _context;
        private readonly IMapper _mapper;

        public CreateClassCommandHandler(IYPSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            //if ( await _context.Classes
            //    .AnyAsync(x=>x.Character.ToUpper() == request.Character.ToUpper() && x.Number == request.Number, cancellationToken).ConfigureAwait(false))
            //{
            //    {
            //        throw new ValidationException(new List<ValidationFailure>
            //        {
            //            new ValidationFailure("name", "YPS.ExpenseTransactionCategory.Exist")
            //        });
            //    }
            //}

            var classRequest = new Class
            {
                Character = request.Character,
                Number = request.Number,
                ClassTeacherId = request.ClassTeacherId
            };

            _context.Classes.Add(classRequest);
            await _context.SaveChangesAsync(cancellationToken);

            return classRequest.Id;
        }
    }
}
