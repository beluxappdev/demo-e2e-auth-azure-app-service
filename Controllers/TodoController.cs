using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private static readonly HttpClient _client = new HttpClient();
        private static readonly string _remoteUrl = "https://demotodoapi-backend.azurewebsites.net";
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {  
            base.OnActionExecuting(context);

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Request.Headers["X-MS-TOKEN-AAD-ACCESS-TOKEN"]);
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            var data = await _client.GetStringAsync($"{_remoteUrl}/api/todo");
            return JsonConvert.DeserializeObject<List<TodoItem>>(data);
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var data = await _client.GetStringAsync($"{_remoteUrl}/api/todo/{id}");
            return Content(data, "application/json");
        }

        // PUT: api/Todo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            var res = await _client.PutAsJsonAsync($"{_remoteUrl}/api/todo/{id}", todoItem);
            return new NoContentResult();
        }

        // POST: api/Todo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            var response = await _client.PostAsJsonAsync($"{_remoteUrl}/api/todo", todoItem);
            var data = await response.Content.ReadAsStringAsync();
            return Content(data, "application/json");
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var res = await _client.DeleteAsync($"{_remoteUrl}/api/todo/{id}");
            return new NoContentResult();
        }

        private bool TodoItemExists(long id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault(false);
        }
    }
}
