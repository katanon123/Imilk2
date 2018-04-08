using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Globalization;

namespace MobileAppsWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private DataAccess da;

        public Service1()
        {
            da = new DataAccess();

        }

        #region UserAccount
        public List<UserAccount> GetUserAccount()
        {
            return da.GetUserAccount().ToList();
        }
        public List<UserAccount> GetUserAccountById(string Id)
        {
            return da.GetUserAccountById(long.Parse(Id)).ToList();
        }


        public UserAccount InsertQueryUserAccount(UserAccount AddUser)
        {
            return da.InsertQueryUserAccount(AddUser);
        }



        public List<UserAccount> GetUserAccountBySignIn(string Email, string Password)
        {
            return da.GetUserAccountBySignIn(Email, Password).ToList();
        }


        public Result UpdateQueryUserCountById(UserAccount UpDateUser)
        {
            return da.UpdateQueryUserCountById(UpDateUser);
        }

        public Result UpDateChangePassword(ChangePassword o)
        {
            return da.UpDateChangePassword(o);
        }

        public UserAccount GetUserAccountBySignIn2(UserAccount SignIn)
        {
            return da.GetUserAccountBySignIn2(SignIn);
        }

        #endregion

        #region ProductCategory
        public List<ProductCate> GetProductCate()
        {
            return da.GetProductCate().ToList();
        }

        #endregion

        #region Product
        public List<Product> GetProduct()
        {
            return da.GetProduct().ToList();
        }
        public List<Product> GetProductall()
        {
            return da.GetProductall().ToList();
        }
        public List<Product> GetProductsByCategory(GetProductParam Param)
        {
            return da.GetProductsByCategory(Param.CheckInDate, Param.CheckOutDate, Param.Category).ToList();
        }

        public List<Product> GetProductsPromotion()
        {
            return da.GetProductsPromotion().ToList();
        }

        public List<Product> GetProductById(string Id)
        {
            return da.GetProductById(int.Parse(Id)).ToList();
        }


        public List<Product> GetProductBycate(string Category)
        {
            return da.GetProductCateByCategory2(int.Parse(Category)).ToList();
        }

        public List<Product> GetDataCategoryRecommend(string Category)
        {
            return da.GetDataCategoryRecommend(int.Parse(Category)).ToList();
        }


        public List<Textmessage> GetTextmessage()
        {
            return da.GetTextmessage().ToList();
        }


        #endregion

        #region ProductDetail
        public List<ProductDetail> GetProductDetailByProduct(string Product)
        {
            return da.GetProductDetailByProduct(int.Parse(Product)).ToList();
        }

        public List<ProductDetail> GetProductImageByProductId(string Product)
        {
            return da.GetProductImageByProductId(int.Parse(Product)).ToList();
        }

        #endregion

        #region TicketOrder
        public TicketOrder InsertTicketOrder(TicketOrder AddTicketOrder)
        {
            return da.InsertTicketOrder(AddTicketOrder);
        }

        public Result UpdateOrderStatusByOrderId(TicketOrder UpDateTicketOrder)
        {
            return da.UpdateOrderStatusByOrderId(UpDateTicketOrder);
        }

        public Result UpdateStatusById(TicketOrder UpdateStatus)
        {
            return da.UpdateStatusById(UpdateStatus);
        }

        public Result CancelStatusById(TicketOrder CancleStatus)
        {
            return da.CancelStatusById(CancleStatus);
        }

        public Result ConfirmOrder(TicketOrderConfirm param)
        {
            return da.ConfirmOrder(param);
        }

        public List<TicketOrder> GetTicketOrderById(string Id)
        {
            return da.GetTicketOrderById(long.Parse(Id)).ToList();
        }
        public List<TicketOrder> GetTicketOrderByStatus1OR2()
        {
            return da.GetTicketOrderByStatus1OR2().ToList();
        }
        #endregion
        #region account
        public List<Account> GetAllAccount()
        {
            return da.GetAllAccount().ToList();
        }
        public List<Account> GetAccountById(Account id)
        {
            return da.GetAccountById(id).ToList();
        }
        #endregion
        #region ProductOrder

        public Result InsertProductOrder(ProductOrder AddProductOrder)
        {
            return da.InsertProductOrder(AddProductOrder);
        }

        public List<ProductOrder> GetMyOrder(string TicketOrder)
        {
            return da.GetMyOrder(int.Parse(TicketOrder)).ToList();
        }

        public Result DeleteProductOrder(ProductOrder Delete)
        {
            return da.DeleteProductOrder(Delete);
        }
        public Result DeleteProductOrderById(ProductOrder Delete)
        {
            return da.DeleteProductOrderById(Delete);
        }

        public List<ProductOrder> GetProductOrderByProduct(GetProductOrderParam Param)
        {
            return da.GetProductOrderByProduct(Param.CheckInDate, Param.CheckOutDate, Param.Product).ToList();
        }


        //IEnumerable<ProductOrder> GetProductOrderByProduct(string CheckInDate, string CheckOutDate, long Product)



        #endregion

        #region OrderDetail
        public List<OrderDetail> GetOrderDetailByOrderId(string OrderId)
        {
            return da.GetOrderDetailByOrderId(int.Parse(OrderId)).ToList();
        }




        #endregion

        #region Category

        public List<Category> GetCategory()
        {
            return da.GetCategory().ToList();
        }
        public List<Category> GetCategoryById(string Id)
        {
            return da.GetCategoryById(int.Parse(Id)).ToList();
        }

        public List<Category> GetCategoryByType(string Type)
        {
            return da.GetCategoryByType(int.Parse(Type)).ToList();
        }

        #endregion
        #region ConfirmPayment
        public ConFirmPayment InsertQueryConfirmPayment(ConFirmPayment AddConPay)
        {
            ConFirmPayment cp = da.InsertQueryConfirmPayment(AddConPay);
            if (!cp.Equals(null))
            {
                Result rt = da.UpdateChkPaymentByTicketOrder(int.Parse(AddConPay.TicketOrder.ToString()));
            }
            return cp;

        }
        public List<ConFirmPayment> GetPaymentbyTicket(string TicketOrder)
        {
            return da.GetPaymentbyTicket(long.Parse(TicketOrder)).ToList();
        }
        #endregion
        #region Category

        public List<Type> GetType()
        {
            return da.GetType().ToList();
        }
        #endregion
        #region Category

        public Result CommentAdd(Comment AddComment)
        {
            return da.addCommentAdd(AddComment);
        }
        #endregion
        public List<Table> GetTable()
        {
            return da.GetTable().ToList();
        }

    }

    public class DataAccess
    {
        private DataSet1TableAdapters.UserAccountTableAdapter tta;
        private DataSet1TableAdapters.ProductCategoryTableAdapter ttb;
        private DataSet1TableAdapters.ProductTableAdapter ttc;
        private DataSet1TableAdapters.AccountGroupTableAdapter ttd;
        private DataSet1TableAdapters.ProductDetailTableAdapter tte;
        private DataSet1TableAdapters.TicketOrderTableAdapter ttf;
        private DataSet1TableAdapters.ProductOrderTableAdapter ttg;
        private DataSet1TableAdapters.OrderDetailTableAdapter tth;
        private DataSet1TableAdapters.ProductCateTableAdapter tti;
        private DataSet1TableAdapters.CategoryTableAdapter ttj;
        private DataSet1TableAdapters.ProductCategoryRecommendTableAdapter ProductRecom;
        private DataSet1TableAdapters.TableTableAdapter TableTA;
        private DataSet1TableAdapters.View_TicketTableAdapter View_TicketTA;
        private DataSet1TableAdapters.TypeCateTableAdapter Type1;
        private DataSet1TableAdapters.CommentTableAdapter commentdata;
        private DataSet1TableAdapters.TextContentTableAdapter textTa;
        private DataSet1TableAdapters.TextMessageTableAdapter textMTa;
        private DataSet1TableAdapters.AccountTableAdapter Account;
        private DataSet1TableAdapters.ConfirmPaymentTableAdapter ConfirmPayment;
        public DataAccess()
        {
            tta = new DataSet1TableAdapters.UserAccountTableAdapter();
            ttb = new DataSet1TableAdapters.ProductCategoryTableAdapter();
            ttc = new DataSet1TableAdapters.ProductTableAdapter();
            ttd = new DataSet1TableAdapters.AccountGroupTableAdapter();
            tte = new DataSet1TableAdapters.ProductDetailTableAdapter();
            ttf = new DataSet1TableAdapters.TicketOrderTableAdapter();
            ttg = new DataSet1TableAdapters.ProductOrderTableAdapter();
            tth = new DataSet1TableAdapters.OrderDetailTableAdapter();
            tti = new DataSet1TableAdapters.ProductCateTableAdapter();
            ttj = new DataSet1TableAdapters.CategoryTableAdapter();
            Type1 = new DataSet1TableAdapters.TypeCateTableAdapter();
            ProductRecom = new DataSet1TableAdapters.ProductCategoryRecommendTableAdapter();
            TableTA = new DataSet1TableAdapters.TableTableAdapter();
            View_TicketTA = new DataSet1TableAdapters.View_TicketTableAdapter();
            textTa = new DataSet1TableAdapters.TextContentTableAdapter();
            textMTa = new DataSet1TableAdapters.TextMessageTableAdapter();
            commentdata = new DataSet1TableAdapters.CommentTableAdapter();
            Account = new DataSet1TableAdapters.AccountTableAdapter();
            ConfirmPayment = new DataSet1TableAdapters.ConfirmPaymentTableAdapter();
        }

        #region UserAccount

        public IEnumerable<UserAccount> GetUserAccount()
        {
            DataSet1.UserAccountDataTable dt = tta.GetData();
            foreach (DataSet1.UserAccountRow dr in dt)
            {
                yield return new UserAccount()
                {
                    Id = dr.Id,
                    FirstName = dr.FirstName,
                    LastName = dr.LastName,
                    Email = dr.Email,
                    Password = dr.Password,
                    MobilePhoneNumber = dr.MobilePhoneNumber,
                    CreateDate = dr.CreatedDate,
                    LastUpdated = dr.LastUpdated,
                    Status = dr.Status
                };
            }
        }

        public IEnumerable<UserAccount> GetUserAccountById(long Id)
        {

            DataSet1.UserAccountDataTable dt = tta.GetUserAccountById(Id);
            foreach (DataSet1.UserAccountRow dr in dt)
            {
                yield return new UserAccount()
                {
                    Id = dr.Id,
                    FirstName = dr.FirstName,
                    LastName = dr.LastName,
                    Email = dr.Email,
                    Password = dr.Password,
                    MobilePhoneNumber = dr.MobilePhoneNumber,
                    CreateDate = dr.CreatedDate,
                    LastUpdated = dr.LastUpdated,
                    Status = dr.Status
                };
            }

        }

        public IEnumerable<UserAccount> GetUserAccountBySignIn(string Email, string Password)
        {

            DataSet1.UserAccountDataTable dt = tta.GetUserAccountBySignIn(Email, Password);
            foreach (DataSet1.UserAccountRow dr in dt)
            {
                yield return new UserAccount() { Id = dr.Id, FirstName = dr.FirstName, LastName = dr.LastName, Email = dr.Email, Password = dr.Password, MobilePhoneNumber = dr.MobilePhoneNumber, CreateDate = dr.CreatedDate, LastUpdated = dr.LastUpdated, Status = dr.Status };
            }
        }


        public UserAccount GetUserAccountBySignIn2(UserAccount SignIn)
        {
            tta.GetUserAccountBySignIn(SignIn.Email, SignIn.Password);
            DataSet1.UserAccountDataTable dt = tta.GetUserAccountBySignIn(SignIn.Email, SignIn.Password);
            UserAccount u = new UserAccount();
            foreach (DataSet1.UserAccountRow dr in dt)
            {
                u = new UserAccount() { Id = dr.Id, FirstName = dr.FirstName, LastName = dr.LastName, Email = dr.Email, Password = dr.Password, MobilePhoneNumber = dr.MobilePhoneNumber, CreateDate = dr.CreatedDate, LastUpdated = dr.LastUpdated, Status = dr.Status };
            }
            return u;
        }


        public UserAccount InsertQueryUserAccount(UserAccount AddUser)
        {
            long Id = (long)tta.InsertQueryScopeIdentity(AddUser.FirstName, AddUser.LastName, AddUser.Email, AddUser.Password, AddUser.MobilePhoneNumber, DateTime.Now, DateTime.Now, 100, AddUser.ImageUrl);
            UserAccount o = new UserAccount();
            if (Id > 0)
            {
                long Id2 = (long)ttd.InsertUserAccountGroup(Id, 1, DateTime.Now, DateTime.Now, 1);

                DataSet1.UserAccountDataTable dt = tta.GetUserAccountById(Id);
                foreach (DataSet1.UserAccountRow dr in dt)
                {
                    o = new UserAccount()
                    {
                        Id = dr.Id,
                        FirstName = dr.FirstName,
                        LastName = dr.LastName,
                        Email = dr.Email,
                        Password = dr.Password,
                        MobilePhoneNumber = dr.MobilePhoneNumber,
                        CreateDate = dr.CreatedDate,
                        LastUpdated = dr.LastUpdated,
                        Status = dr.Status,
                        ImageUrl = dr.ImageUrl

                    };
                }
            }
            return o;

        }

        public Result UpdateQueryUserCountById(UserAccount UpDateUser)
        {
            tta.UpdateQueryUserAccountById(UpDateUser.FirstName, UpDateUser.LastName, UpDateUser.Email, UpDateUser.Password, UpDateUser.MobilePhoneNumber, DateTime.Now, UpDateUser.Status, UpDateUser.Id);

            DataSet1.UserAccountDataTable dt = tta.GetUserAccountById(UpDateUser.Id);
            Result o = new Result();
            foreach (DataSet1.UserAccountRow dr in dt)
            {
                o = new Result() { Message = "Success ", Success = true };
            }
            return o;
        }


        public Result UpDateChangePassword(ChangePassword o)
        {

            Result rs = new Result() { Success = false, Message = "" };
            DataSet1.UserAccountDataTable userDt = tta.GetUserAccountById(o.Id);

            if (userDt != null)
            {
                string p = userDt.Rows[0]["Password"].ToString();
                if (p != o.OldPassword)
                {
                    rs.Success = false;
                    rs.Message = "Old Password Incorrect.";
                    return rs;
                }
                else
                {
                    rs.Success = true;
                    rs.Message = "Password changed";

                    tta.UpdateQueryChangePassword(o.NewPassword, o.Id);

                    return rs;
                }

            }
            return rs;
        }

        #endregion

        #region ProductCategory

        public IEnumerable<ProductCate> GetProductCate()
        {
            DataSet1.ProductCateDataTable dt = tti.GetData();
            foreach (DataSet1.ProductCateRow dr in dt)
            {

                yield return new ProductCate()
                {
                    Id = dr.Id,
                    Product = dr.Product,
                    Category = dr.Category

                };
            }
        }


        //public IEnumerable<OrderDetail> GetOrderDetailByOrderId(long OrderId)
        //{
        //    OrderDetail o = new OrderDetail();
        //    DataSet1.OrderDetailDataTable collection = new DataSet1TableAdapters.OrderDetailTableAdapter().GetDataByTicketOrder(OrderId);
        //    if (collection.Rows.Count > 0)
        //    {
        //        foreach (DataSet1.OrderDetailRow item in collection)
        //        {
        //            o.CheckInDate = item.CheckInDate.ToString("dd-MM-yyyy");
        //            o.CheckOutDate = item.CheckOutDate.ToString("dd-MM-yyyy");
        //            o.CreatedDate = item.CreatedDate;
        //            o.Customer = item.Customer;
        //            o.Id = item.Id;
        //            o.LastUpdated = item.LastUpdated;
        //            o.Remark = item.Remark;
        //            o.Staus = item.Status;
        //            o.TicketOrder = item.TicketOrder;

        //            yield return o;
        //        }
        //    }
        //}

        #endregion

        #region Product
        public IEnumerable<Product> GetProduct()
        {
            DataSet1.ProductDataTable dt = ttc.GetData();
            foreach (DataSet1.ProductRow dr in dt)
            {
                yield return new Product()
                {
                    Id = dr.Id,
                    CreatedDate = dr.CreatedDate,
                    LastUpdated = dr.LastUpdated,
                    Status = dr.Status,
                    CreatedBy = dr.CreatedBy
                };
            }
        }

        public IEnumerable<Product> GetProductCateByCategory(int Category)
        {
            DataSet1.ProductCateDataTable dt = tti.GetProductCateByCategory(Category);
            foreach (DataSet1.ProductCateRow dr in dt)
            {
                DataSet1.ProductDetailDataTable pdName = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Name");
                DataSet1.ProductDetailDataTable pdPicture = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Thumbnail");
                DataSet1.ProductDetailDataTable pdPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Price");
                DataSet1.ProductDetailDataTable pdDetail = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Detail");
                DataSet1.ProductDetailDataTable pdPromotionPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "PromotionPrice");
                DataSet1.ProductDataTable pd = new DataSet1TableAdapters.ProductTableAdapter().GetProductById(dr.Product);

                Product o = new Product();

                string x = "http://services.totiti.net/Imilk/";

                if (pdName.Rows.Count > 0)
                {
                    o.Name = pdName.Rows[0]["KeyValue"].ToString();
                    IEnumerable<Name> pdtext = this.getdatanamebyId(long.Parse(o.Name));
                    foreach (Name item in pdtext)
                    {
                        o.NameProduct = item;
                    }
                }
                if (pdPicture.Rows.Count > 0)
                {
                    string picpath = pdPicture.Rows[0]["KeyValue"].ToString();
                    //o.Picture = x + "Thumbnail/" + picpath.Substring(picpath.IndexOf("/") + 1, picpath.Length - picpath.IndexOf("/") - 1);
                    o.Picture = x + picpath;
                }
                else
                {
                    o.Picture = "http://services.totiti.net/Imilk/Thumbnail/no_image_available.png";
                }
                if (pdPrice.Rows.Count > 0)
                {
                    o.Price = pdPrice.Rows[0]["KeyValue"].ToString();
                }
                if (pdPromotionPrice.Rows.Count > 0)
                {
                    o.PromotionPrice = pdPromotionPrice.Rows[0]["KeyValue"].ToString();
                }
                if (pdDetail.Rows.Count > 0)
                {
                    o.Detail = pdDetail.Rows[0]["KeyValue"].ToString();
                    IEnumerable<Detail> pdtext = this.getdatadetailbyId(long.Parse(o.Detail));
                    foreach (Detail item in pdtext)
                    {
                        o.DetailProduct = item;
                    }
                }
                o.Id = dr.Product;
                o.CreatedDate = DateTime.Parse(pd.Rows[0]["CreatedDate"].ToString());
                o.LastUpdated = DateTime.Parse(pd.Rows[0]["LastUpdated"].ToString());
                o.Status = int.Parse(pd.Rows[0]["Status"].ToString());
                o.CreatedBy = long.Parse(pd.Rows[0]["CreatedBy"].ToString());
                if (o.Status == 1)
                {
                    yield return o;
                }

            }
        }

        public IEnumerable<Product> GetDataCategoryRecommend(int Category)
        {
            DataSet1.ProductCategoryRecommendDataTable dt = ProductRecom.GetDataCategoryRecommend(10, Category);
            foreach (DataSet1.ProductCategoryRecommendRow dr in dt)
            {
                DataSet1.ProductDetailDataTable pdName = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Name");
                DataSet1.ProductDetailDataTable pdPicture = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Picture");

                DataSet1.ProductDetailDataTable pdDetail = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Detail");

                DataSet1.ProductDataTable pd = new DataSet1TableAdapters.ProductTableAdapter().GetProductById(dr.Id);

                Product o = new Product();

                string x = "http://services.totiti.net/Imilk/";

                if (pdName.Rows.Count > 0)
                {
                    o.Name = pdName.Rows[0]["KeyValue"].ToString();

                    IEnumerable<Name> pdtext = this.getdatanamebyId(long.Parse(o.Name));
                    foreach (Name item in pdtext)
                    {
                        o.NameProduct = item;
                    }
                }

                if (pdPicture.Rows.Count > 0)
                {
                    string picpath = pdPicture.Rows[0]["KeyValue"].ToString();
                    //o.Picture = x + "Thumbnail/" + picpath.Substring(picpath.IndexOf("/") + 1, picpath.Length - picpath.IndexOf("/") - 1);
                    o.Picture = x + picpath;
                }
                else
                {
                    o.Picture = "http://services.totiti.net/Imilk/Thumbnail/no_image_available.png";
                }

                if (pdDetail.Rows.Count > 0)
                {
                    o.Detail = pdDetail.Rows[0]["KeyValue"].ToString();
                }
                o.Id = dr.Id;
                o.CreatedDate = DateTime.Parse(pd.Rows[0]["CreatedDate"].ToString());
                o.LastUpdated = DateTime.Parse(pd.Rows[0]["LastUpdated"].ToString());
                o.Status = int.Parse(pd.Rows[0]["Status"].ToString());
                o.CreatedBy = long.Parse(pd.Rows[0]["CreatedBy"].ToString());

                yield return o;
            }
        }
        public IEnumerable<Product> GetProductall()
        {
            DataSet1.ProductDataTable dt = ttc.GetData();
            foreach (DataSet1.ProductRow dr in dt)
            {
                DataSet1.ProductDetailDataTable pdName = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Name");
                DataSet1.ProductDetailDataTable pdPicture = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Thumbnail");
                DataSet1.ProductDetailDataTable pdPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Price");
                DataSet1.ProductDetailDataTable pdDetail = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Detail");
                DataSet1.ProductDetailDataTable pdPromotionPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "PromotionPrice");
                DataSet1.ProductDataTable pd = new DataSet1TableAdapters.ProductTableAdapter().GetProductById(dr.Id);

                Product o = new Product();

                string x = "http://services.totiti.net/Imilk/";

                if (pdName.Rows.Count > 0)
                {
                    o.Name = pdName.Rows[0]["KeyValue"].ToString();
                    IEnumerable<Name> pdtext = this.getdatanamebyId(long.Parse(o.Name));
                    foreach (Name item in pdtext)
                    {
                        o.NameProduct = item;
                    }
                }
                if (pdPicture.Rows.Count > 0)
                {
                    string picpath = pdPicture.Rows[0]["KeyValue"].ToString();
                    //o.Picture = x + "Thumbnail/" + picpath.Substring(picpath.IndexOf("/") + 1, picpath.Length - picpath.IndexOf("/") - 1);
                    o.Picture = x + picpath;
                }
                else
                {
                    o.Picture = "http://services.totiti.net/Imilk/Thumbnail/no_image_available.png";
                }
                if (pdPrice.Rows.Count > 0)
                {
                    o.Price = pdPrice.Rows[0]["KeyValue"].ToString();
                }
                if (pdPromotionPrice.Rows.Count > 0)
                {
                    o.PromotionPrice = pdPromotionPrice.Rows[0]["KeyValue"].ToString();
                }
                if (pdDetail.Rows.Count > 0)
                {
                    o.Detail = pdDetail.Rows[0]["KeyValue"].ToString();
                    IEnumerable<Detail> pdtext = this.getdatadetailbyId(long.Parse(o.Detail));
                    foreach (Detail item in pdtext)
                    {
                        o.DetailProduct = item;
                    }
                }
                o.Id = dr.Id;
                o.CreatedDate = DateTime.Parse(pd.Rows[0]["CreatedDate"].ToString());
                o.LastUpdated = DateTime.Parse(pd.Rows[0]["LastUpdated"].ToString());
                o.Status = int.Parse(pd.Rows[0]["Status"].ToString());
                o.CreatedBy = long.Parse(pd.Rows[0]["CreatedBy"].ToString());

                yield return o;
            }
        }
        public IEnumerable<Product> GetProductCateByCategory2(int Category)
        {
            DataSet1.ProductCateDataTable dt = tti.GetProductCateByCategory(Category);
            foreach (DataSet1.ProductCateRow dr in dt)
            {
                DataSet1.ProductDetailDataTable pdName = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Name");
                DataSet1.ProductDetailDataTable pdPicture = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Picture");
                DataSet1.ProductDetailDataTable pdPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Price");
                DataSet1.ProductDetailDataTable pdDetail = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Detail");
                DataSet1.ProductDetailDataTable pdPromotionPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "PromotionPrice");
                DataSet1.ProductDataTable pd = new DataSet1TableAdapters.ProductTableAdapter().GetProductById(dr.Product);

                Product o = new Product();

                string x = "http://services.totiti.net/Imilk/";

                if (pdName.Rows.Count > 0)
                {
                    o.Name = pdName.Rows[0]["KeyValue"].ToString();

                    IEnumerable<Name> pdtext = this.getdatanamebyId(long.Parse(o.Name));
                    foreach (Name item in pdtext)
                    {
                        o.NameProduct = item;
                    }
                }
                if (pdPicture.Rows.Count > 0)
                {
                    string picpath = pdPicture.Rows[0]["KeyValue"].ToString();
                    //o.Picture = x + "Thumbnail/" + picpath.Substring(picpath.IndexOf("/") + 1, picpath.Length - picpath.IndexOf("/") - 1);
                    o.Picture = x + picpath;
                }
                else
                {
                    o.Picture = "http://services.totiti.net/Imilk/Thumbnail/no_image_available.png";
                }
                if (pdPrice.Rows.Count > 0)
                {
                    o.Price = pdPrice.Rows[0]["KeyValue"].ToString();
                }
                if (pdPromotionPrice.Rows.Count > 0)
                {
                    o.PromotionPrice = pdPromotionPrice.Rows[0]["KeyValue"].ToString();
                }
                if (pdDetail.Rows.Count > 0)
                {
                    o.Detail = pdDetail.Rows[0]["KeyValue"].ToString();
                    IEnumerable<Detail> pdtext = this.getdatadetailbyId(long.Parse(o.Detail));
                    foreach (Detail item in pdtext)
                    {
                        o.DetailProduct = item;
                    }
                }
                o.Id = dr.Product;
                o.CreatedDate = DateTime.Parse(pd.Rows[0]["CreatedDate"].ToString());
                o.LastUpdated = DateTime.Parse(pd.Rows[0]["LastUpdated"].ToString());
                o.Status = int.Parse(pd.Rows[0]["Status"].ToString());
                o.CreatedBy = long.Parse(pd.Rows[0]["CreatedBy"].ToString());

                yield return o;
            }
        }

        //string format = "dd-MM-yyyy HH:mm";
        //DateTime chkInDate = DateTime.ParseExact(CheckInDate, format, CultureInfo.InvariantCulture);



        public IEnumerable<Product> GetProductsByCategory(string CheckInDate, string CheckOutDate, int Category)
        {
            DataSet1.ProductDataTable dt = ttc.GetProductByProductCate(Category);
            foreach (DataSet1.ProductRow dr in dt)
            {
                DataSet1.ProductDetailDataTable pdName = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Name");
                DataSet1.ProductDetailDataTable pdPicture = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Thumbnail");
                DataSet1.ProductDetailDataTable pdPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Price");
                DataSet1.ProductDetailDataTable pdDetail = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Detail");
                DataSet1.ProductDetailDataTable pdPromotionPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "PromotionPrice");
                Product o = new Product();

                string x = "http://services.totiti.net/Imilk/";

                if (pdName.Rows.Count > 0)
                {
                    o.Name = pdName.Rows[0]["KeyValue"].ToString();
                    IEnumerable<Name> pdtext = this.getdatanamebyId(long.Parse(o.Name));
                    foreach (Name item in pdtext)
                    {
                        o.NameProduct = item;
                    }
                }
                if (pdPicture.Rows.Count > 0)
                {
                    string picpath = pdPicture.Rows[0]["KeyValue"].ToString();
                    //o.Picture = x + "Thumbnail/" + picpath.Substring(picpath.IndexOf("/") + 1, picpath.Length - picpath.IndexOf("/") - 1);
                    o.Picture = x + picpath;
                }
                else
                {
                    o.Picture = "http://services.totiti.net/Imilk/Thumbnail/no_image_available.png";
                }
                if (pdPrice.Rows.Count > 0)
                {
                    o.Price = pdPrice.Rows[0]["KeyValue"].ToString();
                }
                if (pdPromotionPrice.Rows.Count > 0)
                {
                    o.PromotionPrice = pdPromotionPrice.Rows[0]["KeyValue"].ToString();
                }
                if (pdDetail.Rows.Count > 0)
                {
                    o.Detail = pdDetail.Rows[0]["KeyValue"].ToString();
                    IEnumerable<Detail> pdtext = this.getdatadetailbyId(long.Parse(o.Detail));
                    foreach (Detail item in pdtext)
                    {
                        o.DetailProduct = item;
                    }
                }
                o.Id = dr.Id;
                o.CreatedDate = dr.CreatedDate;
                o.LastUpdated = dr.LastUpdated;
                o.Status = dr.Status;
                o.CreatedBy = dr.CreatedBy;
                yield return o;


                //DataSet1.ProductOrderDataTable pdOrder = new DataSet1TableAdapters.ProductOrderTableAdapter().GetDataByProduct(o.Id, 0);
                //string format = "dd-MM-yyyy HH:mm";
                //DateTime chkInDate = DateTime.ParseExact(CheckInDate, format, CultureInfo.InvariantCulture);
                //DateTime chkOutDate = DateTime.ParseExact(CheckOutDate, format, CultureInfo.InvariantCulture);

                //bool chkInAvairable = false;
                //bool chkOutAvairable = false;

                //foreach (DataSet1.ProductOrderRow item in pdOrder)
                //{
                //    chkInAvairable = this.TimeBetween(chkInDate, item.CreatedDate, item.LastUpdated);
                //    chkOutAvairable = this.TimeBetween(chkOutDate, item.CreatedDate, item.LastUpdated);
                //}
                //bool ok = true;
                //if (chkInAvairable)
                //{
                //    ok = false;
                //}
                //if (chkOutAvairable)
                //{
                //    ok = false;
                //}

                //if (ok)
                //{
                //    yield return o;
                //}
            }
        }
        bool TimeBetween(DateTime time, DateTime startDateTime, DateTime endDateTime)
        {
            // get TimeSpan
            TimeSpan start = new TimeSpan(startDateTime.Hour, startDateTime.Minute, 0);
            TimeSpan end = new TimeSpan(endDateTime.Hour, endDateTime.Minute, 0);

            // convert datetime to a TimeSpan
            TimeSpan now = time.TimeOfDay;
            // see if start comes before end
            if (start < end)
                return start <= now && now <= end;
            // start is after end, so do the inverse comparison
            return !(end < now && now < start);
        }

        public IEnumerable<Product> GetProductsPromotion()
        {
            DataSet1.ProductByDetailDataTable dt = new DataSet1TableAdapters.ProductByDetailTableAdapter().GetData();
            foreach (DataSet1.ProductByDetailRow dr in dt.Where(x => x.KeyName == "PromotionPrice"))
            {
                if (dr.KeyValue != "-")
                {
                    DataSet1.ProductDetailDataTable pdName = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Name");
                    DataSet1.ProductDetailDataTable pdPicture = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Thumbnail");
                    DataSet1.ProductDetailDataTable pdPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Price");
                    DataSet1.ProductDetailDataTable pdDetail = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Detail");
                    DataSet1.ProductDetailDataTable pdPromotionPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "PromotionPrice");
                    Product o = new Product();

                    string x = "http://services.totiti.net/Imilk/";

                    o.Id = dr.Id;
                    o.ProductCategory = dr.ProductCategory;
                    o.CreatedDate = dr.CreatedDate;
                    o.LastUpdated = dr.LastUpdated;
                    o.Status = dr.Status;
                    o.CreatedBy = dr.CreatedBy;
                    if (pdName.Rows.Count > 0)
                    {
                        o.Name = pdName.Rows[0]["KeyValue"].ToString();
                        IEnumerable<Name> pdtext = this.getdatanamebyId(long.Parse(o.Name));
                        foreach (Name item in pdtext)
                        {
                            o.NameProduct = item;
                        }
                    }
                    if (pdPicture.Rows.Count > 0)
                    {
                        string picpath = pdPicture.Rows[0]["KeyValue"].ToString();
                        //o.Picture = x + "Thumbnail/" + picpath.Substring(picpath.IndexOf("/") + 1, picpath.Length - picpath.IndexOf("/") - 1);
                        o.Picture = x + picpath;
                    }
                    else
                    {
                        o.Picture = "http://services.totiti.net/Imilk/Thumbnail/no_image_available.png";
                    }
                    if (pdPrice.Rows.Count > 0)
                    {
                        o.Price = pdPrice.Rows[0]["KeyValue"].ToString();
                    }
                    if (pdPromotionPrice.Rows.Count > 0)
                    {
                        o.PromotionPrice = pdPromotionPrice.Rows[0]["KeyValue"].ToString();
                    }
                    if (pdDetail.Rows.Count > 0)
                    {
                        o.Detail = pdDetail.Rows[0]["KeyValue"].ToString();
                        IEnumerable<Detail> pdtext = this.getdatadetailbyId(long.Parse(o.Detail));
                        foreach (Detail item in pdtext)
                        {
                            o.DetailProduct = item;
                        }
                    }
                    yield return o;
                }
            }
        }
        public IEnumerable<Product> GetProductById(int Id)
        {
            DataSet1.ProductDataTable dt = ttc.GetProductById(Id);
            foreach (DataSet1.ProductRow dr in dt)
            {

                DataSet1.ProductDetailDataTable pdName = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Name");
                DataSet1.ProductDetailDataTable pdPicture = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Picture");
                DataSet1.ProductDetailDataTable pdPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Price");
                DataSet1.ProductDetailDataTable pdDetail = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "Detail");
                DataSet1.ProductDetailDataTable pdPromotionPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "PromotionPrice");
                Product o = new Product();

                o.Id = dr.Id;
                o.CreatedDate = dr.CreatedDate;
                o.LastUpdated = dr.LastUpdated;
                o.Status = dr.Status;
                o.CreatedBy = dr.CreatedBy;
                if (pdName.Rows.Count > 0)
                {
                    o.Name = pdName.Rows[0]["KeyValue"].ToString();
                    IEnumerable<Name> pdtext = this.getdatanamebyId(long.Parse(o.Name));
                    foreach (Name item in pdtext)
                    {
                        o.NameProduct = item;
                    }
                }
                if (pdPicture.Rows.Count > 0)
                {
                    o.Picture = "http://services.totiti.net/Imilk/" + pdPicture.Rows[0]["KeyValue"].ToString();
                }
                else
                {
                    o.Picture = "http://services.totiti.net/Imilk/Thumbnail/no_image_available.png";
                }
                if (pdPrice.Rows.Count > 0)
                {
                    o.Price = pdPrice.Rows[0]["KeyValue"].ToString();
                }
                if (pdPromotionPrice.Rows.Count > 0)
                {
                    o.PromotionPrice = pdPromotionPrice.Rows[0]["KeyValue"].ToString();
                }
                if (pdDetail.Rows.Count > 0)
                {
                    o.Detail = pdDetail.Rows[0]["KeyValue"].ToString();
                    IEnumerable<Detail> pdtext = this.getdatadetailbyId(long.Parse(o.Detail));
                    foreach (Detail item in pdtext)
                    {
                        o.DetailProduct = item;
                    }
                }
                yield return o;
            }
        }

        #endregion

        #region AccountGroup

        public IEnumerable<AccountGroup> GetByUserAccountAndUserGroup(long UserAccount, int UserGroup)
        {
            DataSet1.AccountGroupDataTable dt = ttd.GetByUserAccountAndUserGroup(UserAccount, UserGroup);
            foreach (DataSet1.AccountGroupRow dr in dt)
            {
                yield return new AccountGroup() { Id = dr.Id, UserAccount = dr.UserAccount, UserGroup = dr.UserGroup, CreatedDate = dr.CreatedDate, LastUpdated = dr.LastUpdated, Status = dr.Status };
            }

        }







        #endregion

        #region ProductDetail
        public IEnumerable<ProductDetail> GetProductDetailByProduct(long Product)
        {
            DataSet1.ProductDetailDataTable dt = tte.GetProductDetailByProduct(Product);
            ProductDetail o = new ProductDetail();
            foreach (DataSet1.ProductDetailRow dr in dt)
            {

                if (dr.KeyName == "Picture")
                {
                    dr.KeyValue = "http://services.totiti.net/Imilk/" + dr.KeyValue;
                }
                yield return new ProductDetail()
                {
                    Id = dr.Id,
                    Product = dr.Product,
                    CreatedDate = dr.CreatedDate,
                    LastUpdated = dr.LastUpdated,
                    Status = dr.Status,
                    UpdatedBy = dr.UpdatedBy,
                    KeyName = dr.KeyName,
                    KeyValue = dr.KeyValue
                };
            }
        }

        public IEnumerable<ProductDetail> GetProductImageByProductId(long Product)
        {
            DataSet1.ProductDetailDataTable dt = tte.GetProductImageByProductId(Product);

            int i = 0;
            int countdt = dt.Count();
            ProductDetail o = new ProductDetail();
            foreach (DataSet1.ProductDetailRow dr in dt)
            {
                yield return new ProductDetail()
                {
                    Id = dr.Id,
                    Product = dr.Product,
                    CreatedDate = dr.CreatedDate,
                    LastUpdated = dr.LastUpdated,
                    Status = dr.Status,
                    UpdatedBy = dr.UpdatedBy,
                    KeyName = dr.KeyName,
                    KeyValue = "http://services.totiti.net/Imilk/" + dr.KeyValue
                };
            }
        }



        #endregion

        #region TicketOrder

        public IEnumerable<TicketOrder> GetTicketOrderById(long Id)
        {

            DataSet1.TicketOrderDataTable dt = ttf.GetTicketOrderById(Id);
            foreach (DataSet1.TicketOrderRow dr in dt)
            {
                yield return new TicketOrder()
                {
                    Id = dr.Id,
                    Remark = dr.Remark,
                    CreatedDate = dr.CreatedDate,
                    LastUpdated = dr.LastUpdated,
                    Status = dr.Status,
                    ChkPayment = dr.ChkPayment

                };
            }

        }
        public IEnumerable<TicketOrder> GetTicketOrderByStatus1OR2()
        {

            DataSet1.TicketOrderDataTable dt = ttf.GetDataByOrderStatus2();
            foreach (DataSet1.TicketOrderRow dr in dt)
            {
                yield return new TicketOrder()
                {
                    Id = dr.Id,
                    Remark = dr.Remark,
                    CreatedDate = dr.CreatedDate,
                    LastUpdated = dr.LastUpdated,
                    Status = dr.Status

                };
            }

        }

        public TicketOrder InsertTicketOrder(TicketOrder AddTicketOrder)
        {
            long Id = (long)ttf.InsertQuery(AddTicketOrder.Remark, DateTime.Now, DateTime.Now, 1);


            DataSet1.TicketOrderDataTable dt = ttf.GetLastId();
            TicketOrder o = new TicketOrder();
            foreach (DataSet1.TicketOrderRow dr in dt)
            {
                o = new TicketOrder() { Id = dr.Id, Remark = dr.Remark, CreatedDate = dr.CreatedDate, LastUpdated = dr.LastUpdated, Status = dr.Status };
            }
            return o;
        }

        public Result UpdateOrderStatusByOrderId(TicketOrder UpDateTicketOrder)
        {
            ttf.UpdateOrderStatusByOrderId(DateTime.Now, UpDateTicketOrder.Status, UpDateTicketOrder.Id);

            DataSet1.TicketOrderDataTable dt = ttf.GetTicketOrderById(UpDateTicketOrder.Id);
            Result o = new Result();
            foreach (DataSet1.TicketOrderRow dr in dt)
            {
                o = new Result() { Message = "Success ", Success = true };
            }
            return o;
        }

        public Result UpdateStatusById(TicketOrder UpdateStatus)
        {
            ttf.UpdateStatusById(DateTime.Now, 2, UpdateStatus.Id);

            DataSet1.TicketOrderDataTable dt = ttf.GetTicketOrderById(UpdateStatus.Id);
            Result o = new Result();
            foreach (DataSet1.TicketOrderRow dr in dt)
            {
                o = new Result() { Message = "Success ", Success = true };
            }
            return o;
        }

        public Result CancelStatusById(TicketOrder CancelStatus)
        {
            ttf.UpdateStatusById(DateTime.Now, 100, CancelStatus.Id);

            DataSet1.TicketOrderDataTable dt = ttf.GetData();
            Result o = new Result();
            foreach (DataSet1.TicketOrderRow dr in dt.Where(x=>x.Id == CancelStatus.Id))
            {
                o = new Result() { Message = "Success ", Success = true };
            }
            return o;
        }




        public Result ConfirmOrder(TicketOrderConfirm param)
        {
            Result o = new Result();
            //DateTimeFormatInfo usDtfi = new CultureInfo("th-TH", false).DateTimeFormat;
            //string format = "dd-MM-yyyy";
            //DateTime chkInDate = DateTime.ParseExact(param.CheckInDate, format, CultureInfo.InvariantCulture);
            //DateTime chkOutDate = DateTime.ParseExact(param.CheckOutDate, format, CultureInfo.InvariantCulture);
            if (new DataSet1TableAdapters.OrderDetailTableAdapter().GetDataByTicketOrder(param.TicketOrderId).Rows.Count == 0) // where tk > 0
            {
                if (new DataSet1TableAdapters.OrderDetailTableAdapter().Insert(param.TicketOrderId, param.CustomerId, DateTime.Now, DateTime.Now, param.Remark, DateTime.Now, DateTime.Now, 1) == 1)
                {
                    o.Message = "Order confirmed.";
                    o.Success = true;
                }
                else
                {
                    o.Message = "Confirm order failed, Please contact administrator.";
                    o.Success = false;
                    return o;
                }
            }
            if (ttf.UpdateStatusById(DateTime.Now, 2, param.TicketOrderId) == 1)
            {

                o.Message = "Order confirmed.";
                o.Success = true;
            }
            else
            {
                o.Message = "Confirm order failed, Please contact administrator.";
                o.Success = false;
            }


            return o;
        }



        #endregion

        #region ProductOrder

        public Result InsertProductOrder(ProductOrder AddProductOrder)
        {
            //Status =1 ยังไม่ได้กดรับOrder  ,2 กดรับOrder แล้ว
            Result o = new Result();
            decimal aa = 0;
            DataSet1.ProductOrderDataTable productorderTA = new DataSet1TableAdapters.ProductOrderTableAdapter().GetDataByTicketOrderandProduct(AddProductOrder.TicketOrder, AddProductOrder.Product);
            if (productorderTA.Rows.Count >= 1)
            {
                DataSet1.ProductDetailDataTable pdPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(AddProductOrder.Product, "Price");
                DataSet1.ProductDetailDataTable pdPromotionPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(AddProductOrder.Product, "PromotionPrice");

                string format = "dd-MM-yyyy HH:mm";

                try
                {
                    if (pdPromotionPrice.Rows[0]["KeyValue"].ToString() != "-")
                    {
                        AddProductOrder.Total = (AddProductOrder.Quantity) * decimal.Parse((pdPromotionPrice.Rows[0]["KeyValue"].ToString()));
                        AddProductOrder.Price = decimal.Parse((pdPromotionPrice.Rows[0]["KeyValue"].ToString()));
                        AddProductOrder.Remark = "Promotion";
                    }
                    else
                    {
                        AddProductOrder.Total = (AddProductOrder.Quantity) * decimal.Parse((pdPrice.Rows[0]["KeyValue"].ToString()));
                        AddProductOrder.Price = decimal.Parse((pdPrice.Rows[0]["KeyValue"].ToString()));
                    }


                    if (ttg.UpdateQuantityTicketOrderANDProduct(AddProductOrder.Quantity, AddProductOrder.Total, AddProductOrder.TicketOrder, AddProductOrder.Product) == 1)
                    {
                        o = new Result() { Message = "Insert Success ", Success = true };
                    }
                    else
                    {
                        o = new Result() { Message = "Insert Fail ", Success = false };
                    }
                }
                catch
                {

                    o = new Result() { Message = "Insert Fail ", Success = false };

                }
            }
            else
            {

                DataSet1.ProductDetailDataTable pdPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(AddProductOrder.Product, "Price");
                DataSet1.ProductDetailDataTable pdPromotionPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(AddProductOrder.Product, "PromotionPrice");

                string format = "dd-MM-yyyy HH:mm";

                try
                {
                    if (pdPromotionPrice.Rows[0]["KeyValue"].ToString() != "-")
                    {
                        AddProductOrder.Total = AddProductOrder.Quantity * decimal.Parse((pdPromotionPrice.Rows[0]["KeyValue"].ToString()));
                        AddProductOrder.Price = decimal.Parse((pdPromotionPrice.Rows[0]["KeyValue"].ToString()));
                        AddProductOrder.Remark = "Promotion";
                    }
                    else
                    {
                        AddProductOrder.Total = AddProductOrder.Quantity * decimal.Parse((pdPrice.Rows[0]["KeyValue"].ToString()));
                        AddProductOrder.Price = decimal.Parse((pdPrice.Rows[0]["KeyValue"].ToString()));
                    }

                    if (ttg.InsertProductOrderV2(AddProductOrder.TicketOrder, AddProductOrder.Product, AddProductOrder.Quantity, AddProductOrder.Remark, DateTime.Now, DateTime.Now, 1, null, AddProductOrder.Price, AddProductOrder.Total) == 1)
                    {
                        o = new Result() { Message = "Insert Success ", Success = true };
                    }
                    else
                    {
                        o = new Result() { Message = "Insert Fail ", Success = false };
                    }
                }
                catch
                {
                    o = new Result() { Message = "Insert Fail ", Success = false };
                }
            }
            return o;
        }

        public Result DeleteProductOrder(ProductOrder Delete)
        {

            if ((Delete.TicketOrder != 0) && (Delete.Product != 0))
            {
                ttg.DeleteQueryByTicketOrderAndProduct(Delete.TicketOrder, Delete.Product);
                Result o = new Result() { Message = "Success ", Success = true };
                return o;
            }
            else
            {
                Result o = new Result() { Message = "Error ", Success = false };
                return o;
            }
        }

        public Result DeleteProductOrderById(ProductOrder Delete)
        {

            if (Delete.Id != 0)
            {
                ttg.DeleteProductOrderById(Delete.Id);
                Result o = new Result() { Message = "Success ", Success = true };
                return o;
            }
            else
            {
                Result o = new Result() { Message = "Error ", Success = false };
                return o;
            }
        }





        public IEnumerable<ProductOrder> GetProductOrderById(long Id)
        {

            DataSet1.ProductOrderDataTable dt = ttg.GetProductOrderById(Id);

            foreach (DataSet1.ProductOrderRow dr in dt)
            {
                yield return new ProductOrder()
                {
                    Id = dr.Id,
                    TicketOrder = dr.TicketOrder,
                    Product = dr.Product,
                    Quantity = dr.Quantity,
                    Remark = dr.Remark,
                    CheckInDate = Convert.ToString(dr.CreatedDate),
                    CheckOutDate = Convert.ToString(dr.LastUpdated),
                    Status = dr.Status,
                    CreatedBy = dr.CreatedBy,
                    Price = dr.Price,
                    Total = dr.Total

                };
            }

        }

        public IEnumerable<ProductOrder> GetMyOrder(long TicketOrder)
        {
            DataSet1.ProductOrderDataTable dt = ttg.GetDataByTicketOrder(TicketOrder);

            foreach (DataSet1.ProductOrderRow dr in dt)
            {
                DataSet1.ProductDetailDataTable pdName = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Name");
                DataSet1.ProductDetailDataTable pdPicture = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Picture");
                DataSet1.ProductDetailDataTable pdPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Price");
                DataSet1.ProductDetailDataTable pdDetail = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Detail");
                DataSet1.ProductDetailDataTable pdPromotionPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "PromotionPrice");

                ProductOrder o = new ProductOrder();

                string x = "http://services.totiti.net/Imilk/";

                o.Id = dr.Id;
                o.TicketOrder = dr.TicketOrder;
                o.Product = dr.Product;
                o.Quantity = dr.Quantity;
                o.Remark = dr.Remark;
                o.CheckInDate = Convert.ToString(dr.CreatedDate);
                o.CheckOutDate = Convert.ToString(dr.LastUpdated);
                o.Status = dr.Status;
                o.CreatedBy = dr.CreatedBy;
                o.Price = dr.Price;
                o.Total = dr.Total;
                if (pdName.Rows.Count > 0)
                {
                    o.Name = pdName.Rows[0]["KeyValue"].ToString();
                    IEnumerable<Name> pdtext = this.getdatanamebyId(long.Parse(o.Name));
                    foreach (Name item in pdtext)
                    {
                        o.NameProduct = item;
                    }
                }
                if (pdPicture.Rows.Count > 0)
                {
                    string picpath = pdPicture.Rows[0]["KeyValue"].ToString();
                    //    o.Picture = x + "Thumbnail/" + picpath.Substring(picpath.IndexOf("/") + 1, picpath.Length - picpath.IndexOf("/") - 1);
                    if (picpath != "")
                    {
                        // o.ImageURL = "http://services.totiti.net/Imilk/Image/" + dr.ImageURL;
                        o.Picture = x + picpath;
                    }
                    else
                    {
                        o.Picture = "http://services.totiti.net/Imilk/Thumbnail/no_image_available.png";
                    }
                    // o.Picture = x + picpath;
                }
                else
                {
                    o.Picture = "http://services.totiti.net/Imilk/Thumbnail/no_image_available.png";
                }
                if (pdDetail.Rows.Count > 0)
                {
                    o.Detail = pdDetail.Rows[0]["KeyValue"].ToString();
                    IEnumerable<Detail> pdtext = this.getdatadetailbyId(long.Parse(o.Detail));
                    foreach (Detail item in pdtext)
                    {
                        o.DetailProduct = item;
                    }
                }

                yield return o;
            }

        }


        public IEnumerable<ProductOrder> GetProductOrderByProduct(string CheckInDate, string CheckOutDate, long Product)
        {
            DataSet1.ProductOrderDataTable dt = ttg.GetProductOrderByProduct(Product);
            foreach (DataSet1.ProductOrderRow dr in dt)
            {
                DataSet1.ProductDetailDataTable pdName = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Name");
                DataSet1.ProductDetailDataTable pdPicture = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Picture");
                DataSet1.ProductDetailDataTable pdPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Price");
                DataSet1.ProductDetailDataTable pdDetail = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Product, "Detail");
                DataSet1.ProductDetailDataTable pdPromotionPrice = new DataSet1TableAdapters.ProductDetailTableAdapter().GetDataByProduct(dr.Id, "PromotionPrice");

                ProductOrder o = new ProductOrder();

                string x = "http://services.totiti.net/Imilk/";

                o.Id = dr.Id;
                o.TicketOrder = dr.TicketOrder;
                o.Product = dr.Product;
                o.Quantity = dr.Quantity;
                o.Remark = dr.Remark;
                o.CheckInDate = Convert.ToString(dr.CreatedDate);
                o.CheckOutDate = Convert.ToString(dr.LastUpdated);
                o.Status = dr.Status;
                o.CreatedBy = dr.CreatedBy;
                o.Price = dr.Price;
                o.Total = dr.Total;
                if (pdName.Rows.Count > 0)
                {
                    o.Name = pdName.Rows[0]["KeyValue"].ToString();
                    IEnumerable<Name> pdtext = this.getdatanamebyId(long.Parse(o.Name));
                    foreach (Name item in pdtext)
                    {
                        o.NameProduct = item;
                    }
                }
                if (pdPicture.Rows.Count > 0)
                {
                    string picpath = pdPicture.Rows[0]["KeyValue"].ToString();
                    //    o.Picture = x + "Thumbnail/" + picpath.Substring(picpath.IndexOf("/") + 1, picpath.Length - picpath.IndexOf("/") - 1);
                    o.Picture = x + picpath;
                }
                if (pdDetail.Rows.Count > 0)
                {
                    o.Detail = pdDetail.Rows[0]["KeyValue"].ToString();
                    IEnumerable<Detail> pdtext = this.getdatadetailbyId(long.Parse(o.Detail));
                    foreach (Detail item in pdtext)
                    {
                        o.DetailProduct = item;
                    }
                }
                ///////////////////////////
                DataSet1.ProductOrderDataTable pdOrder2 = new DataSet1TableAdapters.ProductOrderTableAdapter().GetProductOrderByProduct(Product);
                string format = "dd-MM-yyyy HH:mm";
                DateTime chkInDate = DateTime.ParseExact(CheckInDate, format, CultureInfo.InvariantCulture);
                DateTime chkOutDate = DateTime.ParseExact(CheckOutDate, format, CultureInfo.InvariantCulture);

                bool chkInAvairable = false;
                bool chkOutAvairable = false;

                foreach (DataSet1.ProductOrderRow item in pdOrder2)
                {
                    chkInAvairable = this.TimeBetween(chkInDate, item.CreatedDate, item.LastUpdated);
                    chkOutAvairable = this.TimeBetween(chkOutDate, item.CreatedDate, item.LastUpdated);
                }
                bool ok = true;
                if (chkInAvairable)
                {
                    ok = false;
                }
                if (chkOutAvairable)
                {
                    ok = false;
                }

                if (ok)
                {
                    yield return o;
                }
            }
        }


        #endregion

        #region OrderDetail
        public IEnumerable<OrderDetail> GetOrderDetailByOrderId(long OrderId)
        {
            OrderDetail o = new OrderDetail();
            DataSet1.OrderDetailDataTable collection = new DataSet1TableAdapters.OrderDetailTableAdapter().GetDataByTicketOrder(OrderId);
            if (collection.Rows.Count > 0)
            {
                foreach (DataSet1.OrderDetailRow item in collection)
                {
                    o.CheckInDate = item.CheckInDate.ToString("dd-MM-yyyy HH:mm");
                    o.CheckOutDate = item.CheckOutDate.ToString("dd-MM-yyyy HH:mm");
                    o.CreatedDate = item.CreatedDate;
                    o.Customer = item.Customer;
                    o.Id = item.Id;
                    o.LastUpdated = item.LastUpdated;
                    o.Remark = item.Remark;
                    o.Staus = item.Status;
                    o.TicketOrder = item.TicketOrder;

                    yield return o;
                }
            }
        }

        #endregion

        #region Category
        public IEnumerable<Category> GetCategory()
        {
            DataSet1.CategoryDataTable dt = ttj.GetData();
            foreach (DataSet1.CategoryRow dr in dt)
            {

                Category o = new Category();
                IEnumerable<Name> pdtext = this.getdatanamebyId(long.Parse(dr.Name));
                foreach (Name item in pdtext)
                {
                    o.NameProduct = item;
                }

                o.Id = dr.Id;
                o.Name = dr.Name;
                o.CreatedDate = dr.CreatedDate;
                o.LastUpdate = dr.LastUpdated;
                o.Status = dr.Status;


                if (dr.ImageURL != "")
                {
                    o.ImageURL = "http://services.totiti.net/Imilk/Image/" + dr.ImageURL;
                }
                else
                {
                    o.ImageURL = "http://services.totiti.net/Imilk/Thumbnail/no_image_available.png";
                }

                if (o.Status == 1)
                {
                    yield return o;
                }

            }
        }

        public IEnumerable<Category> GetCategoryById(int Id)
        {
            //IEnumerable<Detail> detailtext = this.getdatadetailbyId(172);
            //foreach (Detail item2 in detailtext)
            //{
            //    c.NameDetail = item2;
            //}
            DataSet1.CategoryDataTable dt = ttj.GetData();

            foreach (DataSet1.CategoryRow dr in dt.Where(x => x.Id == Id).Where(x => x.Status == 1 || x.Status == 99))
            {

                Category c = new Category();

                c.Id = dr.Id;
                c.Name = textTa.GetData().Where(x => x.Id == int.Parse(dr.Name)).First().Thai;
                IEnumerable<Name> pdtext = this.getdatanamebyId(int.Parse(dr.Name));
                foreach (Name item in pdtext)
                {
                    c.NameProduct = item;
                }

                c.ImageURL = dr.ImageURL;
                c.CreatedDate = dr.CreatedDate;
                c.LastUpdate = dr.LastUpdated;
                c.Status = dr.Status;


                if (dr.ImageURL != "")
                {
                    c.ImageURL = "http://services.totiti.net/Imilk/Image/" + dr.ImageURL;
                }
                else
                {
                    c.ImageURL = "http://services.totiti.net/Imilk/Thumbnail/no_image_available.png";
                }
                yield return c;
            }

        }


        public IEnumerable<Category> GetCategoryByType(int Type)
        {

            DataSet1.CategoryDataTable dt = ttj.GetData();
            foreach (DataSet1.CategoryRow dr in dt.Where(x => x.TypeId == Type).Where(x => x.Status == 1))
            {
                Category c = new Category();
                c.Id = dr.Id;
                c.ImageURL = dr.ImageURL;
                c.CreatedDate = dr.CreatedDate;
                c.LastUpdate = dr.LastUpdated;
                c.Status = dr.Status;
                c.Name = textTa.GetData().Where(x => x.Id == int.Parse(dr.Name)).First().Thai;

                IEnumerable<Name> pdtext = this.getdatanamebyId(long.Parse(dr.Name));
                foreach (Name item in pdtext)
                {
                    c.NameProduct = item;
                }


                yield return c;


            }

        }

        #endregion


        #region Table
        public IEnumerable<Table> GetTable()
        {

            DataSet1.TableDataTable c = new DataSet1TableAdapters.TableTableAdapter().GetData();


            DataSet1.TableDataTable dt = TableTA.GetData();
            foreach (DataSet1.TableRow dr in dt)
            {
                Table o = new Table();
                o.Id = dr.Id;
                o.Name = dr.Name;
                o.Status = dr.Status;
                IEnumerable<Name> pdtext = this.getdatanamebyId(long.Parse(dr.Name));
                foreach (Name item in pdtext)
                {
                    o.NameProduct = item;
                }

                var v = View_TicketTA.GetData().Where(x => (x.Status < 4) && x.Remark == o.Id.ToString());
                if (v.Count() == 0)
                {
                    yield return o;
                }

            }
        }




        #endregion

        public IEnumerable<Textmessage> GetTextmessage()
        {
            DataSet1.TextMessageDataTable dt = textMTa.GetData();
            foreach (DataSet1.TextMessageRow dr in dt)
            {
                yield return new Textmessage()
                {
                    Id = dr.Id,
                    Thai = dr.Thai,
                    Chinese = dr.Chinese,
                    English = dr.English,
                    Remark = dr.Remark
                };
            }
        }

        public IEnumerable<Name> getdatanamebyId(long Id)
        {
            Name o = new Name();
            DataSet1.TextContentDataTable dt = textTa.GetDataBy(Id);
            foreach (DataSet1.TextContentRow dr in dt)
            {
                yield return new Name()
                {
                    Thai = dr.Thai,
                    English = dr.English,
                    Remark = dr.Remark
                };
            }
        }

        public IEnumerable<Detail> getdatadetailbyId(long Id)
        {
            Detail o = new Detail();
            DataSet1.TextContentDataTable dt = textTa.GetDataBy(Id);
            foreach (DataSet1.TextContentRow dr in dt)
            {
                yield return new Detail()
                {
                    Thai = dr.Thai,
                    English = dr.English,
                    Remark = dr.Remark
                };
            }
        }


        #region Type
        public IEnumerable<Type> GetType()
        {
            DataSet1.TypeCateDataTable dt = Type1.GetData();
            DataSet1.CategoryDataTable dt2 = ttj.GetData();
            foreach (DataSet1.TypeCateRow dr in dt.Where(x => x.Status > 0))
            {

                Type o = new Type();

                o.Id = dr.Id;
                o.CreateDate = dr.CreateDate.ToString();
                o.LastUpdate = dr.LastUpdate.ToString();
                o.Status = dr.Status;

                IEnumerable<Name> pdtext = this.getdatanamebyId(long.Parse(dr.Name));
                foreach (Name item in pdtext)
                {
                    o.NameProduct = item;
                }

                if (dr.Status == 2)
                {
                    foreach (var cat in dt2.Where(x => x.Status > 0 && x.TypeId == dr.Id))
                    {

                        o = new Type();
                        o.Id = cat.Id;
                        o.CreateDate = cat.CreatedDate.ToString();
                        o.LastUpdate = cat.LastUpdated.ToString();
                        o.Status = dr.Status;

                        IEnumerable<Name> pdtextstatus2 = this.getdatanamebyId(long.Parse(cat.Name));
                        foreach (Name item in pdtextstatus2)
                        {
                            o.NameProduct = item;
                        }
                        if (dr.UrlImage != "")
                        {
                            o.UrlImage = "http://services.totiti.net/Imilk/Image/" + cat.ImageURL;
                        }
                        else
                        {
                            o.UrlImage = "http://services.totiti.net/Imilk/Thumbnail/no_image_available.png";
                        }

                        yield return o;
                    }

                }



                if (dr.UrlImage != "")
                {
                    o.UrlImage = "http://services.totiti.net/Imilk/Image/" + dr.UrlImage;
                }
                else
                {
                    o.UrlImage = "http://services.totiti.net/Imilk/Thumbnail/no_image_available.png";
                }

                if (o.Status == 1)
                {
                    yield return o;
                }

            }
        }
        #endregion
        #region Account
        public IEnumerable<Account> GetAllAccount()
        {
            DataSet1.AccountDataTable dt = Account.GetData();
            foreach (DataSet1.AccountRow dr in dt.Where(x=>x.Status == 1))
            {
                yield return new Account()
                {
                    Id = dr.Id,
                    Name = dr.Name,
                    Idname = dr.Idname,
                    Bank = dr.Bank,
                    Sector = dr.Sector,
                    Status = dr.Status

                };
            }
        }
        public IEnumerable<Account> GetAccountById(Account id)
        {
            DataSet1.AccountDataTable dt = Account.GetData();
            foreach (DataSet1.AccountRow dr in dt.Where(x => x.Id == id.Id && x.Status == 1))
            {
                yield return new Account()
                {
                    Id = dr.Id,
                    Name = dr.Name,
                    Idname = dr.Idname,
                    Bank = dr.Bank,
                    Sector = dr.Sector,
                    Status = dr.Status

                };
            }
        }
        #endregion

        #region Payment
        public Result UpdateChkPaymentByTicketOrder(int ticketOrder)
        {
            Result o = new Result();
            if ((new DataSet1TableAdapters.TicketOrderTableAdapter().UpdateChkPaymentByTickerOrder(DateTime.Now, 1, ticketOrder)) > 0)
            {
                o.Success = true;
            }
            return o;
        }
        public ConFirmPayment InsertQueryConfirmPayment(ConFirmPayment AddConPay)
        {
            //AddConPay.Date1.ToString("yyyy-MM-dd"), AddConPay.Time.ToString("h:mm tt")
            long Id = (long)ConfirmPayment.InsertQuery(AddConPay.Id_Account, AddConPay.Date, AddConPay.Time, AddConPay.Price, AddConPay.UrlImage, AddConPay.Detail,
                DateTime.Now, AddConPay.TicketOrder, AddConPay.Id_user, 1);

            ConFirmPayment o = new ConFirmPayment();
            if (Id > 0)
            {
                DataSet1.ConfirmPaymentDataTable dt = ConfirmPayment.GetLastId();
                foreach (DataSet1.ConfirmPaymentRow dr in dt)
                {
                    o = new ConFirmPayment()
                    {
                        Id = dr.Id,
                        Id_Account = dr.Id_Account,
                        Date = dr.Date.ToShortDateString(),
                        Time = dr.Time.ToString(),
                        Price = dr.Price,
                        UrlImage = dr.UrlImage,
                        Detail = dr.Detiail,
                        CreateDate = dr.CreateDate,
                        TicketOrder = dr.TicketOrder,
                        Id_user = dr.Id_user,
                        Status = dr.Status
                    };
                }
            }
            return o;

        }
        public IEnumerable<ConFirmPayment> GetPaymentbyTicket(long TicketOrder)
        {
            DataSet1.ConfirmPaymentDataTable dt = ConfirmPayment.GetDataByTicketOrder(TicketOrder);
            foreach (DataSet1.ConfirmPaymentRow dr in dt)
            {
                yield return new ConFirmPayment()
                {
                    Id = dr.Id,
                    Id_Account = dr.Id_Account,
                    Date = dr.Date.ToShortDateString(),
                    Time = dr.Time.ToString(),
                    Price = dr.Price,
                    UrlImage = dr.UrlImage,
                    Detail = dr.Detiail,
                    CreateDate = dr.CreateDate,
                    TicketOrder = dr.TicketOrder,
                    Id_user = dr.Id_user,
                    Status = dr.Status
                };

            }

        }
        #endregion
        #region Comment
        public Result addCommentAdd(Comment AddComment)
        {
            Result o = new Result();
            try
            {
                long Id = (long)commentdata.InsertQuery(AddComment.Comment_user, AddComment.CreateBy, DateTime.Now, DateTime.Now, 1);
                o = new Result() { Message = "Success ", Success = true };
            }
            catch (Exception ex)
            {

            }


            return o;
        }
        #endregion
    }

}
