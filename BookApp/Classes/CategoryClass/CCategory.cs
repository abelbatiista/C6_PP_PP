using System;
using System.Collections.Generic;
using System.Text;
using BookApp.Data.CategoryService;
using Database.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookApp.Classes.CategoryClass
{
    class CCategory : ICategory
    {

        private readonly Category category = new Category();

        private readonly CCategoryService service = new CCategoryService();

        public int ExportCategories()
        {
            return Categories(true);
        }

        private void ShowCategory()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("===============Categorías===============");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine();
        }

        private void PressEnter()
        {
            Console.WriteLine();
            Console.WriteLine("Presione 'Enter' para continuar.");
            Console.ReadKey();
        }

        private int Categories(bool _)
        {
            try
            {
                Console.WriteLine($"Categorías -> ID | Nombre ");
                var categories = service.GetCategoriesTask(_);
                if (categories.Count() > 0)
                {
                    //Parallel.ForEach(categories, category => { Console.WriteLine($"\t{category.IdCategory} | {category.Name}"); });
                    categories.AsParallel().AsOrdered().ToList().ForEach(category => { Console.WriteLine($"\t{category.IdCategory} | {category.Name}"); });
                    Console.WriteLine();
                    return 1;
                }
                else
                {
                    Console.WriteLine("No hay registros.");
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No hay registros.");
                Console.WriteLine(e);
                return 0;
            }
        }

        private int AreYouSure()
        {
            Console.Clear();
            Console.WriteLine("¿Está seguro? s/n");
            var choosen = Console.ReadLine().ToLower();
            if (choosen == "s")
            {
                return 1;
            }
            else if (choosen == "n")
            {
                Console.WriteLine("No borrado.");
                return 0;
            }
            else
            {
                Console.WriteLine("Opción no válida.");
                return 0;
            }
        }

        public void DeleteCategory()
        {
            ShowCategory();
            int identifier = Categories(true);
            if (identifier == 1)
            {
                Console.WriteLine("Elija: ");
                var chooseCategory = ExceptionHandlingAuto(Console.ReadLine());
                if (chooseCategory != -1)
                {
                    int confirm = AreYouSure();
                    if (confirm == 1)
                    {
                        var category = service.FindCategoryTask(chooseCategory);
                        if (category != null)
                        {
                            service.DeleteCategoryTask(category);
                            Console.WriteLine("Borrado con éxito.");
                            PressEnter();
                        }
                        else
                        {
                            Console.WriteLine("No existe ese registro.");
                            PressEnter();
                        }
                        
                    }
                    else
                    {
                        PressEnter();
                    }
                }
                else
                {
                    Console.WriteLine("Favor escriba un número entero.");
                    PressEnter();
                }
            }
            else
            {
                PressEnter();
            }
        }

        public void GetCategories()
        {
            ShowCategory();
            Categories(false);
            PressEnter();
        }

        public void InsertCategory()
        {
            ShowCategory();
            Console.WriteLine("Nombre: ");
            category.Name = Console.ReadLine();
            service.InsertCategoryTask(category);
            Console.WriteLine();
            Console.WriteLine("¡Insertado con éxito!");
            PressEnter();
        }

        public void UpdateCategory()
        {
            ShowCategory();
            int identifier = Categories(true);
            if (identifier == 1)
            {
                Console.WriteLine("Elija: ");
                var chooseCategory = ExceptionHandlingAuto(Console.ReadLine());
                if (chooseCategory != -1)
                {
                    var category = service.FindCategoryTask(chooseCategory);
                    if (category != null)
                    {
                        PressEnter();
                        ShowCategory();
                        Console.WriteLine("Nombre: ");
                        category.Name = Console.ReadLine();
                        service.UpdateCategoryTask(category);
                        PressEnter();
                    }
                    else
                    {
                        Console.WriteLine("No existe ese registro.");
                        PressEnter();
                    }
                }
                else
                {
                    Console.WriteLine("Favor escriba un número entero.");
                    PressEnter();
                }
            }
            else
            {
                PressEnter();
            }
        }

        private int ExceptionHandlingAuto(string e)
        {
            if (int.TryParse(e, out int i))
            {
                return i;
            }
            else
            {
                return -1;
            }
        }
    }
}
