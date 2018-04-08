using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TextMassage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl AddCategory = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Litext");
            AddCategory.Attributes.Add("class", "active");
         
        }
        getdata();
    }

    protected void SuccessLinkButton_Click(object sender, EventArgs e)
    {
        this.SuccessPanel.Visible = false;
    }

    protected void ErrorLinkButton_Click(object sender, EventArgs e)
    {
        this.ErrorPanel.Visible = false;
    }
    protected void Confirm_Button_Click(object sender, EventArgs e)
    {
        
          
          if (new CommonClassLibrary.CommonDataSetTableAdapters.TextMessageTableAdapter().InsertQuery(Name_TextBox.Text,NameEN_TextBox.Text,"","",DateTime.Now,DateTime.Now,1)==1)
            {
                  this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
                   this.SuccessPanel.Visible = true;
                   this.ErrorPanel.Visible = false;
                   getdata();
            }
            else
            {
                this.SuccessPanel.Visible = false;
                this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
                this.ErrorPanel.Visible = true;
            }
                EditPanel.Visible=false;
                 AddPanel.Visible=false;
                ShowPanel.Visible=true;
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        long ID = long.Parse(Name_TextBox.Text);

            if (new CommonClassLibrary.CommonDataSetTableAdapters.TextMessageTableAdapter().UpdateQuery1(EditName_TextBox.Text,EditNameEN_TextBox.Text,"",DateTime.Now,ID) == 1)
            {
                       this.SuccessPanel.Visible = true;
                      this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
                  this.ErrorPanel.Visible = false;
                  getdata();
          }
      else
          {
              this.ErrorPanel.Visible = true;
               this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
                this.SuccessPanel.Visible = false;
          }
                 EditPanel.Visible=false;
                 AddPanel.Visible = false;
                ShowPanel.Visible=true;
         
        }

    public void getdata()
    {
       
        DataTable dt = new DataTable();
        dt.Columns.Add("Id");
        dt.Columns.Add("NameTH");
        dt.Columns.Add("NameEN");
       

        CommonClassLibrary.CommonDataSet.TextMessageDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.TextMessageTableAdapter().GetData();
        foreach (CommonClassLibrary.CommonDataSet.TextMessageRow item in collection)
        { 
            dt.Rows.Add(item.Id,item.Thai, item.English);
        }


        this.TicketOrderRepeater.DataSource = dt;
        this.TicketOrderRepeater.DataBind();
    }
    protected void linkEdit(object sender, CommandEventArgs e)
    {
       // long ID = long.Parse(Request.QueryString["Day_Label"]);
        long ID = long.Parse(e.CommandArgument.ToString());
        CommonClassLibrary.CommonDataSet.TextMessageDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.TextMessageTableAdapter().GetDataById(ID);
        foreach (CommonClassLibrary.CommonDataSet.TextMessageRow item in collection)
        {
            this.Name_TextBox.Text = item.Id.ToString();
            this.EditName_TextBox.Text = item.Thai;
            this.EditNameEN_TextBox.Text = item.English;
           


        }

       EditPanel.Visible=true;
        AddPanel.Visible=false;
        ShowPanel.Visible=false;

    }

    protected void AddButton_Click(object sender, EventArgs e)
    {
        this.ShowPanel.Visible = false;
        this.AddPanel.Visible = true;
        this.EditPanel.Visible = false;
    }
    protected void linkDelete(object sender, CommandEventArgs e)
    {
        long ID = long.Parse(e.CommandArgument.ToString());
        if (new CommonClassLibrary.CommonDataSetTableAdapters.TextMessageTableAdapter().DeleteQuery1(ID) > 0)
        {
           
                this.SuccessLabel.Text = "ลบข้อมูลสำเร็จ";
                this.SuccessPanel.Visible = true;
                this.ErrorPanel.Visible = false;
                getdata();

                EditPanel.Visible=false;
                 AddPanel.Visible=false;
                ShowPanel.Visible=true;
            }
            else
            {
                this.SuccessPanel.Visible = false;
                this.ErrorPanel.Visible = true;
                this.ErrorLabel.Text = "ลบข้อมูลไม่สำเร็จ";
            }
        }
    
    }


