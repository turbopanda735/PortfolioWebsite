using movieProject.Models.Movie;

namespace movieProject.Models.Todo
{
    public interface ITodoRepository
    {
        public IEnumerable<TodoModel> GetAllTodo();
        public IEnumerable<TodoModel> GetIdTodo(long id);
        public IEnumerable<TodoModel> DeleteTodo();
        public IEnumerable<TodoModel> PutTodo();
        public IEnumerable<TodoModel> PostTodo();
    }
}
