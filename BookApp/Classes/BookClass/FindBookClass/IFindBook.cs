using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Classes.BookClass.FindBookClass
{
    interface IFindBook
    {

        public void FindBooksByAuthorName();
        public void FindBooksByBookName();
        public void FindBooksByEditorialCountry();
        public void FindBooksByEditorialName();
        public void FindBooksByYearSinceUntil();

    }
}
