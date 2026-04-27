using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBasics.Entities
{
    internal class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
