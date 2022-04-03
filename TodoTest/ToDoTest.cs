using System.Net;
using System.Text.Json;
using Xunit;
using Todo;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace TodoTest
{
    public class ToDoTest : IClassFixture<WebApplicationFactory<Program>>
    {

        protected readonly HttpClient client;

        //xUnit uses this specific interface for logging to the console, which gets injected by xUnit itself in test fixture constructors.
        private ITestOutputHelper outputHelper;

        public ToDoTest(WebApplicationFactory<Program> factory, ITestOutputHelper outputHelper)
        {
            this.client = factory.CreateClient();
            this.outputHelper = outputHelper;
        }

        [Fact]
        public async System.Threading.Tasks.Task ReturnTasks()
        {
            Todo.Task t = new Todo.Task();
            t.Description = "Test task";
            var content = new StringContent(JsonSerializer.Serialize(t), Encoding.UTF8, "application/json");
            await client.PostAsync("/todo/tasks/", content);

            var response = await client.GetAsync("/todo/tasks");
            var stringResponse = await response.Content.ReadAsStringAsync();
            outputHelper.WriteLine(stringResponse);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("Test task", stringResponse);

        }
    }
}