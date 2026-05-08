using System;
using System.Collections.Generic;
using System.Text;

namespace Zrutas.Domain.Entities.Nodo
{
    public class ModelNews
    {
        public string Title { get; set; }
        public string Content{ get; set; }
        public string UrlImage { get; set; }
        public string MessageHour { get; set; }
        public long MessageID { get; set; }

        public ModelNews(string Title, string Content, long messageID, string MessageHour, string UrlImage = null)
        {
            this.Title = Title;
            this.Content = Content;
            this.UrlImage = UrlImage;
            this.MessageHour = MessageHour;
            this.MessageID = messageID;
        }


    }
}
