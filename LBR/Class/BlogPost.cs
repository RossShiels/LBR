using LBR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBR.Class
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime? PublishedOn { get; set; }

        public PostViewModel GetPostViewModel()
        {
            PostViewModel model = new PostViewModel();

            model.BlogPostId = this.BlogPostId;
            model.Title = this.Title;
            model.PublishedOn = this.PublishedOn.Value;
            model.Body = this.Body;

            return model;
        }

    }
}
