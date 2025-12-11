using Microsoft.AspNetCore.Mvc;
using BookStoreAPI.Models;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "1984", Author = "George Orwell", Price = 29.99m, PublishedYear = 1949 },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Price = 24.99m, PublishedYear = 1960 },
            new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Price = 19.99m, PublishedYear = 1925 }
        };

        /// <summary>
        /// Tüm kitapları listele
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return Ok(books);
        }

        /// <summary>
        /// ID'ye göre kitap getir
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound($"Kitap bulunamadı: {id}");
            }
            return Ok(book);
        }

        /// <summary>
        /// Yeni kitap ekle
        /// </summary>
        [HttpPost]
        public ActionResult<Book> CreateBook(Book book)
        {
            book.Id = books.Max(b => b.Id) + 1;
            books.Add(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        /// <summary>
        /// Kitap bilgilerini güncelle
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound($"Kitap bulunamadı: {id}");
            }

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Price = updatedBook.Price;
            book.PublishedYear = updatedBook.PublishedYear;

            return NoContent();
        }

        /// <summary>
        /// Kitap sil
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound($"Kitap bulunamadı: {id}");
            }

            books.Remove(book);
            return NoContent();
        }
    }
}
