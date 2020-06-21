using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Application.Songs;

namespace MusicApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        [Route("GetSongsByAlbum/{albumId}")]
        public async Task<IEnumerable<SongViewModel>> Get([FromRoute]int albumId, CancellationToken ct)
        {
            return await _songService.GetSongsByAlbum(albumId, ct);
        }

        [HttpPost]
        public int Post(CreateSongRequest song, CancellationToken ct)
        {
            return _songService.AddSong(song, ct);
        }

        [HttpPost]
        [Route("{songId}/Buy")]
        public void Post(int idSong, CancellationToken ct)
        {
            _songService.BuySong(idSong, ct);
        }
    }
}