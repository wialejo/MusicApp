using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MusicApp.Application.Songs
{
    public interface ISongService
    {
        Task<List<SongViewModel>> GetSongsByAlbum(int albumId, CancellationToken cancellationToken);
        int AddSong(CreateSongRequest createSongRequest, CancellationToken ct);
        void BuySong(int songId, CancellationToken ct);
    }
}