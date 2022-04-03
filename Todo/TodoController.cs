using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Todo
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private TodoDbContext dbContext;

        private readonly ILogger<TodoController> logger;

        public TodoController(ILogger<TodoController> logger, TodoDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("tasks/{taskId?}")]
        public Task GetTask(long taskId)
        {
            return dbContext.Tasks.Find(taskId);
        }

        [HttpGet]
        [Route("tasks")]
        public IEnumerable<Task> ListTasks()
        {
            return dbContext.Tasks.ToList();
        }

        [HttpPost]
        [Route("tasks")]
        public ObjectResult AddTask(Task task)
        {
            dbContext.Tasks.Add(task);
            dbContext.SaveChanges();
            return Ok("Task added");
        }

        [HttpDelete]
        [Route("tasks/{taskId?}")]
        public ObjectResult DeleteTask(long taskId)
        {
            Task task = new Task { Id = taskId };
            dbContext.Tasks.Attach(task);
            dbContext.Tasks.Remove(task);
            dbContext.SaveChanges();
            return Ok("Task deleted");
        }
    }
}
