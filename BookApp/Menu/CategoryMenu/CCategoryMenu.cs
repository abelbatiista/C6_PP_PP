using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Menu.CategoryMenu
{
    class CCategoryMenu : ICategoryMenu
    {

        public string CategoryMenuChoice { get; set; }
        public bool CategoryMenuOpen { get; set; }

        public CCategoryMenu(bool _categoryMenuOpen)
        {
            this.CategoryMenuOpen = _categoryMenuOpen;
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

        public void ShowCategoryMenu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("=======Menu Categoría========");
            Console.WriteLine("============================");
            Console.WriteLine("(1)-. Agregar categoría.");
            Console.WriteLine("(2)-. Editar categoría.");
            Console.WriteLine("(3)-. Eliminar categoría.");
            Console.WriteLine("(4)-. Listar categoría.");
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
