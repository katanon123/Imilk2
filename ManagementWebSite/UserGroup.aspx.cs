using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl Usermanagement = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li7");
            Usermanagement.Attributes.Add("class", "active");

            System.Web.UI.HtmlControls.HtmlGenericControl Usergroup = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li8");
            Usergroup.Attributes.Add("class", "active");


            getdatausergroup();
        }
    }

    public void getdatausergroup()
    {
        this.UserGroupRepeater.DataSource = new CommonClassLibrary.CommonDataSetTableAdapters.UserGroupTableAdapter().GetData();
        this.UserGroupRepeater.DataBind();
    }

    protected void linkEdit(object sender, CommandEventArgs e)
    {
        int ID = int.Parse(e.CommandArgument.ToString());
        Response.Redirect("~/EditUserGroup.aspx?Id=" + ID);
    }

    protected void linkDelete(object sender, CommandEventArgs e)
    {
        int ID = int.Parse(e.CommandArgument.ToString());
        if (new CommonClassLibrary.CommonDataSetTableAdapters.UserGroupTableAdapter().DeleteQuery(ID) == 1)
        {
            this.SuccessLabel.Text = "ลบข้อมูลสำเร็จ";
            this.SuccessPanel.Visible = true;
            this.ErrorPanel.Visible = false;
            getdatausergroup();
        }
        else
        {
            this.SuccessPanel.Visible = false;
            this.ErrorPanel.Visible = true;
            this.ErrorLabel.Text = "ลบข้อมูลไม่สำเร็จ";
        }
    }
    protected void SuccessLinkButton_Click(object sender, EventArgs e)
    {
        this.SuccessPanel.Visible = false;
    }

    protected void ErrorLinkButton_Click(object sender, EventArgs e)
    {
        this.ErrorPanel.Visible = false;
    }
}