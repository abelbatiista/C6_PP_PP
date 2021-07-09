using System;
using System.Collections.Generic;
using System.Text;
using Database.Models;

namespace BookApp.Data.AuthorService
{
    interface IAuthorService
    {
        public void InsertAuthorTask(Author author);
        public IEnumerable<Author> GetAuthorsTask(bool _);
        public void UpdateAuthorTask(Author author);
        public void DeleteAuthorTask(Author author);
        public Author FindAuthorTask(int id);

    }
}
