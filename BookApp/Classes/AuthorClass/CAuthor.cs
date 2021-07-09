using System;
using System.Collections.Generic;
using System.Text;
using BookApp.Data.AuthorService;
using Database.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookApp.Classes.AuthorClass
{
    class CAuthor : IAuthor
    {

        private readonly Author author = new Author();

        private readonly CAuthorService service = new CAuthorService();

        public int ExportAuthors()
        {
            return Authors(true);
        }

        private void ShowAuthor()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("===============Autores===============");
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
        private int Authors(bool _)
        {
            try
            {
                Console.WriteLine($"Autores -> ID | Nombre | Correo");
                var authors = service.GetAuthorsTask(_);
                if (authors.Count() > 0)
                {
                    //Parallel.ForEach(authors, author => { Console.WriteLine($"\t{author.IdAuthor} | {author.Name} | {author.Email}"); });
                    authors.AsParallel().AsOrdered().ToList().ForEach(author => { Console.WriteLine($"\t{author.IdAuthor} | {author.Name} | {author.Email}"); });
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

        public void DeleteAuthor()
        {
            ShowAuthor();
            int identifier = Authors(true);
            if (identifier == 1)
            {
                Console.WriteLine("Elija: ");
                var chooseAuthor = ExceptionHandlingAuto(Console.ReadLine());
                if (chooseAuthor != -1)
                {
                    int confirm = AreYouSure();
                    if (confirm == 1)
                    {
                        var author = service.FindAuthorTask(chooseAuthor);
                        if (author != null)
                        {
                            service.DeleteAuthorTask(author);
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

        public void GetAuthors()
        {
            ShowAuthor();
            Authors(false);
            PressEnter();
        }

        public void InsertAuthor()
        {
            ShowAuthor();
            Console.WriteLine("Nombre: ");
            author.Name = Console.ReadLine();
            Console.WriteLine("Correo: ");
            author.Email = Console.ReadLine();
            service.InsertAuthorTask(author);
            Console.WriteLine();
            Console.WriteLine("¡Insertado con éxito!");
            PressEnter();
        }

        public void UpdateAuthor()
        {
            ShowAuthor();
            int identifier = Authors(true);
            if (identifier == 1)
            {
                Console.WriteLine("Elija: ");
                var chooseAuthor = ExceptionHandlingAuto(Console.ReadLine());
                if (chooseAuthor != -1)
                {
                    var author = service.FindAuthorTask(chooseAuthor);
                    if (author != null)
                    {
                        PressEnter();
                        ShowAuthor();
                        Console.WriteLine("Nombre: ");
                        author.Name = Console.ReadLine();
                        Console.WriteLine("Correo: ");
                        author.Email = Console.ReadLine();
                        service.UpdateAuthorTask(author);
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
            if(int.TryParse(e, out int i))
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
