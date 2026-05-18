using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    // [ApiController] — позначає що це Web API контролер.
    // Активує: автоматичну валідацію моделі, автоматичний 400 при помилках,
    // автоматичне читання body як JSON.
    [ApiController]

    // [Route] — базовий URL для всього контролера.
    // [controller] = назва класу без "Controller" = "books"
    // Тобто всі методи доступні через /api/books/...
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        // Dependency Injection: ASP.NET Core сам передасть сервіс в конструктор.
        // Ми залежимо від ІНТЕРФЕЙСУ, не від конкретного класу.
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
            => Ok(_bookService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            var book = _bookService.GetById(id);
            return book is null
                ? NotFound(new { Message = $"Книгу з ID {id} не знайдено" }) // Повертаємо 404 з повідомленням
                : Ok(book); // Повертаємо 200 з даними книги
        }
        // HTTP статус-коди діляться на 5 груп за першою цифрою.
        // 1xx — інформаційні (не використовуються в API)
        // 2xx — успішні (200 OK, 201 Created, 204 No Content)
        // 3xx — перенаправлення (не використовуються в API)    
        // 4xx — помилки клієнта (400 Bad Request, 404 Not Found)
        // 5xx — помилки сервера (500 Internal Server Error)


        [HttpPost]
        // [FromBody] — вказує що дані для створення книги прийдуть з тіла запиту у форматі JSON.
        // Ще існують:
        // [FromQuery] — дані прийдуть з URL query string /api/books?page=2 → int page = 2
        // [FromRoute] — дані прийдуть з маршруту (URL path) /api/books/42  → int id = 42
        // [FromHeader] — дані прийдуть з заголовків HTTP Authorization: Bearer xxx
        // [FromForm] — дані прийдуть з форми (multipart/form-data) при завантаженні файлів
        public ActionResult<Book> Create([FromBody] Book book)
        {
            var created = _bookService.Create(book);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created); // Повертаємо 201 з URL нової книги та її даними
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Book book)
        {
            var updated = _bookService.Update(id, book);
            return updated is null
                ? NotFound(new { Message = $"Книгу з ID {id} не знайдено" })
                : Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _bookService.Delete(id) ? NoContent() : NotFound(new { Message = $"Книгу з ID {id} не знайдено" });
        }
    }
}
