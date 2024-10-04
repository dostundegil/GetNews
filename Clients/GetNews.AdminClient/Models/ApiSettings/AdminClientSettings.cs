namespace GetNews.AdminClient.Models.ApiSettings
{
    public class AdminClientSettings
    {
        public Client WebClient { get; set; }
    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
