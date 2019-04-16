using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DemoRESTServiceCRUD
{
    [DataContract]
    public class Book
    {
        [DataMember]

        public int BookId { get; set; }

        [DataMember]

        public string Title { get; set; }

        [DataMember]

        public string ISBN { get; set; }
    }

    public interface IBookRepository
    {
        List<Book> GetAllBook();

        Book GetBookById(int id);

        Book AddNewBook(Book item);

        bool DeleteABook(int id);

        bool UpdateABook(Book item);
    }

    public class BookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>();
        private int counter = 1;

        public BookRepository()
        {
            AddNewBook(new Book { Title = "C# Programming", ISBN = "12314353" });
            AddNewBook(new Book { Title = "Java Programming", ISBN = "123343514" });
            AddNewBook(new Book { Title = "WCF Programming", ISBN = "1231534214" });
        }

        public Book AddNewBook(Book newBook)
        {
            if(newBook ==null)
                throw new NotImplementedException();
            newBook.BookId = counter++;
            books.Add(newBook);
            return newBook;
        }

        public bool DeleteABook(int bookId)
        {
            int idx = books.FindIndex(b => b.BookId == bookId);
            if(idx == -1)
                return false;
            books.RemoveAll(b => b.BookId == bookId);
            return true;
        }

        public List<Book> GetAllBook()
        {
            return books;
        }

        public Book GetBookById(int bookId)
        {
            return books.Find(b => b.BookId == bookId);
        }

        public bool UpdateABook(Book updateBook)
        {
            if(updateBook == null)
                throw new NotImplementedException();
            int idx = books.FindIndex(b => b.BookId == updateBook.BookId);
            if (idx == -1)
                return false;
            books.RemoveAt(idx);
            books.Add(updateBook);
            return true;
        }
    }
}