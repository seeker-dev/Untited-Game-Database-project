using System.Text.Json;
using GameLibrary.RAWGModels;

namespace GameLibrary
{
    internal class RAWGClient
    {
        private readonly string _apiKey;
        private readonly HttpClient _client;

        public RAWGClient()
        {
            _apiKey = File.ReadAllText("apiKey.txt");
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.rawg.io/api");
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        internal async Task<GameListResponse> GetGameListAsync(GameListRequest request)
        {
            using HttpResponseMessage response = await _client.GetAsync($"/games?{request.GetQueryString()}&key={_apiKey}");

            response.EnsureSuccessStatusCode();

            string serializedResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<GameListResponse>(serializedResponse);
        }

        ~RAWGClient() 
        { 
            _client.Dispose();
        }
    }
}
