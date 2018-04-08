using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.UsernameTextBox.Text = "";
            this.PasswordTextBox.Text = "";
            this.NotificationPanel.Visible = false;
        }
        Button lbButton = form1.FindControl("submitButton") as Button;
        form1.DefaultButton = lbButton.UniqueID;
    }

    void SetTicket(CommonClassLibrary.CommonDataSet.UserAccountRow userItem)
    {
        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(userItem.Id.ToString(), true, 60 * 24);
        string hasCookies = FormsAuthentication.Encrypt(ticket);

        string cookieAuthenName = FormsAuthentication.FormsCookieName;
        HttpCookie cookieAuthen = new HttpCookie(cookieAuthenName, hasCookies);
        Response.Cookies.Add(cookieAuthen);

        string returnUrl = "~/Dashboard.aspx";
        if (Request["ReturnUrl"] != null)
        {
            returnUrl = Request["ReturnUrl"];
        }

        HttpCookie cookieUserDetail = new HttpCookie(Resources.Resource.CookieName);
        cookieUserDetail.Values["Id"] = userItem.Id.ToString();
        cookieUserDetail.Values["FirstName"] = userItem.FirstName;
        cookieUserDetail.Values["LastName"] = userItem.LastName;
        cookieUserDetail.Values["Email"] = userItem.Email;
        cookieUserDetail.Values["Password"] = userItem.Password;
        cookieUserDetail.Values["MobilePhoneNumber"] = userItem.MobilePhoneNumber;
        cookieUserDetail.Values["Status"] = userItem.Status.ToString();

        cookieUserDetail.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Add(cookieUserDetail);

        Response.Redirect(returnUrl);
    }

    protected void submitButton_Click1(object sender, EventArgs e)
    {
        if (this.UsernameTextBox.Text != "")
        {
            if (this.PasswordTextBox.Text != "")
            {
                CommonClassLibrary.CommonDataSet.UserAccountDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.UserAccountTableAdapter().GetDataBySignIn(this.UsernameTextBox.Text, this.PasswordTextBox.Text);
                if (collection.Rows.Count > 0)
                {
                    foreach (CommonClassLibrary.CommonDataSet.UserAccountRow item in collection)
                    {


                        this.SetTicket(item);
                        break;
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "ชื่อผู้ใช้ หรือ รหัสผ่าน ไม่ถูกต้อง" + "');", true);
                    PasswordTextBox.Focus();
                    return;
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "กรุณากรอก รหัสผ่าน" + "');", true);
                PasswordTextBox.Focus();
                return;
            }

        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "กรุณากรอก ชื่อผู้ใข้" + "');", true);
            UsernameTextBox.Focus();
            return;
        }
    }
}



