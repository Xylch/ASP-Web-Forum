using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForumPostAddTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["sessionID"] == null)
            Response.Redirect("Login.aspx");
        if (Session["category"] == null)
            Response.Redirect("Forum.aspx");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        XMLForum forumDB = new XMLForum();

        String category = (String)Session["category"];
        String title = txtTitle.Text;
        String message = txtMessage.Text;

        if ((title == "") || (message == ""))
            return;

        Dictionary<string, string> postInfo = new Dictionary<string, string>();
        postInfo.Add("title", title);
        postInfo.Add("content", message);
        postInfo.Add("user", Request.Cookies["sessionID"].Value);

        forumDB.createPost(postInfo, category);

        Session["post"] = title;
        Response.Redirect("Post.aspx");
    }
}