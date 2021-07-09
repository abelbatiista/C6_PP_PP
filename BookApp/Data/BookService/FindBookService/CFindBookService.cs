using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data.BookService.FindBookService
{
    class CFindBookService : IFindBookService
    {

        private readonly C6_PP_PPContext _context = new C6_PP_PPContext();

        public CFindBookService() { }

        public IEnumerable<object> FindBooksByAuthorNameTask(string authorName, string orderBy)
        {
            var getBooksTask = new Task<IEnumerable<object>>(() => FindBooksByAuthorName(authorName, orderBy));
            getBooksTask.Start();
            return getBooksTask.Result;
        }

        private IEnumerable<object> FindBooksByAuthorName(string authorName, string orderBy)
        {
            var _objects = _context.Books
                .Join(
                _context.Authors,
                book => book.IdAuthor,
                author => author.IdAuthor,
                (book, author) => new
                {
                    Id = book.IdBook!,
                    Book = book.Name!,
                    Year = book.Year!,
                    Author = author.Name!,
                    IdEditorial = book.IdEditorial!
                })
                .Join(
                _context.Editorials,
                book => book.IdEditorial,
                editorial => editorial.IdEditorial,
                (book, editorial) => new
                {
                    Id = book.Id!,
                    Book = book.Book!,
                    Year = book.Year.Value.Year!,
                    Author = book.Author!,
                    Editorial = editorial.Name!,
                    Country = editorial.Country!
            }).Where(x => x.Author.Contains(authorName));

            return orderBy switch
            {
                "1" => _objects.OrderBy(x => x.Book).ToList(),
                "2" => _objects.OrderBy(x => x.Country).ToList(),
                "3" => _objects.OrderByDescending(x => x.Year).ToList(),
                "4" => _objects.OrderBy(x => x.Author).ToList(),
                "5" => _objects.OrderBy(x => x.Editorial).ToList(),
                _ => null,
            };
        }

        public IEnumerable<object> FindBooksByBookNameTask(string bookName, string orderBy)
        {
            var getBooksTask = new Task<IEnumerable<object>>(() => FindBooksByBookName(bookName, orderBy));
            getBooksTask.Start();
            return getBooksTask.Result;
        }

        private IEnumerable<object> FindBooksByBookName(string bookName, string orderBy)
        {
            var _objects = _context.Books
                .Join(
                _context.Authors,
                book => book.IdAuthor,
                author => author.IdAuthor,
                (book, author) => new
                {
                    Id = book.IdBook!,
                    Book = book.Name!,
                    Year = book.Year!,
                    Author = author.Name!,
                    IdEditorial = book.IdEditorial!
                })
                .Join(
                _context.Editorials,
                book => book.IdEditorial,
                editorial => editorial.IdEditorial,
                (book, editorial) => new
                {
                    Id = book.Id!,
                    Book = book.Book!,
                    Year = book.Year.Value.Year!,
                    Author = book.Author!,
                    Editorial = editorial.Name!,
                    Country = editorial.Country!
            }).Where(x => x.Book.Contains($"{bookName}")).ToList();

            return orderBy switch
            {
                "1" => _objects.OrderBy(x => x.Book).ToList(),
                "2" => _objects.OrderBy(x => x.Country).ToList(),
                "3" => _objects.OrderByDescending(x => x.Year).ToList(),
                "4" => _objects.OrderBy(x => x.Author).ToList(),
                "5" => _objects.OrderBy(x => x.Editorial).ToList(),
                _ => null,
            };
        }

        public IEnumerable<object> FindBooksByEditorialCountryTask(string editorialCountry, string orderBy)
        {
            var getBooksTask = new Task<IEnumerable<object>>(() => FindBooksByEditorialCountry(editorialCountry, orderBy));
            getBooksTask.Start();
            return getBooksTask.Result;
        }

        private IEnumerable<object> FindBooksByEditorialCountry(string editorialCountry, string orderBy)
        {
            var _objects = _context.Books
                .Join(
                _context.Authors,
                book => book.IdAuthor,
                author => author.IdAuthor,
                (book, author) => new
                {
                    Id = book.IdBook!,
                    Book = book.Name!,
                    Year = book.Year!,
                    Author = author.Name!,
                    IdEditorial = book.IdEditorial!
                })
                .Join(
                _context.Editorials,
                book => book.IdEditorial,
                editorial => editorial.IdEditorial,
                (book, editorial) => new
                {
                    Id = book.Id!,
                    Book = book.Book!,
                    Year = book.Year.Value.Year!,
                    Author = book.Author!,
                    Editorial = editorial.Name!,
                    Country = editorial.Country!
            }).Where(x => x.Country.Contains($"{editorialCountry}")).ToList();

            return orderBy switch
            {
                "1" => _objects.OrderBy(x => x.Book).ToList(),
                "2" => _objects.OrderBy(x => x.Country).ToList(),
                "3" => _objects.OrderByDescending(x => x.Year).ToList(),
                "4" => _objects.OrderBy(x => x.Author).ToList(),
                "5" => _objects.OrderBy(x => x.Editorial).ToList(),
                _ => null,
            };
        }

        public IEnumerable<object> FindBooksByEditorialNameTask(string editorialName, string orderBy)
        {
            var getBooksTask = new Task<IEnumerable<object>>(() => FindBooksByEditorialName(editorialName, orderBy));
            getBooksTask.Start();
            return getBooksTask.Result;
        }

        private IEnumerable<object> FindBooksByEditorialName(string editorialName, string orderBy)
        {
            var _objects = _context.Books
                .Join(
                _context.Authors,
                book => book.IdAuthor,
                author => author.IdAuthor,
                (book, author) => new
                {
                    Id = book.IdBook!,
                    Book = book.Name!,
                    Year = book.Year!,
                    Author = author.Name!,
                    IdEditorial = book.IdEditorial!
                })
                .Join(
                _context.Editorials,
                book => book.IdEditorial,
                editorial => editorial.IdEditorial,
                (book, editorial) => new
                {
                    Id = book.Id!,
                    Book = book.Book!,
                    Year = book.Year.Value.Year!,
                    Author = book.Author!,
                    Editorial = editorial.Name!,
                    Country = editorial.Country!
                }).Where(x => x.Editorial.Contains($"{editorialName}")).ToList();

            return orderBy switch
            {
                "1" => _objects.OrderBy(x => x.Book).ToList(),
                "2" => _objects.OrderBy(x => x.Country).ToList(),
                "3" => _objects.OrderByDescending(x => x.Year).ToList(),
                "4" => _objects.OrderBy(x => x.Author).ToList(),
                "5" => _objects.OrderBy(x => x.Editorial).ToList(),
                _ => null,
            };
        }

        public IEnumerable<object> FindBooksByYearSinceUntilTask(DateTime yearSince, DateTime yearUntil, string orderBy)
        {
            var getBooksTask = new Task<IEnumerable<object>>(() => FindBooksByYearSinceUntil(yearSince, yearUntil, orderBy));
            getBooksTask.Start();
            return getBooksTask.Result;
        }

        private IEnumerable<object> FindBooksByYearSinceUntil(DateTime yearSince, DateTime yearUntil, string orderBy)
        {
            var _objects = _context.Books
                .Join(
                _context.Authors,
                book => book.IdAuthor,
                author => author.IdAuthor,
                (book, author) => new
                {
                    Id = book.IdBook!,
                    Book = book.Name!,
                    Year = book.Year!,
                    Author = author.Name!,
                    IdEditorial = book.IdEditorial!
                })
                .Join(
                _context.Editorials,
                book => book.IdEditorial,
                editorial => editorial.IdEditorial,
                (book, editorial) => new
                {
                    Id = book.Id!,
                    Book = book.Book!,
                    Year = book.Year.Value.Year!,
                    Author = book.Author!,
                    Editorial = editorial.Name!,
                    Country = editorial.Country!
                }).Where(x => x.Year >= yearSince.Year && x.Year <= yearUntil.Year).ToList();

            return orderBy switch
            {
                "1" => _objects.OrderBy(x => x.Book).ToList(),
                "2" => _objects.OrderBy(x => x.Country).ToList(),
                "3" => _objects.OrderByDescending(x => x.Year).ToList(),
                "4" => _objects.OrderBy(x => x.Author).ToList(),
                "5" => _objects.OrderBy(x => x.Editorial).ToList(),
                _ => null,
            };
        }
    }
}
