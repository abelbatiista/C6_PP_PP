using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using System.Linq;

namespace BookApp.Data.CategoryService
{
    class CCategoryService : ICategoryService
    {
        private readonly C6_PP_PPContext _context = new C6_PP_PPContext();

        public CCategoryService() { }

        public void DeleteCategoryTask(Category category)
        {
            Task deleteCategoryTask = new Task(() => DeleteCategory(category));
            deleteCategoryTask.Start();
        }

        public Category FindCategoryTask(int id)
        {
            var findCategoryTask = new Task<Category>(() => FindCategory(id));
            findCategoryTask.Start();
            return findCategoryTask.Result;
        }

        public IEnumerable<Category> GetCategoriesTask(bool _)
        {
            var getCategoriesTask = new Task<IEnumerable<Category>>(() => GetCategories(_));
            getCategoriesTask.Start();
            return getCategoriesTask.Result;
        }

        public void InsertCategoryTask(Category category)
        {
            Task insertCategoryTask = new Task(() => InsertCategory(category));
            insertCategoryTask.Start();
        }

        public void UpdateCategoryTask(Category category)
        {
            Task updateCategoryTask = new Task(() => UpdateCategory(category));
            updateCategoryTask.Start();
        }

        private void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        private Category FindCategory(int id)
        {
            return _context.Categories.Find(id);
        }

        private IEnumerable<Category> GetCategories(bool _)
        {
            if (_)
            {
                return _context.Categories.OrderByDescending(x => x.IdCategory).ToList();
            }
            else
            {
                return _context.Categories.OrderBy(x => x.Name).ToList();
            }
        }

        private void InsertCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        private void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
