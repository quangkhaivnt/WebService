using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DemoRESTServiceCRUD
{
    
    public class BookServices : IBookServices
    {
        static IBookRepository repository = new BookRepository();
        public string AddBook(Book book, string id)
        {
            Book newBook = repository.AddNewBook(book);
            return "id =" + newBook.BookId;
        }

        public string DeleteBook(string id)
        {
            bool deleted = repository.DeleteABook(int.Parse(id));
            if (deleted)
                return "Book with id =" + id + "deleted successfully";
            else
                return "Unable to delete book with id =" + id;
        }

        public Book GetBookById(string id)
        {
            return repository.GetBookById(int.Parse(id));
        }

        public List<Book> GetBookList()
        {
            return repository.GetAllBook();
        }

        public string UpdateBook(Book book, string id)
        {
            bool updated = repository.UpdateABook(book);
            if (updated)
                return "Book with id =" + id + "updated successfully";
            else
                return "Unable to update book with id = " + id;
        }
    }
}
