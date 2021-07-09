using System;
using System.Collections.Generic;
using System.Text;
using Database.Models;

namespace BookApp.Data.CategoryService
{
    interface ICategoryService
    {

        public void InsertCategoryTask(Category category);
        public IEnumerable<Category> GetCategoriesTask(bool _);
        public void UpdateCategoryTask(Category category);
        public void DeleteCategoryTask(Category category);
        public Category FindCategoryTask(int id);

    }
}
