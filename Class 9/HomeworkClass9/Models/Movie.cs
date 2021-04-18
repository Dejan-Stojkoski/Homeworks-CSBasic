using System;

namespace Models
{
    public class Movie
    {
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public int Rating { get; set; }
        public int TicketPricing { get; set; }
        
        public Movie(string title, Genre genre, int rating)
        {
            if(rating < 1 || rating > 5)
            {
                throw new ArgumentException($"For the movie {title} rating out of range. Should be a number between 1 and 5");
            }

            Title = title;
            Genre = genre;
            Rating = rating;
            TicketPricing = 5 * rating;
        }
    }
}
