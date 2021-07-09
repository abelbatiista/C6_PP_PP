using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Menu.MainMenu
{
    class CMainMenu : IMainMenu
    {
        public string MainMenuChoice { get; set; }
        public bool MainMenuOpen { get; set; }

        public CMainMenu(bool _mainMenuOpen)
        {
            this.MainMenuOpen = _mainMenuOpen;
        }

        public void ChooseOption()
        {
            Console.WriteLine();
            Console.WriteLine("Elija la opción que desea: ");
        }

        public bool CloseProgram()
        {
            bool menuClose = false;
            bool whileChosing = true;
            while (whileChosing)
            {
                Console.Clear();
                Console.WriteLine("¿Desea salir del programa? s/n");
                string menuCloseChoice = Console.ReadLine().ToLower();
                switch (menuCloseChoice)
                {
                    case "s":
                        whileChosing = false;
                        menuClose = false;
                        break;
                    case "n":
                        whileChosing = false;
                        menuClose = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Por favor, escribir 's' para sí, y 'n' para no.");
                        Console.WriteLine("Presione cualquier tecla para continuar.");
                        Console.ReadKey();
                        whileChosing = true;
                        break;
                }
            }
            return menuClose;
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("========Menú Principal=======");
            Console.WriteLine("============================");
            Console.WriteLine("(1)-. Mantenimiento de autores.");
            Console.WriteLine("(2)-. Mantenimiento de categorías.");
            Console.WriteLine("(3)-. Mantenimiento de editoriales.");
            Console.WriteLine("(4)-. Mantenimiento de libros.");
            Console.WriteLine("(5)-. Búsqueda de libro.");
            Console.WriteLine("(6)-. Salir");
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
