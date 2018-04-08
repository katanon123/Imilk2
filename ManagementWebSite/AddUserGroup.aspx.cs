using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddUserGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           System.Web.UI.HtmlControls.HtmlGenericControl Usermanagement = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li7");
            Usermanagement.Attributes.Add("class", "active");

            System.Web.UI.HtmlControls.HtmlGenericControl Usergroup = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li8");
            Usergroup.Attributes.Add("class", "active");
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

    protected void AddButton_Click(object sender, EventArgs e)
    {
        if (new CommonClassLibrary.CommonDataSetTableAdapters.UserGroupTableAdapter().InsertQuery(NameUserGroup_TextBox.Text, DateTime.Now, DateTime.Now, 1) == 1)
        {
            this.SuccessPanel.Visible = true;
            this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
            this.ErrorPanel.Visible = false;
        }
        else
        {
            this.ErrorPanel.Visible = true;
            this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
            this.SuccessPanel.Visible = false;
        }
    }
}