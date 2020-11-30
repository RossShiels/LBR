using LBR.Class;
using LBR.Controllers;
using LBR.DAL;
using LBR.Models;
using LBR.Services;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;

namespace LBRTestProject
{
    public class LBRTests
    {
        [Test]
        public void TestIndexView()
        {
            HomeController controller = new HomeController(null,new BlogService());
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void TestPostTemplateView()
        {
            HomeController controller = new HomeController(null, new BlogService());
            BlogPost model = new BlogPost();
            model.BlogPostId = 1;
            model.Body = "<p>test</p>";
            model.PublishedOn = DateTime.Now;
            model.Title = "Test Title";

            ViewResult result = controller.PostTemplate(model) as ViewResult;
            Assert.IsNotNull(result);
        }       

        [Test]
        public void TestBlogDetailsErrorView()
        {
            HomeController controller = new HomeController(null, new BlogService());
            DataAccess.ConnectionString = "Server=(local);Database=LBR;Integrated Security=SSPI;";
            ViewResult result = controller.BlogDetails(-1) as ViewResult;
            Assert.AreEqual("Error", result.ViewName);
        }

        [Test]
        public void TestGetPostViewModel()
        {
            BlogPost model = new BlogPost();
            model.BlogPostId = 1;
            model.Body = "<p>test</p>";
            model.PublishedOn = DateTime.Now;
            model.Title = "Test Title";

            PostViewModel pvModel = model.GetPostViewModel();

            Assert.IsNotNull(pvModel);
            Assert.AreEqual(pvModel.BlogPostId, model.BlogPostId);
            Assert.AreEqual(pvModel.Body, model.Body);
            Assert.AreEqual(pvModel.PublishedOn, model.PublishedOn);
            Assert.AreEqual(pvModel.Title, model.Title);
            
        }


    }
}
