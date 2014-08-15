<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="ASP.NET.WebForm.CodeAdmin.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

    </script>

    <div class="row">
        <div class="large-5 columns">
            <hr />
            <fieldset class="panel callout radius">
                <legend>Search Users</legend>

                <div class="row collapse">
                    <div class="small-3 large-3 columns">
                        <span class="prefix">Name:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textSearch" runat="server" placeholder="input Name" />
                    </div>
                </div>
            </fieldset>
            <br />
            <asp:Button ID="btnSearch" class="small radius button" Text="Buscar" runat="server" OnClick="btnSearch_Click" />
        </div>
        <div class="large-7 columns">
            <asp:GridView ID="GridViewSearch" runat="server" HeaderStyle-CssClass="panel callout radius"></asp:GridView>
        </div>
    </div>

    <div class="row">
        <div class="large-5 columns">
            <div>
                Your Name :
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                <input id="btnGetTime" type="button" value="Show Current Time"
                    onclick="ShowCurrentTime()" />
            </div>

            <hr />
            <div id="panelMsg" runat="server">
                <div class="panel callout radius">
                    <asp:Label ID="lblMsg" Text="" runat="server" />
                </div>
            </div>
            <br />
            <fieldset class="panel callout radius">
                <legend>Create Users</legend>
                <div class="row collapse">
                    <div class="small-3 large-3 columns">
                        <span class="prefix">Nombre:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textName" runat="server" placeholder="you name" />
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Apellidos:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textApellidos" runat="server" placeholder="you lastname" />
                    </div>
                    <div class="small-3 large-3 columns">
                        <span class="prefix">Correo:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textEmail" runat="server" placeholder="you email" />
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Compañia:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textCompany" runat="server" placeholder="you company" />
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Fecha:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textDate" runat="server" placeholder="you date" />
                    </div>
                </div>
            </fieldset>
            <br />
            <asp:Button ID="btnCreate" class="small radius button" Text="Guardar" runat="server" OnClick="btnCreate_Click" />
            <hr />
            <p>Update Ajax</p>
            <asp:TextBox ID="textUserId" runat="server" placeholder="Input ID User" />
            <asp:GridView ID="GridviewAjax" runat="server"></asp:GridView>
            <input id="btnUpdateAjax" type="button" value="Get User" onclick="GetDetailsUser()" />

            <fieldset class="panel callout radius">
                <legend>Update Users</legend>
                <div class="row collapse">
                    <div class="small-3 large-3 columns">
                        <span class="prefix">ID:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="testUID" runat="server" placeholder="Input ID to Update" />
                    </div>

                    <%--<div runat="server" id="divUpdate">   --%>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Nombre:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textUName" runat="server" placeholder="you name" />
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Apellidos:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textULastName" runat="server" placeholder="you lastname" />
                    </div>
                    <div class="small-3 large-3 columns">
                        <span class="prefix">Correo:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textUEmail" runat="server" placeholder="you email" />
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Compañia:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textUCompany" runat="server" placeholder="you company" />
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Fecha:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textUDate" runat="server" placeholder="you date" />
                    </div>
                </div>
            </fieldset>
            <br />
            <asp:Button ID="btnUpdate" class="small radius button" Text="Actualizar" runat="server" OnClick="btnUpdate_Click" />
            <hr />
            <fieldset class="panel callout radius">
                <legend>Delete Users</legend>

                <div class="row collapse">
                    <div class="small-3 large-3 columns">
                        <span class="prefix">ID:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textID" runat="server" placeholder="input ID" />
                    </div>
                </div>
            </fieldset>
            <br />
            <asp:Button ID="btnDelete" class="small radius button" Text="Eliminar" runat="server" OnClick="btnDelete_Click" />
        </div>

        <div class="large-7 columns">
            <h4>Read <small>Four-Tier</small></h4>
            <asp:GridView ID="GridViewfourTier" runat="server" HeaderStyle-CssClass="panel callout radius"></asp:GridView>
        </div>
    </div>

</asp:Content>
