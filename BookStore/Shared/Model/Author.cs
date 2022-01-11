using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Shared.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        //public ICollection<Book> Books { get; set; }

        //public Author()
        //{
        //    Books = new List<Book>();
        //}
    }
}
