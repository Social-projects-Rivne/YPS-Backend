using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;

namespace YPS.Application.Schools.Queries.GetSchoolById
{
    public class GetSchoolByIdQueryValidator : AbstractValidator<GetSchoolByIdQuery>
    {
        private readonly IYPSDbContext _context;

        public GetSchoolByIdQueryValidator(IYPSDbContext context)
        {
            _context = context;

            RuleFor(v => v.SchoolId)
                .NotEqual(0)
                .WithMessage("The schoolId value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified schoolId doesn't exist.");
        }

        public async Task<bool> Exist(long schoolId, CancellationToken cancellationToken)
        {
            return await _context.Schools
                .AnyAsync(l => l.Id == schoolId);
        }
    }
}
