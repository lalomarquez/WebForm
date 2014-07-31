<%@ Page Title="Consumiendo WS" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="ConsumingWS.aspx.cs" Inherits="ASP.NET.WebForm.ConsumingWS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="large-12 columns">
            <%--<div class="panel callout radius">--%>
            <div class="panel">
                <asp:Label ID="lblHello" Text="" runat="server" /><br />
                <asp:Label ID="lblFood" Text="" runat="server" /><br />
                <asp:Label ID="lblSum" Text="" runat="server" />
                <hr />
                <asp:Button ID="btnConsumirWS" class="small radius button" Text="Consumir" runat="server" OnClick="btnConsumirWS_Click" />
            </div>
        </div>
    </div>
</asp:Content>

