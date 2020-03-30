using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using YPS.Application.Mapping;
using YPS.Persistence;

namespace YPS.Application.UnitTests
{
    public sealed class QueryTestFixture : IDisposable
    {
        public YPSDbContext Context { get; }
        public IMapper Mapper { get; }

        public QueryTestFixture()
        {
            Context = YPSDbContextFactory.Create();

            MapperConfiguration configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            YPSDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryTests")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
