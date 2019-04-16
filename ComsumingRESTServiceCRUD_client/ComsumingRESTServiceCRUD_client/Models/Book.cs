using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComsumingRESTServiceCRUD_client.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }
    }
}