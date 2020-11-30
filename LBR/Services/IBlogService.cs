using LBR.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBR.Services
{
    public interface IBlogService
    {
        public IEnumerable<BlogPost> GetBlogPosts();

        public BlogPost GetBlogPost(int blogPostID);

        public IEnumerable<BlogComment> GetBlogComments(int blogPostID);

    }
}
