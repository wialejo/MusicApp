using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicApp.Application.Artists;
using MusicApp.Domain;
using MusicApp.Infrastructure;

namespace MusicApp.Test
{
    public class TestFixture: IDisposable
    {
        public MusicAppContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public TestFixture()
        {
            Context = CreateContext();
            Mapper = CreateMapper();
        }
        public void Dispose()
        {
            Destroy(Context);
        }

        public MusicAppContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<MusicAppContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            Context = new MusicAppContext(options);

            Context.Database.EnsureCreated();

            Context.Set<Artist>().AddRange(new[] {
                new Artist("Michael Jackson","The greates pop singer"),
                new Artist("Queen","Rock music"),
            });

            Context.SaveChanges();

            return Context;
        }
        
        public static void Destroy(MusicAppContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
        
        public static IMapper CreateMapper()
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ArtistsProfile());
            });

            return mappingConfig.CreateMapper();
        }
    }
}
