using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Models
{
    public partial class Book
    {
        public int IdBook { get; set; }
        public string Name { get; set; }
        public DateTime? Year { get; set; }
        public int IdCategory { get; set; }
        public int IdAuthor { get; set; }
        public int IdEditorial { get; set; }

        public virtual Author IdAuthorNavigation { get; set; }
        public virtual Category IdCategoryNavigation { get; set; }
        public virtual Editorial IdEditorialNavigation { get; set; }
    }
}
