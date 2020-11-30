using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LBR.Models;
using LBR.DAL;
using Microsoft.Extensions.Configuration;
using System.Data;
using LBR.Services;
using LBR.Class;

namespace LBR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogService _blogService;

        public HomeController(ILogger<HomeController> logger, IBlogService blogService)
        {
            _logger = logger;
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            IEnumerable<BlogPost> posts = _blogService.GetBlogPosts();

            BlogViewModel model = new BlogViewModel();
            model.BlogPosts = new List<PostViewModel>();

            if (posts != null)
            {
                foreach (BlogPost post in posts)
                {
                    PostViewModel pModel = post.GetPostViewModel();
                    pModel.Comments = _blogService.GetBlogComments(post.BlogPostId).ToList();
                    model.BlogPosts.Add(pModel);
                }
            }

            return View(model);            
        }

        public IActionResult PostTemplate(BlogPost model)
        {          
            return View(model);
        }

        public ActionResult BlogDetails(int BlogPostId)
        {
            BlogPost post = _blogService.GetBlogPost(BlogPostId);
            if(post != null)
            {
                PostViewModel pModel = post.GetPostViewModel();
                pModel.Comments = _blogService.GetBlogComments(post.BlogPostId).ToList();
                return View(pModel);
            }

            return View("Error", new ErrorViewModel { ErrorMessage = "The Blog cannot be found" });
        }

        

        public ActionResult Error()
        {
            return View(new ErrorViewModel { ErrorMessage = "An unspecified error occured" });
        }
    }
}
