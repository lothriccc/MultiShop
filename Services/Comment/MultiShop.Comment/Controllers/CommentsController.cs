using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;
using System.Globalization;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public IActionResult CommenctList()
        {
            var values = _commentContext.UserComments.ToList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateComment(UserComment comment)
        {
            _commentContext.UserComments.Add(comment);
            _commentContext.SaveChanges();
            return Ok("Yorum başarıyla eklenmiştir");
        }
        [HttpPut]
        public IActionResult UpdateComment(UserComment comment)
        {
            _commentContext.UserComments.Update(comment);
            _commentContext.SaveChanges();
            return Ok("Yorum başarıyla güncellenmiştir");
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            _commentContext.UserComments.Remove(value);
            _commentContext.SaveChanges();
            return Ok("Yorum Başarıyla Silinmiştir");
        }
        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _commentContext.UserComments.Where(x => x.ProductID == id).ToList();
            return Ok(value);

        }
    }
}
