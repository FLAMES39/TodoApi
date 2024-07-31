using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.dto;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoService : TodoInterface
    {

        private  DataContext _dbContext;
        public TodoService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<List<Todo>> adddTodo(string Name, string Description, bool IsComplete)
        {
            var todo = new Todo
            {
                Name = Name,
                Description = Description,
                IsComplete = false
            };

            await _dbContext.Todos.AddAsync(todo);
            await _dbContext.SaveChangesAsync();
            var todos = await _dbContext.Todos.ToListAsync();

            return todos;
        }



        public  async Task<Todo> getTodobyId(int id)
        {
            var todo = await _dbContext.Todos.FirstOrDefaultAsync(todo => todo.id == id);

            return todo;
        }



        public Task<List<Todo>> getTodos()
        {
            return _dbContext.Todos.ToListAsync();
        }

        public async Task<List<Todo>> updateTodo(int id, Todo todo)
        {
            var existingTodo = await _dbContext.Todos.FirstOrDefaultAsync(todo => todo.id == id);
            if (existingTodo != null)
            {
                existingTodo.IsComplete = true;
                existingTodo.Name = todo.Name;
                existingTodo.Description = todo.Description;


                await _dbContext.SaveChangesAsync();
            }

            return await _dbContext.Todos.ToListAsync();
        }



        public async Task<List<Todo>> deleteTodo(int id)
        {
            var Todo = await _dbContext.Todos.FirstOrDefaultAsync(todo => todo.id == id);
            if (Todo != null)
            {
                _dbContext.Remove(Todo);
                await _dbContext.SaveChangesAsync();
            }

            var todoList = await _dbContext.Todos.ToListAsync();
            return todoList;
        }
    }
}
