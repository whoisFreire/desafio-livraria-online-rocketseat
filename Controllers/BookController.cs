using DesafioLivrariaOnline.Models;
using DesafioLivrariaOnline.Requests.Book;
using Microsoft.AspNetCore.Mvc;

namespace DesafioLivrariaOnline.Controllers;

    public class BookController : DesafioLivrariaOnlineBaseController
    {
        private static readonly List<Book> _Books = new List<Book>();
        
        [HttpPost]
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
        [ProducesResponseType( StatusCodes.Status400BadRequest)]
        public IActionResult createBook([FromBody] CreateBookRequestJSON request)
        {
            var book = new Book()
            {
                Title = request.Title,
                Author = request.Author,
                Gender = request.Gender,
                Price = request.Price,
            };
            _Books.Add(book);
            
            return Ok(book);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        public IActionResult getBooks()
        {
            return Ok(_Books);
        }
        
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult editBook([FromRoute] string id, [FromBody]EditBookRequestJSON request)
        {
            var bookIndex = _Books.FindIndex(book => book.Id == id);
            if (bookIndex < 0) return NotFound();
            
            var book = _Books[bookIndex];
            
            if(request.Title is not null) book.Title = request.Title;
            if(request.Author is not null) book.Author = request.Author;
            if(request.Gender is not null) book.Gender = request.Gender;
            if (request.Price.HasValue) book.Price = request.Price.Value;
            
            _Books[bookIndex] = book;
            return NoContent();
        }
        
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult deleteBook([FromRoute] string id)
        {
            _Books.RemoveAt(_Books.FindIndex(book => book.Id == id));

            return NoContent();
        }
    }

