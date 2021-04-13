using System;
using Models;
using System.Collections.Generic;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Song> songs = new List<Song>
            {
                new Song("Zeze", "3:48", Genre.Hip_Hop),
                new Song("Shake That Ass", "4:33", Genre.Hip_Hop),
                new Song("Little bit", "4:51", Genre.Techno)
            };

            Person bob = new Person(1, "Bob", "Bobsky", 33, Genre.Hip_Hop, songs);
            Person greg = new Person(2, "Greg", "Gregsky", 24, Genre.Rock, new List<Song>());

            Console.WriteLine(bob.GetFavSongs());

            Console.WriteLine($"\n{greg.GetFavSongs()}");
        }
    }
}
