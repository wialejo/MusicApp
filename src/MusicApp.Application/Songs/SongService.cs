using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain;
using MusicApp.Infrastructure;

namespace MusicApp.Application.Songs
{

    public class SongService : ISongService
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public SongService(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SongViewModel>> GetSongsByAlbum(int albumId, 
            CancellationToken cancellationToken)
        {
            return await _context.Set<Song>().Where(s => s.AlbumId == albumId)
                .ProjectTo<SongViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        public int AddSong(CreateSongRequest createSongRequest, CancellationToken ct)
        {
            var album = _context.Set<Album>()
                .FirstOrDefaultAsync(a => a.AlbumId.Equals(createSongRequest.AlbumId), ct).Result;

            var song = album.AddSong(createSongRequest.Name, createSongRequest.Price, 
                createSongRequest.Duration, createSongRequest.Popularity);

            _context.Set<Song>().AddAsync(song, ct);

            _context.SaveChangesAsync(ct);

            return song.SongId;
        }

        public void BuySong(int songId, CancellationToken ct)
        {
            var song = _context.Set<Song>().FirstOrDefaultAsync(a => a.SongId.Equals(songId), ct).Result;

            //logic
        }
    }
}
