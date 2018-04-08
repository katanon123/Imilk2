<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="AddUserAccount.aspx.cs" Inherits="AddUserAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
            <script>

        $(document).ready(function () {

            $(".p").mouseover(function () {
                $(".p").attr("type", "text");
            });

            $(".p").mouseout(function () {
                $(".p").attr("type", "password");
            });

        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" runat="Server">
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><a href="UserAccount.aspx">บัญชีผู้ใช้งาน</a>
            <span class="fa fa-angle-right"></span>
        </li>
        <li>เพิ่มบัญชีผู้ใช้งาน</li>
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
                    <i class="fa fa-reorder"></i>เพิ่มบัญชีผู้ใช้งาน
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstNameAddUserAccount_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="FirstNameAddUserAccount_TextBox" runat="server" CssClass="form-control" placeholder="กรุณาใส่ชื่อ"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>นามสกุล : </strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastNameAddUserAccount_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="LastNameAddUserAccount_TextBox" runat="server" CssClass="form-control" placeholder="กรุณาใส่นามสกุล"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>ชื่อผู้ใช้ในการเข้าสู่ระบบ : </strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="EmailAddUserAccount_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="EmailAddUserAccount_TextBox" runat="server" CssClass="form-control" placeholder="กรุณากรอกชื่อผู้ใช้ในการเข้าสู่ระบบ" ></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>รหัสผ่าน : </strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="PasswordAddUserAccount_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="PasswordAddUserAccount_TextBox" runat="server" CssClass="form-control p" placeholder="กรุณาใส่รหัสผ่าน" TextMode="Password"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>เบอร์โทรศัพท์ : </strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="MobilePhoneAddUserAccount_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="MobilePhoneAddUserAccount_TextBox" runat="server" CssClass="form-control" placeholder="กรุณาใส่เบอร์โทรศัพท์"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>กลุ่มผู้ใช้งาน : </strong></p>
                        <asp:CheckBoxList ID="UserGroupAddUserAccount_CheckBoxList" runat="server"></asp:CheckBoxList>
                    </div>


                    <div class="form-group" style="text-align: center">
                        <br />
                        <asp:Button ID="AddButton" runat="server" Text="เพิ่ม" class="btn red" OnClick="AddButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

