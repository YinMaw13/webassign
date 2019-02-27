namespace WebsiteAssignment.Migrations.BlogDbContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebsiteAssignment.Models.BlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\BlogDbContext";
        }

        protected override void Seed(WebsiteAssignment.Models.BlogDbContext context)
        {
            context.Categories.AddOrUpdate(new Models.Category { Id = "cat1", Name = "International", UrlSeo = "international", Description = "International Category" });
            context.Categories.AddOrUpdate(new Models.Category { Id = "cat2", Name = "Business", UrlSeo = "business", Description = "Business Category" });
            context.Categories.AddOrUpdate(new Models.Category { Id = "cat3", Name = "Celebrity", UrlSeo = "celebrity", Description = "Celebrity Category" });
            context.Categories.AddOrUpdate(new Models.Category { Id = "cat4", Name = "Sport", UrlSeo = "sport", Description = "Sport Category" });
            context.Categories.AddOrUpdate(new Models.Category { Id = "cat5", Name = "Science", UrlSeo = "science", Description = "Science Category" });
            context.Categories.AddOrUpdate(new Models.Category { Id = "cat6", Name = "Health", UrlSeo = "health", Description = "Health Category" });

            context.Posts.AddOrUpdate(new Models.Post { Id = "post1", Title = "Rachel Maddow | MSNBC Talks about the Donald Trump Meeting with North Korea", Body = "Donald Trump and Kim Jong-Un meet in Vietnam to discuss denuclearization, the vague promise they made at their historic first summit. However, history may be repeating itself, as nuclear test sites were discovered months after the first summit. Will one destiny regress into fire and fury?", ShortDescription = "Vladimir Putin's Presence Looms Over Donald Trump's Meeting With North Korea", PostedOn = DateTime.Now, Meta = "International", UrlSeo = "international", Published = true });
            context.Posts.AddOrUpdate(new Models.Post { Id = "post2", Title = "What is Good Business?", Body = "It’s become easy to feel that all businesses are somehow bad and corrupt. Far from it. So long as they follow these six principles, any business can be good.", ShortDescription = "Corruptions in business and The Ethecial business. ", PostedOn = DateTime.Now, Meta = "Business", UrlSeo = "business", Published = true });
            context.Posts.AddOrUpdate(new Models.Post { Id = "post3", Title = "PewDiePie speaks out on YouTube’s response to pedophilic content", Body = "Youtube's widespread initiative to prevent videos that may endanger minors has caught some smaller content creators in the crossfire by inadvertently terminating channels or demonetizing videos that have nothing to do with pedophilic content. PewDiePie broke down the controversy and added his take saying that, although it's unfortunate that some channels are being wrongfully targeted, he appreciates YouTube taking decisive action against a larger problem.", ShortDescription = "Pewdiepie talking about problems on Youtube", PostedOn = DateTime.Now, Meta = "Celebrity", UrlSeo = "celebrity", Published = true });
            context.Posts.AddOrUpdate(new Models.Post { Id = "post4", Title = "Brendan Rodgers: Celtic boss set to join Leicester after permission for talks", Body = "Former Liverpool boss Rodgers is in the Midlands after discussions on Monday night and a deal to replace the sacked Claude Puel is believed to be close.Former boss Neil Lennon has agreed to take over at Celtic until the end of the season, and could be in charge for Wednesday's Scottish Premiership trip to Hearts. He will be assisted by current first-team coach John Kennedy.We're still waiting on hearing back from Leicester, Celtic chief executive Peter Lawwell told reporters.", ShortDescription = "Celtic boss Brendan Rodgers is expected to be confirmed as Leicester City's new manager after holding talks with the Premier League club.", PostedOn = DateTime.Now, Meta = "Sport", UrlSeo = "sport", Published = true });

            context.PostCategories.AddOrUpdate(new Models.PostCategory { PostId = "post1", CategoryId = "cat1" });
            context.PostCategories.AddOrUpdate(new Models.PostCategory { PostId = "post1", CategoryId = "cat3" });
            context.PostCategories.AddOrUpdate(new Models.PostCategory { PostId = "post2", CategoryId = "cat2" });
            context.PostCategories.AddOrUpdate(new Models.PostCategory { PostId = "post3", CategoryId = "cat3" });

            context.PostVideos.AddOrUpdate(new Models.PostVideo { Id = 1, PostId = "post1", VideoSiteName = "YouTube", VideoUrl = "https://www.youtube.com/embed/tp0S4tNaH-w", VideoThumbnail = "https://img.youtube.com/vi/tp0S4tNaH-w/maxresdefault.jpg" });
            context.PostVideos.AddOrUpdate(new Models.PostVideo { Id = 2, PostId = "post2", VideoSiteName = "YouTube", VideoUrl = "https://www.youtube.com/embed/otxYSGjMAnk", VideoThumbnail = "https://img.youtube.com/vi/otxYSGjMAnk/maxresdefault.jpg" });
            context.PostVideos.AddOrUpdate(new Models.PostVideo { Id = 3, PostId = "post3", VideoSiteName = "YouTube", VideoUrl = "https://www.youtube.com/embed/F882_Ih61Sc", VideoThumbnail = "https://img.youtube.com/vi/F882_Ih61Sc/maxresdefault.jpg" });
            context.PostVideos.AddOrUpdate(new Models.PostVideo { Id = 4, PostId = "post4", VideoSiteName = "YouTube", VideoUrl = "https://www.youtube.com/embed/8tPnX7OPo0Q	", VideoThumbnail = "https://www.telegraph.co.uk/content/dam/football/2019/02/25/TELEMMGLPICT000189546054_trans_NvBQzQNjv4Bqp0UK_jEh0acXsIxj-tvrXkplep6J7EAKiOYz13E1M5U.jpeg?imwidth=450" });

            //context.Comments.AddOrUpdate(new Models.Comment { Id = "cmt1", PageId = "post1", Body = "Vivamus hendrerit commodo pulvinar. In convallis nunc nec scelerisque sodales. Curabitur aliquam neque dolor, hendrerit cursus felis ultricies ac. Mauris ac justo vel lorem condimentum malesuada. Vivamus porttitor vestibulum lorem a luctus. Suspendisse in eleifend orci.", DateTime = DateTime.Now, UserName = "devsone" });
            //context.Comments.AddOrUpdate(new Models.Comment { Id = "cmt2", PageId = "post1", Body = "Suspendisse egestas risus eget posuere egestas. Nunc facilisis ligula et vestibulum pretium. Suspendisse potenti. Nulla facilisi. Integer mi lorem, efficitur quis viverra in, sollicitudin id urna. Maecenas scelerisque, tellus eget rutrum pulvinar, velit erat pulvinar risus, vitae convallis quam mi ut leo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Ut posuere lacus ex, eget tristique quam eleifend molestie.", DateTime = DateTime.Now, UserName = "mario" });
            //context.Comments.AddOrUpdate(new Models.Comment { Id = "cmt3", PageId = "post1", Body = "Integer lacinia ipsum magna, ac sodales libero porttitor at. Donec at enim felis. Ut bibendum lorem odio, quis ultricies elit eleifend ut. Fusce erat tellus, eleifend at gravida in, fermentum et tellus. Fusce at massa vehicula, maximus diam nec, lacinia lectus.", DateTime = DateTime.Now, UserName = "natash" });

            //context.Comments.AddOrUpdate(new Models.Comment { Id = "cmt4", PageId = "mainPage", Body = "Vivamus hendrerit commodo pulvinar. In convallis nunc nec scelerisque sodales. Curabitur aliquam neque dolor, hendrerit cursus felis ultricies ac. Mauris ac justo vel lorem condimentum malesuada. Vivamus porttitor vestibulum lorem a luctus. Suspendisse in eleifend orci.", DateTime = DateTime.Now, UserName = "devsone" });


            //context.Replies.AddOrUpdate(new Models.Reply { Id = "rep1", CommentId = "cmt3", DateTime = DateTime.Now, UserName = "flint", Body = "Cras sodales justo sit amet libero placerat consectetur. Duis hendrerit facilisis tempor. Nullam ut nisl nec neque posuere semper. Praesent vestibulum id purus quis maximus." });
            //context.Replies.AddOrUpdate(new Models.Reply { Id = "rep9", CommentId = "cmt3", DateTime = DateTime.Now, UserName = "anyav", Body = "Cras sodales justo sit amet libero placerat consectetur. Duis hendrerit facilisis tempor. Nullam ut nisl nec neque posuere semper. Praesent vestibulum id purus quis maximus." });
            //context.Replies.AddOrUpdate(new Models.Reply { Id = "rep2", CommentId = "cmt3", ParentReplyId = "rep1", DateTime = DateTime.Now, UserName = "devsone", Body = "Mauris pulvinar tristique libero id ornare. Quisque sit amet accumsan leo. Vestibulum dapibus elit sed lorem lacinia suscipit. In hac habitasse platea dictumst. Vivamus egestas leo eu nulla faucibus cursus." });
            //context.Replies.AddOrUpdate(new Models.Reply { Id = "rep3", CommentId = "cmt3", ParentReplyId = "rep2", DateTime = DateTime.Now, UserName = "kingkong", Body = "Suspendisse consequat dolor urna, sit amet accumsan lectus luctus eget. Vestibulum maximus ante vel placerat cursus. Nulla luctus augue ac vulputate aliquet." });
            //context.Replies.AddOrUpdate(new Models.Reply { Id = "rep4", CommentId = "cmt3", ParentReplyId = "rep3", DateTime = DateTime.Now, UserName = "hanley", Body = "Donec aliquam, sem a tincidunt tincidunt, orci velit mollis magna, vel auctor arcu augue nec risus. Integer luctus enim ac viverra luctus." });

            //context.Replies.AddOrUpdate(new Models.Reply { Id = "rep5", CommentId = "cmt2", DateTime = DateTime.Now, UserName = "taylor", Body = "Cras sodales justo sit amet libero placerat consectetur. Duis hendrerit facilisis tempor. Nullam ut nisl nec neque posuere semper. Praesent vestibulum id purus quis maximus." });
            //context.Replies.AddOrUpdate(new Models.Reply { Id = "rep6", CommentId = "cmt2", ParentReplyId = "rep5", DateTime = DateTime.Now, UserName = "devsone", Body = "Mauris pulvinar tristique libero id ornare. Quisque sit amet accumsan leo. Vestibulum dapibus elit sed lorem lacinia suscipit." });
            //context.Replies.AddOrUpdate(new Models.Reply { Id = "rep7", CommentId = "cmt2", ParentReplyId = "rep6", DateTime = DateTime.Now, UserName = "hanley", Body = "Suspendisse consequat dolor urna, sit amet accumsan lectus luctus eget. Vestibulum maximus ante vel placerat cursus. Nulla luctus augue ac vulputate aliquet." });
            //context.Replies.AddOrUpdate(new Models.Reply { Id = "rep8", CommentId = "cmt2", ParentReplyId = "rep7", DateTime = DateTime.Now, UserName = "taylor", Body = "Donec aliquam, sem a tincidunt tincidunt, orci velit mollis magna, vel auctor arcu augue nec risus. Integer luctus enim ac viverra luctus." });

        }
    }
}
