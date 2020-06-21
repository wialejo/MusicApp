using System;
using System.Collections.Generic;

namespace MusicApp.Domain
{
    public class Album
    {
        //fpr EF
        private Album()
        {
            Songs = new HashSet<Song>();
            Price = 0;
        }

        public Album(in int artistId, string name, in decimal price, in int rating,
            in int numberOfRates, in DateTime releaseDateTime, string rights, string imageUrl, string genre)
        {
            ArtistId = artistId;
            Name = name;
            Price = price;
            Rating = rating;
            NumberOfRates = numberOfRates;
            ReleaseDateTime = releaseDateTime;
            Rights = rights;
            ImageUrl = imageUrl;
            Genre = genre;
            Songs = new HashSet<Song>();
        }

        public int AlbumId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public int NumberOfRates { get; set; }
        public DateTime ReleaseDateTime { get; set; }
        public string Rights { get; set; }
        public string ImageUrl { get; set; }
        public string Genre { get; set; }
        public int ArtistId{ get; set; }
        public Artist Artist{ get; set; }
        public ICollection<Song> Songs { get; set; }

        public Song AddSong(string name, decimal price, int duration, int popularity)
        {
            //check rules

            return new Song(this.AlbumId, name, price, duration, popularity);
        }
    }
}