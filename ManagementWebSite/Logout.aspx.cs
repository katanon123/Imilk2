using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookies = Request.Cookies[Resources.Resource.CookieName];
        if (cookies != null)
        {
            string owner = cookies.Values["FirstName"].ToString();
            HttpCookie cookieOwner = new HttpCookie(owner);
            cookieOwner.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(cookieOwner);
        }
        HttpCookie cookieUserDetail = new HttpCookie(Resources.Resource.CookieName);
        cookieUserDetail.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(cookieUserDetail);
        Response.Redirect("~/Login.aspx");
    }
}