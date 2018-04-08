using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditUserAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl Usermanagement = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li7");
            Usermanagement.Attributes.Add("class", "active");

            System.Web.UI.HtmlControls.HtmlGenericControl Useraccount = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li9");
            Useraccount.Attributes.Add("class", "active");


            int ID = int.Parse(Request.QueryString["Id"]);
            this.CheckBoxList();

            CommonClassLibrary.CommonDataSet.UserAccountDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.UserAccountTableAdapter().GetDataById(ID);
            foreach (CommonClassLibrary.CommonDataSet.UserAccountRow item in collection)
            {
                this.FirstNameEditUserAccount_TextBox.Text = item.FirstName;
                this.LastNameEditUserAccount_TextBox.Text = item.LastName;
                this.EmailEditUserAccount_TextBox.Text = item.Email;
                this.PasswordEditUserAccount_TextBox.Attributes.Add("value", item.Password);
                this.MobilePhoneEditUserAccount_TextBox.Text = item.MobilePhoneNumber;

                CommonClassLibrary.CommonDataSet.AccountGroupDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.AccountGroupTableAdapter().GetDataByUserAccount(item.Id);
                foreach (CommonClassLibrary.CommonDataSet.AccountGroupRow item2 in collection2)
                {
                    for (int i = 0; i < UserGroupEditUserAccount_CheckBoxList.Items.Count; i++)
                    {
                        if (UserGroupEditUserAccount_CheckBoxList.Items[i].Value == item2.UserGroup.ToString())
                        {
                            UserGroupEditUserAccount_CheckBoxList.Items[i].Selected = true;
                        }
                    }
                }
            }
        }
    }

    private void CheckBoxList()
    {
        this.UserGroupEditUserAccount_CheckBoxList.DataSource = new CommonClassLibrary.CommonDataSetTableAdapters.UserGroupTableAdapter().GetData();
        this.UserGroupEditUserAccount_CheckBoxList.DataValueField = "Id";
        this.UserGroupEditUserAccount_CheckBoxList.DataTextField = "Name";
        this.UserGroupEditUserAccount_CheckBoxList.DataBind();
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
        long ID = long.Parse(Request.QueryString["Id"]);
        if (this.UserGroupEditUserAccount_CheckBoxList.SelectedValue != "")
        {
            try
            {
                if (new CommonClassLibrary.CommonDataSetTableAdapters.UserAccountTableAdapter().UpdateQuery(this.FirstNameEditUserAccount_TextBox.Text, this.LastNameEditUserAccount_TextBox.Text, this.EmailEditUserAccount_TextBox.Text, this.PasswordEditUserAccount_TextBox.Text, this.MobilePhoneEditUserAccount_TextBox.Text, 1, ID) == 1)
                {
                    for (int i = 0; i < this.UserGroupEditUserAccount_CheckBoxList.Items.Count; i++)
                    {
                        if (this.UserGroupEditUserAccount_CheckBoxList.Items[i].Selected == true)
                        {
                            CommonClassLibrary.CommonDataSet.AccountGroupDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.AccountGroupTableAdapter().GetDataByUserAccountAndUserGroup(ID, i + 1);
                            if (collection.Rows.Count == 0)
                            {
                                if (new CommonClassLibrary.CommonDataSetTableAdapters.AccountGroupTableAdapter().InsertQuery(ID, i + 1, DateTime.Now, DateTime.Now, 1) == 1)
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
                        else
                        {
                            CommonClassLibrary.CommonDataSet.AccountGroupDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.AccountGroupTableAdapter().GetDataByUserAccountAndUserGroup(ID, i + 1);
                            if (collection.Rows.Count == 1)
                            {
                                if (new CommonClassLibrary.CommonDataSetTableAdapters.AccountGroupTableAdapter().DeleteQueryUserAccountAndUserGroup(ID, i + 1) == 1)
                                {
                                    this.SuccessPanel.Visible = true;
                                    this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
                                    this.ErrorPanel.Visible = false;
                                }
                                else
                                {
                                    this.SuccessPanel.Visible = false;
                                    this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
                                    this.ErrorPanel.Visible = true;
                                }
                            }
                        }
                    }
                    this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
                    this.SuccessPanel.Visible = true;
                    this.ErrorPanel.Visible = false;
                }
                else
                {
                    this.SuccessPanel.Visible = false;
                    this.ErrorPanel.Visible = true;
                    this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
                }
            }

            catch (Exception)
            {

                this.SuccessPanel.Visible = false;
                this.ErrorLabel.Text = "มี User ใน นี้ระบบแล้ว";
                this.ErrorPanel.Visible = true;
                return;
            }
        }
        else
        {
            this.ErrorPanel.Visible = true;
            this.ErrorLabel.Text = "กรุณาเลือก User-Group (อย่างน้อย 1 ประเภท)";
            this.SuccessPanel.Visible = false;
        }
    }
}