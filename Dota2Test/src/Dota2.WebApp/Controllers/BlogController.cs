namespace Dota2.WebApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using MetaWeblog;
    using Microsoft.AspNet.Mvc;
    using XmlRpc;

    [Route( "/api/blog" )]
    public class BlogController : Controller
    {
        [HttpPost]
        public IActionResult EditPost( string postid, string username, string password, Post post, bool publish )
        {
            return new XmlRpcResult( true );
        }

        [HttpPost]
        public IActionResult GetCategories( string blogid, string username, string password )
        {
            var ret = new List<CategoryInfo>();
            ret.Add( new CategoryInfo {
                categoryid = Guid.NewGuid().ToString("n"),
                description = "The Desc",
                htmlUrl = "http://test",
                title = "The title"
            } );
            return new XmlRpcResult( ret.ToArray() );
        }

        [HttpPost]
        private Post GetPost( string postid, string username, string password )
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        private Post[] GetRecentPosts( string blogid, string username, string password, int numberOfPosts )
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult NewPost( string blogid, string username, string password, Post post, bool publish )
        {
            return new XmlRpcResult( Guid.NewGuid().ToString( "N" ) );
        }

        [HttpPost]
        private UrlData NewMediaObject( string blogid, string username, string password, FileData file )
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        private bool DeletePost( string key, string postid, string username, string password, bool publish )
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult GetUsersBlogs( string key, string username, string password )
        {
            var ret = new List<BlogInfo>();
            ret.Add(
                new BlogInfo
                {
                    blogName = "asfa",
                    blogid = "asfs",
                    url = ""
                } );

            return new XmlRpcResult( ret.ToArray() );
        }

        [HttpPost]
        private UserInfo GetUserInfo( string key, string username, string password )
        {
            throw new NotImplementedException();
        }
    }
}
