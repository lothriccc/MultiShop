using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.RapidMQMessageApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		[HttpPost]
		public IActionResult CreateMessage()
		{
			return Ok("Mesajınız Kuyruğa Alınmıştır");
		}
	}
}
