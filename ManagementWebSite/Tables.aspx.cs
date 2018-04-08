using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tables : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl AddCategory = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li13");
            AddCategory.Attributes.Add("class", "active");
            this.Showdata();
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

    protected void Confirm_Button_Click(object sender, EventArgs e)
    {
        saveImage();
    }
    public void saveImage()
    {
        long IDProduct1 = (long)new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().InsertQuery(Name_TextBox.Text, NameEN_TextBox.Text, " ", DateTime.Now, DateTime.Now, 1);

        if (new CommonClassLibrary.CommonDataSetTableAdapters.TableTableAdapter().InsertQuery(IDProduct1.ToString(), 1) == 1)
        {
            this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
            Response.Redirect("~/Tables.aspx");
        }
        else
        {

            this.SuccessPanel.Visible = false;
            this.ErrorPanel.Visible = true;
            this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
        }
    }
    public void Showdata()
    {
        string nameEn = "";
        string name = "";
        //string detail = "";
        //string price = "";
        //string promotion = "";
        DataTable dt = new DataTable();
        dt.Columns.Add("IDProduct");
        dt.Columns.Add("Name");
        dt.Columns.Add("NameEN");
        CommonClassLibrary.CommonDataSet.TableDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.TableTableAdapter().GetData();
        foreach (CommonClassLibrary.CommonDataSet.TableRow item in collection)
        {
            CommonClassLibrary.CommonDataSet.TextContentDataTable collection3 = new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().GetDataById(long.Parse(item.Name));
            foreach (CommonClassLibrary.CommonDataSet.TextContentRow item3 in collection3)
            {
                name = item3.Thai;
                nameEn = item3.English;
            }
            dt.Rows.Add(item.Id, name, nameEn);
        }


        this.CategoryTa.DataSource = dt;
        this.CategoryTa.DataBind();
    }
    

    public void getImage()
    {

    }


    protected void AddButton_Click(object sender, EventArgs e)
    {
        this.ShowPanel.Visible = false;
        this.AddPanel.Visible = true;
        this.EditPanel.Visible = false;
    }
    protected void CategoryTa_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label idlabel = (Label)e.Item.FindControl("idLabel");
        this.aaa_TextBox.Text = idlabel.Text;
        if (e.CommandName == "EditBtn")
        {
            //this.getImage();
            CommonClassLibrary.CommonDataSet.TableDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.TableTableAdapter().GetDataById(int.Parse(idlabel.Text));
            foreach (CommonClassLibrary.CommonDataSet.TableRow item in collection)
            {
                this.Labelidname.Text = item.Name;
            }
            this.EditPanel.Visible = true;
            this.AddPanel.Visible = false;
            this.ShowPanel.Visible = false;
            CommonClassLibrary.CommonDataSet.TextContentDataTable collection1 = new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().GetDataById(int.Parse(Labelidname.Text));
            foreach (CommonClassLibrary.CommonDataSet.TextContentRow item1 in collection1)
            {
                editName_TextBox.Text = item1.Thai;
                editNameEN_TextBox.Text = item1.English;
            }

            this.EditPanel.Visible = true;
            this.AddPanel.Visible = false;
            this.ShowPanel.Visible = false;
        }
        else if (e.CommandName == "DeleteBtn")
        {
            try
            {
                
              
                    if (new CommonClassLibrary.CommonDataSetTableAdapters.TableTableAdapter().DeleteQuery(int.Parse(aaa_TextBox.Text)) == 1)
                    {
                      
                        this.SuccessPanel.Visible = true;
                        this.ErrorPanel.Visible = false;
                        this.SuccessLabel.Text = "ลบข้อมูลสำเร็จ";
                    }
                    else
                    {
                        this.SuccessPanel.Visible = false;
                        this.ErrorPanel.Visible = true;
                        this.ErrorLabel.Text = "ลบข้อมูลไม่สำเร็จ";
                    }
              
                
            }
            catch (Exception)
            {


            }

            this.Showdata();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {


        if (new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().UpdateQueryById(editName_TextBox.Text, editNameEN_TextBox.Text, "", DateTime.Now, 1, int.Parse(Labelidname.Text)) == 1)
        {
            this.SuccessLabel.Text = "แก้ไขข้อมูลสำเร็จ";
            Response.Redirect("~/Tables.aspx");
        }
        else
        {

            this.SuccessLabel.Text = "แก้ไขข้อมูลสำเร็จ";
            Response.Redirect("~/Tables.aspx");

        }



    }
}