namespace Dota2.MetaWeblog
{
    using System;

    public struct Enclosure
    {
        public int length;
        public string type;
        public string url;
    }

    public struct Source
    {
        public string name;
        public string url;
    }

    
    public struct Post
    {
        public string[] categories;
        public DateTime dateCreated;
        public string description;
        public Enclosure enclosure;
        public string link;
        public object mt_allow_comments;
        public object mt_allow_pings;
        public object mt_convert_breaks;
        public string mt_excerpt;
        public string mt_text_more;
        public string permalink;
        public object postid;
        public Source source;
        public string title;
        public string userid;
    }

    public struct CategoryInfo
    {
        public string categoryid;
        public string description;
        public string htmlUrl;
        public string rssUrl;
        public string title;
    }

    public struct Category
    {
        public string categoryId;
        public string categoryName;
    }

    public struct FileData
    {
        public byte[] bits;
        public string name;
        public string type;
    }

    public struct UrlData
    {
        public string url;
    }

    public struct BlogInfo
    {
        public string blogid;
        public string url;
        public string blogName;
    }

    public struct UserInfo
    {
        public string userid;
        public string firstname;
        public string lastname;
        public string nickname;
        public string email;
        public string url;
    }
}
