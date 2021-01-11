using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingHangfireInASPNETCore_Demo.Data
{
    public class TodoItemService
    {
        public TodoItemService(ApplicationDbContext applicationDbContext)
        {

        }

        public async Task<TodoItem[]> GetTodoItemsForDateAsync(int userID, DateTime dateTime)
        {

        }
    }
}
