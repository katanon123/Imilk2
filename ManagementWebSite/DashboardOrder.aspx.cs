using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DashboardOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClassLibrary.CommonDataSet.PaymentTicketOrderDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.PaymentTicketOrderTableAdapter().GetDatasumtotal();
            foreach (CommonClassLibrary.CommonDataSet.PaymentTicketOrderRow item in collection)
            {
                this.Lifetimesales_Label.Text = item.Total.ToString("#,##0.00");
            }
            CommonClassLibrary.CommonDataSet.PaymentTicketOrderDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.PaymentTicketOrderTableAdapter().GetDataBycountticket();
            foreach (CommonClassLibrary.CommonDataSet.PaymentTicketOrderRow item2 in collection2)
            {
                this.Totalorders_Label.Text = item2.Total.ToString("#,##0");
            }
            this.Averageorder_Label.Text = (decimal.Parse(Lifetimesales_Label.Text) / decimal.Parse(Totalorders_Label.Text)).ToString("#,##0.00");
        }
    }

    public void getallordersrepeater()
    {
        //this.AllOrders_Repeater.DataSource = new CommonClassLibrary.CommonDataSetTableAdapters.PaymentProductOrderDetailUserTableAdapter().GetDataStartDateEndDate()
    }
}