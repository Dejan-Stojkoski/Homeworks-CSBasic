namespace Models
{
    public class Song
    {
        public string Title { get; private set; }
        public string Length { get; private set; }
        public Genre Genre { get; private set; }

        public Song(string title, string length, Genre genre)
        {
            Title = title;
            Length = length;
            Genre = genre;
        }
    }
}
