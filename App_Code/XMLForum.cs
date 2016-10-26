using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for XMLForum
/// </summary>
public class XMLForum
{
	public XMLForum()
	{
	}

    private string xmlPath
    {
        get { return ConfigurationManager.AppSettings["XMLDBForum"]; }
    }

    public bool createPost(Dictionary<string, string> postInfo, String category)
    {
        try
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);

            // Select the specified category title
            XmlNode categoryRoot = xmlDocument.SelectSingleNode(String.Format("Forum/Category[title='{0}']", category));
            XmlNode posts = categoryRoot.SelectSingleNode(String.Format("Posts"));

            XmlNode newPost = posts.AppendChild(xmlDocument.CreateNode(XmlNodeType.Element, "Post", null));

            foreach (KeyValuePair<string, string> entry in postInfo)
            {
                XmlElement node = xmlDocument.CreateElement(entry.Key.ToString());
                node.InnerText = entry.Value.ToString();
                newPost.AppendChild(node);
            }

            posts.AppendChild(newPost);
            xmlDocument.Save(xmlPath);

            return true;
        }
        catch { return false; }
    }

    public void createReply(Dictionary<string, string> replyInfo, String category, String post)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlPath);

        XmlNode root = xmlDocument.SelectSingleNode(String.Format("Forum/Category[title='{0}']/Posts/Post[title='{1}']", category, post));
        XmlNode newReply = root.AppendChild(xmlDocument.CreateNode(XmlNodeType.Element, "Reply", null));

        foreach (KeyValuePair<string, string> entry in replyInfo)
        {
            XmlElement node = xmlDocument.CreateElement(entry.Key.ToString());
            node.InnerText = entry.Value.ToString();
            newReply.AppendChild(node);
        }

        root.AppendChild(newReply);
        xmlDocument.Save(xmlPath);
    }

    public String readPost(String category, String title)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlPath);

        XmlNode node = xmlDocument.SelectSingleNode(String.Format("Forum/Category[title='{0}']/Posts/Post[title='{1}']", category, title));

        return node["content"].InnerText;
    }

    public String getPostedBy(String category, String title)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlPath);

        XmlNode node = xmlDocument.SelectSingleNode(String.Format("Forum/Category[title='{0}']/Posts/Post[title='{1}']", category, title));

        return node["user"].InnerText;
    }

    public Dictionary<string, string> getPostReplies(String category, String title)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlPath);

        XmlNode node = xmlDocument.SelectSingleNode(String.Format("Forum/Category[title='{0}']/Posts/Post[title='{1}']", category, title));

        if (node["Reply"] != null)
        {
            Dictionary<string, string> dReplies = new Dictionary<string,string>();

            int replyID = 900; // Fix for adding the same user to Dictionary multiple times
            XmlNodeList replies = node.SelectNodes("Reply");
            foreach (XmlNode reply in replies)
            {
                dReplies.Add(reply["user"].InnerText + replyID.ToString(), reply["content"].InnerText);
                replyID--;
            }

            return dReplies;
        }
            
        return null;
    }

    public List<String> getCategories()
    {
        List<String> categories = new List<string>();
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlPath);

        XmlNode root = xmlDocument.SelectSingleNode("Forum");
        foreach (XmlNode category in root)
        {
            if (category["title"] != null)
                categories.Add(category["title"].InnerText);
            else
                categories.Add("There was an error!");
        }

        return categories;
    }

    public List<String> getPosts(String category)
    {
        List<String> posts = new List<String>();
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlPath);

        XmlNode root = xmlDocument.SelectSingleNode(String.Format("Forum/Category[title='{0}']/Posts", category));
        foreach (XmlNode post in root)
        {
            posts.Add(post["title"].InnerText);
        }

        return posts;
    }
}