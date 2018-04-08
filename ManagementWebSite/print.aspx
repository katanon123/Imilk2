<%@ Page Language="C#"  CodeFile="print.aspx.cs"   Inherits="print" %>
<%--AutoEventWireup="true"--%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
  
<%--<head runat="server">--%>
    <head>
    <title>ใบเสร็จ</title>

        <script type="text/javascript">
            function PrintDiv() {
                var divContents = document.getElementById("dvContents").innerHTML;
                var printWindow = window.open('', '', 'height=200,width=400');
                printWindow.document.write('<html><head><title>DIV Contents</title>');
                printWindow.document.write('</head><body >');
                printWindow.document.write(divContents);
                printWindow.document.write('</body></html>');
                printWindow.document.close();
                printWindow.print();
            }
    </script>
   
</head>
<body>
    <form id="form1" runat="server">
    <div id="dvContents" style="border: 1px dotted black; padding: 5px; width: 300px">
        <asp:Label ID="Label1" runat="server">DGS-</asp:Label>
                                <asp:Label ID="IDT" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
        
        <p><asp:Label ID="DateLabel" runat="server" Text='<%# Eval("") %>'></asp:Label> </p>
		<table > 
            <tbody>
                        <asp:Repeater ID="DetailTicketOrderRepeater" runat="server" >
                            <ItemTemplate>
                                <tr>
                                    
                                    <td style="width: 1%"><%# Container.ItemIndex + 1 %>
                                        <asp:Label ID="ProductOrderID_Label" runat="server" Text='<%# Eval("ProductOrderID") %>' Visible="false"></asp:Label>
                                    </td>
                                     <td style="width: 150px"><%# Eval("Quantity") %></td>
                                    <td style="width: 200px"><%# Eval("Product") %></td>
                                  <%--  <td style="width: 150px"><%# Eval("Quantity") %></td>--%>
                                    <td style="width: 150px"><%# Eval("Price") %></td>
                                    <%--<td style="width: 20%"><%# Eval("Checkin") %></td>--%>
                                    <%--<td style="width: 250px"><%# Eval("Checkout") %></td>--%>
                                    <td style="width: 15%"><%# Eval("Total") %></td>
                                    <%--<td style="text-align: center">
                                        <asp:LinkButton ID="Payment_LinkButton" runat="server" Text="Payment" CommandArgument='<%# Eval("ProductOrderID") %>' OnCommand="Payment_LinkButton" CssClass="btn green" CommandName="PaymentLink" OnClientClick="return confirm('Are you payment ?')"></asp:LinkButton>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:LinkButton ID="Checkin_LinkButton" runat="server" Text="Check In" CommandArgument='<%# Eval("ProductOrderID") %>' OnCommand="Checkin_LinkButton" CssClass="btn blue" CommandName="CheckinLink" OnClientClick="return confirm('Are you check-in ?')"></asp:LinkButton>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:LinkButton ID="Checkout_LinkButton" runat="server" Text="Check Out" CommandArgument='<%# Eval("ProductOrderID") %>' OnCommand="Checkout_LinkButton" CssClass="btn Default disabled" CommandName="CheckoutLink" Enabled="False" OnClientClick="return confirm('Are you check-out ?')"></asp:LinkButton>
                                    </td>--%>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td colspan="4" style="text-align: right" class="auto-style1">
                                <strong style="vertical-align: top; font-size: medium;">Grand Total : </strong></td>
                            <td style="text-wrap: normal" class="auto-style1">
                                <asp:Label ID="Total_Label" runat="server"  Font-Size="Medium"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
          </div>
        <input type="button" onclick="PrintDiv();" value="Print" />
        <%--<asp:Button ID="Button1" runat="server"  Text="Button"  onclick="PrintDiv();/>--%>
    </form>
</body>
    </html>
     