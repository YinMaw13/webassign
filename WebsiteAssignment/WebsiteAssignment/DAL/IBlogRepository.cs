using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteAssignment.Models;


namespace WebsiteAssignment.DAL
{
    public interface IBlogRepository : IDisposable
    {


        IList<Post> GetPosts();
        IList<Category> GetPostCategories(Post post);
        IList<Tag> GetPostTags(Post post);
        IList<PostVideo> GetPostVideos(Post post);
        IList<Tag> GetTags();
        IList<Category> GetCategories();
        Post GetPostById(string postid);
        string GetPostIdBySlug(string slug);

    }


}