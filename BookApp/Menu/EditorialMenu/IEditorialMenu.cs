using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Menu.EditorialMenu
{
    interface IEditorialMenu
    {

        public void ShowEditorialMenu();
        public void ChooseOption();
        public void WrongChoice();
        public bool BackForward();

    }
}
