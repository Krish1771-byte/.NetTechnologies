<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Practical_5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Academic Calendar</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Calendar ID="Calendar1" runat="server"
                OnSelectionChanged="calAcademic">
            </asp:Calendar>

            <br />

            <asp:Label ID="lblselectDate" runat="server"></asp:Label>

            <br /><br />

            <asp:Button ID="Button1" runat="server"
                Text="ApplyLeave"
                OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>