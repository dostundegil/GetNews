namespace GetNews.UserClient.Models.NewsModels
{
    public class NewsVM
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public bool is_published { get; set; }
        public DateTime publish_date { get; set; }
        public DateTime last_updated { get; set; }
        public string image_url { get; set; }
    }
}
