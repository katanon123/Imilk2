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
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl AddCategory = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li6");
            AddCategory.Attributes.Add("class", "active");
            System.Web.UI.HtmlControls.HtmlGenericControl AddCategory2 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li15");
            AddCategory2.Attributes.Add("class", "active");
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
                    CommonClassLibrary.TypeCate tc = new CommonClassLibrary.TypeCate()
                    {
                        Name = IDProduct1.ToString(),
                        UrlImage = aaa,
                        CreateDate = DateTime.Now,
                        LastUpdate = DateTime.Now,
                        Status = 1


                    };

                   
                    innofood.TypeCates.Add(tc);
                    innofood.SaveChanges();

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลสำเร็จ" + "');", true);



                    //this.SuccessPanel.Visible = true;
                    //this.ErrorPanel.Visible = false;
                    //this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
                   Response.Redirect("~/ListCategory.aspx");

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


            }

        }
        else
        {


            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลไม่สำเร็จ กรุณาเลือกรูปภาพ" + "');", true);


            //this.SuccessPanel.Visible = false;
            //this.ErrorPanel.Visible = true;
            //this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ กรุณาเลือกรูปภาพ";
        }
    }
    public void Showdata()
    {
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
        foreach (var item in innofood.TypeCates.Where(x => x.Status == 1))
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
        int ID = int.Parse(aaa_TextBox.Text);

        try
        {
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
                    CommonClassLibrary.TypeCate oo = innofood.TypeCates.Where(x => x.Id == ID).First();

                    oo.UrlImage = img;

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



            }
        }


    }


    protected void LinkButtonEdat_Command(object sender, CommandEventArgs e)
    {
        this.EditPanel.Visible = true;
        this.AddPanel.Visible = false;
        this.ShowPanel.Visible = false;

        long ID = long.Parse(e.CommandArgument.ToString());

        CommonClassLibrary.TypeCate cate = innofood.TypeCates.Where(x => x.Id == ID).First();
        this.Labelidname.Text = cate.Name;
        this.Image_category.ImageUrl = "Image/" + cate.UrlImage;
        this.aaa_TextBox.Text = ID.ToString();



        long Idtext = long.Parse(cate.Name);
        CommonClassLibrary.TextContent textc = innofood.TextContents.Where(x => x.Id == Idtext).First();

        editName_TextBox.Text = textc.Thai;
        editNameEN_TextBox.Text = textc.English;

    }

    protected void LinkButtonDelete_Command(object sender, CommandEventArgs e)
    {

        long ID = long.Parse(e.CommandArgument.ToString());
        try
        {
            var tyc = innofood.TypeCates.Where(x => x.Id == ID);
            var cate = innofood.Categories.Where(x => x.TypeId == ID);
            if (tyc.Count() > 0)
            {
                tyc.First().Status = 0;
            }
            if (cate.Count() > 0)
            {
                cate.First().Status = 0;
            }
            
            innofood.SaveChanges();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "ลบข้อมูลสำเร็จ" + "');", true);
            //this.SuccessPanel.Visible = true;
            //this.ErrorPanel.Visible = false;
            //this.SuccessLabel.Text = "ลบข้อมูลสำเร็จ";
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
}