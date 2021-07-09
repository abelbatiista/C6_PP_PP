using System;
using System.Collections.Generic;
using System.Text;
using BookApp.Data.BookService.FindBookService;
using Database.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookApp.Classes.BookClass.FindBookClass
{
    class CFindBook : IFindBook
    {

        private readonly Book book = new Book();

        private readonly CFindBookService service = new CFindBookService();

        private void ShowBook()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("===============Libros=================");
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

        public void FindBooksByAuthorName()
        {
            ShowBook();
            Console.WriteLine("Escriba el nombre del autor: ");
            var author = Console.ReadLine();
            OrderByMenu();
            var _chose = Console.ReadLine();
            PressEnter();
            var _objectsNoDynamic = service.FindBooksByAuthorNameTask(author, _chose);
            if (_objectsNoDynamic.Count() > 0)
            {
                Console.Clear();
                dynamic _objects = _objectsNoDynamic;
                foreach (var _object in _objects)
                {
                    Console.WriteLine();
                    Console.WriteLine("=================================================");
                    Console.WriteLine($"ID: {_object.Id}\n" +
                        $"Nombre del libro: {_object.Book}\n" +
                        $"Año de publicación: {_object.Year}\n" +
                        $"País de origen: {_object.Country}\n" +
                        $"Nombre del editorial: {_object.Editorial}\n" +
                        $"Nombre del autor: {_object.Author}");
                    Console.WriteLine("=================================================");
                }
            }
            else
            {
                Console.WriteLine("No hay libros escritos por ese autor.");
            }
            PressEnter();
        }

        public void FindBooksByBookName()
        {
            ShowBook();
            Console.WriteLine("Escriba el nombre del libro: ");
            var book = Console.ReadLine();
            OrderByMenu();
            var _chose = Console.ReadLine();
            PressEnter();
            var _objectsNoDynamic = service.FindBooksByBookNameTask(book, _chose);
            if (_objectsNoDynamic.Count() > 0)
            {
                Console.Clear();
                dynamic _objects = _objectsNoDynamic;
                foreach (var _object in _objects)
                {
                    Console.WriteLine();
                    Console.WriteLine("=================================================");
                    Console.WriteLine($"ID: {_object.Id}\n" +
                        $"Nombre del libro: {_object.Book}\n" +
                        $"Año de publicación: {_object.Year}\n" +
                        $"País de origen: {_object.Country}\n" +
                        $"Nombre del editorial: {_object.Editorial}\n" +
                        $"Nombre del autor: {_object.Author}");
                    Console.WriteLine("=================================================");
                }
            }
            else
            {
                Console.WriteLine("No hay libros con ese nombre.");
            }
            PressEnter();
        }

        public void FindBooksByEditorialCountry()
        {
            ShowBook();
            Console.WriteLine("Escriba el país del editorial: ");
            var country = Console.ReadLine();
            OrderByMenu();
            var _chose = Console.ReadLine();
            PressEnter();
            var _objectsNoDynamic = service.FindBooksByEditorialCountryTask(country, _chose);
            if (_objectsNoDynamic.Count() > 0)
            {
                Console.Clear();
                dynamic _objects = _objectsNoDynamic;
                foreach (var _object in _objects)
                {
                    Console.WriteLine();
                    Console.WriteLine("=================================================");
                    Console.WriteLine($"ID: {_object.Id}\n" +
                        $"Nombre del libro: {_object.Book}\n" +
                        $"Año de publicación: {_object.Year}\n" +
                        $"País de origen: {_object.Country}\n" +
                        $"Nombre del editorial: {_object.Editorial}\n" +
                        $"Nombre del autor: {_object.Author}");
                    Console.WriteLine("=================================================");
                }
            }
            else
            {
                Console.WriteLine("No hay libros escritos en editoriales de ese país.");
            }
            PressEnter();
        }

        public void FindBooksByEditorialName()
        {
            ShowBook();
            Console.WriteLine("Escriba el nombre del editorial: ");
            var editorial = Console.ReadLine();
            OrderByMenu();
            var _chose = Console.ReadLine();
            PressEnter();
            var _objectsNoDynamic = service.FindBooksByEditorialNameTask(editorial, _chose);
            if (_objectsNoDynamic.Count() > 0)
            {
                Console.Clear();
                dynamic _objects = _objectsNoDynamic;
                foreach (var _object in _objects)
                {
                    Console.WriteLine();
                    Console.WriteLine("=================================================");
                    Console.WriteLine($"ID: {_object.Id}\n" +
                        $"Nombre del libro: {_object.Book}\n" +
                        $"Año de publicación: {_object.Year}\n" +
                        $"País de origen: {_object.Country}\n" +
                        $"Nombre del editorial: {_object.Editorial}\n" +
                        $"Nombre del autor: {_object.Author}");
                    Console.WriteLine("=================================================");
                }
            }
            else
            {
                Console.WriteLine("No hay libros escritos en esa editorial.");
            }
            PressEnter();
        }

        public void FindBooksByYearSinceUntil()
        {
            ShowBook();
            Console.WriteLine("Escriba los años: ");
            Console.WriteLine("Desde: ");
            var _since = int.Parse(Console.ReadLine());
            Console.WriteLine("Hasta: ");
            var _until = int.Parse(Console.ReadLine());
            var _sinceYear = new DateTime(_since, 1, 1, 00, 00, 00);
            var _untilYear = new DateTime(_until, 1, 1, 00, 00, 00);
            OrderByMenu();
            var _chose = Console.ReadLine();
            PressEnter();
            var _objectsNoDynamic = service.FindBooksByYearSinceUntilTask(_sinceYear, _untilYear, _chose);
            if (_objectsNoDynamic.Count() > 0)
            {
                Console.Clear();
                dynamic _objects = _objectsNoDynamic;
                foreach (var _object in _objects)
                {
                    Console.WriteLine();
                    Console.WriteLine("=================================================");
                    Console.WriteLine($"ID: {_object.Id}\n" +
                        $"Nombre del libro: {_object.Book}\n" +
                        $"Año de publicación: {_object.Year}\n" +
                        $"País de origen: {_object.Country}\n" +
                        $"Nombre del editorial: {_object.Editorial}\n" +
                        $"Nombre del autor: {_object.Author}");
                    Console.WriteLine("=================================================");
                }
            }
            else
            {
                Console.WriteLine("No hay libros escritos entre esas fechas.");
            }
            PressEnter();
        }

        private void OrderByMenu()
        {
            PressEnter();
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("=======Ordenar Libros========");
            Console.WriteLine("============================");
            Console.WriteLine("(1)-. Por nombre del libro.");
            Console.WriteLine("(2)-. Por el país del editorial.");
            Console.WriteLine("(3)-. Por año de publicación.");
            Console.WriteLine("(4)-. Por nombre del autor.");
            Console.WriteLine("(5)-. Por nombre del editorial.");
            Console.WriteLine();
            Console.WriteLine("Elija la opción que desea: ");
        }
    }
}
