using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IncomeInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl Services = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li4");
            Services.Attributes.Add("class", "active");

            getdata();


        }
    }



    //protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    //{
    //    this.Calendar1.Visible = false;
    //    this.Button1.Text = this.Calendar1.SelectedDate.ToString("yyyy-MM-dd HH:mm:ss");
    //}

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    this.Calendar1.Visible = true;
    //}



    //protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    //{
    //    this.Calendar2.Visible = false;
    //    this.Button2.Text = this.Calendar2.SelectedDate.ToString("yyyy-MM-dd HH:mm:ss");
    //    this.textBox.Text = this

    //}

    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    this.Calendar2.Visible = true;

    //}

    public void getdata()
    {
        //string day = "";
        //DataTable dt = new DataTable();
        //dt.Columns.Add("Id");
        //dt.Columns.Add("Code");
        //dt.Columns.Add("Status");
        //dt.Columns.Add("Day");
        //dt.Columns.Add("Total");

        ////CommonClassLibrary.CommonDataSet.TicketOrderDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.TicketOrderTableAdapter().GetData();
        ////foreach (CommonClassLibrary.CommonDataSet.TicketOrderRow item in collection)
        ////{
        ////    if (item.Status == 2 || item.Status == 3) //confirm
        ////    {
        ////        CommonClassLibrary.CommonDataSet.OrderDetailDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.OrderDetailTableAdapter().GetDataByTicketOrder(item.Id);
        ////        foreach (CommonClassLibrary.CommonDataSet.OrderDetailRow item2 in collection2)
        ////        {
        ////            day = item2.CheckInDate.ToString("dd-MM-yyyy");
        ////            time = item2.CheckInDate.ToString("HH:mm:ss");
        ////            dt.Rows.Add(item.Id, "DGS-" + item.Id, item.Status, day, time);
        ////        }

        ////    }

        //CommonClassLibrary.CommonDataSet.TicketOrderDetailDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.TicketOrderDetailTableAdapter().GetDataByStatusBetween23();
        //foreach (CommonClassLibrary.CommonDataSet.TicketOrderDetailRow item in collection)
        //{
        //    day = item.CheckInDate.ToString("dd-MM-yyyy");

        //    dt.Rows.Add(item.Id, "DGS-" + item.Id, item.Status, day);
        //}
        //this.TicketOrderRepeater.DataSource = dt;
        //this.TicketOrderRepeater.DataBind();
        System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-US");
        decimal total = 0;
        string day;
        DataTable dt = new DataTable();
        dt.Columns.Add("Day");
        dt.Columns.Add("Code");
        dt.Columns.Add("Total");

        DateTime sta = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

        DateTime end = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
        CommonClassLibrary.CommonDataSet.PaymentProductOrderDetailUserDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.PaymentProductOrderDetailUserTableAdapter().GetDataStartDateEndDate(sta.ToString("MM-dd-yyyy"), end.ToString("MM-dd-yyyy"));
        foreach (CommonClassLibrary.CommonDataSet.PaymentProductOrderDetailUserRow item in collection)
        {
            day = item.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
            total += item.Total;
            dt.Rows.Add(day, "DGS-" + item.TicketOrder, item.Total.ToString("#,###") + ".-");
        }
        this.TicketOrderRepeater.DataSource = dt;
        this.TicketOrderRepeater.DataBind();
        this.Total_Label.Text = total.ToString("#,###") + ".-";

    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-US");

        if (Date_TextBox1.Text != "" && Date_TextBox2.Text != "")
        {
            decimal total = 0;
            string day;
            DataTable dt = new DataTable();
            dt.Columns.Add("Day");
            dt.Columns.Add("Code");
            dt.Columns.Add("Total");

            DateTime sta = DateTime.Parse((DateTime.Parse(this.Date_TextBox1.Text)).ToString("yyyy-MM-dd"));
            DateTime end = DateTime.Parse((DateTime.Parse(this.Date_TextBox2.Text)).ToString("yyyy-MM-dd 23:59:59"));
            //DateTime sta = DateTime.Parse.ToString();
            //DateTime end = DateTime.
            //DateTime end = Convert.ToDateTime(Date_TextBox2.Text);
            CommonClassLibrary.CommonDataSet.PaymentProductOrderDetailUserDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.PaymentProductOrderDetailUserTableAdapter().GetDataStartDateEndDate(sta.ToString("MM-dd-yyyy"), end.ToString("MM-dd-yyyy"));
            foreach (CommonClassLibrary.CommonDataSet.PaymentProductOrderDetailUserRow item in collection)
            {
                day = item.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
                total += item.Total;
                dt.Rows.Add(day, "DGS-" + item.TicketOrder, item.Total.ToString("#,###") + ".-");
            }
            this.TicketOrderRepeater.DataSource = dt;
            this.TicketOrderRepeater.DataBind();
            this.Total_Label.Text = total.ToString("#,###") + ".-";
        }
        else
        {
            notification(false, "เลือกวันที่เริ่มต้นการค้นหา และวันที่สุดท้ายการค้นหาด้วยครับ");
        }
    }




    protected void Button4_Click(object sender, EventArgs e)
    {
        System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-US");

        decimal total = 0;
        string day;
        DataTable dt = new DataTable();
        dt.Columns.Add("Day");
        dt.Columns.Add("Code");
        dt.Columns.Add("Total");

        DateTime sta = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

        DateTime end = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
        CommonClassLibrary.CommonDataSet.PaymentProductOrderDetailUserDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.PaymentProductOrderDetailUserTableAdapter().GetDataStartDateEndDate(sta.ToString("MM-dd-yyyy"), end.ToString("MM-dd-yyyy"));
        foreach (CommonClassLibrary.CommonDataSet.PaymentProductOrderDetailUserRow item in collection)
        {
            day = item.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
            total += item.Total;
            dt.Rows.Add(day, "DGS-" + item.TicketOrder, item.Total.ToString("#,###") + ".-");
        }
        this.TicketOrderRepeater.DataSource = dt;
        this.TicketOrderRepeater.DataBind();
        this.Total_Label.Text = total.ToString("#,###") + ".-";

    }
    protected void notification(bool rs, string errormsg)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('" + errormsg + "');", true);
    }
}