using System;
using System.Collections.Generic;
using System.Text;
using Database.Models;

namespace BookApp.Data.BookService
{
    interface IBookService
    {

        public void InsertBookTask(Book book);
        public IEnumerable<Book> GetBooksTask(bool _);
        public void UpdateBookTask(Book book);
        public void DeleteBookTask(Book book);
        public Book FindBookTask(int id);

    }
}
