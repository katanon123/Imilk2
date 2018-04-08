using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class print : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            long ID = long.Parse(Request.QueryString["Id"]); 
            
            getdatarepeater();
            this.DateLabel.Text = DateTime.Now.ToString();  
            this.IDT.Text = ID.ToString(); 
          
        }

    }
    public void getdatarepeater()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Product");
        //dt.Columns.Add("ProductDetail");
        dt.Columns.Add("Price");
        //dt.Columns.Add("Checkin");
        //dt.Columns.Add("Checkout");
        //dt.Columns.Add("Quantity");
        dt.Columns.Add("Total");
        dt.Columns.Add("ProductOrderID");
        decimal total = 0;
        long ID = long.Parse(Request.QueryString["Id"]);
        CommonClassLibrary.CommonDataSet.ProductOrderDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.ProductOrderTableAdapter().GetDataByTicketOrder(ID);
        foreach (CommonClassLibrary.CommonDataSet.ProductOrderRow item in collection)
        {
            CommonClassLibrary.CommonDataSet.ProductDetailDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().GetDataByProductShowName(item.Product);
            foreach (CommonClassLibrary.CommonDataSet.ProductDetailRow item2 in collection2)
            {
                total += item.Total;
                dt.Rows.Add(item2.KeyValue, item.Price.ToString("#,###") + ".-", item.Quantity, item.Total.ToString("#,###") + ".-", item.Id);  // item.LastUpdated.ToString("dd-MM-yyyy") + "   " + item.LastUpdated.ToString("HH:mm" + " น.")
            }
        }
      
        this.DetailTicketOrderRepeater.DataSource = dt;
        this.DetailTicketOrderRepeater.DataBind();
        this.Total_Label.Text = total.ToString("#,###") + ".-";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}