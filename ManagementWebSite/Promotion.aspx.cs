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
        
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl Services = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li5");
            Services.Attributes.Add("class", "active");
            
            this.BackMenu_HyperLink.NavigateUrl = "~/Promotion.aspx";
                getbeveragerepeater();
        }
    }

    
   
    public void getbeveragerepeater()
    {
        string nameEn = "";
        string nameCH = "";
        DataTable dt = new DataTable();
        dt.Columns.Add("IDProduct");
        dt.Columns.Add("Name");
        dt.Columns.Add("ImageURL");
        dt.Columns.Add("Detail");
        dt.Columns.Add("DetailEn");
        dt.Columns.Add("Price");
        dt.Columns.Add("PromotionPrice");
        dt.Columns.Add("NameEn");
        CommonClassLibrary.CommonDataSet.ProductCateDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.ProductCateTableAdapter().GetDataByCategory(30);
        foreach (CommonClassLibrary.CommonDataSet.ProductCateRow item in collection)
        {
            string name = "";
            string imageUrl = "Image/no_image_available.jpg";
            string detail = "";
            string detailEn = "";
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
                    CommonClassLibrary.CommonDataSet.TextContentDataTable collection3 = new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().GetDataById(long.Parse(item2.KeyValue));
                    foreach (CommonClassLibrary.CommonDataSet.TextContentRow item3 in collection3)
                    {
                        detail = item3.Thai;
                        detailEn = item3.English;
                    }
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
            dt.Rows.Add(item.Product, name, imageUrl, detail, detailEn, price, promotion,nameEn);


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
        int IDProduct = int.Parse(e.CommandArgument.ToString());
        Response.Redirect("~/EditPromotions.aspx?IDProduct=" + IDProduct);
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

    }

    protected void AddButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AddPromotions.aspx");
    }
}