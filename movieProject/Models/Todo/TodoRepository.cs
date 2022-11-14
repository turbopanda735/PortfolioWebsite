using MySqlX.XDevAPI;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;

namespace movieProject.Models.Todo
{
    public class TodoRepository : ITodoRepository
    {
        private static readonly HttpClient _client = new HttpClient();
        public TodoRepository()
        {
            _client.BaseAddress = new Uri("https://joelkozek.com/");
        }
        public void DeleteTodo(long id)
        {
            _client.DeleteAsync($"api/TodoItems/{id}");
        }

        public IEnumerable<TodoModel> GetAllTodo()
        {
            _client.BaseAddress = new Uri("https://joelkozek.com/api/TodoItems");
            var response = _client.GetStringAsync(_client.BaseAddress).Result;
            var result = JArray.Parse(response);
            var allTodo = new List<TodoModel>();
            foreach (var item in result)
            {
                var todo = new TodoModel()
                {
                    Name = item["name"].ToString(),
                    Id = Convert.ToInt32(item["id"]),
                    IsComplete = Convert.ToBoolean(item["isComplete"])
                };
                allTodo.Add(todo);
            }
            return allTodo;
        }

        public TodoModel GetIdTodo(long id)
        {
            _client.BaseAddress = new Uri("https://joelkozek.com/api/TodoItems");
            var response = _client.GetStringAsync(_client.BaseAddress).Result;
            var result = JArray.Parse(response);
            try
            {
                foreach (var item in result)
                {
                    var todo = new TodoModel()
                    {
                        Name = item["name"].ToString(),
                        Id = Convert.ToInt32(item["id"]),
                        IsComplete = Convert.ToBoolean(item["isComplete"])
                    };
                    if (todo.Id == id)
                    {
                        return todo;
                    }                
                }
                return new TodoModel()
                {
                    Name = "an error has occured"
                };
            }
            catch (Exception)
            {
                return new TodoModel()
                {
                    Name = "an error has occured"
                };
            }
        }

        public void PostTodo(TodoItem todo)
        {
            using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                todo.Name,
                todo.Id,
                todo.IsComplete
            }),
            Encoding.UTF8,
            "application/json");
            _client.BaseAddress = new Uri("https://joelkozek.com/");
            _client.PostAsync("api/TodoItems", jsonContent);
        }

        public void PutTodo(TodoItem todo)
        {
            using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                todo.Name,
                todo.Id,
                todo.IsComplete
            }),
            Encoding.UTF8,
            "application/json");
            _client.BaseAddress = new Uri("https://joelkozek.com/");
            _client.PutAsync("api/TodoItems", jsonContent);
        }
    }
}
