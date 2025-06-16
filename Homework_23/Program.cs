using Homework_23.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LibraryContext())
            {
                context.Database.EnsureCreated();

                var author1 = new Author { Name = "Vasil Bykov" };
                var book1 = new Book { Title = "Сrane cry" };
                var book2 = new Book { Title = "A sign of trouble" };
                var reader1 = new Reader { Name = "Tom" };
                var reader2 = new Reader { Name = "Bob" };
                var reader3 = new Reader { Name = "Sam" };

                book1.Authors.Add(author1);
                book2.Authors.Add(author1);
                reader1.Books.Add(book1);
                reader2.Books.Add(book2);

                context.Readers.AddRange(reader1, reader2, reader3);

                context.SaveChanges();

                foreach (var book in context.Books.Include(b => b.Authors))
                {
                    Console.Write($"Title: {book.Title}");
                    foreach (var author in book.Authors)
                    {
                        Console.Write($" Author: { author.Name}");
                    }
                    Console.WriteLine();
                }

                foreach (var reader in context.Readers.Include(r => r.Books))
                {
                    Console.Write($"Reader: {reader.Name}");
                    foreach (var book in reader.Books)
                    {
                        Console.Write($" Book: {book.Title}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
