using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using YPS.Persistence;

namespace YPS.Application.UnitTests
{
    public static class YPSDbContextFactory
    {
        public static YPSDbContext Create()
        {
            DbContextOptions<YPSDbContext> options = new DbContextOptionsBuilder<YPSDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            YPSDbContext context = new YPSDbContext(options);

            context.Database.EnsureCreated();

            return context;
        }

        public static void Destroy(YPSDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
