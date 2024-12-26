using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] MessageRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Message))
            {
                return BadRequest(new { reply = "Ошибка: пустое сообщение!" });
            }

            // Возвращаем сообщение, которое пришло на сервер
            return Ok(new { reply = $"Вы сказали: {request.Message}" });
        }
    }

    public class MessageRequest
    {
        public string Message { get; set; }
    }
}
