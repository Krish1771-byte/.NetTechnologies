<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Practical_5.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Application</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            Leave Application
            <br />
            <br />

            Employee Name:
            <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>

            <br />
            <br />

            Leave Date:
            

            <asp:Label ID="lblleaveDate" runat="server"></asp:Label>

            <br />

            LeaveType:

            <asp:DropDownList ID="DropDownList1" runat="server"
                OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">

                <asp:ListItem>Personal Leave</asp:ListItem>
                <asp:ListItem>Medical Leave</asp:ListItem>
                <asp:ListItem>Emergency leave</asp:ListItem>

            </asp:DropDownList>

            <br />
            <br />

            Reason:

            <asp:TextBox ID="TextBox2" runat="server"
                Height="65px" Width="166px"></asp:TextBox>

            <br />
            <br />

            Remember Name:

            <asp:CheckBox ID="CheckBox1" runat="server"
                OnCheckedChanged="CheckBox1_CheckedChanged"
                Text="Remember my name" />

            <br />
            <br />
            <br />

            <asp:Button ID="Btnsubmit" runat="server"
                OnClick="Btnsubmit_Click"
                Text="Submit Leave" />

            <br />
            <br />

        </div>

        <p>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </p>

    </form>
</body>
</html>