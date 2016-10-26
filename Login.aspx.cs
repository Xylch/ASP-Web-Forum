using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["sessionID"] != null)
        {
            // Replace with redirect **
            Response.Redirect("Forum.aspx");
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        XMLUsers userDB = new XMLUsers();

        if (userDB.getNode(txtUsername.Text, "password") == txtPassword.Text)
        {
            String sessID = userDB.getNode(txtUsername.Text, "sessionID");
            Response.SetCookie(Helper.createCookie("sessionID", sessID));
            Response.Redirect("Forum.aspx");
            return;
        }

        // Replace with Validation Control **
        Response.Write("Incorrect Password!");

    }
}