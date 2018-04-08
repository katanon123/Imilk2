<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Tables.aspx.cs" Inherits="Tables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" runat="Server">
    <h3 class="page-title">โต๊ะอาหาร</h3>
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><a href="AddCategory.aspx">โต๊ะอาหาร</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CONTENTContentPlaceHolder" runat="Server">
    <asp:Panel ID="SuccessPanel" runat="server" Visible="false">
        <div class="alert alert-success">
            <p style="text-align: right">
                <asp:LinkButton ID="SuccessLinkButton" runat="server" OnClick="SuccessLinkButton_Click">X</asp:LinkButton>
            </p>
            <p><strong>Success!</strong></p>
            <asp:Label ID="SuccessLabel" runat="server"></asp:Label>
        </div>
    </asp:Panel>
    <asp:Panel ID="ErrorPanel" runat="server" Visible="false">
        <div class="alert alert-danger">
            <p style="text-align: right">
                <asp:LinkButton ID="ErrrorLinkButton" runat="server" OnClick="ErrorLinkButton_Click">X</asp:LinkButton>
            </p>
            <p><strong>Error!</strong></p>
            <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
        </div>
    </asp:Panel>

    <asp:TextBox ID="aaa_TextBox" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="nameimage_TextBox" runat="server" Visible="false"></asp:TextBox>
    <asp:Panel ID="ShowPanel" runat="server">


        <div class="col-lg-12">
            <div class="portlet box yellow">
                <div class="portlet-title">
                    <div class="caption">
                        โต๊ะอาหาร
                    </div>
                    <div class="actions">
                        <div class="btn-group">

                            <asp:Button ID="AddButton" runat="server" Text="+" CssClass="btn green" OnClick="AddButton_Click" />

                        </div>
                    </div>
                </div>

                <div class="portlet-body">
                    <table class="table table-striped table-bordered table-hover table-full-width">
                        <thead>
                            <tr>
                                <th><strong>ลำดับ</strong></th>
                                <th><strong>ชื่อ</strong></th>
                                <th><strong>จัดการ</strong></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="CategoryTa" runat="server" OnItemCommand="CategoryTa_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 25px; text-align: center;">
                                            <%# Container.ItemIndex + 1 %></td>

                                        <td style="width: 400px;">
                                            <asp:Label ID="Day_Label" runat="server" Text='<%# Eval("Name") %>' Font-Size="Medium"></asp:Label><br />
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("NameEN") %>' Font-Size="Medium"></asp:Label><br />


                                           

                                            <td style="width: 200px;">
                                                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("IDProduct") %>' Visible="False"></asp:Label>
                                                
                                                <asp:LinkButton ID="LinkButtonEdat" runat="server" Text='Edit' class="btn blue " CommandName="EditBtn"></asp:LinkButton>
                                                <asp:LinkButton ID="LinkButtonDelete" runat="server" Text='Delete' class="btn yellow " CommandName="DeleteBtn" OnClientClick="return confirm('Are you delete ?');"></asp:LinkButton>

                                            </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="AddPanel" runat="server" Visible="false">
        <div class="col-lg-12">
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        เพิ่มโต๊ะอาหาร
                    </div>
                </div>
                <div class="portlet-body form">
                    <div class="form-body">

                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            <p><strong>ชื่อ : </strong></p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="Name_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อความ"></asp:RequiredFieldValidator>
                            <br />
                            <asp:TextBox ID="Name_TextBox" runat="server" CssClass="form-control" placeholder="กรุณากรอกข้อมูลภาษาไทย"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="NameEN_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อความ"></asp:RequiredFieldValidator>
                            <br />
                            <asp:TextBox ID="NameEN_TextBox" runat="server" CssClass="form-control" placeholder="กรุณากรอกข้อมูลภาษาอังกฤษ"></asp:TextBox>


                        </div>

                        <div class="form-group;" style="text-align: center;">
                            <asp:Button ID="Confirm_Button" runat="server" CssClass="btn purple" Text="Agree" OnClick="Confirm_Button_Click" />
                            <asp:Button ID="Cancel_Button" runat="server" CssClass="btn grey" Text="Cancel" OnClientClick="this.form.reset();return false;" />
                        </div>

                    </div>
                </div>
            </div>
        </div>

       
    </asp:Panel>
    <asp:Panel ID="EditPanel" runat="server" Visible="false">
        <div class="col-lg-12">
            <div class="portlet box warning">
                <div class="portlet-title">
                    <div class="caption">
                       แก้โต๊ะอาหาร
                    </div>
                </div>
                <div class="portlet-body form">
                    <div class="form-body">

                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label><asp:Label ID="Labelidname" runat="server" Text="Label" Visible="false"></asp:Label>
                            <p><strong>ชื่อ : </strong></p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="editName_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อความ"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="editName_TextBox" runat="server" CssClass="form-control" placeholder="กรุณากรอกข้อมูลภาษาไทย"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ControlToValidate="editNameEN_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อความ"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="editNameEN_TextBox" runat="server" CssClass="form-control" placeholder="กรุณากรอกข้อมูลภาษาอังกฤษ"></asp:TextBox>

                        </div>

                         <div class="form-group;" style="text-align: center;">
                            <asp:Button ID="Button1" runat="server" CssClass="btn purple" Text="Agree" ValidationGroup="3" OnClick="Button1_Click" />
                            <asp:Button ID="Button2" runat="server" CssClass="btn grey" Text="Cancel" OnClientClick="this.form.reset();return false;" />
                        </div>

                    </div>
                </div>
            </div>
        </div>

      

    </asp:Panel>

</asp:Content>

