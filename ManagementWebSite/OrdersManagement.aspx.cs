using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TicketOrder : System.Web.UI.Page
{
    private CommonClassLibrary.ImilkEntities1 model;
    public TicketOrder()
    {
        model = new CommonClassLibrary.ImilkEntities1();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AppendHeader("Refresh", "15");
        int number1 = 0;
        string number2 = "";
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl Services = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li2");
            Services.Attributes.Add("class", "active");

            getdata();

        }
        if (Session["RowNumber"] != null)
        {
            number2 = Session["RowNumber"].ToString();
        }
        else
        {

            number2 = "0";
        }
        CommonClassLibrary.CommonDataSet.TicketOrderDetailDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.TicketOrderDetailTableAdapter().GetDataByStatusBetween23();
        number1 = collection.Count;
        if (number1 > int.Parse(number2))
        {
            Panel1.Visible = true;
            //SoundPlayer player = new SoundPlayer(Server.MapPath("~/assets/audio/alarm.wav"));
            //player.Play();
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\FTP\milkcafe\assets\audio\alarm.wav");
            //player.Play();
            //SoundPlayer x = new SoundPlayer();
            //x.SoundLocation = "WindowsBalloon.wav";
            ////x.Play();
            //x.PlaySync();
            Session["RowNumber"] = number1;
        }
        else
        {
            Panel1.Visible = false;
            Session["RowNumber"] = number1;
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

    protected void linkDetail(object sender, CommandEventArgs e)
    {
        long ID = long.Parse(e.CommandArgument.ToString());
        Response.Redirect("~/DetailOrdersManagement.aspx?Id=" + ID);
    }

    public void getdata()
    {
        CommonClassLibrary.CommonDataSet.View_TicketDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.View_TicketTableAdapter().GetDataByStatus23();
        this.TicketOrderRepeater.DataSource = collection;
        this.TicketOrderRepeater.DataBind();
        
    }

    protected void linkPayment(object sender, CommandEventArgs e)
    {

    }
    protected void linkCheckin(object sender, CommandEventArgs e)
    {

    }

    protected void linkCheckout(object sender, CommandEventArgs e)
    {

    }
    protected void TicketOrderRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        HiddenField Status = (HiddenField)e.Item.FindControl("Status_HiddenField");
        Label StatusLabel = (Label)e.Item.FindControl("StatusLabel");
        Label statusconfirm = (Label)e.Item.FindControl("statusconfirm");
        Label TicketCode_Label = (Label)e.Item.FindControl("TicketCode_Label");

        long IdTicket = long.Parse(TicketCode_Label.Text);
        var payment = model.Payments.Where(x => x.TicketOrder == IdTicket);
        //Label RemarkLabel = (Label)e.Item.FindControl("RemarkLabel");

        //string[] remark = Regex.Split(RemarkLabel.Text, ",");

        //RemarkLabel.Text = remark[0];
        long ChkPayment = long.Parse(statusconfirm.Text);
        if(ChkPayment == 1)
        {
            statusconfirm.Visible = true;
            statusconfirm.Text = "แจ้งชำระเงินแล้ว";
        }
        if (StatusLabel.Text == "2")
        {
            StatusLabel.Text = "รอรับออเดอร์";
            StatusLabel.Attributes.Add("class", "label label-warning");
        }
        else if (true)
        {
            StatusLabel.Text = "รับออเดอร์แล้ว";
            StatusLabel.Attributes.Add("class", "label label-primary");
        }
        if(payment.Count() > 0)
        {
            StatusLabel.Text = "ชำระเงินแล้ว";
            StatusLabel.Attributes.Add("class", "label label-success");
        }
        
    }
}