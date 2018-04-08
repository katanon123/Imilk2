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
    private CommonClassLibrary.ImilkEntities1 inno;
    public AddCategory()
    {
        inno = new CommonClassLibrary.ImilkEntities1();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl AddCategory = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li6");
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

                try { 
                CommonClassLibrary.TypeCate tc = new CommonClassLibrary.TypeCate()
                {
                    Name = IDProduct1.ToString(),
                    UrlImage = aaa,
                    CreateDate = DateTime.Now,
                    LastUpdate = DateTime.Now,
                    Status = 1
                    
                };
                inno.TypeCates.Add(tc);
                inno.SaveChanges();

                this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
                Response.Redirect("~/AddCategory.aspx");
                }
                catch (Exception ex) {


                    this.SuccessPanel.Visible = false;
                    this.ErrorPanel.Visible = true;
                    this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";

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
            this.SuccessPanel.Visible = false;
            this.ErrorPanel.Visible = true;
            this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ กรุณาเลือกรูปภาพ";
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
        CommonClassLibrary.CommonDataSet.CategoryDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.CategoryTableAdapter().GetDataByStatus(1);
        foreach (CommonClassLibrary.CommonDataSet.CategoryRow item in collection)
        {
          
    
                    CommonClassLibrary.CommonDataSet.TextContentDataTable collection3 = new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().GetDataById(long.Parse(item.Name));
                    foreach (CommonClassLibrary.CommonDataSet.TextContentRow item3 in collection3)
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
    protected void CategoryTa_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label idlabel = (Label)e.Item.FindControl("idLabel");
        Label imagenamelabel = (Label)e.Item.FindControl("imagenameLabel");
        this.aaa_TextBox.Text = idlabel.Text;
        string  nameimageurl ="";
        if (e.CommandName == "EditBtn")
        {
            //this.getImage();
            CommonClassLibrary.CommonDataSet.CategoryDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.CategoryTableAdapter().GetDataByID(int.Parse(idlabel.Text));
            foreach (CommonClassLibrary.CommonDataSet.CategoryRow item in collection)
            {
                this.Labelidname.Text = item.Name;
                this.Image_category.ImageUrl = "Image/"+item.ImageURL;
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
                CommonClassLibrary.CommonDataSet.CategoryDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.CategoryTableAdapter().GetDataByID(int.Parse(idlabel.Text));
                foreach (CommonClassLibrary.CommonDataSet.CategoryRow item in collection)
                {
                    nameimageurl = item.ImageURL;
                } 
                    if (new CommonClassLibrary.CommonDataSetTableAdapters.CategoryTableAdapter().UpdateQueryStatus(DateTime.Now, 0,int.Parse(aaa_TextBox.Text)) == 1)
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
                this.Showdata();
            }
            catch (Exception)
            {

         
            }

            this.Showdata();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string img = "";
        CommonClassLibrary.CommonDataSet.CategoryDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.CategoryTableAdapter().GetDataByID(int.Parse(aaa_TextBox.Text));
        foreach (CommonClassLibrary.CommonDataSet.CategoryRow item in collection)
        {

            this.nameimage_TextBox.Text = item.ImageURL;
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

                new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().UpdateQueryById(editName_TextBox.Text, editNameEN_TextBox.Text,"", DateTime.Now,1, int.Parse(Labelidname.Text));
                if (new CommonClassLibrary.CommonDataSetTableAdapters.CategoryTableAdapter().UpdateQueryimage( img, DateTime.Now, int.Parse(aaa_TextBox.Text)) == 1)
                {
                    if (nameimage_TextBox.Text != "")
                    {
                        FileInfo DeleteImage = new FileInfo(@"C:/FTP/Imilk/Image/" + nameimage_TextBox.Text);
                        DeleteImage.Delete();
                        this.SuccessLabel.Text = "แก้ไขข้อมูลสำเร็จ";
                        Response.Redirect("~/AddCategory.aspx");
                    }
                    else {

                        this.SuccessLabel.Text = "แก้ไขข้อมูลสำเร็จ";
                    Response.Redirect("~/AddCategory.aspx");

                    }
                        

                    
                }
                else
                {
                    FileInfo DeleteImage = new FileInfo(@"C:/FTP/Imilk/Image/" + img);
                    DeleteImage.Delete();
                    this.SuccessPanel.Visible = false;
                    this.ErrorPanel.Visible = true;
                    this.ErrorLabel.Text = "แก้ไขข้อมูลไม่สำเร็จ";
                }
            }
            else
            {
                this.SuccessPanel.Visible = false;
                this.ErrorPanel.Visible = true;
                this.ErrorLabel.Text = "ไม่สามารถเพิ่มรูปภาพได้ ต้องเป็นไฟล์ .PNG , .JPG , .JPEG ";
            }

        }
        else
        {

            new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().UpdateQueryById(editName_TextBox.Text, editNameEN_TextBox.Text,"", DateTime.Now,1, int.Parse(Labelidname.Text));
            img = nameimage_TextBox.Text;
            if (new CommonClassLibrary.CommonDataSetTableAdapters.CategoryTableAdapter().UpdateQueryimage(img, DateTime.Now, int.Parse(aaa_TextBox.Text)) == 1)
            {

                this.SuccessLabel.Text = "แก้ไขข้อมูลสำเร็จ";
                Response.Redirect("~/AddCategory.aspx");
            }
            else
            {
                this.SuccessPanel.Visible = false;
                this.ErrorPanel.Visible = true;
                this.ErrorLabel.Text = "แก้ไขข้อมูลไม่สำเร็จ";
            }
        }

    }
}