using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YPS.Application.Interfaces;
using YPS.Application.Models;
using YPS.Domain.Entities;

namespace YPS.Application.Classes.Commands.CreateClass
{
    public class CreateClassCommand : IRequest<CreatedResponse>
    {
        public long Number { get; set; }
        public string Character { get; set; }
        public long ClassTeacherId { get; set; }

        public sealed class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, CreatedResponse>
        {
            private readonly IYPSDbContext _context;
            private readonly IClassService _classService;
            public CreateClassCommandHandler(IYPSDbContext context, IClassService classService)
            {
                _context = context;
                _classService = classService;
            }

            public async Task<CreatedResponse> Handle(CreateClassCommand request, CancellationToken cancellationToken)
            {
                CreatedResponse res = new CreatedResponse();

                IDictionary<string, string> failures = _classService.CheckFailures(request.Number, request.Character);

                res.Failures = failures;

                if (res.Failures == null || !res.Failures.Any())
                {
                    var newClass = await _classService.CreateClass(request.Number, request.Character, request.ClassTeacherId);

                    res.CreatedId = newClass.Id;
                }

                return res;
            }
        }
    }
}
