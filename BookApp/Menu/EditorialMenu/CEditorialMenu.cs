using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Menu.EditorialMenu
{
    class CEditorialMenu : IEditorialMenu
    {

        public string EditorialMenuChoice { get; set; }
        public bool EditorialMenuOpen { get; set; }

        public CEditorialMenu(bool _editorialMenuOpen)
        {
            this.EditorialMenuOpen = _editorialMenuOpen;
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

        public void ShowEditorialMenu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("=======Menu Editorial========");
            Console.WriteLine("============================");
            Console.WriteLine("(1)-. Agregar editorial.");
            Console.WriteLine("(2)-. Editar editorial.");
            Console.WriteLine("(3)-. Eliminar editorial.");
            Console.WriteLine("(4)-. Listar editorial.");
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
