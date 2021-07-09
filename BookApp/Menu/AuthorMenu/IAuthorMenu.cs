using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Menu.AuthorMenu
{
    interface IAuthorMenu
    {

        public void ShowAuthorMenu();
        public void ChooseOption();
        public void WrongChoice();
        public bool BackForward();

    }
}
