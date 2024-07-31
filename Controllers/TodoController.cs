using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.dto;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Todo>>> getTodos()
        {
            var todos =  await _todoService.getTodos();
            return Ok(todos);
        }

 


        [HttpGet("id")]
        public async Task<ActionResult<List<Todo>>>getodosbyId( int id)
        {
            var todo = await _todoService.getTodobyId(id);
            return Ok(todo);
        }

        [HttpPost]

        public async Task<ActionResult<List<Todo>>> addTodo(string Name,  string Description , bool IsComplete)
        {
            var new_Todo = await _todoService.adddTodo(Name, Description, IsComplete);
            return Ok(new_Todo);
        }

        [HttpPut]
        public async Task<ActionResult<List<Todo>>> updateTodo(int id, Todo todo)
        {
            var new_Todo = await _todoService.updateTodo(id, todo);
            return Ok(new_Todo);
        }


        [HttpDelete]
        public async Task<ActionResult<List<Todo>>> deleteTodo(int id)
        {
            var todo = await _todoService.deleteTodo(id);
            return Ok(todo);
        }

    }
}
