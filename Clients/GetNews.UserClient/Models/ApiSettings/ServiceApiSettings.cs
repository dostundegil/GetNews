namespace GetNews.UserClient.Models.ApiSettings
{
    public class ServiceApiSettings
    {
        public string IdentityBaseUri { get; set; }
        public string GatewayBaseUri { get; set; }
        public string NewsUri { get; set; }
        public ServiceApi News { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
