using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Classes.AuthorClass
{
    interface IAuthor
    {

        public void InsertAuthor();
        public void GetAuthors();
        public void DeleteAuthor();
        public void UpdateAuthor();

    }
}
