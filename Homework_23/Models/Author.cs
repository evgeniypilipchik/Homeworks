﻿namespace Homework_23.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Book> Books { get; set; } = new();

    }
}
