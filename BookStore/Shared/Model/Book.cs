
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Shared.Model
{
    public class Book
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; }
        public string Description { get; set; }

        public int categoryId { get; set; } = 1;
        public Category Category { get; set; }

        public int publisherId { get; set; } = 1;
        public Publisher publisher { get; set; }



    }
}
