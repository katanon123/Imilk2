<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="EditUserGroup.aspx.cs" Inherits="EditUserGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" runat="Server">
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><a href="UserGroup.aspx">กลุ่มผู้ใช้งาน</a>
            <span class="fa fa-angle-right"></span>
        </li>
        <li>แก้ไขกลุ่มผู้ใช้งาน</li>
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

    <div class="col-lg-12">
        <div class="portlet box yellow">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-reorder"></i>แก้ไขกลุ่มผู้ใช้งาน
                </div>
                <div class="tools">
                    <a href="" class="collapse"></a>
                </div>
            </div>
            <div class="portlet-body form">

                <div class="form-body">
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>ชื่อ : </strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NameEditUserGroup_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="NameEditUserGroup_TextBox" runat="server" CssClass="form-control" placeholder="Enter text"></asp:TextBox>
                    </div>

                    <div class="form-group" style="text-align: center">
                        <br />
                        <asp:Button ID="AddButton" runat="server" Text="แก้ไข" class="btn red" OnClick="AddButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

