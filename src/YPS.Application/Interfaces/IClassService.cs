using System.Collections.Generic;
using System.Threading.Tasks;
using YPS.Domain.Entities;

namespace YPS.Application.Interfaces
{
    public interface IClassService
    {
        Task<Class> CreateClass(long number, string character, long teacherId);
        Task<IDictionary<string, string>> CheckFailures(long number, string character, long teacherId);
    }
}