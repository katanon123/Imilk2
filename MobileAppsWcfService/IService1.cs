using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MobileAppsWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        #region UserAccount

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetUserAccount", ResponseFormat = WebMessageFormat.Json)]
        List<UserAccount> GetUserAccount();

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetUserAccountById/{Id}", ResponseFormat = WebMessageFormat.Json)]
        List<UserAccount> GetUserAccountById(string Id);

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetUserAccountBySignIn/{Email}/{Password}", ResponseFormat = WebMessageFormat.Json)]
        List<UserAccount> GetUserAccountBySignIn(string Email, string Password);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UserAccount/SignIn", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UserAccount GetUserAccountBySignIn2(UserAccount SignIn);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UserAccount/Add", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UserAccount InsertQueryUserAccount(UserAccount AddUser);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UserAccount/Update", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result UpdateQueryUserCountById(UserAccount UpDateUser);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UserAccount/ChangePassword", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result UpDateChangePassword(ChangePassword o);


        #endregion

        #region ProductCategoty

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetProductCate", ResponseFormat = WebMessageFormat.Json)]
        List<ProductCate> GetProductCate();

        #endregion

        #region Product
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetProduct", ResponseFormat = WebMessageFormat.Json)]
        List<Product> GetProduct();
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetProductAll", ResponseFormat = WebMessageFormat.Json)]
        List<Product> GetProductall();
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetProductById/{Id}", ResponseFormat = WebMessageFormat.Json)]
        List<Product> GetProductById(string Id);

       

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetProductByCategory/{Category}", ResponseFormat = WebMessageFormat.Json)]
        List<Product> GetProductBycate(string Category);

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetDataCategoryRecommend/{Category}", ResponseFormat = WebMessageFormat.Json)]
        List<Product> GetDataCategoryRecommend(string Category);

        

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetProductsPromotion", ResponseFormat = WebMessageFormat.Json)]
        List<Product> GetProductsPromotion();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetProductsByCategory/Get", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Product> GetProductsByCategory(GetProductParam Param);
        #endregion

        #region ProductDetail
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetProductDetailByProduct/{Product}", ResponseFormat = WebMessageFormat.Json)]
        List<ProductDetail> GetProductDetailByProduct(string Product);

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetProductImageByProductId/{Product}", ResponseFormat = WebMessageFormat.Json)]
        List<ProductDetail> GetProductImageByProductId(string Product);

        #endregion

        #region TicketOrder

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "TicketOrder/Add", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        TicketOrder InsertTicketOrder(TicketOrder AddTicketOrder);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "TicketOrder/Update", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result UpdateOrderStatusByOrderId(TicketOrder UpDateTicketOrder);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "TicketOrder/UpdateStatus", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result UpdateStatusById(TicketOrder UpdateStatus);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "TicketOrder/CancelStatus", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result CancelStatusById(TicketOrder CancleStatus);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "TicketOrder/ConfirmOrder", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result ConfirmOrder(TicketOrderConfirm param);

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetTicketOrderById/{Id}", ResponseFormat = WebMessageFormat.Json)]
        List<TicketOrder> GetTicketOrderById(string Id);

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetTicketOrderByStatus1OR2", ResponseFormat = WebMessageFormat.Json)]
        List<TicketOrder> GetTicketOrderByStatus1OR2();

        #endregion

        #region OrderDetail
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetOrderDetailByOrderId/{OrderId}", ResponseFormat = WebMessageFormat.Json)]
        List<OrderDetail> GetOrderDetailByOrderId(string OrderId);
        #endregion

        #region ProductOrder

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ProductOrder/Add", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result InsertProductOrder(ProductOrder AddProductOrder);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ProductOrder/Delete", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result DeleteProductOrder(ProductOrder Delete);



        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteProductOrderById/Delete", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result DeleteProductOrderById(ProductOrder Delete);


        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetMyOrder/{TicketOrder}", ResponseFormat = WebMessageFormat.Json)]
        List <ProductOrder> GetMyOrder(string TicketOrder);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ProductOrder/Product", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<ProductOrder> GetProductOrderByProduct(GetProductOrderParam Param);


        #endregion

        #region Category
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetCategory", ResponseFormat = WebMessageFormat.Json)]
        List<Category> GetCategory();

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetCategoryById/{Id}", ResponseFormat = WebMessageFormat.Json)]
        List<Category> GetCategoryById(string Id);

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetCategoryByType/{Type}", ResponseFormat = WebMessageFormat.Json)]
        List<Category> GetCategoryByType(string Type);
        #endregion

        #region payments
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ConFirmpayment/Add", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ConFirmPayment InsertQueryConfirmPayment(ConFirmPayment AddConPay);

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetPaymentbyTicket/{ticketorder}", ResponseFormat = WebMessageFormat.Json)]
        List<ConFirmPayment> GetPaymentbyTicket(string TicketOrder);
        #endregion

        #region Type
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetType", ResponseFormat = WebMessageFormat.Json)]
        List<Type> GetType();
        #endregion

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetTable", ResponseFormat = WebMessageFormat.Json)]
        List<Table> GetTable();

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetTextmessage", ResponseFormat = WebMessageFormat.Json)]

        List<Textmessage> GetTextmessage();

        #region Account
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/GetAllAccount", ResponseFormat = WebMessageFormat.Json)]
        List<Account> GetAllAccount();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetAccountById", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        List<Account> GetAccountById(Account id);
        #endregion

        #region Comment
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Comment/Add", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result CommentAdd(Comment AddComment);
        #endregion

    }
    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    [DataContract]
    public class UserAccount
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string MobilePhoneNumber { get; set; }
        [DataMember]
        public DateTime? CreateDate { get; set; }
        [DataMember]
        public DateTime? LastUpdated { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }


    }

    public class ChangePassword
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string OldPassword { get; set; }
        [DataMember]
        public string NewPassword { get; set; }

    }

    public class ProductCategory
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? LastUpdated { get; set; }
        [DataMember]
        public int Status { get; set; }

    }

    public class Product
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public int ProductCategory { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? LastUpdated { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public long CreatedBy { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Picture { get; set; }
        [DataMember]
        public string Price { get; set; }
        [DataMember]
        public string Detail { get; set; }
        [DataMember]
        public string PromotionPrice { get; set; }
        [DataMember]
        public Name NameProduct { get; set; }
        [DataMember]
        public Detail DetailProduct { get; set; }


    }

    public class GetProductParam
    {
        [DataMember]
        public string CheckInDate { get; set; }
        [DataMember]
        public string CheckOutDate { get; set; }
        [DataMember]
        public int Category { get; set; }
    }

    public class GetProductOrderParam
    {
        [DataMember]
        public string CheckInDate { get; set; }
        [DataMember]
        public string CheckOutDate { get; set; }
        [DataMember]
        public long Product { get; set; }
    }

    public class AccountGroup
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long UserAccount { get; set; }
        [DataMember]
        public int UserGroup { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? LastUpdated { get; set; }
        [DataMember]
        public int Status { get; set; }

    }

    public class ProductDetail
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long Product { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? LastUpdated { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public long UpdatedBy { get; set; }
        [DataMember]
        public string KeyName { get; set; }
        [DataMember]
        public string KeyValue { get; set; }


    }

    public class TicketOrder
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? LastUpdated { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public int ChkPayment { get; set; }
        [DataMember]
        public string Remark { get; set; }
    }

    public class TicketOrderConfirm
    {
        [DataMember]
        public long TicketOrderId { get; set; }
         [DataMember]
        public long CustomerId { get; set; }
         [DataMember]
        public string CheckInDate { get; set; }
         [DataMember]
        public string CheckOutDate { get; set; }
         [DataMember]
        public string Remark { get; set; }
    }

    public class ProductOrder
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long TicketOrder { get; set; }
        [DataMember]
        public long Product { get; set; }
        [DataMember]
        public decimal Quantity { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public string CheckInDate { get; set; }
        [DataMember]
        public string CheckOutDate { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public long CreatedBy { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Picture { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string Detail { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public string PromotionPrice { get; set; }
        [DataMember]
        public Name NameProduct { get; set; }
        [DataMember]
        public Detail DetailProduct { get; set; }

    }

    public class OrderDetail
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long TicketOrder { get; set; }
        [DataMember]
        public long Customer { get; set; }
        [DataMember]
        public string CheckInDate { get; set; }
        [DataMember]
        public string CheckOutDate { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? LastUpdated { get; set; }
        [DataMember]
        public int Staus { get; set; }

    }

    public class ProductCate
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long Product { get; set; }
        [DataMember]
        public int Category { get; set; }
    }

    public class Result
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string Message { get; set; }

    }
    public class Category
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ImageURL { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? LastUpdate { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public Name NameProduct { get; set; }
        
    }
    public class ConFirmPayment
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long Id_Account { get; set; }
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public string Time { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public string UrlImage { get; set; }
        [DataMember]
        public string Detail { get; set; }
        [DataMember]
        public DateTime? CreateDate { get; set; }
        [DataMember]
        public long TicketOrder { get; set; }
        [DataMember]
        public long Id_user { get; set; }
        [DataMember]
        public int Status { get; set; }
    }
    public class Table
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]            
        public int Status { get; set; }
        [DataMember]
        public Name NameProduct { get; set; }
    }

    public class View_Ticket
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? LastUpdate { get; set; }
        [DataMember]
        public int Customer { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]       
        public int Status { get; set; }
    }

    public class Textmessage
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Thai { get; set; }
        [DataMember]
        public string English { get; set; }
        [DataMember]
        public string Chinese { get; set; }
        [DataMember]
        public string Remark { get; set; }


    }

    public class Name
    {

        [DataMember]
        public string Thai { get; set; }
        [DataMember]
        public string English { get; set; }
       
        [DataMember]
        public string Remark { get; set; }
    }

    public class Detail
    {

        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Thai { get; set; }
        [DataMember]
        public string English { get; set; }
     
        [DataMember]
        public string Remark { get; set; }




    }

    public class Type
    {

        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string UrlImage { get; set; }

        [DataMember]
        public string CreateDate { get; set; }
        [DataMember]
        public string LastUpdate { get; set; }
        [DataMember]
        public long Status { get; set; }
        [DataMember]
        public Name NameProduct { get; set; }




    }
    public class Account
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Idname { get; set; }
        [DataMember]
        public string Bank { get; set; }
        [DataMember]
        public string Sector { get; set; }
        [DataMember]
        public int Status { get; set; }
    }
    public class Comment
    {
        [DataMember]
        public string Comment_user { get; set; }

        [DataMember]
        public long CreateBy { get; set; }
    }
}
