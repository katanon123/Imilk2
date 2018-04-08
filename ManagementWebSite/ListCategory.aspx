<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="ListCategory.aspx.cs" Inherits="AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" runat="Server">
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><a href="ListCategory.aspx">ประเภทอาหารเเละเครื่องดื่ม</a>
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

    <asp:TextBox ID="aaa_TextBox" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="nameimage_TextBox" runat="server" Visible="false"></asp:TextBox>
    <asp:Panel ID="ShowPanel" runat="server">


        <div class="col-lg-12">
            <div class="portlet box yellow">
                <div class="portlet-title">
                    <div class="caption">
                        ประเภทอาหารเเละเครื่องดื่ม
                    </div>
                    <div class="actions">
                        <div class="btn-group">

                            <asp:Button ID="AddButton" runat="server" Text="+" CssClass="btn green" OnClick="AddButton_Click" Visible="true"/>

                        </div>
                    </div>
                </div>

                <div class="portlet-body">
                    <table class="table table-striped table-bordered table-hover table-full-width" id="sample_2">
                        <thead>
                            <tr>
                                <th><strong>ลำดับ</strong></th>
                                <th><strong>ชื่อ</strong></th>
                                <th><strong>รูปภาพ</strong></th>
                                <th><strong>จัดการ</strong></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="CategoryTa" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 25px; text-align: center;">
                                            <%# Container.ItemIndex + 1 %></td>

                                        <td style="width: 400px;">
                                            <asp:Label ID="Day_Label" runat="server" Text='<%# Eval("Name") %>' Font-Size="Medium"></asp:Label><br />
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("NameEN") %>' Font-Size="Medium"></asp:Label><br />


                                            <td style="width: 600px;">
                                                <img src='Image/<%#Eval("ImageURL")%>' width="132" class="center-block" />
                                                <%--<a class="btn purple fancybox" href="Image/<%#Eval("ImageURL")%>"><i class="fa fa-picture-o" aria-hidden="true"> ดูรูปภาพ</i></a>--%>
                                            </td>

                                            <td style="width: 200px;">
                                                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("IDProduct") %>' Visible="False"></asp:Label>
                                                <asp:Label ID="imagenameLabel" runat="server" Text='<%# Eval("ImageURL") %>' Visible="False"></asp:Label>


                                                 <asp:LinkButton ID="LinkButtonEdat" runat="server" Text='แก้ไข' class="btn blue " OnCommand="LinkButtonEdat_Command" CommandArgument='<%# Eval("IDProduct") %>'></asp:LinkButton>
                                                
                                                
                                                
                                                 <a id="deletebutton" class="btn btn-warning" data-target='#myModalD-<%# Eval("IDProduct") %>' data-toggle="modal"  <%# Request.QueryString["Type"] == "18" ? "Style='display:none'" : string.Empty %> >ลบ</a>
                                        
                                                <div class="modal fade" id="myModalD-<%# Eval("IDProduct") %>" role="dialog">
                                                        <div class="modal-dialog">
                                                          <div class="modal-content">
                                                            <div class="modal-header">
                                                              <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                             <h4>ยืนยันการลบ</h4>
                                                            </div>
                                                            <div class="modal-body">
                                                            <div class="modal-body">
                                                                <asp:LinkButton ID="LinkButtonDelete" runat="server" Text='ยืนยัน' class="btn yellow " OnCommand="LinkButtonDelete_Command" CommandArgument='<%# Eval("IDProduct") %>'></asp:LinkButton>
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
    </asp:Panel>
    <asp:Panel ID="AddPanel" runat="server" Visible="false">
        <div class="col-lg-12">
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        เพิ่มประเภทอาหารเเละเครื่องดื่ม
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
                        

                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-12">
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                       เพิ่มรูปภาพ
                    </div>
                </div>
                <div class="portlet-body form">
                    <div class="form-body">

                        <div class="form-group">
                            <p><strong>รูปภาพ :</strong></p>
                            <asp:FileUpload ID="Picture_FileUpload" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group;" style="text-align: center;">
                            <asp:Button ID="Confirm_Button" runat="server" CssClass="btn purple" Text="ตกลง" OnClick="Confirm_Button_Click" />
                            <asp:Button ID="Cancel_Button" runat="server" CssClass="btn grey" Text="ยกเลิก" OnClientClick="this.form.reset();return false;" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="EditPanel" runat="server" Visible="false">
        <div class="col-lg-12">
            <div class="portlet box yellow">
                <div class="portlet-title">
                    <div class="caption">
                       แก้ประเภทอาหารเเละเครื่องดื่ม
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
                        <div class="form-group">
                            <p><strong>รูปภาพ :</strong></p>
                            <asp:Image ID="Image_category" runat="server" CssClass="form-control" Width="15%" Height="15%" />
                        </div>
                        <div class="form-group">
                            
                            <asp:FileUpload ID="EditFileUpload" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group;" style="text-align: center;">
                            <asp:Button ID="Button1" runat="server" CssClass="btn purple" Text="ตกลง" ValidationGroup="3" OnClick="Button1_Click" />
                            <asp:Button ID="Button2" runat="server" CssClass="btn grey" Text="ยกเลิก" OnClientClick="this.form.reset();return false;" />
                        </div>

                    </div>
                </div>
            </div>
        </div>

      
    </asp:Panel>

</asp:Content>

