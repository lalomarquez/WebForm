<%@ Page Title="Tabla de Usuarios" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="TablesUser.aspx.cs" Inherits="ASP.NET.WebForm.CodeAdmin.TablesUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="large-12 columns">
            
            <hr />
            <h6 class="subheader">SqlDataSource</h6>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_User" DataSourceID="SqlDataSource1" EmptyDataText="No records Found" HeaderStyle-CssClass="panel callout radius">
                <Columns>
                    <asp:BoundField DataField="ID_User" HeaderText="ID_User" InsertVisible="False" ReadOnly="True" SortExpression="ID_User" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connString %>" SelectCommand="SELECT * FROM [SCRUD_RegisterUser]"></asp:SqlDataSource>
            
            <hr />
            <h6 class="subheader">Query</h6>
            <asp:GridView ID="GridViewQuery" runat="server" HeaderStyle-CssClass="panel callout radius"></asp:GridView>

            <hr />
            <h6 class="subheader">Store</h6>
            <asp:GridView ID="GridViewSP" runat="server" HeaderStyle-CssClass="panel callout radius"></asp:GridView>

            <hr />
            <h6 class="subheader">Method & SP</h6>
            <asp:GridView ID="GridViewMethodSP" runat="server" HeaderStyle-CssClass="panel callout radius"></asp:GridView>

            <hr />
            <h6 class="subheader">Four Tier</h6>
            <asp:GridView ID="GridViewFourTier" runat="server" HeaderStyle-CssClass="panel callout radius"></asp:GridView>

        </div>
    </div>
</asp:Content>
