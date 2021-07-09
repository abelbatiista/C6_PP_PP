using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Menu.AuthorMenu
{
    class CAuthorMenu : IAuthorMenu
    {

        public string AuthorMenuChoice { get; set; }
        public bool AuthorMenuOpen { get; set; }

        public CAuthorMenu(bool _authorMenuOpen)
        {
            this.AuthorMenuOpen = _authorMenuOpen;
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

        public void ShowAuthorMenu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("=======Menu Autor========");
            Console.WriteLine("============================");
            Console.WriteLine("(1)-. Agregar autor.");
            Console.WriteLine("(2)-. Editar autor.");
            Console.WriteLine("(3)-. Eliminar autor.");
            Console.WriteLine("(4)-. Listar autor.");
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
