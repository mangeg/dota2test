namespace Dota2.MetaWeblog
{
    public interface IMetaWeblog
    {
        bool EditPost(
            string postid,
            string username,
            string password,
            Post post,
            bool publish );
        CategoryInfo[] GetCategories(
            string blogid,
            string username,
            string password );
        Post GetPost(
            string postid,
            string username,
            string password );
        Post[] GetRecentPosts(
            string blogid,
            string username,
            string password,
            int numberOfPosts );
        string NewPost(
            string blogid,
            string username,
            string password,
            Post post,
            bool publish );
        UrlData NewMediaObject(
            string blogid,
            string username,
            string password,
            FileData file );
        bool DeletePost( string key, string postid, string username, string password, bool publish );
        BlogInfo[] GetUsersBlogs( string key, string username, string password );
        UserInfo GetUserInfo( string key, string username, string password );
    }
}
