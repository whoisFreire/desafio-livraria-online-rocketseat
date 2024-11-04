using DesafioLivrariaOnline.Models;
using DesafioLivrariaOnline.Requests.Book;
using Microsoft.AspNetCore.Mvc;

namespace DesafioLivrariaOnline.Controllers;

    public class BookController : DesafioLivrariaOnlineBaseController
    {
        private static readonly List<Book> Books = [];
        
        [HttpPost]
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
        [ProducesResponseType( StatusCodes.Status400BadRequest)]
        public IActionResult CreateBook([FromBody] CreateBookRequestJSON request)
        {
            var book = new Book()
            {
                Title = request.Title,
                Author = request.Author,
                Gender = request.Gender,
                Price = request.Price,
            };
            Books.Add(book);
            
            return Ok(book);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        public IActionResult GetBooks()
        {
            return Ok(Books);
        }
        
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult EditBook([FromRoute] string id, [FromBody]EditBookRequestJSON request)
        {
            var bookIndex = Books.FindIndex(book => book.Id == id);
            if (bookIndex < 0) return NotFound();
            
            var book = Books[bookIndex];
            
            if(request.Title is not null) book.Title = request.Title;
            if(request.Author is not null) book.Author = request.Author;
            if(request.Gender is not null) book.Gender = request.Gender;
            if (request.Price.HasValue) book.Price = request.Price.Value;
            
            Books[bookIndex] = book;
            return NoContent();
        }
        
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteBook([FromRoute] string id)
        {
            Books.RemoveAt(Books.FindIndex(book => book.Id == id));

            return NoContent();
        }
    }

