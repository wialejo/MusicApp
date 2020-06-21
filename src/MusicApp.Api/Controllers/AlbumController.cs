using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Application.Albums;

namespace MusicApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        [Route("GetAlbumByArtist/{artistId}")]
        public async Task<IEnumerable<AlbumViewModel>> Get([FromRoute] int artistId, CancellationToken ct)
        {
            return await _albumService.GetAlbumByArtist(artistId, ct);
        }

        [HttpPost]
        public int Post(CreateAlbumRequest albumViewModel ,CancellationToken ct)
        {
            return _albumService.AddAlbum(albumViewModel, ct);
        }
    }
}