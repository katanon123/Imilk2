using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class approve : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl Usermanagement = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li7");
            Usermanagement.Attributes.Add("class", "active");

            System.Web.UI.HtmlControls.HtmlGenericControl Useraccount = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li14");
            Useraccount.Attributes.Add("class", "active");

            getdatauseraccount();
        }
    }

    public void getdatauseraccount()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Id");
        dt.Columns.Add("FirstName");
        dt.Columns.Add("LastName");
        dt.Columns.Add("Email");
        dt.Columns.Add("Password");
        dt.Columns.Add("MobilePhone");
        dt.Columns.Add("UserGroup");
        dt.Columns.Add("Urlimage");
  string urlImage = "Image/innofood.jpg";
        CommonClassLibrary.CommonDataSet.UserAccountDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.UserAccountTableAdapter().GetDataByStatus100();
        foreach (CommonClassLibrary.CommonDataSet.UserAccountRow item in collection)
        {
            CommonClassLibrary.CommonDataSet.AccountGroupDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.AccountGroupTableAdapter().GetDataByUserAccount(item.Id);
            if (collection2.Rows.Count > 1)
            {
                string usergroup = "";
              
                foreach (CommonClassLibrary.CommonDataSet.AccountGroupRow item2 in collection2)
                {
                    CommonClassLibrary.CommonDataSet.UserGroupDataTable collection3 = new CommonClassLibrary.CommonDataSetTableAdapters.UserGroupTableAdapter().GetDataByID(item2.UserGroup);
                    foreach (CommonClassLibrary.CommonDataSet.UserGroupRow item3 in collection3)
                    {
                        usergroup += item3.Name + ", ";
                        if (item.ImageUrl != null)
                        {
                            urlImage = "Image/" + item.ImageUrl;
                        }
                      
                       
                    }
                }
                usergroup = usergroup.Trim();
                if (usergroup.EndsWith(","))
                {
                    usergroup = usergroup.Substring(0, usergroup.Length - 1);
                }
                dt.Rows.Add(item.Id, item.FirstName, item.LastName, item.Email, item.Password, item.MobilePhoneNumber, usergroup,urlImage);
            }
            else
            {
                foreach (CommonClassLibrary.CommonDataSet.AccountGroupRow item2 in collection2)
                {
                    CommonClassLibrary.CommonDataSet.UserGroupDataTable collection3 = new CommonClassLibrary.CommonDataSetTableAdapters.UserGroupTableAdapter().GetDataByID(item2.UserGroup);
                    foreach (CommonClassLibrary.CommonDataSet.UserGroupRow item3 in collection3)
                    {
                        if (item.ImageUrl != null)
                        {
                            urlImage = "Image/" + item.ImageUrl;
                        }
                        dt.Rows.Add(item.Id, item.FirstName, item.LastName, item.Email, item.Password, item.MobilePhoneNumber, item3.Name,urlImage);
                    }
                }
            }
        }
        this.UserAccountRepeater.DataSource = dt;
        this.UserAccountRepeater.DataBind();
    }

    protected void linkEdit(object sender, CommandEventArgs e)
    {
        int ID = int.Parse(e.CommandArgument.ToString());
        if (new CommonClassLibrary.CommonDataSetTableAdapters.UserAccountTableAdapter().UpdateQueryStatusOnly(1, ID) == 1)
        {
            this.SuccessLabel.Text = "อนุมัติเรียบร้อย";
            this.SuccessPanel.Visible = true;
            this.ErrorPanel.Visible = false;
            getdatauseraccount();
        }
        else
        {
            this.SuccessPanel.Visible = false;
            this.ErrorPanel.Visible = true;
            this.ErrorLabel.Text = "อนุมัติไม่สำเร็จ";
        }
    }

    protected void linkDelete(object sender, CommandEventArgs e)
    {
        int ID = int.Parse(e.CommandArgument.ToString());
        if (new CommonClassLibrary.CommonDataSetTableAdapters.AccountGroupTableAdapter().DeleteQueryUserAccount(ID) > 0)
        {
            if (new CommonClassLibrary.CommonDataSetTableAdapters.UserAccountTableAdapter().DeleteQuery(ID) == 1)
            {
                this.SuccessLabel.Text = "ลบข้อมูลสำเร็จ";
                this.SuccessPanel.Visible = true;
                this.ErrorPanel.Visible = false;
                getdatauseraccount();
            }
            else
            {
                this.SuccessPanel.Visible = false;
                this.ErrorPanel.Visible = true;
                this.ErrorLabel.Text = "ลบข้อมูลไม่สำเร็จ";
            }
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