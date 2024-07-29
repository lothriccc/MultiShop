using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponent
{
    public class _AdminLayoutHeaderComponentPartial:ViewComponent
    {   

        private readonly IUserService _userService;
        private readonly ICommentService _commentService;

        public _AdminLayoutHeaderComponentPartial( IUserService userService, ICommentService commentService)
        {

            _userService = userService;
            _commentService = commentService;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            

            int totalCommentCount = await _commentService.GetTotalCommentCount();
            ViewBag.totalCommentCount = totalCommentCount;
            return View();
        }
    }
}
