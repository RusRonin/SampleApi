using Microsoft.EntityFrameworkCore;
using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Services
{
    public class TodoService
    {
        private ApplicationContext _context;

        public TodoService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Todo>> GetTodos()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task AddTodo(Todo todo)
        {
            if (todo != null)
            {
                _context.Todos.Add(todo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTodo(Todo todo)
        {
            if (todo != null)
            {
                _context.Todos.Update(todo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
