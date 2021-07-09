using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using System.Linq;

namespace BookApp.Data.BookService
{
    class CBookService : IBookService
    {
        private readonly C6_PP_PPContext _context = new C6_PP_PPContext();

        public CBookService() { }

        public void DeleteBookTask(Book book)
        {
            Task deleteBookTask = new Task(() => DeleteBook(book));
            deleteBookTask.Start();
        }

        public Book FindBookTask(int id)
        {
            var findBookTask = new Task<Book>(() => FindBook(id));
            findBookTask.Start();
            return findBookTask.Result;
        }

        public IEnumerable<Book> GetBooksTask(bool _)
        {
            var getBooksTask = new Task<IEnumerable<Book>>(() => GetBooks(_));
            getBooksTask.Start();
            return getBooksTask.Result;
        }

        public void InsertBookTask(Book book)
        {
            Task insertBookTask = new Task(() => InsertBook(book));
            insertBookTask.Start();
        }

        public void UpdateBookTask(Book book)
        {
            Task updateBookTask = new Task(() => UpdateBook(book));
            updateBookTask.Start();
        }

        private void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        private Book FindBook(int id)
        {
            return _context.Books.Find(id);
        }

        private IEnumerable<Book> GetBooks(bool _)
        {
            if (_)
            {
                return _context.Books.OrderByDescending(x => x.IdBook).ToList();
            }
            else
            {
                return _context.Books.OrderBy(x => x.Name).ToList();
            }
        }

        private void InsertBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        private void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
