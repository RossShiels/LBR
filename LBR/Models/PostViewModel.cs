using LBR.Class;
using System;
using System.Collections.Generic;

namespace LBR.Models
{
    public class PostViewModel
    {
        public int BlogPostId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime PublishedOn { get; set; }

        public List<BlogComment> Comments { get; set; }

    }
}
