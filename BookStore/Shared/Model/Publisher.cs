
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.Shared.Model
{
    public class Publisher
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Book> book { get; set; }

        public Publisher()
        {
            book = new List<Book>();
        }
    }
}
