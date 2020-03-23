using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Domain.Entities;

namespace YPS.Application.SchoolRequests.Commands.ApproveSchoolRequest
{
    public class ApproveSchoolRequestCommand : IRequest<SchoolViewModel>
    {
        public long Id { get; set; }
        public class ApproveSchoolRequestCommandHandler : IRequestHandler<ApproveSchoolRequestCommand, SchoolViewModel>
        {
            private IYPSDbContext _dbContext;
            private IMailSenderService _mailSender;

            public ApproveSchoolRequestCommandHandler(IYPSDbContext dbContext, IMailSenderService mailSender)
            {
                _dbContext = dbContext;
                _mailSender = mailSender;
            }

            public async Task<SchoolViewModel> Handle(ApproveSchoolRequestCommand request, CancellationToken cancellationToken)
            {
                var requests = _dbContext.SchoolRequests.AsNoTracking();

                string guidLink = Guid.NewGuid().ToString();
                string masterRegisterLink = "http://localhost:4200/register-headmaster/" + guidLink;
                string message = "<h1>Congratulations your school was succesfully registered</h1> <p>Please follow the link to register your head master " + masterRegisterLink;
                await _mailSender.SendMessageAsync(requests.FirstOrDefault(x => x.Id == request.Id).Email, "Successfuly registered", message);

                var school = new School
                {
                    Name = requests.FirstOrDefault(x => x.Id == request.Id).Name,
                    ShortName = requests.FirstOrDefault(x => x.Id == request.Id).ShortName,
                    RegistrationLink = guidLink,
                    Email = requests.FirstOrDefault(x => x.Id == request.Id).Email,
                    Address = requests.FirstOrDefault(x => x.Id == request.Id).Address,
                    Locality = requests.FirstOrDefault(x => x.Id == request.Id).Locality
                };
                _dbContext.Schools.Add(school);
                _dbContext.SchoolRequests.FirstOrDefault(x => x.Id == request.Id).IsApproved = true;
                await _dbContext.SaveChangesAsync(cancellationToken);

                return new SchoolViewModel { Id = request.Id };
            }
        }
    }
}
