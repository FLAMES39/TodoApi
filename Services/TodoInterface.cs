using TodoApi.Models;

namespace TodoApi.Services
{
    public interface TodoInterface
    {
        Task<List<Todo>>getTodos();

        Task<Todo>getTodobyId(int id);

        Task<List<Todo>>adddTodo(string Name, string Description, bool IsComplete);

        Task<List<Todo>> updateTodo(int id, Todo todo);

        Task<List<Todo>> deleteTodo(int id);
    }
}
