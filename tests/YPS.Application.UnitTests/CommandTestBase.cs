using System;
using System.Collections.Generic;
using System.Text;
using YPS.Persistence;

namespace YPS.Application.UnitTests
{
    public class CommandTestBase : IDisposable
    {
        public YPSDbContext Context { get; }

        public CommandTestBase()
        {
            Context = YPSDbContextFactory.Create();
        }

        public void Dispose()
        {
            YPSDbContextFactory.Destroy(Context);
        }
    }
}
