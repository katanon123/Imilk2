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

public partial class AddCategory : System.Web.UI.Page
{
    private CommonClassLibrary.ImilkEntities1 innofood;
    public AddCategory()
    {
        innofood = new CommonClassLibrary.ImilkEntities1();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        int Type = int.Parse(Request.QueryString["Type"]);
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl AddCategory = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li6");
            AddCategory.Attributes.Add("class", "active");
            setradio();
            this.Showdata();

            if (Type == 18)
            {
                AddButton.Visible = false;

            }
            long idtext = long.Parse(innofood.TypeCates.Where(x => x.Id == Type).First().Name);
            title2.Text = innofood.TextContents.Where(x => x.Id == idtext).First().English;
            title3.Text = innofood.TextContents.Where(x => x.Id == idtext).First().Thai;
            titleadd.Text = innofood.TextContents.Where(x => x.Id == idtext).First().Thai;
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
        int Type = int.Parse(Request.QueryString["Type"]);
        HttpPostedFile UpFileProduct = Picture_FileUpload.PostedFile;

        string UpFilePro = System.IO.Path.GetExtension(UpFileProduct.FileName);
        if (this.Picture_FileUpload.PostedFile.FileName.ToString() != "")
        {

            long IDProduct1 = (long)new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().InsertQuery(Name_TextBox.Text, NameEN_TextBox.Text, " ", DateTime.Now, DateTime.Now, 1);


            if (UpFilePro == ".jpg" || UpFilePro == ".png" || UpFilePro == ".JPG" || UpFilePro == ".PNG" || UpFilePro == ".jpeg" || UpFilePro == ".JPEG")
            {
                string imageFileName = "IMF" + "_" + DateTime.Now.ToString("ddMMyyyy-HHmmss");
                imageFileName += ".jpg";
                string aaa = imageFileName;
                string path = System.IO.Path.Combine(Server.MapPath("~/Image/"), imageFileName);
                // string path = System.IO.Path.Combine(Server.MapPath("D:/OWP/DigitalServicesRestaurant/ManagementWebSite/Image/"), imageFileName);
                UpFileProduct.SaveAs(path);

                try
                {
                    CommonClassLibrary.Category tc = new CommonClassLibrary.Category()
                    {
                        Name = IDProduct1.ToString(),
                        ImageURL = aaa,
                        CreatedDate = DateTime.Now,
                        LastUpdated = DateTime.Now,
                        Status = 1,
                        TypeId = Type


                    };
                    innofood.Categories.Add(tc);
                    innofood.SaveChanges();


                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลสำเร็จ" + "');", true);

                    //this.SuccessPanel.Visible = true;
                    //this.ErrorPanel.Visible = false;
                    //this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";



                  
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลไม่สำเร็จ" + "');", true);

                    //this.SuccessPanel.Visible = false;
                    //this.ErrorPanel.Visible = true;
                    //this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";

                }


                //if (new CommonClassLibrary.CommonDataSetTableAdapters.CategoryTableAdapter().Insert(IDProduct1.ToString(), aaa, DateTime.Now, DateTime.Now, 1) == 1)
                //{
                //    this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
                //    Response.Redirect("~/AddCategory.aspx");
                //}
                //else
                //{

                //    FileInfo DeleteImage = new FileInfo(@"C:/FTP/Imilk/Image/" + aaa);
                //    DeleteImage.Delete();
                //    this.SuccessPanel.Visible = false;
                //    this.ErrorPanel.Visible = true;
                //    this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
                //}

                this.Name_TextBox.Text = "";
                this.NameEN_TextBox.Text = "";
            }

        }
        else
        {
            //this.SuccessPanel.Visible = false;
            //this.ErrorPanel.Visible = true;
            //this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ กรุณาเลือกรูปภาพ";

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลไม่สำเร็จ กรุณาเลือกรูปภาพ" + "');", true);
        }
    }
    public void Showdata()
    {
        long Type = long.Parse(Request.QueryString["Type"]);
        string nameEn = "";
        string nameCH = "";
        string name = "";
        string imageUrl = "Image/no_image_available.jpg";
        //string detail = "";
        //string price = "";
        //string promotion = "";
        DataTable dt = new DataTable();
        dt.Columns.Add("IDProduct");
        dt.Columns.Add("Name");
        dt.Columns.Add("ImageURL");
        dt.Columns.Add("NameEN");
        foreach (var item in innofood.Categories.Where(x => x.Status == 1).Where(x=>x.TypeId == Type))
        {
            long idtextcontect = long.Parse(item.Name);
            foreach (var item3 in innofood.TextContents.Where(x => x.Id == idtextcontect))
            {
                name = item3.Thai;
                nameEn = item3.English;
            }
            imageUrl = item.ImageURL;
            dt.Rows.Add(item.Id, name, imageUrl, nameEn);
        }


        this.CategoryTa.DataSource = dt;
        this.CategoryTa.DataBind();
    }

    //{     c= new CommonClassLibrary.CommonDataSetTableAdapters.CategoryTableAdapter().GetData();
    //    this.CategoryTa.DataSource 
    //    this.CategoryTa.DataBind();
    //    this.ShowPanel.Visible = true;
    //    this.AddPanel.Visible = false;
    //    this.EditPanel.Visible = false;

    public void getImage()
    {

    }


    protected void AddButton_Click(object sender, EventArgs e)
    {
        this.ShowPanel.Visible = false;
        this.AddPanel.Visible = true;
        this.EditPanel.Visible = false;
    }
  
    protected void Button1_Click(object sender, EventArgs e)
    {
        string img = "";
        int ID = int.Parse(Labelidname.Text);
        int IdCate = int.Parse(aaa_TextBox.Text);
        
        try
        {
            CommonClassLibrary.Category cate1 = innofood.Categories.Where(x => x.Id == IdCate).First();

            cate1.TypeId = int.Parse(RadioButtonList.SelectedItem.Value);

            CommonClassLibrary.TextContent o = innofood.TextContents.Where(x => x.Id == ID).First();

            o.Thai = editName_TextBox.Text;
            o.English = editNameEN_TextBox.Text;
            o.LastUpdated = DateTime.Now;

            innofood.SaveChanges();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "แก้ไขข้อมูลสำเร็จ" + "');", true);
            //this.SuccessPanel.Visible = true;
            //this.ErrorPanel.Visible = false;
            //this.SuccessLabel.Text = "แก้ไขข้อมูลสำเร็จ";
        }
        catch (Exception ex)
        {

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "แก้ไขข้อมูลไม่สำเร็จ" + "');", true);
            //this.SuccessPanel.Visible = false;
            //this.ErrorPanel.Visible = true;
            //this.ErrorLabel.Text = "แก้ไขข้อมูลไม่สำเร็จ";
        }

        if (this.EditFileUpload.HasFile)
        {
            HttpPostedFile UpFileProduct = EditFileUpload.PostedFile;

            string UpFilePro = System.IO.Path.GetExtension(UpFileProduct.FileName);


            if (UpFilePro == ".jpg" || UpFilePro == ".png" || UpFilePro == ".JPG" || UpFilePro == ".PNG" || UpFilePro == ".jpeg" || UpFilePro == ".JPEG")
            {

                string imageFileName = "IMF" + "_" + DateTime.Now.ToString("ddMMyyyy-HHmmss");
                imageFileName += ".jpg";
                img = imageFileName;
                string path = System.IO.Path.Combine(Server.MapPath("~/Image/"), imageFileName);
                // string path = System.IO.Path.Combine(Server.MapPath("D:/OWP/DigitalServicesRestaurant/ManagementWebSite/Image/"), imageFileName);
                UpFileProduct.SaveAs(path);

                try
                {
                    CommonClassLibrary.Category oo = innofood.Categories.Where(x => x.Id == IdCate).First();

                    oo.ImageURL = img;

                    innofood.SaveChanges();
                    //this.SuccessPanel.Visible = true;
                    //this.ErrorPanel.Visible = false;
                    //this.SuccessLabel.Text = "แก้ไขข้อมูลสำเร็จ";

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "แก้ไขข้อมูลสำเร็จ" + "');", true);
                }
                catch (Exception ex)
                {
                    //this.SuccessPanel.Visible = false;
                    //this.ErrorPanel.Visible = true;
                    //this.ErrorLabel.Text = "แก้ไขข้อมูลไม่สำเร็จ";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "แก้ไขข้อมูลไม่สำเร็จ" + "');", true);
                }



            }
        }


    }


    protected void LinkButtonEdat_Command(object sender, CommandEventArgs e)
    {
        this.EditPanel.Visible = true;
        this.AddPanel.Visible = false;
        this.ShowPanel.Visible = false;

        long ID = long.Parse(e.CommandArgument.ToString());

        CommonClassLibrary.Category cate = innofood.Categories.Where(x=>x.Id == ID).First();
        this.Labelidname.Text = cate.Name;
        this.Image_category.ImageUrl = "Image/" + cate.ImageURL;
        this.aaa_TextBox.Text = ID.ToString();

        CommonClassLibrary.TypeCate typecate = innofood.TypeCates.Where(x => x.Id == cate.TypeId).First();
        RadioButtonList.SelectedValue = typecate.Id.ToString();

        long Idtext = long.Parse(cate.Name);
        CommonClassLibrary.TextContent textc = innofood.TextContents.Where(x => x.Id == Idtext).First();
       
            editName_TextBox.Text = textc.Thai;
            editNameEN_TextBox.Text = textc.English;
        

    }

    protected void LinkButtonDelete_Command(object sender, CommandEventArgs e)
    {

        long ID = long.Parse(e.CommandArgument.ToString());
        try { 
        CommonClassLibrary.Category cate = innofood.Categories.Where(x => x.Id == ID).First();
        cate.Status = 0;
        innofood.SaveChanges();
            //this.SuccessPanel.Visible = true;
            //this.ErrorPanel.Visible = false;
            //this.SuccessLabel.Text = "ลบข้อมูลสำเร็จ";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "ลบข้อมูลสำเร็จ" + "');", true);
        }
        catch (Exception ex)
        {
            //this.SuccessPanel.Visible = false;
            //this.ErrorPanel.Visible = true;
            //this.ErrorLabel.Text = "ลบข้อมูลไม่สำเร็จ";

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "ลบข้อมูลไม่สำเร็จ" + "');", true);
        }
        this.Showdata();
    }

    public void setradio()
    {

        string nameEn = "";
        string nameCH = "";
        string name = "";
        string imageUrl = "Image/no_image_available.jpg";

        DataTable dt = new DataTable();
        dt.Columns.Add("Id");
        dt.Columns.Add("Name");
        dt.Columns.Add("ImageURL");
        dt.Columns.Add("NameEN");

        foreach (var item in innofood.TypeCates.Where(x => x.Status > 0))
        {
            long idtextcontect = long.Parse(item.Name);
            foreach (var item3 in innofood.TextContents.Where(x => x.Id == idtextcontect))
            {
                name = item3.Thai;
                nameEn = item3.English;
            }
            imageUrl = item.UrlImage;
            dt.Rows.Add(item.Id, name, imageUrl, nameEn);
        }
        this.RadioButtonList.DataSource = dt;
        this.RadioButtonList.DataTextField = "Name";
        this.RadioButtonList.DataValueField = "Id";
        this.RadioButtonList.DataBind();
    }
}