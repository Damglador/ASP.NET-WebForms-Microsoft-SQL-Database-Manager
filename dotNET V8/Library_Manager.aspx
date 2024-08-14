<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Library_Manager.aspx.cs" Inherits="dotNET_V8.Library_Manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 104px;
        }
        .auto-style2 {
            width: 104px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table border-spacing="100px 0">
            <tr>
                        <td style="padding: 0 100px 0 0;">
        <table style="width: 300px">
        <tr>
            <td class="auto-style1"><asp:Label ID="Label1" runat="server" Text="ID"></asp:Label></td>
            <td class="auto-style3"><asp:TextBox ID="tbID" runat="server"></asp:TextBox>
                <asp:Label ID="errID" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2"><asp:Label ID="Label7" runat="server" Text="Назва"></asp:Label></td>
            <td class="auto-style3"><asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                <asp:Label ID="errName" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"><asp:Label ID="Label2" runat="server" Text="Опис"></asp:Label></td>
            <td><asp:TextBox ID="tbDesc" runat="server"></asp:TextBox>
                <asp:Label ID="errDesc" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"><asp:Label ID="Label3" runat="server" Text="Рік виходу"></asp:Label></td>
            <td><asp:TextBox ID="tbReleaseYear" runat="server"></asp:TextBox>
                <asp:Label ID="errReleaseYear" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"><asp:Label ID="Label4" runat="server" Text="Код виробника"></asp:Label></td>
            <td><asp:TextBox ID="tbManufactureCode" runat="server"></asp:TextBox>
                <asp:Label ID="errManufactureCode" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"><asp:Label ID="Label5" runat="server" Text="Код автора"></asp:Label></td>
            <td><asp:TextBox ID="tbAuthorCode" runat="server"></asp:TextBox>
                <asp:Label ID="errAuthorCode" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"><asp:Label ID="Label6" runat="server" Text="Код у сховищі"></asp:Label></td>
            <td><asp:TextBox ID="tbStorageCode" runat="server"></asp:TextBox>
                <asp:Label ID="errStorageCode" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"><asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
            <td><asp:Button ID="btnWrite" runat="server" OnClick="btnWrite_Click" Text="Write" />
                <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove" />
                <asp:Button ID="btnGet" runat="server" OnClick="btnGet_Click" Text="Get data from ID" />
            </td>
        </table>
        </td>
                <td valign="top">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="LibraryDB">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Назва" SortExpression="Name" />
                    <asp:BoundField DataField="ShortDesc" HeaderText="Опис" SortExpression="ShortDesc" />
                    <asp:BoundField DataField="ReleaseYear" HeaderText="Рік випуску" SortExpression="ReleaseYear" />
                    <asp:BoundField DataField="ManufactureCode" HeaderText="Код виробника" SortExpression="ManufactureCode" />
                    <asp:BoundField DataField="AuthorCode" HeaderText="Код автора" SortExpression="AuthorCode" />
                    <asp:BoundField DataField="StorageCode" HeaderText="Код у сховищі" SortExpression="StorageCode" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="LibraryDB" runat="server" ConnectionString="<%$ ConnectionStrings:LibraryDB %>" SelectCommand="SELECT * FROM [Book]"></asp:SqlDataSource>
        </td>
            </tr>
        </table>
    </form>
    </body>
</html>
