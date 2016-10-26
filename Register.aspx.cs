using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        XMLUsers userDB = new XMLUsers();

        // Check if user already exists
        String username = txtUsername.Text;
        if (userDB.findUser(username))
        {
            // Replace following line with Validation Control **
            Response.Write("Username already in use.");
            return;
        }

        // Check if password and confirmation match
        String password = txtPassword.Text;
        if (password != txtPasswordConfirm.Text)
        {
            // Replace following line with Validation Control **
            Response.Write("Password and password confirmation do not match.");
        }

        // Generate session ID
        String sessID = Helper.createSessionID();

        // Create Dictionary of user info and add to database
        Dictionary<string, string> userInfo = new Dictionary<string, string>();
        userInfo.Add("username", username);
        userInfo.Add("password", password);
        userInfo.Add("sessionID", sessID);
        userDB.AddUser(userInfo);

        // Sets the sessionID as a cookie to help keep user logged in
        Response.SetCookie(Helper.createCookie("sessionID", sessID));

        Response.Redirect("Forum.aspx");
    }
}