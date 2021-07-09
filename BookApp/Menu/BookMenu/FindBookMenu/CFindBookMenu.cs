using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Menu.BookMenu.FindBookMenu
{
    class CFindBookMenu : IFindBookMenu
    {

        public string FindBookMenuChoice { get; set; }
        public bool FindBookMenuOpen { get; set; }

        public CFindBookMenu(bool _findBookMenuOpen)
        {
            this.FindBookMenuOpen = _findBookMenuOpen;
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

        public void ShowFindBookMenu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("=======Buscar Libro========");
            Console.WriteLine("============================");
            Console.WriteLine("(1)-. Por nombre.");
            Console.WriteLine("(2)-. Por el país del editorial.");
            Console.WriteLine("(3)-. Por año de publicación (desde - hasta).");
            Console.WriteLine("(4)-. Por nombre del autor.");
            Console.WriteLine("(5)-. Por nombre del editorial.");
            Console.WriteLine("(6)-. Volver atrás.");
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
