using System;
using System.Collections.Generic;
using System.Text;
using Database.Models;

namespace BookApp.Data.EditorialService
{
    interface IEditorialService
    {

        public void InsertEditorialTask(Editorial editorial);
        public IEnumerable<Editorial> GetEditorialsTask(bool _);
        public void UpdateEditorialTask(Editorial editorial);
        public void DeleteEditorialTask(Editorial editorial);
        public Editorial FindEditorialTask(int id);

    }
}
