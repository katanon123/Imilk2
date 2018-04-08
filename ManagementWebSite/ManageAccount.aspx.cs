using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageAccount : System.Web.UI.Page
{
    private CommonClassLibrary.ImilkEntities1 model;
    public ManageAccount()
    {
        model = new CommonClassLibrary.ImilkEntities1();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl AddMenu = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li12");
            AddMenu.Attributes.Add("class", "active");
            showaccountdetail();
        }
    }
    public void showaccountdetail()
    {
        this.detailaccount.DataSource = model.Accounts.ToList();
        this.detailaccount.DataBind();
    }
    protected void AddButton_Click(object sender, EventArgs e)
    {
        addaccount.Visible = true;
        account.Visible = false;
    }
    protected void notification(bool rs, string errormsg)
    {

        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('" + errormsg + "');", true);

    }
    protected void Confirm_Button_Click(object sender, EventArgs e)
    {
        CommonClassLibrary.Account account = new CommonClassLibrary.Account()
        {
            Name = Name_account.Text,
            Idname = No_account.Text,
            Bank = Name_bank.Text,
            Sector = Sector_bank.Text
        };
        model.Accounts.Add(account);
        if (model.SaveChanges() > 0)
        {

            this.SuccessPanel.Visible = true;
            this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
            this.ErrorPanel.Visible = false;
            showaccountdetail();
            this.account.Visible = true;
            addaccount.Visible = false;


        }
        else
        {
            this.SuccessPanel.Visible = false;
            this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
            this.ErrorPanel.Visible = true;
        }
    }
    

    protected void Delete_LinkButton_Command(object sender, CommandEventArgs e)
    {
        long Id = long.Parse(e.CommandArgument.ToString());
        CommonClassLibrary.Account ac = model.Accounts.Where(x => x.Id == Id).First();
        model.Accounts.Remove(ac);
        if(model.SaveChanges() > 0)
        {
            this.SuccessPanel.Visible = true;
            this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
            this.ErrorPanel.Visible = false;
            showaccountdetail();
            this.account.Visible = true;
            editform.Visible = false;
            addaccount.Visible = false;
        }
        else
        {
            this.SuccessPanel.Visible = false;
            this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
            this.ErrorPanel.Visible = true;
        }
    }

    protected void editbutton_Click(object sender, EventArgs e)
    {
        long Id = long.Parse(Idaccount.Text);
        CommonClassLibrary.Account ac = model.Accounts.Where(x => x.Id == Id).First();
        ac.Name = editname.Text;
        ac.Idname = editno.Text;
        ac.Bank = editbank.Text;
       ac.Sector = editbran.Text;
        if(model.SaveChanges() >= 0)
        {
            this.SuccessPanel.Visible = true;
            this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
            this.ErrorPanel.Visible = false;
            showaccountdetail();
            this.account.Visible = true;
            editform.Visible = false;

        }
        else
        {
            this.SuccessPanel.Visible = false;
            this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
            this.ErrorPanel.Visible = true;
            //this.notification(false, "ไม่สามารถบันทึกข้อมูลได้");
        }
    }

    protected void buttonedit_Command(object sender, CommandEventArgs e)
    {
        account.Visible = false;
        addaccount.Visible = false;
        editform.Visible = true;
        long Id = long.Parse(e.CommandArgument.ToString());
        CommonClassLibrary.Account ac = model.Accounts.Where(x => x.Id == Id).First();
        Idaccount.Text = ac.Id.ToString();
        editname.Text = ac.Name;
        editno.Text = ac.Idname;
        editbank.Text = ac.Bank;
        editbran.Text = ac.Sector;
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