namespace MusicApp.Application.Songs
{
    public class CreateSongRequest
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Popularity { get; set; }
        public decimal Price { get; set; }
        public int AlbumId { get; set; }
    }
}