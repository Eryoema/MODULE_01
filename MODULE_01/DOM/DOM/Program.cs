using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Copies { get; set; }

        public Book(string title, string author, string isbn, int copies)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Copies = copies;
        }
    }

    class Reader
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Reader(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }

    class Library
    {
        private List<Book> books = new List<Book>();
        private List<Reader> readers = new List<Reader>();

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Книга '{book.Title}' добавлена в библиотеку.");
        }

        public void RemoveBook(string isbn)
        {
            Book book = books.Find(b => b.ISBN == isbn);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine($"Книга '{book.Title}' удалена из библиотеки.");
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }

        public void RegisterReader(Reader reader)
        {
            readers.Add(reader);
            Console.WriteLine($"Читатель '{reader.Name}' зарегистрирован.");
        }

        public void RemoveReader(int readerId)
        {
            Reader reader = readers.Find(r => r.Id == readerId);
            if (reader != null)
            {
                readers.Remove(reader);
                Console.WriteLine($"Читатель '{reader.Name}' удален из библиотеки.");
            }
            else
            {
                Console.WriteLine("Читатель не найден.");
            }
        }

        public void BorrowBook(string isbn, int readerId)
        {
            Book book = books.Find(b => b.ISBN == isbn);
            Reader reader = readers.Find(r => r.Id == readerId);

            if (book == null)
            {
                Console.WriteLine("Книга не найдена.");
                return;
            }

            if (reader == null)
            {
                Console.WriteLine("Читатель не найден.");
                return;
            }

            if (book.Copies > 0)
            {
                book.Copies--;
                Console.WriteLine($"Книга '{book.Title}' выдана читателю '{reader.Name}'.");
            }
            else
            {
                Console.WriteLine("Нет доступных экземпляров книги.");
            }
        }

        public void ReturnBook(string isbn)
        {
            Book book = books.Find(b => b.ISBN == isbn);
            if (book != null)
            {
                book.Copies++;
                Console.WriteLine($"Книга '{book.Title}' возвращена в библиотеку.");
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }
    }

    class DOM
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Book book1 = new Book("Война и мир", "Лев Толстой", "978-5-17-070929-3", 5);
            Book book2 = new Book("Преступление и наказание", "Федор Достоевский", "978-5-17-083945-7", 3);
            Book book3 = new Book("Мастер и Маргарита", "Михаил Булгаков", "978-5-17-084039-2", 2);

            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

            Reader reader1 = new Reader("Ернар Калдарбек", 1);
            Reader reader2 = new Reader("Жанибек Мергенбай", 2);

            library.RegisterReader(reader1);
            library.RegisterReader(reader2);

            library.BorrowBook("978-5-17-070929-3", 1);
            library.BorrowBook("978-5-17-083945-7", 2);

            library.ReturnBook("978-5-17-070929-3");

            library.RemoveBook("978-5-17-084039-2");

            library.RemoveReader(1);
        }
    }
}
