using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master : System.Web.UI.MasterPage
{
    private CommonClassLibrary.ImilkEntities1 innofood;
    public Master()
    {
        innofood = new CommonClassLibrary.ImilkEntities1();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            try
            {
                this.TicketOrder_Label.Text = new CommonClassLibrary.CommonDataSetTableAdapters.TicketOrderTableAdapter().ScalarQueryStatusbetween23().ToString();
                //OrderServices_Label.Text = new CommonClassLibrary.CommonDataSetTableAdapters.ProductOrderTableAdapter().ScalarQuery().ToString();
                //    //PaymentTicketOrder_Label.Text = new CommonClassLibrary.CommonDataSetTableAdapters.PaymentTableAdapter().ScalarQuery().ToString();
                this.UserGroup_Label.Text = new CommonClassLibrary.CommonDataSetTableAdapters.UserGroupTableAdapter().ScalarQuery().ToString();
                this.UserAccount_Label.Text = innofood.UserAccounts.Where(x => x.Status != 0).Count().ToString();
                this.Label1.Text = new CommonClassLibrary.CommonDataSetTableAdapters.UserAccountTableAdapter().GetDataByStatus100().Rows.Count.ToString();
                HttpCookie cookieFirstname = Request.Cookies[Resources.Resource.CookieName];
                this.NameUserLabel.Text = cookieFirstname.Values["FirstName"];
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Login.aspx");
            }

            //    //if (cookieFirstname != null)
            //    //{
            //    //    int ID = int.Parse(cookieFirstname.Values["Id"]);

            //    //    CommonClassLibrary.CommonDataSet.AccountGroupDataTable collection = new CommonClassLibrary.CommonDataSetTableAdapters.AccountGroupTableAdapter().GetDataByUserAccount(ID);
            //    //    if (collection.Rows.Count > 0)
            //    //    {
            //    //        foreach (CommonClassLibrary.CommonDataSet.AccountGroupRow item in collection)
            //    //        {
            //    //            if (item.UserGroup == 2)
            //    //            {
            //    //                //this.Li1.Visible = true;
            //    //                this.Li2.Visible = true;
            //    //                this.Center_Panel.Visible = true;
            //    //            }
            //    //        }
            //    //    }

            //    //}
            //    //else
            //    //{
            //    //    Response.Redirect("~/Login.aspx");
            //    //}
            setcate();
            setlist();


        }

    }

    //public string CurrentPageName { get; set; }
    public string CurrentUrl(string textconnect)
    {
        return Path.GetFileName(Request.Url.AbsolutePath) + Request.QueryString[textconnect];
    }

    public string ActiveType(string value, string url, string textconnect)
    {
        return CurrentUrl(textconnect) == url + value ? "active" : string.Empty;
    }

    public string ActiveCate(string value, string url, string textconnect)
    {
        return CurrentUrl(textconnect) == url + value ? "active" : string.Empty;
    }



    public void setlist()
    {
        string nameEn = "";
        string nameCH = "";
        string name = "";
        string imageUrl = "Image/no_image_available.jpg";
        int TypeLog = 0;

        DataTable dt = new DataTable();
        dt.Columns.Add("Id");
        dt.Columns.Add("type");
        dt.Columns.Add("Name");
        dt.Columns.Add("ImageURL");
        dt.Columns.Add("NameEN");
        dt.Columns.Add("Title");

        foreach (var item in innofood.Categories.Where(x => x.Status == 1).OrderBy(x => x.TypeId))
        {
            long idtextcontect = long.Parse(item.Name);
            foreach (var item3 in innofood.TextContents.Where(x => x.Id == idtextcontect))
            {
                name = item3.Thai;
                nameEn = item3.English;

            }
            if (item.TypeId != TypeLog)
            {
                imageUrl = item.ImageURL;
                TypeLog = item.TypeId;
                int idText = int.Parse(innofood.TypeCates.Where(x => x.Id == item.TypeId).First().Name);
                dt.Rows.Add(item.Id, item.TypeId, name, imageUrl, nameEn,
                  "<li><a><span style='color:#4d90fe'><strong>" + innofood.TextContents.Where(x => x.Id == idText).First().Thai + "</strong></span></a></li>");
            }
            else
            {
                imageUrl = item.ImageURL;
                int idText = int.Parse(innofood.TypeCates.Where(x => x.Id == item.TypeId).First().Name);
                dt.Rows.Add(item.Id, item.TypeId, name, imageUrl, nameEn, "<span></span>");
            }
        }
        this.Repeater1.DataSource = dt;
        this.Repeater1.DataBind();
    }
    public void setcate()
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

        foreach (var item in innofood.TypeCates.Where(x => x.Status > 0))
        {
            long idtextcontect = long.Parse(item.Name);
            foreach (var item3 in innofood.TextContents.Where(x => x.Id == idtextcontect))
            {
                name = item3.Thai;
                nameEn = item3.English;

            }
            imageUrl = item.UrlImage;
            dt.Rows.Add(item.Id, name, imageUrl, nameEn);
        }
        this.Repeater2.DataSource = dt;
        this.Repeater2.DataBind();
    }
    public void setpage()
    {
        //this.Li1.Visible = false;
        this.Li2.Visible = false;
    }
}
