using AutoMapper;
using MusicApp.Application.Albums;
using MusicApp.Application.Artists;
using MusicApp.Application.Songs;
using MusicApp.Domain;

namespace MusicApp.Application.Infrastructure
{
    public class AutofacProfile: Profile
    {
        public AutofacProfile()
        {
            CreateMap<Artist, ArtistViewModel>();
            CreateMap<Album, AlbumViewModel>();
            CreateMap<Song, SongViewModel>();
        }
    }
}
