using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MusicApp.Application.Artists
{
    public interface IArtistService
    {
         Task<List<ArtistViewModel>> GetAllArtist(CancellationToken cancellationToken);
        int AddArtist(CreateArtistRequest createArtistRequest, in CancellationToken ct);
    }
}