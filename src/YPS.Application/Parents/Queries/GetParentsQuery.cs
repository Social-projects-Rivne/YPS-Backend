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
                var parents = _dbContext.Users.Include(x => x.Parent).Where(x => x.Parent != null).AsNoTracking().Where(x => x.Parent.SchoolId == request.Id);
                var children = _dbContext.ParentToPupils.Include(x => x.ParentOf)
                    .Include(x => x.PupilOf)
                    .Include(x => x.PupilOf.User)
                    .Include(x => x.PupilOf.ClassOf)
                    .Where(x => x.ParentOf.SchoolId == request.Id)
                    .AsNoTracking()
                    .Select(x => x.PupilOf).Select(x => new ChildInfoViewModel
                    {
                        Info=x.User.FirstName+" "+x.User.Surname+" "+x.User.MiddleName+" "+x.ClassOf.Number.ToString()+"-"+x.ClassOf.Character
                    });
                return parents.Select(x => new ParentViewModel
                {
                    Email = x.Email,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    Surname = x.Surname,
                    ImageUrl = x.ImageUrl,
                    WorkInfo=x.Parent.WorkInfo,
                    PhoneNumber = x.PhoneNumber,
                    Children=children.ToList()
                }).ToList();
            }
        }
    }
}
