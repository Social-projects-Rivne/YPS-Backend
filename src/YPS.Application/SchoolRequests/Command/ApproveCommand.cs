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
using YPS.Application.SchoolRequests.ViewModel;
using YPS.Domain.Entities;

namespace YPS.Application.SchoolRequests.Command
{
    public class ApproveCommand : IRequest<SchoolViewModel>
    {
        public long Id { get; set; }
        public class ApproveCommandHandler : IRequestHandler<ApproveCommand, SchoolViewModel>
        {
            private IYPSDbContext _dbContext;
            private IMapper _mapper;
            private IMailSenderService _mailSender;

            public ApproveCommandHandler(IYPSDbContext dbContext, IMapper mapper,IMailSenderService mailSender)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                _mailSender = mailSender;
            }

            public async Task<SchoolViewModel> Handle(ApproveCommand request, CancellationToken cancellationToken)
            {
                var requests = _dbContext.SchoolRequests.AsNoTracking();                
                
                string guidLink = Guid.NewGuid().ToString();
                string masterRegisterLink= "http://localhost:4200/register-headmaster/"+guidLink;
                string message = "<h1>Congratulations your school was succesfully registered</h1> <p>Please follow the link to register your head master "+ masterRegisterLink;
                _mailSender.SendMessageAsync(requests.FirstOrDefault(x => x.Id == request.Id).Email, "Successfuly registered", message);

                var school = new School
                {
                    Name = requests.FirstOrDefault(x => x.Id == request.Id).Name,
                    ShortName = requests.FirstOrDefault(x => x.Id == request.Id).ShortName,
                    RegistrationLink=guidLink
                };
                _dbContext.Schools.Add(school);
                await _dbContext.SaveChangesAsync(cancellationToken);

                await _dbContext.SaveChangesAsync(cancellationToken);

                _dbContext.SchoolRequests.FirstOrDefault(x => x.Id == request.Id).IsApproved = true;
                await _dbContext.SaveChangesAsync(cancellationToken);

                return new SchoolViewModel { Id = request.Id };   
            }
        }
    }
}
