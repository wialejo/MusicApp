using System;
using System.Collections.Generic;

namespace MusicApp.Domain
{
    public class Artist
    {
        //for EF
        private Artist()
        {
            Albums = new HashSet<Album>();
        }

        public Artist(string name, string review)
        {
            Name = name;
            Review = review;
            Albums = new HashSet<Album>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }
        public ICollection<Album> Albums { get; set; }

        public Album AddAlbum(string name, in decimal price, in int rating, in int numberOfRates, in DateTime releaseDateTime, string rights, string imageUrl, string genre)
        {
            //check rules

            return new Album(this.ArtistId, name, price, rating, numberOfRates, releaseDateTime, rights, imageUrl, genre);

        }
    }
}