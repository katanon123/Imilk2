using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DetailTicketOrder : System.Web.UI.Page
{
    private CommonClassLibrary.ImilkEntities1 model;
    public DetailTicketOrder()
    {
        model = new CommonClassLibrary.ImilkEntities1();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl Services = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Li2");
            Services.Attributes.Add("class", "active");

            long ID = long.Parse(Request.QueryString["Id"]);
            CommonClassLibrary.CommonDataSet.OrderDetailDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.OrderDetailTableAdapter().GetDataByTicketOrder(ID);
            if (collection.Rows.Count > 0)
            {
                foreach (CommonClassLibrary.CommonDataSet.OrderDetailRow item in collection)
                {
                    CommonClassLibrary.CommonDataSet.UserAccountDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.UserAccountTableAdapter().GetDataById(item.Customer);
                    foreach (CommonClassLibrary.CommonDataSet.UserAccountRow item2 in collection2)
                    {
                        this.Customer_Label.Text = item2.FirstName + " " + item2.LastName;
                        this.Confirmdatetime_Label.Text = item.CheckInDate.ToString();
                    }
                }
            }
            getdatarepeater();
            getdatarepeater1();
            GetDataPrint();
            this.Ticket_Label.Text = "DGS - " + ID.ToString();
            showbutton();
            if (model.ConfirmPayments.Where(x=>x.TicketOrder == ID).Count() > 0) { 
            GetPaymentDetail();
            }
        }
    }
    public void GetPaymentDetail()
    {
        PaymentPanel.Visible = true;
        long ID = long.Parse(Request.QueryString["Id"]);

        CommonClassLibrary.ConfirmPayment con = model.ConfirmPayments.Where(x => x.TicketOrder == ID).First();
        string[] dateFull = con.Date.ToString().Split(' ');
        lb_DatePayment.Text = dateFull[0] + " " + con.Time.ToString();
        lb_AmountPayment.Text = con.Price.ToString("#,##0.0") + " บาท";
        if (con.Detiail.Equals(""))
        {
            lb_remark.Text = "-";
        }
        else
        {
            lb_remark.Text = con.Detiail.ToString();
        }
        CommonClassLibrary.Account ac = model.Accounts.Where(x => x.Id == con.Id_Account).First();

        lb_AccountPayment.Text = ac.Bank + " เลขที่ : " + ac.Idname + " ชื่อบัญชี : " + ac.Name;
        if (con.UrlImage != "")


        {
            this.Image_category.ImageUrl = "/Image/" + con.UrlImage;
        }
        else
        {
            Image_category.ImageUrl = "" + "no_image_available.jpg";
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

    public void getdatarepeater()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Product");
        //dt.Columns.Add("ProductDetail");
        dt.Columns.Add("Price");
        dt.Columns.Add("Checkin");
        dt.Columns.Add("Checkout");
        dt.Columns.Add("Quantity");
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
                string name = "";
                CommonClassLibrary.CommonDataSet.TextContentDataTable dt1 = new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().GetDataById(long.Parse(item2.KeyValue));
                name = dt1.Rows[0]["Thai"].ToString();
                total += item.Total;
                dt.Rows.Add(name, item.Price.ToString("#,###") + ".-", item.CreatedDate.ToString("dd-MM-yyyy") + "   " + item.CreatedDate.ToString("HH:mm" + " น."), item.LastUpdated.ToString("dd-MM-yyyy") + "   " + item.LastUpdated.ToString("HH:mm" + " น."), item.Quantity, item.Total.ToString("#,###") + ".-", item.Id);
            }
        }

        this.DetailTicketOrderRepeater.DataSource = dt;
        this.DetailTicketOrderRepeater.DataBind();
        this.Label1.Text = total.ToString("#,###") + ".-";
    }
    public void getdatarepeater1()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Product");
        //dt.Columns.Add("ProductDetail");
        dt.Columns.Add("Price");
        dt.Columns.Add("Checkin");
        dt.Columns.Add("Checkout");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Total");
        dt.Columns.Add("ProductOrderID");
        decimal total = 0;
        long ID = long.Parse(Request.QueryString["Id"]);
        CommonClassLibrary.CommonDataSet.ProductOrderDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.ProductOrderTableAdapter().GetDataByTicket2(ID);
        foreach (CommonClassLibrary.CommonDataSet.ProductOrderRow item in collection)
        {
            CommonClassLibrary.CommonDataSet.ProductDetailDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().GetDataByProductShowName(item.Product);
            foreach (CommonClassLibrary.CommonDataSet.ProductDetailRow item2 in collection2)
            {
                string name = "";
                CommonClassLibrary.CommonDataSet.TextContentDataTable dt1 = new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().GetDataById(long.Parse(item2.KeyValue));
                name = dt1.Rows[0]["Thai"].ToString();
                total += item.Total;
                dt.Rows.Add(name, item.Price.ToString("#,###") + ".-", item.CreatedDate.ToString("dd-MM-yyyy") + "   " + item.CreatedDate.ToString("HH:mm" + " น."), item.LastUpdated.ToString("dd-MM-yyyy") + "   " + item.LastUpdated.ToString("HH:mm" + " น."), item.Quantity, item.Total.ToString("#,###") + ".-", item.Id);
            }
        }

        this.DetailTicketOrderRepeater1.DataSource = dt;
        this.DetailTicketOrderRepeater1.DataBind();
        this.Total_Label.Text = total.ToString("#,###") + ".-";
    }
    protected void Payment_LinkButton(object sender, CommandEventArgs e)
    {
        string ProductOrderID = e.CommandArgument.ToString();
        long ID = long.Parse(Request.QueryString["Id"]);
        HttpCookie cookie = Request.Cookies[Resources.Resource.CookieName];
        if (new CommonClassLibrary.CommonDataSetTableAdapters.PaymentTableAdapter().InsertQuery(ID, ProductOrderID, DateTime.Now, DateTime.Now, 0, int.Parse(cookie.Values["Id"])) == 1)
        {
            this.SuccessPanel.Visible = true;
            this.SuccessLabel.Text = "ชำระเงินสำเร็จ";
            this.ErrorPanel.Visible = false;
        }
        else
        {
            this.ErrorPanel.Visible = true;
            this.ErrorLabel.Text = "ชำระเงินไม่สำเร็จ";
            this.SuccessPanel.Visible = false;
        }
    }

    protected void Checkin_LinkButton(object sender, CommandEventArgs e)
    {
        string ProductOrderID = e.CommandArgument.ToString();
        long ID = long.Parse(Request.QueryString["Id"]);
        HttpCookie cookie = Request.Cookies[Resources.Resource.CookieName];
        if (new CommonClassLibrary.CommonDataSetTableAdapters.CheckInTableAdapter().InsertQuery(ID, ProductOrderID, DateTime.Now, DateTime.Now, 0, int.Parse(cookie.Values["Id"])) > 0)
        {
            this.SuccessPanel.Visible = true;
            this.SuccessLabel.Text = "Check-In สำเร็จ";
            this.ErrorPanel.Visible = false;
        }
        else
        {
            this.ErrorPanel.Visible = true;
            this.ErrorLabel.Text = "Check-In ไม่สำเร็จ";
            this.SuccessPanel.Visible = false;
        }
    }

    protected void Checkout_LinkButton(object sender, CommandEventArgs e)
    {
        string ProductOrderID = e.CommandArgument.ToString();
        long ID = long.Parse(Request.QueryString["Id"]);
        HttpCookie cookie = Request.Cookies[Resources.Resource.CookieName];
        if (new CommonClassLibrary.CommonDataSetTableAdapters.CheckOutTableAdapter().InsertQuery(ID, ProductOrderID, DateTime.Now, DateTime.Now, 0, int.Parse(cookie.Values["Id"])) == 1)
        {
            if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductOrderTableAdapter().UpdateQueryOnlyStatus(ID, 1, long.Parse(ProductOrderID)) == 1)
            {
                this.SuccessPanel.Visible = true;
                this.SuccessLabel.Text = "Check-Out สำเร็จ";
                this.ErrorPanel.Visible = false;
            }
            else
            {
                this.ErrorPanel.Visible = true;
                this.ErrorLabel.Text = "Check-Out ไม่สำเร็จ";
                this.SuccessPanel.Visible = false;
            }
        }
        else
        {
            this.ErrorPanel.Visible = true;
            this.ErrorLabel.Text = "Check-Out ไม่สำเร็จ";
            this.SuccessPanel.Visible = false;
        }
    }


    protected void DetailTicketOrderRepeater_ItemDataBound1(object sender, RepeaterItemEventArgs e)
    {
        LinkButton Checkin = (LinkButton)e.Item.FindControl("Checkin_LinkButton");
        LinkButton Checkout = (LinkButton)e.Item.FindControl("Checkout_LinkButton");
        LinkButton Payment = (LinkButton)e.Item.FindControl("Payment_LinkButton");
        Label ProductOrderID = (Label)e.Item.FindControl("ProductOrderID_Label");
        int ID = int.Parse(Request.QueryString["Id"]);

        CommonClassLibrary.CommonDataSet.CheckInDataTable chkin = new CommonClassLibrary.CommonDataSetTableAdapters.CheckInTableAdapter().GetDataByRemark(ProductOrderID.Text);
        if (chkin.Rows.Count > 0)
        {
            Checkin.Enabled = false;
            Checkin.CssClass = "btn Default disabled";
        }

        CommonClassLibrary.CommonDataSet.PaymentDataTable payment = new CommonClassLibrary.CommonDataSetTableAdapters.PaymentTableAdapter().GetDataByRemark(ProductOrderID.Text);
        if (payment.Rows.Count > 0)
        {
            Payment.Enabled = false;
            Payment.CssClass = "btn Default disabled";
        }

        if (chkin.Rows.Count > 0 && payment.Rows.Count > 0)
        {
            CommonClassLibrary.CommonDataSet.CheckOutDataTable chkout = new CommonClassLibrary.CommonDataSetTableAdapters.CheckOutTableAdapter().GetDataByRemark(ProductOrderID.Text);
            if (chkout.Rows.Count == 0)
            {
                Checkout.Enabled = true;
                Checkout.CssClass = "btn yellow";
            }
        }
    }

    protected void DetailTicketOrderRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        LinkButton Checkin = (LinkButton)e.Item.FindControl("Checkin_LinkButton");
        LinkButton Checkout = (LinkButton)e.Item.FindControl("Checkout_LinkButton");
        LinkButton Payment = (LinkButton)e.Item.FindControl("Payment_LinkButton");

        if (e.CommandName == "CheckinLink")
        {
            Checkin.Enabled = false;
            Checkin.CssClass = "btn Default disabled";
            if (Payment.Enabled == false)
            {
                Checkout.Enabled = true;
                Checkout.CssClass = "btn yellow";
            }
            else
            {
                Checkout.Enabled = false;
            }
        }
        else if (e.CommandName == "PaymentLink")
        {
            Payment.Enabled = false;
            Payment.CssClass = "btn Default disabled";
            if (Checkin.Enabled == false)
            {
                Checkout.Enabled = true;
                Checkout.CssClass = "btn yellow";
            }
            else
            {
                Checkout.Enabled = false;
            }
        }
        else if (e.CommandName == "CheckoutLink")
        {
            Checkout.Enabled = false;
            Checkout.CssClass = "btn Default disabled";
        }
    }

    protected void Completeorder_Button_Click(object sender, EventArgs e)
    {
        long ID = long.Parse(Request.QueryString["Id"]);
        if (new CommonClassLibrary.CommonDataSetTableAdapters.TicketOrderTableAdapter().UpdateQuery(DateTime.Now, DateTime.Now, 4, ID) == 1)
        {
            this.SuccessPanel.Visible = true;
            this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
            this.ErrorPanel.Visible = false;
            Response.Redirect("~/OrdersManagement.aspx");
        }
        else
        {
            this.SuccessPanel.Visible = false;
            this.ErrorPanel.Visible = true;
            this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
        }
    }

    protected void Confirmorder_Button_Click(object sender, EventArgs e)
    {
        long ID = long.Parse(Request.QueryString["Id"]);
        DataTable dt = new DataTable();
        dt.Columns.Add("Product");
        //dt.Columns.Add("ProductDetail");
        dt.Columns.Add("Price");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Total");
        dt.Columns.Add("ProductOrderID");
        decimal total = 0;
        CommonClassLibrary.CommonDataSet.ProductOrderDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.ProductOrderTableAdapter().GetDataByTicketOrder(ID);
        foreach (CommonClassLibrary.CommonDataSet.ProductOrderRow item in collection)
        {
            CommonClassLibrary.CommonDataSet.ProductDetailDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().GetDataByProductShowName(item.Product);
            foreach (CommonClassLibrary.CommonDataSet.ProductDetailRow item2 in collection2)
            {
                total += item.Price * item.Quantity;
                dt.Rows.Add(item2.KeyValue, item.Price.ToString("#,###.00"), item.Quantity.ToString("#,###.00"), (item.Price * item.Quantity).ToString("#,###") + ".-", item.Id);
            }
        }
        //Session["aaa"] = dt;
        //Session["bb"] = total.ToString("#,###") + ".-";
        if (new CommonClassLibrary.CommonDataSetTableAdapters.TicketOrderTableAdapter().UpdateQuery(DateTime.Now, DateTime.Now, 3, ID) == 1)
        {
            if (new CommonClassLibrary.CommonDataSetTableAdapters.ProductOrderTableAdapter().UpdateQueryStatus2(ID) != 0)
            {
                this.SuccessPanel.Visible = true;
                this.SuccessLabel.Text = "บันทึกข้อมูลสำเร็จ";
                this.ErrorPanel.Visible = false;
                showbutton();
                //Bill();
            }
            else
            {
                this.SuccessPanel.Visible = false;
                this.ErrorPanel.Visible = true;
                this.ErrorLabel.Text = "บันทึกข้อมูลไม่สำเร็จ";
            }
            getdatarepeater1();


            this.DetailTicketOrderRepeater.DataSource = dt;
            this.DetailTicketOrderRepeater.DataBind();
            this.Total_Label.Text = total.ToString("#,###") + ".-";
            
        }
    }
    public void GetDataPrint()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Product");
        //dt.Columns.Add("ProductDetail");
        dt.Columns.Add("Price");
        dt.Columns.Add("Checkin");
        dt.Columns.Add("Checkout");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Total");
        dt.Columns.Add("ProductOrderID");
        decimal total = 0;
        long ID = long.Parse(Request.QueryString["Id"]);
        CommonClassLibrary.CommonDataSet.ProductOrderDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.ProductOrderTableAdapter().GetDataByTicket2(ID);
        foreach (CommonClassLibrary.CommonDataSet.ProductOrderRow item in collection)
        {
            CommonClassLibrary.CommonDataSet.ProductDetailDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().GetDataByProductShowName(item.Product);
            foreach (CommonClassLibrary.CommonDataSet.ProductDetailRow item2 in collection2)
            {
                string name = "";
                CommonClassLibrary.CommonDataSet.TextContentDataTable dt1 = new CommonClassLibrary.CommonDataSetTableAdapters.TextContentTableAdapter().GetDataById(long.Parse(item2.KeyValue));
                name = dt1.Rows[0]["Thai"].ToString();
                total += item.Total;
                dt.Rows.Add(name, item.Price.ToString("#,###") + ".-", item.CreatedDate.ToString("dd-MM-yyyy") + "   " + item.CreatedDate.ToString("HH:mm" + " น."), item.LastUpdated.ToString("dd-MM-yyyy") + "   " + item.LastUpdated.ToString("HH:mm" + " น."), item.Quantity, item.Total.ToString("#,###") + ".-", item.Id);
            }
        }
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        Label3.Text = total.ToString("#,###") + ".-";
        DateLabel.Text = DateTime.Now.ToString();
        IDT.Text = ID.ToString();
    }
    protected void Payment_Button_Click(object sender, EventArgs e)
    {
        long ID = long.Parse(Request.QueryString["Id"]);
        DataTable dt = new DataTable();
        dt.Columns.Add("Product");
        //dt.Columns.Add("ProductDetail");
        dt.Columns.Add("Price");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Total");
        dt.Columns.Add("ProductOrderID");
        decimal total = 0;
        CommonClassLibrary.CommonDataSet.ProductOrderDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.ProductOrderTableAdapter().GetDataByTicketOrder(ID);
        foreach (CommonClassLibrary.CommonDataSet.ProductOrderRow item in collection)
        {
            CommonClassLibrary.CommonDataSet.ProductDetailDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.ProductDetailTableAdapter().GetDataByProductShowName(item.Product);
            foreach (CommonClassLibrary.CommonDataSet.ProductDetailRow item2 in collection2)
            {
                total += item.Price * item.Quantity;
                dt.Rows.Add(item2.KeyValue, item.Price.ToString("#,###.00"), item.Quantity.ToString("#,###.00"), (item.Price * item.Quantity).ToString("#,###") + ".-", item.Id);

            }
        }

        // Session["aaa"] = dt;
        // Session["bb"] = total.ToString("#,###") + ".-";

        HttpCookie cookie = Request.Cookies[Resources.Resource.CookieName];
        if (new CommonClassLibrary.CommonDataSetTableAdapters.PaymentTableAdapter().InsertQuery(ID, "-", DateTime.Now, DateTime.Now, 0, int.Parse(cookie.Values["Id"])) == 1)
        {
            this.SuccessPanel.Visible = true;
            this.SuccessLabel.Text = "ชำระเงินสำเร็จ";
            this.ErrorPanel.Visible = false;
            
            //ConfirmOrderPrintPanel.Visible = true;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "PrintConfirmDiv()", true);

            showbutton();
        }
        else
        {
            this.SuccessPanel.Visible = false;
            this.ErrorPanel.Visible = true;
            this.ErrorLabel.Text = "ชำระเงินไม่สำเร็จ";
        }
    }

    public void showbutton()
    {
        long ID = long.Parse(Request.QueryString["Id"]);
        CommonClassLibrary.CommonDataSet.TicketOrderDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.TicketOrderTableAdapter().GetDataByID(ID);
        foreach (CommonClassLibrary.CommonDataSet.TicketOrderRow item in collection)
        {
            if (item.Status == 2)
            {
                this.Confirmorder_Button.Visible = true;
                this.Completeorder_Button.Visible = false;
                this.Payment_Button.Visible = false;

            }
            else if (item.Status == 3)
            {
                this.orderTa.Visible = false;
                this.Confirmorder_Button.Visible = false;
                this.Completeorder_Button.Visible = true;
                this.Payment_Button.Visible = true;
                CommonClassLibrary.CommonDataSet.PaymentDataTable collection2 = new CommonClassLibrary.CommonDataSetTableAdapters.PaymentTableAdapter().GetDataByTicketOrder(ID);
                if (collection2.Rows.Count == 1)
                {
                    this.Payment_Button.CssClass = "btn green disabled";
                }
                else
                {
                    this.Payment_Button.Enabled = true;
                }
            }
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        long ID = long.Parse(Request.QueryString["Id"]); // รับค่าจาก url 

        string returnUrl = "~/print.aspx?Id=" + ID;
        Response.Redirect(returnUrl);  // เปลี่ยนหน้า

    }

    public void Bill()
    {
        long ID = long.Parse(Request.QueryString["Id"]); // รับค่าจาก url 

        string returnUrl = "~/print.aspx?Id=" + ID;
        Response.Redirect(returnUrl);  // เปลี่ยนหน้า


    }

    public bool DetailOrdersManagement { get; set; }

}