using GetNews.Services.News.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("news")]
    
    public class ENews:BaseEntity
    {
        public string Title { get; set; }
        public string Content{ get; set; }
        public string Summary{ get; set; }
        public bool is_published{ get; set; }
        public DateTime publish_date{ get; set; }
        public DateTime last_updated{ get; set; }
        public string image_url { get; set; }
    }
}
