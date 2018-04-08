using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddUserAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            System.Web.UI.HtmlControls.HtmlGenericControl Usermanagement = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li7");
            Usermanagement.Attributes.Add("class", "active");

            System.Web.UI.HtmlControls.HtmlGenericControl Useraccount = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li9");
            Useraccount.Attributes.Add("class", "active");

            getdatacheckbox();
        }
    }

    public void getdatacheckbox()
    {
        this.UserGroupAddUserAccount_CheckBoxList.DataSource = new CommonClassLibrary.CommonDataSetTableAdapters.UserGroupTableAdapter().GetData();
        this.UserGroupAddUserAccount_CheckBoxList.DataTextField = "Name";
        this.UserGroupAddUserAccount_CheckBoxList.DataValueField = "Id";
        this.UserGroupAddUserAccount_CheckBoxList.DataBind();
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
        long ID = 0;
        if (this.UserGroupAddUserAccount_CheckBoxList.SelectedValue != "")
        {
            try
            {
                CommonClassLibrary.CommonDataSet.UserAccountDataTable dt = new CommonClassLibrary.CommonDataSetTableAdapters.UserAccountTableAdapter().GetDataByEmail(this.EmailAddUserAccount_TextBox.Text);
                if (dt.Rows.Count != 0)
                {
                    new CommonClassLibrary.CommonDataSetTableAdapters.UserAccountTableAdapter().UpdateQuery(this.FirstNameAddUserAccount_TextBox.Text, this.LastNameAddUserAccount_TextBox.Text, this.EmailAddUserAccount_TextBox.Text, this.PasswordAddUserAccount_TextBox.Text, this.MobilePhoneAddUserAccount_TextBox.Text, 1, long.Parse(dt.Rows[0]["Id"].ToString()));
                    if (long.Parse(dt.Rows[0]["Id"].ToString()) != 0)
                    {
                        for (int i = 0; i < UserGroupAddUserAccount_CheckBoxList.Items.Count; i++)
                        {
                            if (UserGroupAddUserAccount_CheckBoxList.Items[i].Selected == true)
                            {

                                if (new CommonClassLibrary.CommonDataSetTableAdapters.AccountGroupTableAdapter().InsertQuery(long.Parse(dt.Rows[0]["Id"].ToString()), i + 1, DateTime.Now, DateTime.Now, 1) == 1)
                                {
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

                        }
                    }
                }
                ID = (long)new CommonClassLibrary.CommonDataSetTableAdapters.UserAccountTableAdapter().InsertQuery(this.FirstNameAddUserAccount_TextBox.Text, this.LastNameAddUserAccount_TextBox.Text, this.EmailAddUserAccount_TextBox.Text, this.PasswordAddUserAccount_TextBox.Text, this.MobilePhoneAddUserAccount_TextBox.Text, DateTime.Now, DateTime.Now, 1);
                if (ID > 0)
                {
                    for (int i = 0; i < UserGroupAddUserAccount_CheckBoxList.Items.Count; i++)
                    {
                        if (UserGroupAddUserAccount_CheckBoxList.Items[i].Selected == true)
                        {

                            if (new CommonClassLibrary.CommonDataSetTableAdapters.AccountGroupTableAdapter().InsertQuery(ID, i + 1, DateTime.Now, DateTime.Now, 1) == 1)
                            {
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
                    }
                }
            }
            catch (Exception)
            {

                this.SuccessPanel.Visible = false;
                this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
                this.ErrorPanel.Visible = true;
                return;
            }
        }
        else
        {
            this.SuccessPanel.Visible = false;
            this.ErrorLabel.Text = "กรุณาเลือก User-Group (อย่างน้อย 1 ประเภท)";
            this.ErrorPanel.Visible = true;
        }
    }
}