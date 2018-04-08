<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="approve.aspx.cs" Inherits="approve" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" runat="Server">
    
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><a href="UserAccount.aspx">อนุมัติการเข้าใช้งาน</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CONTENTContentPlaceHolder" runat="Server">
    <asp:Panel ID="SuccessPanel" runat="server" Visible="false">
        <div class="alert alert-success">
            <p style="text-align: right">
                <asp:LinkButton ID="SuccessLinkButton" runat="server" OnClick="SuccessLinkButton_Click">X</asp:LinkButton>
            </p>
            <p><strong>Success! </strong></p>
            <asp:Label ID="SuccessLabel" runat="server" Text=""></asp:Label>
        </div>
    </asp:Panel>
    <asp:Panel ID="ErrorPanel" runat="server" Visible="false">
        <div class="alert alert-danger">
            <p style="text-align: right">
                <asp:LinkButton ID="ErrorLinkButton" runat="server" OnClick="ErrorLinkButton_Click">X</asp:LinkButton>
            </p>
            <p><strong>Error! </strong></p>
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        </div>
    </asp:Panel>

    <div class="col-lg-12">
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                   อนุมัติการเข้าใช้งาน
                </div>
               
            </div>

            <div class="portlet-body">
                <table class="table table-striped table-bordered table-hover table-full-width" id="sample_2">
                    <thead>
                        <tr>
                            <th><strong>ลำดับ.</strong></th>
                            <th><strong>ชื่อ</strong></th>
                            <th><strong>นามสกุล</strong></th>
                            <th><strong>อีเมล์</strong></th>
                           <%-- <th><strong>พาสเวิร์ด</strong></th>--%>
                            <th><strong>โทรศัพท์</strong></th>
                            <th><strong>รูปภาพ</strong></th>
                            <th><strong>จัดการ</strong></th>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="UserAccountRepeater" runat="server" >
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 1%"><%# Container.ItemIndex +1 %></td>
                                    <td style="width: 15%"><%# Eval("FirstName") %></td>
                                    <td style="width: 15%"><%# Eval("LastName") %></td>
                                    <td><%# Eval("Email") %></td>
                                 <%--   <td style="width: 15%"><%# Eval("Password") %></td>--%>
                                    <td style="width: 10%"><%# Eval("MobilePhone") %></td>
                                 <td> <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Urlimage") %>'  Width="200px" Height="100px"/></td> 
                                    <td style="width: 10%">
                                        <asp:LinkButton ID="Edit_Button" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="linkEdit" Text="อนุมัติ" CssClass="btn blue"></asp:LinkButton>
                                        <asp:LinkButton ID="Delete_Button" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="linkDelete" Text="ไม่อนุมัติ" OnClientClick="return confirm('Are you delete ?');" CssClass="btn yellow"></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

