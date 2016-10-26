using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["post"] != null)
        {
            XMLForum forumDB = new XMLForum();
            XMLUsers userDB = new XMLUsers();

            TableRow rowTitle = new TableRow();
            TableRow rowContent = new TableRow();
            TableCell cellTitle = new TableCell();
            TableCell cellBy = new TableCell();
            TableCell cellContent = new TableCell();
            TableCell cellReplyButton = new TableCell();
            
            Button btnReply = new Button();
            btnReply.Click += new EventHandler(this.onReplyClick);
            btnReply.Text = "Reply";

            mainTable.Rows.Add(rowTitle);
            mainTable.Rows.Add(rowContent);

            String category = (String)Session["category"];
            String title = (String)Session["post"];
            String postBy = userDB.getUserFromSessionID(forumDB.getPostedBy(category, title));

            cellTitle.Text = title;
            cellBy.Text = "Posted by " + postBy;
            cellContent.Text = forumDB.readPost(category, title);
            cellReplyButton.Controls.Add(btnReply);

            cellTitle.Attributes.Add("class", "postTitle");
            cellBy.Attributes.Add("class", "postBy");
            cellReplyButton.Attributes.Add("class", "postBy");

            rowTitle.Cells.Add(cellTitle);
            rowTitle.Cells.Add(cellReplyButton);
            rowTitle.Attributes.Add("class", "postTitleRow");
            rowContent.Cells.Add(cellContent);
            rowContent.Cells.Add(cellBy);
            rowContent.Attributes.Add("class", "postContentRow");

            if (forumDB.getPostReplies(category, title) != null)
            {
                TableRow rowReply;
                TableCell cellReplyContent;
                TableCell cellReplyBy;
                String replyBy;

                foreach (var pair in forumDB.getPostReplies(category, title))
                {
                    rowReply = new TableRow();
                    cellReplyContent = new TableCell();
                    cellReplyBy = new TableCell();

                    mainTable.Rows.Add(rowReply);
                    rowReply.Attributes.Add("class", "postReplyRow");

                    replyBy = pair.Key;
                    replyBy = replyBy.Substring(0, replyBy.Length - 3);
                    replyBy = userDB.getUserFromSessionID(replyBy);

                    cellReplyContent.Text = pair.Value;
                    cellReplyBy.Text = "Posted by " + replyBy;
                    cellReplyBy.Attributes.Add("class", "postBy");

                    rowReply.Cells.Add(cellReplyContent);
                    rowReply.Cells.Add(cellReplyBy);
                }
            }
        }
        else
            Response.Redirect("Forum.aspx");
    }

    protected void onReplyClick(object sender, EventArgs e)
    {
        Response.Redirect("CreateReply.aspx");
    }
}