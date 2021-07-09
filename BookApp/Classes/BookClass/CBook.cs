using System;
using System.Collections.Generic;
using System.Text;
using BookApp.Data.BookService;
using Database.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookApp.Classes.AuthorClass;
using BookApp.Classes.CategoryClass;
using BookApp.Classes.EditorialClass;

namespace BookApp.Classes.BookClass
{
    class CBook : IBook
    {

        private readonly Book book = new Book();

        private readonly CBookService service = new CBookService();

        private readonly CCategory categoryClass = new CCategory();

        private readonly CAuthor authorClass = new CAuthor();

        private readonly CEditorial editorialClass = new CEditorial();

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

        private int Books(bool _)
        {
            try
            {
                Console.WriteLine($"Libros -> ID | Nombre | Año");
                var books = service.GetBooksTask(_);
                if (books.Count() > 0)
                {
                    //Parallel.ForEach(books, book => { Console.WriteLine($"\t{book.IdBook} | {book.Name} | {book.Year}"); });
                    books.AsParallel().AsOrdered().ToList().ForEach(editorial => { Console.WriteLine($"\t{book.IdBook} | {book.Name} | {book.Year.Value.Year}"); });
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

        public void DeleteBook()
        {
            ShowBook();
            int identifier = Books(true);
            if (identifier == 1)
            {
                Console.WriteLine("Elija: ");
                var chooseBook = ExceptionHandlingAuto(Console.ReadLine());

                if(chooseBook != -1)
                {
                    int confirm = AreYouSure();
                    if (confirm == 1)
                    {
                        var book = service.FindBookTask(chooseBook);
                        if (book != null)
                        {
                            service.DeleteBookTask(book);
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

        public void GetBooks()
        {
            ShowBook();
            Books(false);
            PressEnter();
        }

        public void InsertBook()
        {
            ShowBook();

            Console.WriteLine("Nombre: ");
            book.Name = Console.ReadLine();
            Console.WriteLine("Año: ");
            var _year = int.Parse(Console.ReadLine());
            book.Year = new DateTime(_year, 1, 1, 00, 00, 00);

            var confirmCategory = categoryClass.ExportCategories();

            if (confirmCategory == 1)
            {
                Console.WriteLine("Categoría (ID): ");
                book.IdCategory = int.Parse(Console.ReadLine());

                var confirmAuthor = authorClass.ExportAuthors();

                if (confirmAuthor == 1)
                {
                    Console.WriteLine("Autor (ID): ");
                    book.IdAuthor = int.Parse(Console.ReadLine());

                    var confirmEditorial = editorialClass.ExportEditorial();

                    if (confirmEditorial == 1)
                    {
                        Console.WriteLine("Editorial (ID): ");
                        book.IdEditorial = int.Parse(Console.ReadLine());

                        service.InsertBookTask(book);
                        Console.WriteLine();
                        Console.WriteLine("¡Insertado con éxito!");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No hay editoriales disponibles.");
                    }

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("No hay autores disponibles.");
                }

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No hay categorías disponibles.");
            }
            PressEnter();
        }

        public void UpdateBook()
        {
            ShowBook();
            int identifier = Books(true);
            if (identifier == 1)
            {
                Console.WriteLine("Elija: ");
                var chooseBook = ExceptionHandlingAuto(Console.ReadLine());
                if(chooseBook != -1)
                {
                    var book = service.FindBookTask(chooseBook);

                    if (book != null)
                    {
                        PressEnter();

                        ShowBook();

                        Console.WriteLine("Nombre: ");
                        book.Name = Console.ReadLine();
                        Console.WriteLine("Año: ");
                        var _year = int.Parse(Console.ReadLine());
                        book.Year = new DateTime(_year, 1, 1, 00, 00, 00);

                        var confirmCategory = categoryClass.ExportCategories();

                        if (confirmCategory == 1)
                        {
                            Console.WriteLine("Categoría (ID): ");
                            book.IdCategory = ExceptionHandlingAuto(Console.ReadLine());

                            var confirmAuthor = authorClass.ExportAuthors();

                            if (confirmAuthor == 1)
                            {
                                Console.WriteLine("Autor (ID): ");
                                book.IdAuthor = int.Parse(Console.ReadLine());

                                var confirmEditorial = editorialClass.ExportEditorial();

                                if (confirmEditorial == 1)
                                {
                                    Console.WriteLine("Editorial (ID): ");
                                    book.IdEditorial = int.Parse(Console.ReadLine());

                                    service.UpdateBookTask(book);
                                    Console.WriteLine();
                                    Console.WriteLine("¡Editado con éxito!");
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("No hay editoriales disponibles.");
                                }

                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("No hay autores disponibles.");
                            }

                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("No hay categorías disponibles.");
                        }
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
