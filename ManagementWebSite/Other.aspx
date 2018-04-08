<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Other.aspx.cs" Inherits="Other" %>



<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server"
        ><title></title>
        <link href="jsMoblie/css/themes/default/jquery.mobile-1.4.5.min.css" rel="stylesheet" />
        <link href="jsMoblie/_assets/css/jqm-demos.css" rel="stylesheet" />
        <script src="jsMoblie/js/jquery.js"></script>
        <script src="jsMoblie/_assets/js/index.js"></script>
        <script src="jsMoblie/js/jquery.mobile-1.4.5.min.js"></script>

    </head>
    <body>
        <form id="form1" runat="server">
  
       <div data-role="page">

	<div data-role="header">
		<center><h1>แซ่บการ์เด้น</h1></center></div>

	<div role="main" class="ui-content">
		
        <ul data-role="listview">
    <li><a href="aboutus.aspx">เกี่ยวกับ Apptlication</a></li>
   <li><a href="Contactus.aspx">ข้อมูลการติดต่อ</a></li>
</ul>
	</div><!-- /content -->

	<%--<div data-role="footer">
		<h4>ชมทุ่งสเต็กเฮ้าส์</h4>
	</div>--%><!-- /footer -->

</div><!-- /page -->
    
    </form>
</body>
</html>


