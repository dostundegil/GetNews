using System.ComponentModel.DataAnnotations;

namespace GetNews.AdminClient.Models.NewsModels
{
    public class UpdateNewsVM
    {
        public string Id { get; set; }
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Display(Name = "İçerik")]
        public string Content { get; set; }
        [Display(Name = "Özet")]
        public string Summary { get; set; }
        [Display(Name = "Paylaşıldı mı?")]
        public bool is_published { get; set; }
        [Display(Name = "Resim Url'si")]
        public string image_url { get; set; }
    }
}
