using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using System.Linq;

namespace BookApp.Data.AuthorService
{
    class CAuthorService : IAuthorService
    {
        private readonly C6_PP_PPContext _context = new C6_PP_PPContext();

        public CAuthorService() { }

        public void DeleteAuthorTask(Author author)
        {
            Task deleteAuthorTask = new Task(() => DeleteAuthor(author));
            deleteAuthorTask.Start();
        }

        public Author FindAuthorTask(int id)
        {
            var findAuthorTask = new Task<Author>(() => FindAuthor(id));
            findAuthorTask.Start();
            return findAuthorTask.Result;
        }

        public IEnumerable<Author> GetAuthorsTask(bool _)
        {
            var getAuthorsTask = new Task<IEnumerable<Author>>(() => GetAuthors(_));
            getAuthorsTask.Start();
            return getAuthorsTask.Result;
        }

        public void InsertAuthorTask(Author author)
        {
            Task insertAuthorTask = new Task(() => InsertAuthor(author));
            insertAuthorTask.Start();
        }

        public void UpdateAuthorTask(Author author)
        {
            Task updateAuthorTask = new Task(() => UpdateAuthor(author));
            updateAuthorTask.Start();
        }

        private void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        private Author FindAuthor(int id)
        {
            return _context.Authors.Find(id);
        }

        private IEnumerable<Author> GetAuthors(bool _)
        {
            if (_)
            {
                return _context.Authors.OrderByDescending(x => x.IdAuthor).ToList();
            }
            else
            {
                return _context.Authors.OrderBy(x => x.Name).ToList();
            }
        }

        private void InsertAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        private void UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
    }
}
