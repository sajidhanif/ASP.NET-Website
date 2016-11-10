<%@ Page Language="C#" AutoEventWireup="true" CodeFile="users.aspx.cs" Inherits="users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 99px">
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label_welcome" runat="server" Text="Welcome text"></asp:Label>
    
    </div>
        <asp:Button ID="Button_logout" runat="server" OnClick="Button_logout_Click" Text="Logout" />
    </form>
</body>
</html>
