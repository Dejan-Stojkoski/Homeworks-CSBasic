using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Cinema cinema1 = new Cinema("Cineplexx", 8);
                Cinema cinema2 = new Cinema("Millennium", 4);
                Cinema cinema3 = new Cinema("Cinematheque of Macedonia", 1);

                Movie movie1 = new Movie("Treto poluvreme", Genre.Drama, 4);
                Movie movie2 = new Movie("Medena zemja", Genre.Drama, 5);
                Movie movie3 = new Movie("Tetoviranje", Genre.Drama, 5);
                Movie movie4 = new Movie("Balkankan", Genre.Comedy, 4);
                Movie movie5 = new Movie("Coming to America", Genre.Comedy, 4);
                Movie movie6 = new Movie("Vikend na mrtovci", Genre.Comedy, 5);
                Movie movie7 = new Movie("Senki", Genre.Horror, 3);
                Movie movie8 = new Movie("Tremor", Genre.Action, 2);
                Movie movie9 = new Movie("Inception", Genre.SciFi, 5);
                Movie movie10 = new Movie("Annihilation", Genre.Horror, 5);

                cinema1.Movies.AddRange(new List<Movie> { movie1, movie3, movie5, movie7, movie9 });
                cinema2.Movies.AddRange(new List<Movie> { movie2, movie4, movie6, movie8, movie10 });
                cinema3.Movies.AddRange(new List<Movie> { movie1, movie4, movie7, movie9, movie10, movie6 });

                List<Cinema> cinemas = new List<Cinema> { cinema1, cinema2, cinema3 };

                Cinema cinemaChoice = ChooseCinema(cinemas);
                Movie movieChoice = ChooseMovie(cinemaChoice);

                Console.WriteLine($"\n{cinemaChoice.MoviePlaying(movieChoice)}");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"NullReferenceException: {ex.Message}");
                throw;
            }
            catch ( ArgumentException ex)
            {
                Console.WriteLine($"ArgumentException: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        static Cinema ChooseCinema(List<Cinema> cinemas)
        {
            Console.Write("Please choose a cinema:  ");
            for(int i = 0; i<cinemas.Count; i++)
            {
                Console.Write($"{cinemas[i].Name}");
                if (i == cinemas.Count - 1) Console.WriteLine();
                else Console.Write(", ");

            }
            string cinemaName = Console.ReadLine().ToLower();

            if (!cinemas.Any(x => x.Name.ToLower() == cinemaName))
            {
                throw new ArgumentException($"There is no cinema with the name {cinemaName}.");
            }

            return cinemas.Where(x => x.Name.ToLower() == cinemaName).First();
        }

        static Movie ChooseMovie(Cinema cinema)
        {
            Console.WriteLine("\nPlease choose an option: \n1. See all movies \n2. See movies by genre");
            string optionString = Console.ReadLine();

            if (!int.TryParse(optionString, out int option))
            {
                throw new ArgumentException("Invalid option!");
            }

            switch (option)
            {
                case 1:
                    return GetMovie(cinema.Movies);

                case 2:
                    Console.WriteLine("\nPlease enter your favourite genre: ");
                    string genre = Console.ReadLine().ToLower();

                    if (genre.Length == 0)
                    {
                        throw new ArgumentNullException("You have not entered a genre!");
                    }
                    else
                    {
                        genre = char.ToUpper(genre[0]) + genre.Substring(1);
                    }

                    if (!Enum.TryParse(genre, out Genre genreEnum))
                    {
                        throw new Exception("There is no such genre available!");
                    }

                    if (!cinema.Movies.Any(x => x.Genre == genreEnum))
                    {
                        throw new NullReferenceException($"There are no movies of the genre {genreEnum} in this cinema available!");
                    }

                    List<Movie> bySpecificGenre = cinema.Movies.Where(x => x.Genre == genreEnum).ToList();
                    return GetMovie(bySpecificGenre);

                default:
                    throw new Exception("There are only two options available!");
            }
        }

        static Movie GetMovie(List<Movie> movies)
        {
            Console.WriteLine("\nPlease choose a movie: ");
            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine($"-{movies[i].Title}");
            }
            string movie = Console.ReadLine().ToLower();

            if (!movies.Any(x => x.Title.ToLower() == movie))
            {
                throw new ArgumentException("There in no such movie in this cinema!");
            }

            return movies.Where(x => x.Title.ToLower() == movie).First(); ;
        }
    }
}
