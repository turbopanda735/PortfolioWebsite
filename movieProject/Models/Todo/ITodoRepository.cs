using movieProject.Models.Movie;

namespace movieProject.Models.Todo
{
    public interface ITodoRepository
    {
        public IEnumerable<TodoModel> GetAllTodo();
        public TodoModel GetIdTodo(long id);
        public void DeleteTodo(long id);
        public void PutTodo(TodoItem todo);
        public void PostTodo(TodoItem todo);
    }
}
