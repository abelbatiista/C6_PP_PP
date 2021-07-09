using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Menu.BookMenu.FindBookMenu
{
    interface IFindBookMenu
    {

        public void ShowFindBookMenu();
        public void ChooseOption();
        public void WrongChoice();
        public bool BackForward();

    }
}
