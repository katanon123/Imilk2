using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddMenu : System.Web.UI.Page
{
    private CommonClassLibrary.ImilkEntities1 innofood;
    public AddMenu()
    {
        innofood = new CommonClassLibrary.ImilkEntities1();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            long ID = long.Parse(Request.QueryString["Id"]);
            System.Web.UI.HtmlControls.HtmlGenericControl AddMenu = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li1");
            AddMenu.Attributes.Add("class", "active");
            int idnamecate = int.Parse(innofood.Categories.Where(x => x.Id == ID).First().Name);
            string title = innofood.TextContents.Where(x=>x.Id== idnamecate).First().Thai;
            
            headtitle2.Text = title;
            headtitle3.Text = title;
        }
    }

    protected void Confirm_Button_Click(object sender, EventArgs e)
    {
        int ID = int.Parse(Request.QueryString["Id"]);
        long IDProduct1 = (long)new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().InsertQuery(Name_TextBox.Text, NameEN_TextBox.Text, " ", DateTime.Now, DateTime.Now, 1);

        long IDProductdetail = (long)new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().InsertQuery(Detail_TextBox.Text, DetailEN_TextBox.Text, "", DateTime.Now, DateTime.Now, 1);
        long IDProduct = (long)new CommonClassLibrary.CommonDataSetTableAdapters.ProductTableAdapter().InsertQuery(DateTime.Now, DateTime.Now, 1, 1);

        this.IDProduct_TextBox.Text = IDProduct.ToString();
        if (IDProduct > 0)
        {
            if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductCateTableAdapter().InsertQuery(IDProduct, ID) > 0)
            {
                //this.SuccessPanel.Visible = true;
                //this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
                //this.ErrorPanel.Visible = false;


                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลสำเร็จ" + "');", true);

            }
            else
            {
                //this.SuccessPanel.Visible = false;
                //this.ErrorPanel.Visible = true;
                //this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลไม่สำเร็จ" + "');", true);
            }
        }


        if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().InsertQuery(IDProduct, DateTime.Now, DateTime.Now, 1, 1, "Name", IDProduct1.ToString()) == 1)
        {
            //this.SuccessPanel.Visible = true;
            //this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
            //this.ErrorPanel.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลสำเร็จ" + "');", true);
        }
        else
        {
            //this.ErrorPanel.Visible = true;
            //this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
            //this.SuccessPanel.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลไม่สำเร็จ" + "');", true);
        }
        if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().InsertQuery(IDProduct, DateTime.Now, DateTime.Now, 1, 1, "Detail", IDProductdetail.ToString()) == 1)
        {
            //this.SuccessPanel.Visible = true;
            //this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
            //this.ErrorPanel.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลสำเร็จ" + "');", true);
        }
        else
        {
            //this.ErrorPanel.Visible = true;
            //this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
            //this.SuccessPanel.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลไม่สำเร็จ" + "');", true);
        }
        if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().InsertQuery(IDProduct, DateTime.Now, DateTime.Now, 1, 1, "Price", this.Price_TextBox.Text) == 1)
        {
            //this.SuccessPanel.Visible = true;
            //this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
            //this.ErrorPanel.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลสำเร็จ" + "');", true);
           
        }
        else
        {
            //this.ErrorPanel.Visible = true;
            //this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
            //this.SuccessPanel.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลไม่สำเร็จ" + "');", true);
        }
        if (this.PromotionPrice_TextBox.Text != "")
        {
            if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().InsertQuery(IDProduct, DateTime.Now, DateTime.Now, 1, 1, "PromotionPrice", this.PromotionPrice_TextBox.Text) == 1)
            {
                //this.SuccessPanel.Visible = true;
                //this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
                //this.ErrorPanel.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลสำเร็จ" + "');", true);
            }
            else
            {
                //this.ErrorPanel.Visible = true;
                //this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
                //this.SuccessPanel.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลไม่สำเร็จ" + "');", true);
            }
        }
        else
        {
            if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().InsertQuery(IDProduct, DateTime.Now, DateTime.Now, 1, 1, "PromotionPrice", "-") == 1)
            {
                //this.SuccessPanel.Visible = true;
                //this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
                //this.ErrorPanel.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลสำเร็จ" + "');", true);
            }
            else
            {
                //this.ErrorPanel.Visible = true;
                //this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
                //this.SuccessPanel.Visible = false;

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลไม่สำเร็จ" + "');", true);
            }
        }
        if (Picture_FileUpload.HasFile)
        {
            string rename = SaveFile(Picture_FileUpload);

            if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().InsertQuery(IDProduct, DateTime.Now, DateTime.Now, 1, 1, "Picture", "Image/" + rename) == 1)
            {
                if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().InsertQuery(IDProduct, DateTime.Now, DateTime.Now, 1, 1, "Thumbnail", "Thumbnail/" + rename) == 1)
                {
                    //this.SuccessPanel.Visible = true;
                    //this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
                    //this.ErrorPanel.Visible = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลสำเร็จ" + "');", true);
                }
                else
                {
                    //this.ErrorPanel.Visible = true;
                    //this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
                    //this.SuccessPanel.Visible = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "บันทึกข้อมูลไม่สำเร็จ" + "');", true);
                }
            }
        }
    }



    //public void setcheckboxlist()
    //{

    //    string nameEn = "";
    //    string nameCH = "";  
    //    string name = "";
    //        string imageUrl = "Image/no_image_available.jpg";

    //    DataTable dt = new DataTable();
    //    dt.Columns.Add("Id");
    //    dt.Columns.Add("Name");
    //    dt.Columns.Add("ImageURL");
    //    dt.Columns.Add("NameEN");

    //    foreach (var item in innofood.TypeCates.Where(x => x.Status == 1))
    //    {
    //        long idtextcontect = long.Parse(item.Name);
    //        foreach (var item3 in innofood.TextContents.Where(x => x.Id == idtextcontect))
    //        {
    //            name = item3.Thai;
    //                    nameEn = item3.English;
    //                }
    //                imageUrl = item.UrlImage;
    //            dt.Rows.Add(item.Id, name, imageUrl, nameEn);
    //        }
    //    this.Category_CheckBoxList.DataSource = dt;
    //    this.Category_CheckBoxList.DataTextField = "Name";
    //    this.Category_CheckBoxList.DataValueField = "Id";
    //    this.Category_CheckBoxList.DataBind();
    //    }
    //this.Category_CheckBoxList.DataSource = new CommonClassLibrary.CommonDataSetTableAdapters.CategoryTableAdapter().GetData();
    //this.Category_CheckBoxList.DataTextField = "Name";
    //this.Category_CheckBoxList.DataValueField = "Id";
    //this.Category_CheckBoxList.DataBind();


    protected void ErrorLinkButton_Click(object sender, EventArgs e)
    {
        this.ErrorPanel.Visible = false;
    }

    protected void SuccessLinkButton_Click(object sender, EventArgs e)
    {
        this.SuccessPanel.Visible = false;
    }

    protected void Cancel_Button_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddMenu.aspx");
    }
    string SaveFile(FileUpload fileUpload)
    {
        HttpPostedFile UpFileProduct = fileUpload.PostedFile;

        string file = System.IO.Path.GetExtension(UpFileProduct.FileName);
        string rename = "";


        if (file == ".jpg" || file == ".png" || file == ".JPG" || file == ".PNG" || file == ".jpeg" || file == ".JPEG")
        {
            rename = DateTime.Now.ToString("ddMMyyyyHHmmss");

            System.Drawing.Image fullsize = System.Drawing.Image.FromStream(fileUpload.PostedFile.InputStream);

            int Width = 720, Height = 480;
            int NewWidth = 0, NewHeight = 0;
            decimal Ratio, Temp;

            Bitmap BMP = new Bitmap(fullsize);

            if (BMP.Width > BMP.Height)
            {
                Ratio = (decimal)Width / BMP.Width;
                NewWidth = Width;
                Temp = BMP.Height * Ratio;
                NewHeight = (int)Temp;
            }
            else
            {
                Ratio = (decimal)Height / BMP.Height;
                NewHeight = Height;
                Temp = BMP.Width * Ratio;
                NewWidth = (int)Temp;
            }

            Bitmap NewBMP = new Bitmap(BMP, NewWidth, NewHeight);
            Graphics graphice = Graphics.FromImage(NewBMP);
            graphice.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphice.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphice.DrawImage(BMP, 0, 0, NewWidth, NewHeight);

            string path = System.IO.Path.Combine(Server.MapPath("~/Image/"), rename + file);

            NewBMP.Save(path);

            BMP.Dispose();
            NewBMP.Dispose();
            graphice.Dispose();


            System.Drawing.Image fullsizeThumbail = System.Drawing.Image.FromStream(fileUpload.PostedFile.InputStream);
            int WidthThumbnail = 320, HeightThumbnail = 320;
            int NewWidthThumbnail = 0, NewHeightThumbnail = 0;
            decimal RatioThumbnail, TempThumbnail;

            Bitmap BMPThumbnail = new Bitmap(fullsizeThumbail);

            if (BMPThumbnail.Width > BMPThumbnail.Height)
            {
                RatioThumbnail = (decimal)WidthThumbnail / BMPThumbnail.Width;
                NewWidthThumbnail = WidthThumbnail;
                TempThumbnail = BMPThumbnail.Height * RatioThumbnail;
                NewHeightThumbnail = (int)TempThumbnail;
            }
            else
            {
                RatioThumbnail = (decimal)HeightThumbnail / BMPThumbnail.Height;
                NewHeightThumbnail = HeightThumbnail;
                TempThumbnail = BMPThumbnail.Height * RatioThumbnail;
                NewWidthThumbnail = (int)TempThumbnail;
            }

            Bitmap NewBMPThumbnail = new Bitmap(BMPThumbnail, NewWidthThumbnail, NewHeightThumbnail);
            Graphics graphicthumbnail = Graphics.FromImage(NewBMPThumbnail);
            graphicthumbnail.SmoothingMode = SmoothingMode.AntiAlias;
            graphicthumbnail.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphicthumbnail.DrawImage(BMPThumbnail, 0, 0, NewWidthThumbnail, NewHeightThumbnail);

            string paththumbnail = System.IO.Path.Combine(Server.MapPath("~/Thumbnail/"), rename + file);

            NewBMPThumbnail.Save(paththumbnail);

            BMPThumbnail.Dispose();
            NewBMPThumbnail.Dispose();
            graphicthumbnail.Dispose();
        }

        return rename + file;
    }
}