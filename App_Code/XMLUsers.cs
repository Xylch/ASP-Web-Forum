using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Xml;
using System.Collections;

/// <summary>
/// Summary description for XMLUsers
/// </summary>
public class XMLUsers
{
	public XMLUsers()
	{
	}

    private string xmlPath
    {
        get { return ConfigurationManager.AppSettings["XMLDBUsers"]; }
    }

    public bool AddUser(Dictionary<string, string> userInfo)
    {
        try
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);

            XmlNode newUser = xmlDocument.CreateNode(XmlNodeType.Element, "User", null);

            foreach (KeyValuePair<string, string> entry in userInfo)
            {
                XmlElement node = xmlDocument.CreateElement(entry.Key.ToString());
                node.InnerText = entry.Value.ToString();
                newUser.AppendChild(node);
            }

            XmlNode root = xmlDocument.DocumentElement;
            root.AppendChild(newUser);
            xmlDocument.Save(xmlPath);

            return true;
        }
        catch { return false; }
    }

    public bool RemoveUser(String name)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlPath);

        XmlNode node = xmlDocument.SelectSingleNode(String.Format("Users/User[username='{0}']", name));
        if (node != null)
        {
            node.ParentNode.RemoveChild(node);
            xmlDocument.Save(xmlPath);
            return true;
        }

        return false;
    }

    public bool findUser(String name)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlPath);

        XmlNode node = xmlDocument.SelectSingleNode(String.Format("Users/User[username='{0}']", name));
        if (node != null) return true;
        return false;
    }

    public String getUserFromSessionID(String sessID)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlPath);

        XmlNode node = xmlDocument.SelectSingleNode(String.Format("Users/User[sessionID='{0}']", sessID));
        return node["username"].InnerText;
    }

    public string getNode(String userName, String nodeName)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlPath);

        XmlNodeList nodes = xmlDocument.SelectNodes("Users/User");

        // return string contained in nodeName for the specified userName
        foreach (XmlNode node in nodes)
            if (node["username"].InnerText == userName)
                return node[nodeName].InnerText;

        return null;
    }
}