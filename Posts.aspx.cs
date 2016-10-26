using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Categories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["category"] != null)
        {
            XMLForum forumDB = new XMLForum();

            // Cycle through each post in category that was clicked on
            foreach (String post in forumDB.getPosts((String)Session["category"]))
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                LinkButton link = new LinkButton();

                mainTable.Rows.Add(row);
                link.Text = post;
                link.Click += new EventHandler(this.onPostClick);
                cell.Controls.Add(link);
                cell.Attributes.Add("class", "postsCell");
                row.Cells.Add(cell);
            }
        }
        else
            Response.Redirect("Forum.aspx");
    }

    protected void onPostClick(object sender, EventArgs e)
    {
        mainTable.Controls.Clear();
        LinkButton lb = (LinkButton)sender;
        String post = lb.Text;
        Session["post"] = post;
        Response.Redirect("Post.aspx");
    }
}