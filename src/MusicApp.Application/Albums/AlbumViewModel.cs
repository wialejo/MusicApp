using System;

namespace MusicApp.Application.Albums
{
    public class AlbumViewModel
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public int NumberOfRates { get; set; }
        public DateTime ReleaseDateTime { get; set; }
        public string Rights { get; set; }
        public string ImageUrl { get; set; }
        public string Genre { get; set; }
        public int ArtistId { get; set; }
    }
}