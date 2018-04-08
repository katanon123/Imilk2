<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="EditBeverage.aspx.cs" Inherits="EditBeverage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" runat="Server">
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><asp:HyperLink ID="BackMenu_HyperLink" runat="server" >HyperLink</asp:HyperLink>
            <span class="fa fa-angle-double-right"></span>
        </li>
        <li>
            <asp:Label ID="Menu1_Label" runat="server"></asp:Label>
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

    <asp:TextBox ID="DateTime_TextBox" runat="server" Visible="false"></asp:TextBox>
    <div class="col-lg-12">
        <div class="portlet box grey">
            <div class="portlet-title">
                <div class="caption">
                    <asp:Label ID="Menu2_Label" runat="server"></asp:Label>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-body">
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*" Visible="false"></asp:Label>
                        <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*" Visible="false"></asp:Label>

                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>ชื่อ :</strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Name_TextBox" ErrorMessage="กรุณากรอกข้อความ" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Name_TextBox" runat="server" CssClass="form-control" phaceholder="กรุณากรอกข้อมูลภาษาไทย"></asp:TextBox>
                          <br />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="NameEN_TextBox" ErrorMessage="กรุณากรอกข้อความ" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="NameEN_TextBox" runat="server" CssClass="form-control" phaceholder="กรุณากรอกข้อมูลภาษาอังกฤษ"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>รายละเอียด :</strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Detail_TextBox" ErrorMessage="กรุณากรอกข้อความ" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Detail_TextBox" runat="server" CssClass="form-control" TextMode="MultiLine" Columns="50" Rows="4" phaceholder="กรุณากรอกข้อมูลภาษาไทย "></asp:TextBox>
                          <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DetailEN_TextBox" ErrorMessage="กรุณากรอกข้อความ" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="DetailEN_TextBox" runat="server" CssClass="form-control" TextMode="MultiLine" Columns="50" Rows="4" phaceholder="กรุณากรอกข้อมูลภาษาอังกฤษ"></asp:TextBox>
                 
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>ราคา :</strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Price_TextBox" ErrorMessage="กรุณากรอกข้อความ" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Price_TextBox" runat="server" CssClass="form-control" phaceholder="0.00" onkeyup="value=value.replace(/[^0-9,'.']/g,'')"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <p><strong>ราคาพิเศษ :</strong></p>
                        <asp:TextBox ID="PromotionPrice_TextBox" runat="server" CssClass="form-control" phaceholder="0.00" onkeyup="value=value.replace(/[^0-9,'.']/g,'')"></asp:TextBox>
                    </div>
                       <div class="form-group">
                        <asp:Image ID="Picture_Image" runat="server" CssClass="form-control" Width="15%" Height="15%" />
                    </div>
                    <div class="form-group">
                        <p><strong>รูปภาพ :</strong></p>
                        <asp:FileUpload ID="Picture_FileUpload" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <p><strong>เลือกประเภทอาหารเเละเครื่องดื่ม :</strong></p>
                        <asp:RadioButtonList ID="radiobutton" runat="server" Font-Size="X-Large"></asp:RadioButtonList>
                    </div>

                    <div class="form-group" style="text-align: center">
                        <asp:Button ID="Confirm_Button" runat="server" CssClass="btn purple" Text="ตกลง" OnClick="Confirm_Button_Click" />
                        <asp:Button ID="Cancel_Button" runat="server" CssClass="btn grey" Text="ยกเลิก" OnClientClick="this.form.reset();return false;" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    
</asp:Content>

