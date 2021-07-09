using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Models
{
    public partial class Editorial
    {
        public Editorial()
        {
            Books = new HashSet<Book>();
        }

        public int IdEditorial { get; set; }
        public string Name { get; set; }
        public string TelephoneNumber { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
