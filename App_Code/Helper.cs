using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

/// <summary>
/// Summary description for Helper
/// </summary>
public class Helper
{
	public Helper()
	{
	}

    public static String createSessionID()
    {
        SessionIDManager manager = new SessionIDManager();
        return manager.CreateSessionID(System.Web.HttpContext.Current);
    }

    public static HttpCookie createCookie(String name, String value)
    {
        HttpCookie cookie = new HttpCookie(name);
        cookie.Value = value;
        return cookie;
    }
}