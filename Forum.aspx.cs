using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Forum : System.Web.UI.Page
{


    XMLForum forumDB = new XMLForum();

    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (String category in forumDB.getCategories())
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            LinkButton link = new LinkButton();

            mainTable.Rows.Add(row); // Adds a row to the main table
            link.Text = category; // Sets the text of the LinkButton to category
            link.Click += new EventHandler(this.onCategoryClick);
            cell.Controls.Add(link); // Adds the LinkButton to the cell
            cell.Attributes.Add("class", "postsCell");
            row.Cells.Add(cell); // Adds the cell to the row
        }
    }


    protected void onCategoryClick(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        String category = lb.Text;
        Session["category"] = category;
        Response.Redirect("Posts.aspx");
    }
}
