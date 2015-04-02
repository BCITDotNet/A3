<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 200px;
            height: 60px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img class="auto-style1" src="img/logo.png" /><br />
    
        <asp:TextBox ID="TextBoxSearch" runat="server" Width="343px"></asp:TextBox>
        <asp:Button ID="Search" runat="server" BackColor="Black" BorderColor="White" BorderStyle="None" OnClick="Search_Click" Text="Search" ForeColor="White" />
        <br />
        <br />
        Document :&nbsp; <asp:Label ID="LabelFileName" runat="server"></asp:Label>
    
        &nbsp;&nbsp;&nbsp;
    
        &nbsp;<asp:Label ID="LabelNumber" runat="server"></asp:Label>
    
        <br />
&nbsp;<br />
        <asp:TextBox ID="TextBoxResult" TextMode="MultiLine" runat="server" Height="337px" Width="400px"></asp:TextBox>
        <br />
        <asp:ImageButton ID="ImageButtonDownload" runat="server" ImageUrl="~/img/070.png" OnClick="ImageButtonDownload_Click" />
        <asp:ImageButton ID="ImageButtonPrint" runat="server" ImageUrl="~/img/300.png" OnClick="ImageButtonPrint_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButtonFirst" runat="server" ImageUrl="~/img/122.png" OnClick="ImageButtonFirst_Click" />
&nbsp;
        <asp:ImageButton ID="ImageButtonPrev" runat="server" ImageUrl="~/img/118.png" OnClick="ImageButtonPrev_Click" />
&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButtonNext" runat="server" ImageUrl="~/img/117.png" OnClick="ImageButtonNext_Click" />
&nbsp;
        <asp:ImageButton ID="ImageButtonLast" runat="server" ImageUrl="~/img/120.png" OnClick="ImageButtonLast_Click" />
        <br />
    
    </div>
    </form>
</body>
</html>
