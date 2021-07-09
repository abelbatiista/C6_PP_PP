using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Menu.CategoryMenu
{
    interface ICategoryMenu
    {

        public void ShowCategoryMenu();
        public void ChooseOption();
        public void WrongChoice();
        public bool BackForward();

    }
}
