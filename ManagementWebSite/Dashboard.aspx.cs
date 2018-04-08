using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl AddMenu = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li4");
            AddMenu.Attributes.Add("class", "active");

            CommonClassLibrary.CommonDataSet.PaymentTicketOrderDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.PaymentTicketOrderTableAdapter().GetDatasumtotal();
            foreach (CommonClassLibrary.CommonDataSet.PaymentTicketOrderRow item in collection)
            {
                if (item.Total == 0)
                {
                    this.Lifetimesales_Label.Text = "0";
                }
                else
                {
                    this.Lifetimesales_Label.Text = item.Total.ToString("#,##0.00");
                }
            }
            CommonClassLibrary.CommonDataSet.PaymentTicketOrderDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.PaymentTicketOrderTableAdapter().GetDataBycountticket();
            foreach (CommonClassLibrary.CommonDataSet.PaymentTicketOrderRow item2 in collection2)
            {
                if (item2.Total == 0)
                {
                    this.Totalorders_Label.Text = "0";
                }
                else
                {
                    this.Totalorders_Label.Text = item2.Total.ToString("#,##0");
                }
            }
            if (Totalorders_Label.Text == "0")
            {
                this.Averageorder_Label.Text = "0";
            }
            else
            {
                this.Averageorder_Label.Text = (decimal.Parse(Lifetimesales_Label.Text) / decimal.Parse(Totalorders_Label.Text)).ToString("#,##0.00");
            }

            gettoptenrepeater();
            getnewuserrepeater();
            getneworderrepeater();
            getgraph();
        }
    }

    public void gettoptenrepeater()
    {
        this.TopRepeater.DataSource = new CommonClassLibrary.CommonDataSetTableAdapters.PaymentTicketOrderandDetailTableAdapter().GetDataTopTen();
        this.TopRepeater.DataBind();
    }

    public void getnewuserrepeater()
    {
        this.NewcustomerRepeater.DataSource = new CommonClassLibrary.CommonDataSetTableAdapters.UserTableAdapter().GetDataUserTopTen();
        this.NewcustomerRepeater.DataBind();
    }
    public void getneworderrepeater()
    {
        this.NewOrdersRepeater.DataSource = new CommonClassLibrary.CommonDataSetTableAdapters.TicketOrderProductOrderUserTableAdapter().GetDataTopTenOrders();
        this.NewOrdersRepeater.DataBind();
    }

    public void getgraph()
    {
        string graph = "";
        int d1 = 1, d2 = 2, d3 = 3, d4 = 4, d5 = 5, d6 = 6, d7 = 7, d8 = 8, d9 = 9, d10 = 10, d11 = 11, d12 = 12;
        decimal p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0, p6 = 0, p7 = 0, p8 = 0, p9 = 0, p10 = 0, p11 = 0, p12 = 0;

        CommonClassLibrary.CommonDataSet.GraphDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.GraphTableAdapter().GetDataGraphTotalWhereYear(decimal.Parse(DateTime.Now.ToString("yyyy")));
        foreach (CommonClassLibrary.CommonDataSet.GraphRow item in collection)
        {

            switch (item.Month)
            {
                case 1:
                    p1 = item.Total;
                    break;
                case 2:
                    p2 = item.Total;
                    break;
                case 3:
                    p3 = item.Total;
                    break;
                case 4:
                    p4 = item.Total;
                    break;
                case 5:
                    p5 = item.Total;
                    break;
                case 6:
                    p6 = item.Total;
                    break;
                case 7:
                    p7 = item.Total;
                    break;
                case 8:
                    p8 = item.Total;
                    break;
                case 9:
                    p9 = item.Total;
                    break;
                case 10:
                    p10 = item.Total;
                    break;
                case 11:
                    p11 = item.Total;
                    break;
                case 12:
                    p12 = item.Total;
                    break;
                default:
                    break;
            }
        }

        graph += "['" + 1 + "/" + DateTime.Now.ToString("yyyy") + " '," + p1 + "],";
        graph += "['" + 2 + "/" + DateTime.Now.ToString("yyyy") + " '," + p2 + "],";
        graph += "['" + 3 + "/" + DateTime.Now.ToString("yyyy") + " '," + p3 + "],";
        graph += "['" + 4 + "/" + DateTime.Now.ToString("yyyy") + " '," + p4 + "],";
        graph += "['" + 5 + "/" + DateTime.Now.ToString("yyyy") + " '," + p5 + "],";
        graph += "['" + 6 + "/" + DateTime.Now.ToString("yyyy") + " '," + p6 + "],";
        graph += "['" + 7 + "/" + DateTime.Now.ToString("yyyy") + " '," + p7 + "],";
        graph += "['" + 8 + "/" + DateTime.Now.ToString("yyyy") + " '," + p8 + "],";
        graph += "['" + 9 + "/" + DateTime.Now.ToString("yyyy") + " '," + p9 + "],";
        graph += "['" + 10 + "/" + DateTime.Now.ToString("yyyy") + " '," + p10 + "],";
        graph += "['" + 11 + "/" + DateTime.Now.ToString("yyyy") + " '," + p11 + "],";
        graph += "['" + 12 + "/" + DateTime.Now.ToString("yyyy") + " '," + p12 + "],";


        Graph_Literal.Text = @"<script type='text/javascript'>
        google.charts.load('current', { 'packages': ['corechart']});
        google.charts.setOnLoadCallback(drawChart);
        function drawChart(){
            var data = google.visualization.arrayToDataTable([

            ['Month', 'รายได้ (บาท)']," + graph +
            @"]);

         var options = {
                title: 'รายได้ทั้งหมดในปีนี้',
                hAxis: { title: 'เดือน / ปี', titleTextStyle: { color: '#333' } },
                vAxis: { minValue: 0 }
        };

        var chart = new google.visualization.AreaChart(document.getElementById('chart_div'));
        chart.draw(data, options);
        }
    </script>";

    }

    protected void NewOrdersRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label status = (Label)e.Item.FindControl("Label1");

        if (status.Text == "2")
        {
            status.Text = "รอยืนยันการสั่งซื้อ";
            status.Attributes.Add("style", "padding:5px; text-align:center; background-color:red; color:white");
        }
        else if (status.Text == "3")
        {
            status.Text = "รอการส่งออเดอร์";
            status.Attributes.Add("style", "padding:5px; text-align:center; background-color:orange; color:white");
        }
        else if (status.Text == "4")
        {
            status.Text = "เสร็จสิ้น";
            status.Attributes.Add("style", "padding:5px; text-align:center; background-color:green; color:white");
        }
        else if (status.Text == "100")
        {
            status.Text = "ยกเลิกการสั่งซื้อ";
            status.Attributes.Add("style", "padding:5px; text-align:center; background-color:blue; color:white");
        }
    }
}