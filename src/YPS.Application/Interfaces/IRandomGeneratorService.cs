using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YPS.Application.Interfaces
{
    public interface IRandomGeneratorService
    {
        public string RandomString(int size, bool lowerCase);
        public int RandomNumber(int min, int max);
        public string RandomPassword();
    }
}
