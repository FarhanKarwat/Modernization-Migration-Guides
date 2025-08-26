<%@ Page Language="C#" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Legacy Web Forms - Users</title>
</head>
<body>
<form id="form1" runat="server">
    <h2>Legacy Users (Web Forms)</h2>
    <asp:TextBox runat="server" ID="txtName" Placeholder="Name" />
    <asp:Button runat="server" ID="btnAdd" Text="Add User" OnClick="AddUser_Click" />
    <hr />
    <asp:GridView runat="server" ID="gvUsers" AutoGenerateColumns="true" />
</form>
<script runat="server">
using System;
using System.Data;
using System.Collections.Generic;

static List<string> Users = new List<string> { "Alice", "Bob" };

protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
        BindGrid();
}

protected void AddUser_Click(object sender, EventArgs e)
{
    if (!string.IsNullOrWhiteSpace(txtName.Text))
    {
        Users.Add(txtName.Text.Trim());
        txtName.Text = "";
        BindGrid();
    }
}

void BindGrid()
{
    var dt = new DataTable();
    dt.Columns.Add("Name");
    foreach (var u in Users) dt.Rows.Add(u);
    gvUsers.DataSource = dt;
    gvUsers.DataBind();
}
</script>
</body>
</html>
