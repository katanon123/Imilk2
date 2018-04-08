using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditUserGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl Usermanagement = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li7");
            Usermanagement.Attributes.Add("class", "active");

            System.Web.UI.HtmlControls.HtmlGenericControl Usergroup = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li8");
            Usergroup.Attributes.Add("class", "active");


            int ID = int.Parse(Request.QueryString["Id"]);
            CommonClassLibrary.CommonDataSet.UserGroupDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.UserGroupTableAdapter().GetDataByID(ID);
            if (collection.Rows.Count > 0)
            {
                foreach (CommonClassLibrary.CommonDataSet.UserGroupRow item in collection)
                {
                    this.NameEditUserGroup_TextBox.Text = item.Name;
                }
            }
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
        int ID = int.Parse(Request.QueryString["Id"]);
        if (new CommonClassLibrary.CommonDataSetTableAdapters.UserGroupTableAdapter().UpdateQuery(this.NameEditUserGroup_TextBox.Text, DateTime.Now, DateTime.Now, 1, ID) == 1)
        {
            this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
            this.SuccessPanel.Visible = true;
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