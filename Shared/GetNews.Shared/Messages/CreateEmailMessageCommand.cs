using System;
using System.Collections.Generic;
using System.Text;

namespace GetNews.Shared.Messages
{
    public class CreateEmailMessageCommand
    {
        public string SenderName { get; set; }       // Gönderen adı
        public string SenderEmail { get; set; }      // Gönderen e-posta adresi
        public string RecipientName { get; set; }     // Alıcı adı
        public string RecipientEmail { get; set; }    // Alıcı e-posta adresi
        public string Subject { get; set; }           // E-posta konusu
        public string Body { get; set; }              // E-posta içeriği
    }
}
