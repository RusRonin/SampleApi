using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApi.Models;
using SampleApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private ILogger<TodoController> _logger;
        private TodoService _todoService;

        public TodoController(TodoService todoService, ILogger<TodoController> logger)
        {
            _todoService = todoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> Read()
        {
            return new ObjectResult(await _todoService.GetTodos());
        }

        [HttpPost]
        public async Task<ActionResult> Create(Todo todo)
        {
            await _todoService.AddTodo(todo);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Todo todo)
        {
            _logger.LogInformation(todo.Id.ToString());
            _logger.LogInformation(todo.Name);
            await _todoService.UpdateTodo(todo);
            return Ok();
        }
    }
}
