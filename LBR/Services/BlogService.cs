using LBR.Class;
using LBR.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LBR.Services
{
    public class BlogService : IBlogService
    {
        public IEnumerable<BlogComment> GetBlogComments(int blogPostID)
        {
            string sql = string.Format("select * from BlogComment where BlogPostID = {0} order by CommentedOn desc", blogPostID);

            DataTable table = DataAccess.DataConnection(sql);

            if (table == null)
                return null;

            List<BlogComment> blogCommentList = new List<BlogComment>();

            foreach (DataRow row in table.Rows)
            {
                blogCommentList.Add(GetBlogCommentFromRow(row));
            }

            return blogCommentList;
        }

        public BlogPost GetBlogPost(int blogPostID)
        {
            string sql = string.Format("select * from BlogPosts where BlogPostID = {0}", blogPostID);

            DataTable table = DataAccess.DataConnection(sql);

            if (table == null)
                return null;

            List<BlogPost> blogPostList = new List<BlogPost>();

            foreach (DataRow row in table.Rows)
            {
                blogPostList.Add(GetBlogPostFromRow(row));
            }

            if (blogPostList.Count > 0)
                return blogPostList[0];
            else
                return null;
        }

        public IEnumerable<BlogPost> GetBlogPosts()
        {
            string sql = "select * from BlogPosts order by PublishedOn desc";

            DataTable table = DataAccess.DataConnection(sql);

            if (table == null)
                return null;

            List<BlogPost> blogPostList = new List<BlogPost>();

            foreach (DataRow row in table.Rows)
            {
                blogPostList.Add(GetBlogPostFromRow(row));
            }

            if (blogPostList.Count > 0)
                return blogPostList;
            else
                return null;
        }

        private BlogPost GetBlogPostFromRow(DataRow row)
        {
            BlogPost post = new BlogPost();

            post.BlogPostId = row["BlogPostId"] != null ? int.Parse(row["BlogPostId"].ToString()) : 0;
            post.Title = row["Title"].ToString();
            post.Body = row["Body"].ToString();
            post.PublishedOn = row["PublishedOn"] != null ? DateTime.Parse(row["PublishedOn"].ToString()) : (DateTime?)null;

            return post;
        }

        private BlogComment GetBlogCommentFromRow(DataRow row)
        {
            BlogComment comment = new BlogComment();

            comment.BlogPostId = row["CommentId"] != null ? int.Parse(row["CommentId"].ToString()) : 0;
            comment.BlogPostId = row["BlogPostId"] != null ? int.Parse(row["BlogPostId"].ToString()) : 0;
            comment.Comment = row["Comment"].ToString();
            comment.CommentedOn = row["CommentedOn"] != null ? DateTime.Parse(row["CommentedOn"].ToString()) : (DateTime?)null;

            return comment;
        }
    }
}
