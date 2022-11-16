using movieProject.Models.Movie;

namespace movieProject.Models.Todo
{
    public interface ITodoRepository
    {
        public IEnumerable<TodoModel> GetAllTodo();
        public TodoModel GetIdTodo(long id);
        public void DeleteTodo(long id);
        public void PutTodo(TodoModel todo);
        public void PostTodo(TodoModel todo);
        public void UpdatePutTodo(TodoModel todo);
    }
}
