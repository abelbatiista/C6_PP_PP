using System;
using System.Collections.Generic;
using System.Text;
using BookApp.Data.EditorialService;
using Database.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookApp.Classes.EditorialClass
{
    class CEditorial : IEditorial
    {
        private readonly Editorial editorial = new Editorial();

        private readonly CEditorialService service = new CEditorialService();

        public int ExportEditorial()
        {
            return Editorials(true);
        }

        private void ShowEditorial()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("===============Editoriales===============");
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
        private int Editorials(bool _)
        {
            try
            {
                Console.WriteLine($"Editoriales -> ID | Nombre | Teléfono | País");
                var editorials = service.GetEditorialsTask(_);
                if (editorials.Count() > 0)
                {
                    //foreach(var editorial in editorials) Console.WriteLine($"\t{editorial.IdEditorial} | {editorial.Name} | {editorial.TelephoneNumber} | {editorial.Country}");
                    editorials.AsParallel().AsOrdered().ToList().ForEach(editorial => { Console.WriteLine($"\t{editorial.IdEditorial} | {editorial.Name} | {editorial.TelephoneNumber} | {editorial.Country}"); });
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

        public void DeleteEditorial()
        {
            ShowEditorial();
            int identifier = Editorials(true);
            if (identifier == 1)
            {
                Console.WriteLine("Elija: ");
                var chooseEditorial = ExceptionHandlingAuto(Console.ReadLine());
                if (chooseEditorial != -1)
                {
                    int confirm = AreYouSure();
                    if (confirm == 1)
                    {
                        var editorial = service.FindEditorialTask(chooseEditorial);
                        if (editorial != null)
                        {
                            service.DeleteEditorialTask(editorial);
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

        public void GetEditorial()
        {
            ShowEditorial();
            Editorials(false);
            PressEnter();
        }

        public void InsertEditorial()
        {
            ShowEditorial();
            Console.WriteLine("Nombre: ");
            editorial.Name = Console.ReadLine();
            Console.WriteLine("Teléfono: ");
            editorial.TelephoneNumber = Console.ReadLine();
            Console.WriteLine("País: ");
            editorial.Country = Console.ReadLine();
            service.InsertEditorialTask(editorial);
            Console.WriteLine();
            Console.WriteLine("¡Insertado con éxito!");
            PressEnter();
        }

        public void UpdateEditorial()
        {
            ShowEditorial();
            int identifier = Editorials(true);
            if (identifier == 1)
            {
                Console.WriteLine("Elija: ");
                var chooseEditorial = ExceptionHandlingAuto(Console.ReadLine());
                if (chooseEditorial != -1)
                {
                    var editorial = service.FindEditorialTask(chooseEditorial);
                    if (editorial != null)
                    {
                        PressEnter();
                        ShowEditorial();
                        Console.WriteLine("Nombre: ");
                        editorial.Name = Console.ReadLine();
                        Console.WriteLine("Teléfono: ");
                        editorial.TelephoneNumber = Console.ReadLine();
                        Console.WriteLine("País: ");
                        editorial.Country = Console.ReadLine();
                        service.UpdateEditorialTask(editorial);
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
