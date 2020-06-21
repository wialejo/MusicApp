using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain;
using MusicApp.Infrastructure;

namespace MusicApp.Application.Albums
{
    public class AlbumService : IAlbumService
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public AlbumService(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AlbumViewModel>> GetAlbumByArtist(int artistId, CancellationToken cancellationToken)
        {
            return await _context.Set<Album>().Where(s => s.ArtistId.Equals(artistId))
                .ProjectTo<AlbumViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        public int AddAlbum(CreateAlbumRequest createAlbumRequest, CancellationToken ct)
        {
            var artist = _context.Set<Artist>()
                .FirstOrDefaultAsync(a => a.ArtistId.Equals(createAlbumRequest.ArtistId), ct).Result;

            var album = artist.AddAlbum(
                createAlbumRequest.Name,
                createAlbumRequest.Price,
                createAlbumRequest.Rating,
                createAlbumRequest.NumberOfRates,
                createAlbumRequest.ReleaseDateTime,
                createAlbumRequest.Rights,
                createAlbumRequest.ImageUrl,
                createAlbumRequest.Genre
                );

            _context.Set<Album>().AddAsync(album, ct);

            _context.SaveChangesAsync(ct);

            return album.AlbumId;
        }
    }
}
