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
using YPS.Application.Parents.ViewModels;

namespace YPS.Application.Parents.Queries
{
    public class GetParentsQuery : IRequest<ICollection<ParentViewModel>>
    {
        public long Id { get; set; }
        public class GetParentsQueryHandler : IRequestHandler<GetParentsQuery, ICollection<ParentViewModel>>
        {
            private IYPSDbContext _dbContext;
            private IMapper _mapper;
            public GetParentsQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<ICollection<ParentViewModel>> Handle(GetParentsQuery request, CancellationToken cancellationToken)
            {

                return await _dbContext.Users
                    .Include(x => x.Parent)
                    .Where(x => x.Parent != null)
                    .AsNoTracking()
                    .Where(x => x.Parent.SchoolId == request.Id)
                    .Select(x => x.Parent)
                    .Select(x => new ParentViewModel
                    {
                        Id = x.Id,
                        Email = x.User.Email,
                        FirstName = x.User.FirstName,
                        MiddleName = x.User.MiddleName,
                        Surname = x.User.Surname,
                        WorkInfo = x.User.Parent.WorkInfo,
                        PhoneNumber = x.User.PhoneNumber,
                        Children = x.ParentToPupils.Select(y => y.PupilOf.User.FirstName + " " + y.PupilOf.User.Surname + " " + y.PupilOf.User.MiddleName 
                        + " Class:" + y.PupilOf.ClassOf.Number.ToString() + "-" + y.PupilOf.ClassOf.Character 
                              + "\n").ToList()
                    }).ToListAsync();
            }
        }
    }
}
