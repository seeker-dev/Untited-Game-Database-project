namespace GameLibrary.RAWGModels
{
    public class GameListResponse
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public Game[] results { get; set; }
    }

    public class Game
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string released { get; set; }
        public bool tba { get; set; }
        public string background_image { get; set; }
        public int rating { get; set; }
        public int rating_top { get; set; }
        public Ratings ratings { get; set; }
        public int ratings_count { get; set; }
        public string reviews_text_count { get; set; }
        public int added { get; set; }
        public AddedByStatus added_by_status { get; set; }
        public int metacritic { get; set; }
        public int playtime { get; set; }
        public int suggestions_count { get; set; }
        public DateTime updated { get; set; }
        public EsrbRating esrb_rating { get; set; }
        public Platform[] platforms { get; set; }
    }

    public class Ratings
    {
    }

    public class AddedByStatus
    {
    }

    public class EsrbRating
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
    }

    public class Platform
    {
        public PlatformDescription platform { get; set; }
        public string released_at { get; set; }
        public Requirements requirements { get; set; }
    }

    public class PlatformDescription
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
    }

    public class Requirements
    {
        public string minimum { get; set; }
        public string recommended { get; set; }
    }
}
