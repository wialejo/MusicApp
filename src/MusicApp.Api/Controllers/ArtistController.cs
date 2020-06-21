using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Application.Artists;

namespace MusicApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<IEnumerable<ArtistViewModel>> Get(CancellationToken ct)
        {

            var allArtist = await _artistService.GetAllArtist(ct);

            return allArtist;
        }

        
        [HttpPost]
        public int Post(CreateArtistRequest artist, CancellationToken ct)
        {
            return _artistService.AddArtist(artist, ct);
        }
    }
}