﻿namespace OntarioMovieApp.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        // Add more properties as needed based on the OMDB API response.
    }
}
