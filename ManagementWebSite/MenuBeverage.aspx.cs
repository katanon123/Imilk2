using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class MenuBeverage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Categoryli = int.Parse(Request.QueryString["Category"]);
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl Services = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li1");
            Services.Attributes.Add("class", "active");

            string Category = Request.QueryString["Category"];
            getMenu();
            this.BackMenu_HyperLink.NavigateUrl = "~/MenuBeverage.aspx?Category=" + Category;
            if (Category != "0")
            {
                getbeveragerepeater();
            }
            else
            {
                this.getProductAll();
            }
        }
    }

    
    public void getMenu()
    {
        int Category = int.Parse(Request.QueryString["Category"]);
        if (Category > 0)
        {
            CommonClassLibrary.CommonDataSet.CategoryDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.CategoryTableAdapter().GetDataByID(Category);
            foreach (CommonClassLibrary.CommonDataSet.CategoryRow item in collection)
            {
                CommonClassLibrary.CommonDataSet.TextContentDataTable collection3 = new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().GetDataById(long.Parse(item.Name));
                foreach (CommonClassLibrary.CommonDataSet.TextContentRow item3 in collection3)
                {
                    this.Menu2_Label.Text = item3.Thai;
                    this.BackMenu_HyperLink.Text = item3.English;
                }
                //this.Menu_Label.Text = item.Name;
                //this.Menu2_Label.Text = item.Name;
                //this.BackMenu_HyperLink.Text = item.Name;
            }
        }
        else
        {
            this.Menu2_Label.Text = "รายการอาหารเเละเครื่องดื่มทั้งหมด";
            this.BackMenu_HyperLink.Text = "รายการอาหารเเละเครื่องดื่มทั้งหมด";
        }


    }
    public void getbeveragerepeater()
    {
        string nameEn = "";
        string nameCH = "";
        int Category = int.Parse(Request.QueryString["Category"]);
        DataTable dt = new DataTable();
        dt.Columns.Add("IDProduct");
        dt.Columns.Add("Name");
        dt.Columns.Add("ImageURL");
        dt.Columns.Add("Detail");
        dt.Columns.Add("Price");
        dt.Columns.Add("PromotionPrice");
        dt.Columns.Add("NameEn");
        CommonClassLibrary.CommonDataSet.ProductCateDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.ProductCateTableAdapter().GetDataByCategory(Category);
        foreach (CommonClassLibrary.CommonDataSet.ProductCateRow item in collection)
        {
            string name = "";
            string imageUrl = "Image/no_image_available.jpg";
            string detail = "";
            string price = "";
            string promotion = "";
            CommonClassLibrary.CommonDataSet.ProductDetailDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().GetDataByProduct(item.Product);
            foreach (CommonClassLibrary.CommonDataSet.ProductDetailRow item2 in collection2)
            {

                if (item2.KeyName == "Name")
                {
                    name = item2.KeyValue;
                    CommonClassLibrary.CommonDataSet.TextContentDataTable collection3 = new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().GetDataById(long.Parse(item2.KeyValue));
                    foreach (CommonClassLibrary.CommonDataSet.TextContentRow item3 in collection3)
                    {
                        name = item3.Thai;
                        nameEn = item3.English;
                    }
                }
                else if (item2.KeyName == "Picture")
                {
                    if (item2.KeyValue == "")
                    {
                        imageUrl = "no_image_available.jpg";
                    }
                    else
                    {
                        imageUrl = item2.KeyValue;
                    }
                }
                else if (item2.KeyName == "Detail")
                {
                    detail = item2.KeyValue;
                }
                else if (item2.KeyName == "Price")
                {
                    price = double.Parse(item2.KeyValue).ToString("#.###") + ".-";
                }
                else if (item2.KeyName == "PromotionPrice")
                {
                    if (item2.KeyValue == "-")
                    {
                        promotion = (item2.KeyValue);

                    }
                    else
                    {
                        promotion = double.Parse(item2.KeyValue).ToString("#.###") + ".-";
                    }
                }
            }
            dt.Rows.Add(item.Product, name, imageUrl, detail, price, promotion,nameEn);


        }
        this.BeverageRepeater.DataSource = dt;
        this.BeverageRepeater.DataBind();

    }
    public void getProductAll()
    {
        int Category = int.Parse(Request.QueryString["Category"]);
        DataTable dt = new DataTable();
        dt.Columns.Add("IDProduct");
        dt.Columns.Add("Name");
        dt.Columns.Add("ImageURL");
        dt.Columns.Add("Detail");
        dt.Columns.Add("Price");
        dt.Columns.Add("PromotionPrice");
        dt.Columns.Add("NameEn"); string nameEn = "";
        string nameCH = "";
        CommonClassLibrary.CommonDataSet.ProductCateDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.ProductCateTableAdapter().GetData();
        foreach (CommonClassLibrary.CommonDataSet.ProductCateRow item in collection)
        {
            string name = "";
            string imageUrl = "Image/no_image_available.jpg";
            string detail = "";
            string price = "";
            string promotion = "";
            CommonClassLibrary.CommonDataSet.ProductDetailDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().GetDataByProduct(item.Product);
            foreach (CommonClassLibrary.CommonDataSet.ProductDetailRow item2 in collection2)
            {

                if (item2.KeyName == "Name")
                {
                    name = item2.KeyValue;
                    CommonClassLibrary.CommonDataSet.TextContentDataTable collection3 = new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().GetDataById(long.Parse(item2.KeyValue));
                    foreach (CommonClassLibrary.CommonDataSet.TextContentRow item3 in collection3)
                    {
                        name = item3.Thai;
                        nameEn = item3.English;
                    }
                }
                else if (item2.KeyName == "Picture")
                {
                    if (item2.KeyValue == "")
                    {
                        imageUrl = "no_image_available.jpg";
                    }
                    else
                    {
                        imageUrl = item2.KeyValue;
                    }
                }
                else if (item2.KeyName == "Detail")
                {
                    detail = item2.KeyValue;
                }
                else if (item2.KeyName == "Price")
                {
                    price = double.Parse(item2.KeyValue).ToString("#.###") + ".-";
                }
                else if (item2.KeyName == "PromotionPrice")
                {
                    if (item2.KeyValue == "-")
                    {
                        promotion = (item2.KeyValue);

                    }
                    else
                    {
                        promotion = double.Parse(item2.KeyValue).ToString("#.###") + ".-";
                    }
                }
            }
            dt.Rows.Add(item.Product, name, imageUrl, detail, price, promotion, nameEn);


        }
        this.BeverageRepeater.DataSource = dt;
        this.BeverageRepeater.DataBind();
    }
    protected void linkDelete(object sender, CommandEventArgs e)
    {
        int IDProduct = int.Parse(e.CommandArgument.ToString());
        if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().UpdateQueryStatus(0,IDProduct) > 0)
        {
            if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductCateTableAdapter().DeleteQueryProduct(IDProduct) > 0)
            {
                if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductTableAdapter().UpdateQueryStatus(DateTime.Now, 0,IDProduct) > 0)
                {
                    this.SuccessPanel.Visible = true;
                    this.SuccessLabel.Text = "ลบข้อมูลสำเร็จ";
                    this.ErrorPanel.Visible = false;
                    getbeveragerepeater();
                }
                else
                {
                    this.ErrorPanel.Visible = true;
                    this.ErrorLabel.Text = "ลบข้อมูลไม่สำเร็จ";
                    this.SuccessPanel.Visible = false;
                }
            }
            else
            {
                this.ErrorPanel.Visible = true;
                this.ErrorLabel.Text = "ลบข้อมูลไม่สำเร็จ";
                this.SuccessPanel.Visible = false;
            }
        }
        else
        {
            this.ErrorPanel.Visible = true;
            this.ErrorLabel.Text = "ลบข้อมูลไม่สำเร็จ";
            this.SuccessPanel.Visible = false;
        }
    }
    public void linkEdit(object sender, CommandEventArgs e)
    {
        string Category = Request.QueryString["Category"];
        int IDProduct = int.Parse(e.CommandArgument.ToString());
        Response.Redirect("~/EditBeverage.aspx?IDProduct=" + IDProduct + "&Category=" + Category);
    }
    protected void SuccessLinkButton_Click(object sender, EventArgs e)
    {
        this.SuccessPanel.Visible = false;
    }

    protected void ErrorLinkButton_Click(object sender, EventArgs e)
    {
        this.ErrorPanel.Visible = false;
    }

    protected void BeverageRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton Edit = (LinkButton)e.Item.FindControl("Edit_LinkButton");

        int Category = int.Parse(Request.QueryString["Category"]);

        //if (Category == 1)
        //{
        //    Edit.Visible = false;
        //}
    }

    protected void AddButton_Click(object sender, EventArgs e)
    {
        long cate = long.Parse(Request.QueryString["Category"]);
        long type = long.Parse(Request.QueryString["Type"]);
        Response.Redirect("~/addMenu.aspx?Type="+type+"&Id="+cate);
    }
}