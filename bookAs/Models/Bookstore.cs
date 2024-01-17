using System;
using System.Collections.Generic;

namespace bookAs.models
{
    public partial class Bookstore
    {
        public int BookId { get; set; }
        public string PublisherName { get; set; } = null!;
        public string? Address { get; set; }
        public string? AuthorId { get; set; }
        public string? BookName { get; set; }
        public string? BookCategory { get; set; }
        public string? Price { get; set; }
    }
}
