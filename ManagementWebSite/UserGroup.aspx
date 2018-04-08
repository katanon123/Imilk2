<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="UserGroup.aspx.cs" Inherits="UserGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" Runat="Server">
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><a href="UserGroup.aspx">กลุ่มผู้ใช้งาน</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CONTENTContentPlaceHolder" Runat="Server">
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
        <div class="portlet box light-grey">
            <div class="portlet-title">
                <div class="caption">
                    กลุ่มผู้ใช้งาน
                </div>
                <div class="actions">
                    <a class="btn green" href="AddUserGroup.aspx">เพิ่มกลุ่ม <i class="fa fa-plus"></i></a>
                </div>
            </div>


            <div class="portlet-body">
                <table class="table table-striped table-bordered table-hover table-full-width" id="sample_2">
                    <thead>
                        <tr>
                            <th><strong>ลำดับ.</strong></th>
                            <th><strong>ประเภทผู้ใช้งาน</strong></th>
                            <th><strong>จัดการ</strong></th>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="UserGroupRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Container.ItemIndex + 1 %></td>
                                    <td><%# Eval("Name") %></td>
                                    <td style="width: 300px">
                                        <asp:LinkButton ID="Edit_Button" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="linkEdit" Text="แก้ไข" CssClass="btn blue"></asp:LinkButton>
                                    
                                        <asp:LinkButton ID="Delete_Button" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="linkDelete" Text="ลบ" OnClientClick="return confirm('Are you delete ?');" CssClass="btn yellow"></asp:LinkButton>
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

