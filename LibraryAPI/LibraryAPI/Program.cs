
// ASP.NET Core — це open-source фреймворк від Microsoft для створення веб-додатків та API на мові C#.

//  Web API - це вид додатку, що відповідає на HTTP-запити даними (JSON), а не HTML-сторінками. Призначений для спілкування між системами.
using LibraryAPI.Data;
using LibraryAPI.Services;

namespace LibraryAPI
{
    public class Program
    {
        public static void Main()
        {
            var builder = WebApplication.CreateBuilder(); // Створює об'єкт WebApplicationBuilder, який використовується для налаштування та створення веб-додатку. Він надає доступ до конфігурації, реєстрації сервісів та інших налаштувань.

            builder.Services.AddControllers(); // Додає підтримку для контролерів, які обробляють HTTP-запити. Це необхідно для роботи BooksController.


            // Реєструємо сервіси для Dependency Injection. Це дозволяє нам використовувати IBookService в контролері, а ASP.NET Core сам створить екземпляр BookService і передасть його.
            builder.Services.AddSingleton<BookStore>();
            builder.Services.AddScoped<IBookService, BookService>(); // Реєструємо BookService як реалізацію IBookService.
                                                                     // AddSingleton — створює один екземпляр BookStore на все життя додатку, який буде спільним для всіх запитів.
                                                                     // AddScoped — створює новий екземпляр BookService для кожного HTTP-запиту.
                                                                     // AddTransient — створює новий екземпляр кожного разу, коли він потрібен (не використовується в нашому випадку).

            builder.Services.AddEndpointsApiExplorer();// Додає підтримку для автоматичного генерування документації API.
            builder.Services.AddSwaggerGen(); // Додає підтримку для генерації Swagger документації, яка описує всі доступні ендпоінти API, їх параметри та відповіді. Це дозволяє легко тестувати API через Swagger UI.

            var app = builder.Build(); // Створює веб-додаток на основі налаштувань, які ми вказали в builder.

            if (app.Environment.IsDevelopment()) // Якщо ми в режимі розробки, то активуємо Swagger UI для тестування API.
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Додаємо проміжне програмне забезпечення (middleware) для обробки HTTP-запитів. Порядок важливий!

            //app.UseHttpsRedirection(); // Додає middleware, який перенаправляє всі HTTP-запити на HTTPS. Це забезпечує безпечне з'єднання.
           // app.UseAuthorization(); // Додає middleware для авторизації. У нашому прикладі ми не налаштовували авторизацію, але цей рядок потрібен для того, щоб додаток міг обробляти запити з авторизацією, якщо ми її додамо в майбутньому.
            app.MapControllers(); // Додає маршрутизацію для контролерів. Це дозволяє обробляти HTTP-запити через методи контролерів.

            app.Run(); // Запускає веб-додаток і починає обробку HTTP-запитів.
        }
    }
}
