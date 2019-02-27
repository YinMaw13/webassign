using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using WebsiteAssignment.DAL;
using WebsiteAssignment.Models;

namespace WebsiteAssignment.Controllers
{
    public class BlogController : Controller
    {

        private IBlogRepository _blogRepository;
        public static List<BlogViewModel> postList = new List<BlogViewModel>();
        public static List<AllPostsViewModel> allPostsList = new List<AllPostsViewModel>();
        public static List<AllPostsViewModel> checkCatList = new List<AllPostsViewModel>();
        public static List<AllPostsViewModel> checkTagList = new List<AllPostsViewModel>();

        public BlogController()
        {
            _blogRepository = new BlogRepository(new BlogDbContext());
        }
        public BlogController(IBlogRepository blogRepository, ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _blogRepository = blogRepository;

        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(int? page, string sortOrder, string searchString, string[] searchCategory, string[] searchTag)
        {
            checkCatList.Clear();
            checkTagList.Clear();
            CreateCatAndTagList();

            BlogViewModel model = new BlogViewModel();
            model.PagedBlogViewModel = CreatePagedBlogViewModel(page, sortOrder, searchString, searchCategory, searchTag);
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult Posts()
        {
            return PartialView();
        }
        public IPagedList<BlogViewModel> CreatePagedBlogViewModel(int? page, string sortOrder, string searchString, string[] searchCategory, string[] searchTag)
        {
            postList.Clear();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentSearchString = searchString;
            ViewBag.CurrentSearchCategory = searchCategory;
            ViewBag.CurrentSearchTag = searchTag;
            ViewBag.DateSortParm = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewBag.TitleSortParm = sortOrder == "Title" ? "title_desc" : "Title";

            var posts = _blogRepository.GetPosts();
            foreach (var post in posts)
            {
                var postCategories = GetPostCategories(post);
                var postTags = GetPostTags(post);

                postList.Add(new BlogViewModel()
                { Post = post, Modified = post.Modified, Title = post.Title, ShortDescription = post.ShortDescription, PostedOn = post.PostedOn, ID = post.Id, PostCategories = postCategories, PostTags = postTags, UrlSlug = post.UrlSeo });

            }

            if (searchString != null)
            {
                postList = postList.Where(x => x.Title.ToLower().Contains(searchString.ToLower())).ToList();
            }

            if (searchCategory != null)
            {
                List<BlogViewModel> newlist = new List<BlogViewModel>();
                foreach (var catName in searchCategory)
                {
                    foreach (var item in postList)
                    {
                        if (item.PostCategories.Where(x => x.Name == catName).Any())
                        {
                            newlist.Add(item);
                        }
                    }
                    foreach (var item in checkCatList)
                    {
                        if (item.Category.Name == catName)
                        {
                            item.Checked = true;
                        }
                    }
                }
                postList = postList.Intersect(newlist).ToList();
            }

            if (searchTag != null)
            {
                List<BlogViewModel> newlist = new List<BlogViewModel>();
                foreach (var tagName in searchTag)
                {
                    foreach (var item in postList)
                    {
                        if (item.PostTags.Where(x => x.Name == tagName).Any())
                        {
                            newlist.Add(item);
                        }
                    }
                    foreach (var item in checkTagList)
                    {
                        if (item.Tag.Name == tagName)
                        {
                            item.Checked = true;
                        }
                    }
                }
                postList = postList.Intersect(newlist).ToList();
            }

            switch (sortOrder)
            {
                case "date_desc":
                    postList = postList.OrderByDescending(x => x.PostedOn).ToList();
                    break;
                case "Title":
                    postList = postList.OrderBy(x => x.Title).ToList();
                    break;
                case "title_desc":
                    postList = postList.OrderByDescending(x => x.Title).ToList();
                    break;
                default:
                    postList = postList.OrderBy(x => x.PostedOn).ToList();
                    break;
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return postList.ToPagedList(pageNumber, pageSize);
            }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult AllPosts(int? page, string sortOrder, string searchString, string[] searchCategory, string[] searchTag)
        {
            allPostsList.Clear();
            checkCatList.Clear();
            checkTagList.Clear();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentSearchString = searchString;
            ViewBag.CurrentSearchCategory = searchCategory;
            ViewBag.CurrentSearchTag = searchTag;
            ViewBag.DateSortParm = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewBag.TitleSortParm = sortOrder == "Title" ? "title_desc" : "Title";

            var posts = _blogRepository.GetPosts();
            foreach (var post in posts)
            {
                var postCategories = GetPostCategories(post);
                var postTags = GetPostTags(post);
                allPostsList.Add(new AllPostsViewModel() { PostId = post.Id, Date = post.PostedOn, Description = post.ShortDescription, Title = post.Title, PostCategories = postCategories, PostTags = postTags, UrlSlug = post.UrlSeo });
            }

            if (searchString != null)
            {
                allPostsList = allPostsList.Where(x => x.Title.ToLower().Contains(searchString.ToLower())).ToList();
            }

            CreateCatAndTagList();

            if (searchCategory != null)
            {
                List<AllPostsViewModel> newlist = new List<AllPostsViewModel>();
                foreach (var catName in searchCategory)
                {
                    foreach (var item in allPostsList)
                    {
                        if (item.PostCategories.Where(x => x.Name == catName).Any())
                        {
                            newlist.Add(item);
                        }
                    }
                    foreach (var item in checkCatList)
                    {
                        if (item.Category.Name == catName)
                        {
                            item.Checked = true;
                        }
                    }
                }
                allPostsList = allPostsList.Intersect(newlist).ToList();
            }

            if (searchTag != null)
            {
                List<AllPostsViewModel> newlist = new List<AllPostsViewModel>();
                foreach (var tagName in searchTag)
                {
                    foreach (var item in allPostsList)
                    {
                        if (item.PostTags.Where(x => x.Name == tagName).Any())
                        {
                            newlist.Add(item);
                        }
                    }
                    foreach (var item in checkTagList)
                    {
                        if (item.Tag.Name == tagName)
                        {
                            item.Checked = true;
                        }
                    }
                }
                allPostsList = allPostsList.Intersect(newlist).ToList();
            }

            switch (sortOrder)
            {
                case "date_desc":
                    allPostsList = allPostsList.OrderByDescending(x => x.Date).ToList();
                    break;
                case "Title":
                    allPostsList = allPostsList.OrderBy(x => x.Title).ToList();
                    break;
                case "title_desc":
                    allPostsList = allPostsList.OrderByDescending(x => x.Title).ToList();
                    break;
                default:
                    allPostsList = allPostsList.OrderBy(x => x.Date).ToList();
                    break;
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View("AllPosts", allPostsList.ToPagedList(pageNumber, pageSize));

        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Post(string slug)
        {
            PostViewModel model = new PostViewModel();
            var posts = GetPosts();
            var postid = _blogRepository.GetPostIdBySlug(slug);
            var post = _blogRepository.GetPostById(postid);
            var videos = GetPostVideos(post);
            var firstPostId = posts.OrderBy(i => i.PostedOn).First().Id;
            var lastPostId = posts.OrderBy(i => i.PostedOn).Last().Id;
            var nextId = posts.OrderBy(i => i.PostedOn).SkipWhile(i => i.Id != postid).Skip(1).Select(i => i.Id).FirstOrDefault();
            var previousId = posts.OrderBy(i => i.PostedOn).TakeWhile(i => i.Id != postid).Select(i => i.Id).LastOrDefault();
            model.FirstPostId = firstPostId;
            model.LastPostId = lastPostId;
            model.PreviousPostSlug = posts.Where(x => x.Id == previousId).Select(x => x.UrlSeo).FirstOrDefault();
            model.NextPostSlug = posts.Where(x => x.Id == nextId).Select(x => x.UrlSeo).FirstOrDefault();
            model.ID = post.Id;
            model.PostCount = posts.Count();
            model.UrlSeo = post.UrlSeo;
            model.Videos = videos;
            model.Title = post.Title;
            model.Body = post.Body;
            //model.CommentViewModel = CreateCommentViewModel(post.Id, sortOrder);
            return View(model);
        }
        public ActionResult Feed()
        {
            var blogTitle = "Your Blog Title";
            var blogDescription = " Your Blog Description.";
            var blogUrl = "http://yourblog.com ";

            var posts = _blogRepository.GetPosts().Select(
                p => new SyndicationItem(
                    p.Title,
                    p.ShortDescription,
                  new Uri(blogUrl)
                )
                );

            var feed = new SyndicationFeed(blogTitle, blogDescription, new Uri(blogUrl), posts)
            {
                Copyright = new TextSyndicationContent(string.Format("Copyright © {0}", blogTitle)),
                Language = "en-US"
            };
            var feedFormatter = new Rss20FeedFormatter(feed);
            return new FeedResult(feedFormatter);

        }
        #region Helpers
        public IList<Post> GetPosts()
        {
            return _blogRepository.GetPosts();
        }
        public IList<Category> GetPostCategories(Post post)
        {
            return _blogRepository.GetPostCategories(post);
        }
        public IList<Tag> GetPostTags(Post post)
        {
            return _blogRepository.GetPostTags(post);
        }
        public IList<PostVideo> GetPostVideos(Post post)
        {
            return _blogRepository.GetPostVideos(post);
        }

        public void CreateCatAndTagList()
        {
            foreach (var ct in _blogRepository.GetCategories())
            {
                checkCatList.Add(new AllPostsViewModel { Category = ct, Checked = false });
            }
            foreach (var tg in _blogRepository.GetTags())
            {
                checkTagList.Add(new AllPostsViewModel { Tag = tg, Checked = false });
            }
        }

        #endregion


    }
}