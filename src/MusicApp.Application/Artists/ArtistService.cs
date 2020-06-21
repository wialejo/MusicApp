using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain;
using MusicApp.Infrastructure;

namespace MusicApp.Application.Artists
{
    public class ArtistService : IArtistService
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public ArtistService(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ArtistViewModel>> GetAllArtist(CancellationToken cancellationToken)
        {
            return await _context.Set<Artist>().ProjectTo<ArtistViewModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }

        public int AddArtist(CreateArtistRequest createArtistRequest, in CancellationToken ct)
        {
            var artist = new Artist(createArtistRequest.Name, createArtistRequest.Review);

            _context.Set<Artist>().AddAsync(artist, ct);
            _context.SaveChangesAsync(ct);

            return artist.ArtistId;
        }
    }
}
