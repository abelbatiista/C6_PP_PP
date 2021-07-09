using System;
using System.Collections.Generic;
using System.Text;
using Database.Models;

namespace BookApp.Data.BookService.FindBookService
{
    interface IFindBookService
    {

        public IEnumerable<object> FindBooksByBookNameTask(string bookName, string orderBy);
        public IEnumerable<object> FindBooksByEditorialCountryTask(string editorialCountry, string orderBy);
        public IEnumerable<object> FindBooksByYearSinceUntilTask(DateTime yearSince, DateTime yearUntil, string orderBy);
        public IEnumerable<object> FindBooksByAuthorNameTask(string authorName, string orderBy);
        public IEnumerable<object> FindBooksByEditorialNameTask(string editorialName, string orderBy);

    }
}
