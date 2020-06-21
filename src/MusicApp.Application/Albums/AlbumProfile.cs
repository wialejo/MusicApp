using AutoMapper;
using MusicApp.Domain;

namespace MusicApp.Application.Albums
{
    public class AlbumProfile: Profile
    {
        public AlbumProfile()
        {
            CreateMap<Album, AlbumViewModel>();
        }
    }
}
