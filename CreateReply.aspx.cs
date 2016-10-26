using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["sessionID"] == null)
            Response.Redirect("Login.aspx");
        if (Session["post"] == null)
            Response.Redirect("Forum.aspx");

        lblPost.Text = "Replying to post '" + Session["post"] + "'";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        XMLForum forumDB = new XMLForum();

        String category = (String)Session["category"];
        String title = (String)Session["post"];
        String message = txtContent.Text;

        if ((title == "") || (message == ""))
            return;

        Dictionary<string, string> replyInfo = new Dictionary<string, string>();
        replyInfo.Add("content", message);
        replyInfo.Add("user", Request.Cookies["sessionID"].Value);

        forumDB.createReply(replyInfo, category, title);

        Response.Redirect("Post.aspx");
    }
}