using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Menu.BookMenu
{
    interface IBookMenu
    {

        public void ShowBookMenu();
        public void ChooseOption();
        public void WrongChoice();
        public bool BackForward();

    }
}
