<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="AddPromotions.aspx.cs" Inherits="AddMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" runat="Server">
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><a href="AddMenu.aspx"><asp:Label runat="server" ID="headtitle2">โปรโมชั่น</asp:Label></a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CONTENTContentPlaceHolder" runat="Server">
   <asp:Panel ID="SuccessPanel" runat="server" Visible="false">
        <div class="alert alert-success">
            <div style="float:left"><strong>Success!</strong>
            <asp:Label ID="SuccessLabel" runat="server"></asp:Label></div>
                <div style="float:right"> <asp:LinkButton ID="SuccessLinkButton" runat="server" OnClick="SuccessLinkButton_Click">X</asp:LinkButton></div>
          <br />
        </div>
    </asp:Panel>

     <asp:Panel ID="ErrorPanel" runat="server" Visible="false">
       <div class="alert alert-danger">
            <div style="float:left"><strong>Error!</strong>
            <asp:Label ID="ErrorLabel" runat="server"></asp:Label></div>
                <div style="float:right">  <asp:LinkButton ID="ErrrorLinkButton" runat="server" OnClick="ErrorLinkButton_Click">X</asp:LinkButton></div>
          <br />
        </div>
    </asp:Panel>

    <asp:TextBox ID="IDProduct_TextBox" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="DateTime_TextBox" runat="server" Visible="false"></asp:TextBox>
    <div class="col-lg-12">
        <div class="portlet box red">
            <div class="portlet-title">
                <div class="caption">
                   <asp:Label runat="server" ID="headtitle3">โปรโมชั่น</asp:Label>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-body">

                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>ชื่อโปรโมชั่น : </strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="Name_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อความ"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Name_TextBox" runat="server" CssClass="form-control" placeholder="กรุณากรอกข้อมูลภาษาไทย"></asp:TextBox>
                        <br />
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="NameEN_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อความ"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="NameEN_TextBox" runat="server" CssClass="form-control" placeholder="กรุณากรอกข้อมูลภาษาอังกฤษ"></asp:TextBox>
                         
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>รายละเอียดโปรโมชั่น :</strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="Detail_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อความ"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Detail_TextBox" runat="server" CssClass="form-control" placeholder="กรุณากรอกข้อมูลภาษาไทย" TextMode="MultiLine" Rows="4" Columns="50"></asp:TextBox>
                          <br />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ControlToValidate="DetailEN_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อความ"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="DetailEN_TextBox" runat="server" CssClass="form-control" placeholder="กรุณากรอกข้อมูลภาษาอังกฤษ" TextMode="MultiLine" Rows="4" Columns="50"></asp:TextBox>
                         
                    </div>


                    <div class="form-group">
                            <p><strong>รูปภาพ :</strong></p>
                            <asp:FileUpload ID="Picture_FileUpload" runat="server" CssClass="form-control" />
                        </div>
                        
                   <%-- <div class="form-group">
                        <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>ประเภทอาหารเเละเครื่องดื่ม :</strong></p>
                         
                        <asp:CheckBoxList ID="Category_CheckBoxList" runat="server" Font-Size="X-Large"></asp:CheckBoxList>
                    <asp:CustomValidator ID="CustomValidator1" ErrorMessage="Please Select Type of Service"
                         ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList" runat="server" />
                    </div>--%>

                    <div class="form-group;" style="text-align: center;">
                        <asp:Button ID="Confirm_Button" runat="server" CssClass="btn purple" Text="ตกลง"  OnClick="Confirm_Button_Click" />
                        <asp:Button ID="Cancel_Button" runat="server" CssClass="btn grey" Text="ยกเลิก" OnClientClick="this.form.reset();return false;" OnClick="Cancel_Button_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

