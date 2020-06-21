using AutoMapper;
using MusicApp.Domain;

namespace MusicApp.Application.Artists
{
    public class ArtistsProfile: Profile
    {
        public ArtistsProfile()
        {
            CreateMap<Artist,ArtistViewModel>();
        }

    }
}
