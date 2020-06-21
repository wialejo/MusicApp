using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MusicApp.Application.Artists;
using MusicApp.Infrastructure;
using Shouldly;
using Xunit;

namespace MusicApp.Test
{
    public class ArtistTest
    {
        private readonly MusicAppContext _context;
        private readonly IMapper _mapper;

        public ArtistTest()
        {
            var fixture = new TestFixture();
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        

        [Fact]
        public async Task GetAllArtistTest()
        {
            IArtistService artistService = new ArtistService(_context, _mapper);

            var result = await artistService.GetAllArtist(CancellationToken.None);
            
            result.ShouldBeOfType<List<ArtistViewModel>>();
            result.Count.ShouldBe(2);
        }

        [Fact]
        public void AddArtistTest()
        {
            IArtistService artistService = new ArtistService(_context, _mapper);

            var artist = new CreateArtistRequest
            {
                Name = "The Doors",
                Review = "An American rock band formed in Los Angeles in 1965"
            };

            var result = artistService.AddArtist(artist, CancellationToken.None);

            result.ShouldBeOfType<int>();
            result.ShouldBe(3);
        }
    }
}
