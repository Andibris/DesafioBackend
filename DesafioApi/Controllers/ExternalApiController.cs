using DesafioApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalApiController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ExternalApiController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("todos")]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Erro ao acessar API externa");

            var todos = await response.Content.ReadFromJsonAsync<IEnumerable<Todo>>();
            return Ok(todos?.Take(5));
        }
    }
}