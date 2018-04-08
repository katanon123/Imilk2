<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="UserAccount.aspx.cs" Inherits="User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .backgA{
            background-color:#808080;
        }
        .backgA:hover{
            background-color:#6f6c6c;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" runat="Server">
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><a href="UserAccount.aspx">บัญชีผู้ใช้งาน</a>
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
                    บัญชีผู้ใช้งาน
                </div>
                <div class="actions">
                    <a class="btn green" href="AddUserAccount.aspx">เพิ่มผู้ใช้ <i class="fa fa-plus"></i></a>
                </div>
            </div>

            <div class="portlet-body">
                <table class="table table-striped table-bordered table-hover table-full-width" id="sample_2">
                    <thead>
                        <tr>
                            <th><strong>ลำดับ.</strong></th>
                            <th><strong>ชื่อ</strong></th>
                            <th><strong>นามสกุล</strong></th>
                            <th><strong>ชื่อผ้ใช้</strong></th>
                            <th><strong>เบอร์โทรศัพท์</strong></th>
                            <th><strong>สถานะ</strong></th>
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
                                    <td style="width: 10%"><%# Eval("MobilePhone") %></td>
                                    <td style="width: 13%">

                                      
                                        <%# Eval("Name") %>

                                       </td>
                                    <td style="width: 10%">
                                        <asp:LinkButton ID="Edit_Button" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="linkEdit" Text="แก้ไข" CssClass="btn blue"></asp:LinkButton>
                                        
                                        
                                        
                                        
                                        <a class="btn btn-warning" data-target='#myModalDe-<%# Eval("Id") %>' data-toggle="modal">ลบ</a>
                                        
                                                <div class="modal fade" id="myModalDe-<%# Eval("Id") %>" role="dialog">
                                                        <div class="modal-dialog">
                                                          <div class="modal-content">
                                                            <div class="modal-header">
                                                              <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                             <h4>ยืนยันการลบ</h4>
                                                            </div>
                                                            <div class="modal-body">
                                                                <asp:LinkButton ID="Delete_Button" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="linkDelete" Text="ยืนยัน"  CssClass="btn yellow"></asp:LinkButton>
                                                                 <button type="button" class="btn btn-default" data-dismiss="modal">ยกเลิก</button>
                                                            </div>
                                                          </div>
                                                        </div>
                                                      </div>

                                        
                                        
                                        
                                        
                                        
                                        
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

