using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditBeverage : System.Web.UI.Page
{
    private CommonClassLibrary.ImilkEntities1 innofoodmodel;
    public EditBeverage()
    {
        innofoodmodel = new CommonClassLibrary.ImilkEntities1();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl Services = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li1");
            Services.Attributes.Add("class", "active");

            int IDProduct = int.Parse(Request.QueryString["IDProduct"]);
            getcategorycheckbox();

           
            CommonClassLibrary.CommonDataSet.ProductDetailDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().GetDataByProductShowName(IDProduct);
            foreach (CommonClassLibrary.CommonDataSet.ProductDetailRow item in collection)
            {
                Label4.Text = item.KeyValue;
                CommonClassLibrary.CommonDataSet.TextContentDataTable collection111 = new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().GetDataById(long.Parse(item.KeyValue));
                foreach (CommonClassLibrary.CommonDataSet.TextContentRow item111 in collection111)
                {
                    this.Name_TextBox.Text = item111.Thai;
                    this.NameEN_TextBox.Text = item111.English;

                }
            }

            CommonClassLibrary.CommonDataSet.ProductDetailDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().GetDataByProductShowDetail(IDProduct);
            foreach (CommonClassLibrary.CommonDataSet.ProductDetailRow item2 in collection2)
            {
                Label5.Text = item2.KeyValue;

                CommonClassLibrary.CommonDataSet.TextContentDataTable collection222 = new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().GetDataById(long.Parse(item2.KeyValue));

                foreach (CommonClassLibrary.CommonDataSet.TextContentRow item222 in collection222)
                {
                    this.Detail_TextBox.Text = item222.Thai;
                    this.DetailEN_TextBox.Text = item222.English;
                }
            }

            CommonClassLibrary.CommonDataSet.ProductDetailDataTable collection3 = new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().GetDataByProductShowPrice(IDProduct);
            foreach (CommonClassLibrary.CommonDataSet.ProductDetailRow item3 in collection3)
            {
                this.Price_TextBox.Text = item3.KeyValue;
            }

            CommonClassLibrary.CommonDataSet.ProductDetailDataTable collection4 = new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().GetDataByProductShowPromotionPrice(IDProduct);
            foreach (CommonClassLibrary.CommonDataSet.ProductDetailRow item4 in collection4)
            {
                if (item4.KeyValue != "-")
                {
                    this.PromotionPrice_TextBox.Text = item4.KeyValue;
                }
            }

            

            CommonClassLibrary.CommonDataSet.ProductCateDataTable collection6 = new CommonClassLibrary.CommonDataSetTableAdapters.ProductCateTableAdapter().GetDataByProduct(IDProduct);
            foreach (CommonClassLibrary.CommonDataSet.ProductCateRow item6 in collection6)
            {
                radiobutton.SelectedValue = Request.QueryString["Category"]; //setselect
            }
            
            getImage();
            getMenu();
        }
    }
    public void getMenu()
    {
        int Category = int.Parse(Request.QueryString["Category"]);
        string IDProduct = Request.QueryString["IDProduct"];
        this.BackMenu_HyperLink.NavigateUrl = "~/MenuBeverage.aspx?IDProduct=" + IDProduct + "&Category=" + Category;

        CommonClassLibrary.CommonDataSet.CategoryDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.CategoryTableAdapter().GetDataByID(Category);
        foreach (CommonClassLibrary.CommonDataSet.CategoryRow item in collection)
        {
            CommonClassLibrary.CommonDataSet.TextContentDataTable collection222 = new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().GetDataById(long.Parse(item.Name));

            foreach (CommonClassLibrary.CommonDataSet.TextContentRow item222 in collection222)
            {
            this.Menu2_Label.Text = "แก้ไข " + item222.Thai;
            this.BackMenu_HyperLink.Text = item222.Thai;
            this.Menu1_Label.Text = "แก้ไข " + item222.Thai;
            }
          
        }
    }
    public void getImage()
    {
        int IDProduct = int.Parse(Request.QueryString["IDProduct"]);
        try { 
        var inno = innofoodmodel.ProductDetails.Where(x => x.Product == IDProduct).Where(x => x.KeyName == "Picture").First().KeyValue;
        this.Picture_Image.ImageUrl = inno;
        }
        catch (Exception ex) { 
            this.Picture_Image.ImageUrl = "~/Image/innofood.jpg";
        }

    }
    public void getcategorycheckbox()
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
        dt.Columns.Add("NameCN");
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
            dt.Rows.Add(item.Id, name, imageUrl, nameEn, nameCH);
        }
        this.radiobutton.DataSource =dt;
        this.radiobutton.DataTextField = "Name";
        this.radiobutton.DataValueField = "Id";
        this.radiobutton.DataBind();
    }

    protected void Confirm_Button_Click(object sender, EventArgs e)
    {
        int IDProduct = int.Parse(Request.QueryString["IDProduct"]);
        //Name
         if (new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().UpdateQueryById(Name_TextBox.Text, NameEN_TextBox.Text," ",DateTime.Now,1, long.Parse(Label4.Text)) == 1)
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
        //Detail
         if (new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().UpdateQueryById(Detail_TextBox.Text, DetailEN_TextBox.Text, " ", DateTime.Now,1, long.Parse(Label5.Text)) == 1)
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
        //if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().UpdateQuery(IDProduct, DateTime.Now, DateTime.Now, 1, 1, "Name", this.Name_TextBox.Text) == 1)
        //{
        //    this.SuccessPanel.Visible = true;
        //    this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
        //    this.ErrorPanel.Visible = false;
        //    this.PictureSuccessPanel.Visible = false;
        //    this.PictureErrorPanel.Visible = false;
        //}
        //else
        //{
        //    this.SuccessPanel.Visible = false;
        //    this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
        //    this.ErrorPanel.Visible = true;
        //    this.PictureSuccessPanel.Visible = false;
        //    this.PictureErrorPanel.Visible = false;
        //}
     
        if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().UpdateQuery(IDProduct, DateTime.Now, DateTime.Now, 1, 1, "Price", this.Price_TextBox.Text) == 1)
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
        if (this.PromotionPrice_TextBox.Text != "")
        {
            if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().UpdateQuery(IDProduct, DateTime.Now, DateTime.Now, 1, 1, "PromotionPrice", this.PromotionPrice_TextBox.Text) == 1)
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
        else
        {
            if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().UpdateQuery(IDProduct, DateTime.Now, DateTime.Now, 1, 1, "PromotionPrice", "-") == 1)
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






        if (Picture_FileUpload.HasFile) {

        string namefile = SaveFile(Picture_FileUpload);

        CommonClassLibrary.CommonDataSet.ProductDetailDataTable collection3 = new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().GetDataByProduceShowImage(IDProduct);
        if (collection3.Rows.Count > 0)
        {
            if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().UpdateQuery(IDProduct, DateTime.Now, DateTime.Now, 1, 1, "Picture", "Image/" + namefile) == 1)
            {
                if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().UpdateQuery(IDProduct, DateTime.Now, DateTime.Now, 1, 1, "Thumbnail", "Thumbnail/" + namefile) == 1)
                {
                        this.SuccessPanel.Visible = true;
                        this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
                        this.ErrorPanel.Visible = false;
                        getImage();
                }
                else
                {
                        this.SuccessPanel.Visible = false;
                        this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
                        this.ErrorPanel.Visible = true;
                    }
            }
            else
            {
                    this.SuccessPanel.Visible = false;
                    this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
                    this.ErrorPanel.Visible = true;
                }
        }
        else
        {
            if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().InsertQuery(IDProduct, DateTime.Now, DateTime.Now, 1, 1, "Picture", "Image/" + namefile) == 1)
            {
                if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().InsertQuery(IDProduct, DateTime.Now, DateTime.Now, 1, 1, "Thumbnail", "Thumbnail/" + namefile) == 1)
                {
                        this.SuccessPanel.Visible = true;
                        this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
                        this.ErrorPanel.Visible = false;
                        getImage();
                }
                else
                {
                        this.SuccessPanel.Visible = false;
                        this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
                        this.ErrorPanel.Visible = true;
                    }
            }
            else
            {
                    this.SuccessPanel.Visible = false;
                    this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
                    this.ErrorPanel.Visible = true;
                }
        }
    }
        












        if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductCateTableAdapter().DeleteQueryProduct(IDProduct) > 0)
        {
            
                if (radiobutton.SelectedItem.Selected)
                {
                    if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductCateTableAdapter().InsertQuery(IDProduct, int.Parse(radiobutton.SelectedItem.Value)) == 1)
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

        //for (int i = 0; i < Category_CheckBoxList.Items.Count; i++)
        //{
        //    if (Category_CheckBoxList.Items[i].Selected)
        //    {
        //        CommonClassLibrary.CommonDataSet.ProductCateDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.ProductCateTableAdapter().GetDataByProductandCategory(IDProduct, int.Parse(Category_CheckBoxList.SelectedValue));
        //        if (collection.Rows.Count == 0)
        //        {
        //            if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductCateTableAdapter().InsertQuery(IDProduct, int.Parse(Category_CheckBoxList.SelectedValue)) == 1)
        //            {
        //                this.SuccessPanel.Visible = true;
        //                this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
        //                this.ErrorPanel.Visible = false;
        //                this.PictureSuccessPanel.Visible = false;
        //                this.PictureErrorPanel.Visible = false;
        //            }
        //            else
        //            {
        //                this.SuccessPanel.Visible = false;
        //                this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
        //                this.ErrorPanel.Visible = true;
        //                this.PictureSuccessPanel.Visible = false;
        //                this.PictureErrorPanel.Visible = false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        CommonClassLibrary.CommonDataSet.ProductCateDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.ProductCateTableAdapter().GetDataByProductandCategory(IDProduct, i + 1);
        //        if (collection2.Rows.Count == 1)
        //        {
        //            if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductCateTableAdapter().DeleteQueryProductandCategory(IDProduct, i + 1) == 1)
        //            {
        //                this.SuccessPanel.Visible = true;
        //                this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
        //                this.ErrorPanel.Visible = false;
        //                this.PictureSuccessPanel.Visible = false;
        //                this.PictureErrorPanel.Visible = false;
        //            }
        //            else
        //            {
        //                this.SuccessPanel.Visible = false;
        //                this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
        //                this.ErrorPanel.Visible = true;
        //                this.PictureSuccessPanel.Visible = false;
        //                this.PictureErrorPanel.Visible = false;
        //            }
        //        }
        //    }
        //}
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
    protected void SuccessLinkButton_Click(object sender, EventArgs e)
    {
        this.SuccessPanel.Visible = false;
    }
    protected void ErrorLinkButton_Click(object sender, EventArgs e)
    {
        this.ErrorPanel.Visible = false;
    }
}