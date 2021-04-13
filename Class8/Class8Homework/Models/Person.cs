using System.Collections.Generic;

namespace Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Genre FavouriteMusicType { get; set; }
        public List<Song> FavouriteSongs { get; set; }

        public Person(int id, string firstName, string lastName, int age, Genre favMusicType, List<Song> favSongs)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            FavouriteMusicType = favMusicType;
            FavouriteSongs = favSongs;
        }

        public string GetFavSongs()
        {
            if (FavouriteSongs.Count == 0) return $"{FirstName} {LastName} hates music!";

            string favSongsTitles = $"{FirstName} {LastName} favourite songs are :";
            int i = 1;
            foreach(Song song in FavouriteSongs)
            {
                favSongsTitles += $"\n{i}. {song.Title}";
                i++;
            }

            return favSongsTitles;
        }
    }
}
