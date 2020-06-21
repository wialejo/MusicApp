using System.Runtime.InteropServices;

namespace MusicApp.Domain
{
    public class Song
    {
        //for EF
        private Song()
        {
            Price = 0;
        }

        public Song(int albumId, string name, decimal price, int duration, int popularity)
        {
            AlbumId = albumId;
            Name = name;
            Price = price;
            Duration = duration;
            Popularity = popularity;
        }

        public int SongId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Popularity { get; set; }
        public decimal Price { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
