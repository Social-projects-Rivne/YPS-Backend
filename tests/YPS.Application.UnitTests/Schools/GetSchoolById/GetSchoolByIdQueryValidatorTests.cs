using AutoMapper;
using FluentValidation.Results;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using YPS.Application.Schools.Queries.GetSchoolById;
using YPS.Persistence;

namespace YPS.Application.UnitTests.Schools.GetSchoolById
{
    [Collection("QueryTests")]
    public sealed class GetSchoolByIdQueryValidatorTests
    {
        private readonly YPSDbContext _context;

        public GetSchoolByIdQueryValidatorTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void IsValid_ShouldBeTrue_WhenSchoolExists(long schoolId)
        {
            GetSchoolByIdQuery query = new GetSchoolByIdQuery { SchoolId = schoolId };
            GetSchoolByIdQueryValidator validator = new GetSchoolByIdQueryValidator(_context);

            ValidationResult result = validator.Validate(query);

            result.IsValid.ShouldBe(true);
        }

        [Theory]
        [InlineData(789)]
        [InlineData(2342)]
        public void IsValid_ShouldBeFalse_WhenSchoolDoesNotExist(long schoolId)
        {
            GetSchoolByIdQuery query = new GetSchoolByIdQuery { SchoolId = schoolId };
            GetSchoolByIdQueryValidator validator = new GetSchoolByIdQueryValidator(_context);

            ValidationResult result = validator.Validate(query);

            result.IsValid.ShouldBe(false);
        }
    }
}
