using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using OntarioMovieApp.Models; 

namespace OntarioMovieApp.Services
{
    public class OmdbService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://www.omdbapi.com/";
        private const string ApiKey = "72936f33"; 

        public OmdbService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Movie>> GetMoviesAsync(List<string> ids)
        {
            var movies = new List<Movie>();
            foreach (var id in ids)
            {
                try
                {
                    var url = $"{BaseUrl}?i={id}&apikey={ApiKey}";
                    var response = await _httpClient.GetStreamAsync(url);
                    var movie = await JsonSerializer.DeserializeAsync<Movie>(response);
                    if (movie != null)
                    {
                        movies.Add(movie);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching movie data: {ex.Message}");
                }
            }
            Console.WriteLine($"Fetched {movies.Count} movies");
            return movies;
        }

    }

    public class SearchResult
    {
        public List<Movie> Search { get; set; }
    }
}