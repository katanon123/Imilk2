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

    protected void SignUpButton_Click(object sender, EventArgs e)
    {
        string Email = this.Email_TextBox.Text;
        if (this.Password_TextBox.Text != "")
        {
            CommonClassLibrary.CommonDataSet.UserAccountDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.UserAccountTableAdapter().GetDataByEmail(Email);
            if (collection.Rows.Count == 0)
            {
                int ID = new CommonClassLibrary.CommonDataSetTableAdapters.UserAccountTableAdapter().Insert(this.Firstname_TextBox.Text, this.Lastname_TextBox.Text, this.Email_TextBox.Text,
                        this.Password_TextBox.Text, this.Mobilephone_TextBox.Text, DateTime.Now, DateTime.Now, 1,"");
                if (ID > 0)
                {
                    if (new CommonClassLibrary.CommonDataSetTableAdapters.AccountGroupTableAdapter().InsertQuery(ID, 1, DateTime.Now, DateTime.Now, 1) == 1)
                    {
                        this.SuccessPanel.Visible = true;
                        this.SuccessLabel.Text = "สมัครสมาชิกสำเร็จ";
                        this.ErrorPanel.Visible = false;
                    }
                    else
                    {
                        this.ErrorPanel.Visible = true;
                        this.ErrorLabel.Text = "สมัครสมาชิกไม่สำเร็จ";
                        this.SuccessPanel.Visible = false;
                    }
                }
                else
                {
                    this.ErrorPanel.Visible = true;
                    this.ErrorLabel.Text = "สมัครสมาชิกไม่สำเร็จ";
                    this.SuccessPanel.Visible = false;
                }
            }
            else
            {
                foreach (CommonClassLibrary.CommonDataSet.UserAccountRow item in collection)
                {
                    if (item.Email == this.Email_TextBox.Text)
                    {
                        this.ErrorPanel.Visible = true;
                        this.ErrorLabel.Text = "มี E-mail ในระบบแล้ว";
                        this.SuccessPanel.Visible = false;
                    }
                }
            }
        }
        else
        {
            this.ErrorPanel.Visible = true;
            this.ErrorLabel.Text = "กรุณากรอกรหัสผ่าน";
            this.SuccessPanel.Visible = false;
        }
    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
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