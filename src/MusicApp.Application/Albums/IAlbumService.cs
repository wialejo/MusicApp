using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MusicApp.Application.Albums
{
    public interface IAlbumService
    {
        Task<List<AlbumViewModel>> GetAlbumByArtist(int artistId, CancellationToken cancellationToken);
        int AddAlbum(CreateAlbumRequest createAlbumRequest, CancellationToken ct);
    }
}