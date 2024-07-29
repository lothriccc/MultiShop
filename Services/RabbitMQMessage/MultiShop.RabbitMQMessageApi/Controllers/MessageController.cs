﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Linq.Expressions;
using System.Text;

namespace MultiShop.RabbitMQMessageApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		[HttpPost]
		public IActionResult CreateMessage()
		{
			var connectionFactory = new ConnectionFactory()
			{
				HostName= "localhost",
			};

			var connection = connectionFactory.CreateConnection();

			var channel = connection.CreateModel();
			channel.QueueDeclare("Kuyruk2", false, false, false, arguments: null);

			var messageContent = "Merhaba bugün hava çok sıcak";

			var byteMessageContent=Encoding.UTF8.GetBytes(messageContent);

			channel.BasicPublish(exchange: "", routingKey: "Kuyruk2", basicProperties: null, body: byteMessageContent);

			return Ok("Mesaj Kuyruğa Alınmıştır"); 
		}
		private static string message;
		[HttpGet]
		public IActionResult ReadMessage()
		{
			string message = "";
			var factory = new ConnectionFactory();

			factory.HostName = "localhost";

			var connection = factory.CreateConnection();

			var channel = connection.CreateModel();
			var consumer = new EventingBasicConsumer(channel);
			consumer.Received += (model, body) =>
			{
				var byteMessage = body.Body.ToArray();
				 message = Encoding.UTF8.GetString(byteMessage);


			};
			channel.BasicConsume(queue:"Kuyruk2",autoAck:false,consumer:consumer);
			if (string.IsNullOrEmpty(message))
			{
				return NoContent();
			}
			else
			{
				return Ok(message);
			}
			
		}
	}
}