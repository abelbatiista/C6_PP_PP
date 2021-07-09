using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Menu.MainMenu
{
    interface IMainMenu
    {
        public void ShowMenu();
        public void ChooseOption();
        public void WrongChoice();
        public bool CloseProgram();
    }
}
