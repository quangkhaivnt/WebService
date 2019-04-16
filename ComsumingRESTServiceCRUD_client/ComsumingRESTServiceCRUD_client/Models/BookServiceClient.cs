using ComsumingRESTServiceCRUD_client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace ComsumingRESTServiceCRUD_client.Models
{
    public class BookServiceClient
    {
        BookServicesClient client = new BookServicesClient();
        string BASE_URL = "http://localhost:50577/BookServices.svc";
        
        public List<Book> getAllBook()
        {
            var list = client.GetBookList().ToList();
            var rt = new List<Book>();
            list.ForEach(b => rt.Add(new Book()
            {
                BookId = b.BookId, ISBN = b.ISBN, Title = b.Title 
            }));
            return rt;

            /*var syncClient = new WebClient();
            var content = syncClient.DownloadString(BASE_URL + "Books");
            var json_serializer = new JavaScriptSerializer();
            return json_serializer.Deserialize<List<Book>>(content);*/

        }

        public string AddBook(Book newbook)
        {
            var books = new ServiceReference1.Book()
            {
                BookId = newbook.BookId,
                ISBN = newbook.ISBN,
                Title = newbook.Title
            };
            return client.AddBook(books);
        }

        public string Delete(int id)
        {
            return client.DeleteBook(Convert.ToString(id));
        }

        public string Edit (Book newBook)
        {
            var book = new ServiceReference1.Book()
            {
                BookId = newBook.BookId,
                ISBN = newBook.ISBN,
                Title = newBook.Title
            };
            return client.UpdateBook(book);
        }
    }
}