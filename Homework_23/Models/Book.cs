﻿namespace Homework_23.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Author> Authors { get; set; } = new();

        public List<Reader> Readers { get; set; } = new();

    }
}
