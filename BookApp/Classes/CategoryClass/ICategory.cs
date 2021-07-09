using System;
using System.Collections.Generic;
using System.Text;
using BookApp.Data.CategoryService;
using Database.Models;

namespace BookApp.Classes.CategoryClass
{
    interface ICategory
    {
        public void InsertCategory();
        public void GetCategories();
        public void DeleteCategory();
        public void UpdateCategory();

    }
}
