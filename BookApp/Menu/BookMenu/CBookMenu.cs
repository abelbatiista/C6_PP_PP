using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Menu.BookMenu
{
    class CBookMenu : IBookMenu
    {

        public string BookMenuChoice { get; set; }
        public bool BookMenuOpen { get; set; }

        public CBookMenu(bool _bookMenuOpen)
        {
            this.BookMenuOpen = _bookMenuOpen;
        }

        public bool BackForward()
        {
            return false;
        }

        public void ChooseOption()
        {
            Console.WriteLine();
            Console.WriteLine("Elija la opción que desea: ");
        }

        public void ShowBookMenu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("=======Menu Libro========");
            Console.WriteLine("============================");
            Console.WriteLine("(1)-. Agregar libro.");
            Console.WriteLine("(2)-. Editar libro.");
            Console.WriteLine("(3)-. Eliminar libro.");
            Console.WriteLine("(4)-. Listar libro.");
            Console.WriteLine("(5)-. Volver atrás.");
        }

        public void WrongChoice()
        {
            Console.WriteLine();
            Console.WriteLine("Ha introducido una opción incorrecta.");
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }
    }
}
