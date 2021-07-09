using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using System.Linq;

namespace BookApp.Data.EditorialService
{
    class CEditorialService : IEditorialService
    {

        private readonly C6_PP_PPContext _context = new C6_PP_PPContext();

        public CEditorialService() { }

        public void DeleteEditorialTask(Editorial editorial)
        {
            Task deleteEditorialTask = new Task(() => DeleteEditorial(editorial));
            deleteEditorialTask.Start();
        }

        public Editorial FindEditorialTask(int id)
        {
            var findEditorialTask = new Task<Editorial>(() => FindEditorial(id));
            findEditorialTask.Start();
            return findEditorialTask.Result;
        }

        public IEnumerable<Editorial> GetEditorialsTask(bool _)
        {
            var getEditorialsTask = new Task<IEnumerable<Editorial>>(() => GetEditorials(_));
            getEditorialsTask.Start();
            return getEditorialsTask.Result;
        }

        public void InsertEditorialTask(Editorial editorial)
        {
            Task insertEditorialTask = new Task(() => InsertEditorial(editorial));
            insertEditorialTask.Start();
        }

        public void UpdateEditorialTask(Editorial editorial)
        {
            Task updateEditorialTask = new Task(() => UpdateEditorial(editorial));
            updateEditorialTask.Start();
        }

        private void DeleteEditorial(Editorial editorial)
        {
            _context.Editorials.Remove(editorial);
            _context.SaveChanges();
        }

        private Editorial FindEditorial(int id)
        {
            return _context.Editorials.Find(id);
        }

        private IEnumerable<Editorial> GetEditorials(bool _)
        {
            if (_)
            {
                return _context.Editorials.OrderByDescending(x => x.IdEditorial).ToList();
            }
            else
            {
                return _context.Editorials.OrderBy(x => x.Name).ToList();
            }
        }

        private void InsertEditorial(Editorial editorial)
        {
            _context.Editorials.Add(editorial);
            _context.SaveChanges();
        }

        private void UpdateEditorial(Editorial editorial)
        {
            _context.Editorials.Update(editorial);
            _context.SaveChanges();
        }
    }
}
