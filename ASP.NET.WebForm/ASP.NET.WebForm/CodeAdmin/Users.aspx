<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="ASP.NET.WebForm.CodeAdmin.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="large-12 columns">
            <br />

            <h1 class="subheader">query</h1>
            <asp:GridView ID="GridView3" runat="server"></asp:GridView>

            <hr />
            <h1 class="subheader">SqlDataSource</h1>
            <%--            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_User" DataSourceID="SqlDataSource1" EmptyDataText="No records Found">
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connString %>" SelectCommand="SELECT * FROM [SCRUD_RegisterUser]"></asp:SqlDataSource>--%>

            <hr />
            <h1 class="subheader">Store</h1>
            <asp:GridView ID="GridView2" runat="server" HeaderStyle-CssClass="panel callout radius"></asp:GridView>
            <hr />
            <h1 class="subheader">Method & SP</h1>
            <asp:GridView ID="GridView4" runat="server" HeaderStyle-CssClass="panel callout radius"></asp:GridView>            
            <hr />
        </div>
    </div>

    <div class="row">
        <div class="large-5 columns">
            <fieldset class="panel callout radius">
                <legend>Search Users</legend>

                    <div class="row collapse">
                        <div class="small-3 large-3 columns">
                            <span class="prefix">ID:</span>
                        </div>
                        <div class="small-9 large-9 columns">
                            <asp:TextBox ID="textSearch" runat="server" placeholder="input ID"/>                          
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
            <hr />
            <fieldset class="panel callout radius">
                <legend>Create Users</legend>
                <div class="row collapse">
                    <div class="small-3 large-3 columns">
                        <span class="prefix">Nombre:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textName" runat="server" placeholder="you name"/>                          
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Apellidos:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textApellidos" runat="server" placeholder="you lastname"/>                          
                    </div>
                    <div class="small-3 large-3 columns">
                        <span class="prefix">Correo:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textEmail" runat="server" placeholder="you email"/>                          
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Compañia:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textCompany" runat="server" placeholder="you company"/>                          
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Fecha:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textDate" runat="server" placeholder="you date"/>                          
                    </div>
                </div>
            </fieldset>
            <br />
            <asp:Button ID="btnCreate" class="small radius button" Text="Guardar" runat="server" OnClick="btnCreate_Click" />
            
            <br />
            <div id="panelMsg" runat="server" >
                <div class="panel callout radius">
                    <asp:Label ID="lblMsg" Text="" runat="server" />
                </div>
            </div>        
            <hr />        

            <fieldset class="panel callout radius">
                <legend>Update Users</legend>
                <div class="row collapse">
                    <div class="small-3 large-3 columns">
                        <span class="prefix">ID:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="testUID" runat="server" placeholder="Input ID to Update"/>                          
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Nombre:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textUName" runat="server" placeholder="you name"/>                          
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Apellidos:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textULastName" runat="server" placeholder="you lastname"/>                          
                    </div>
                    <div class="small-3 large-3 columns">
                        <span class="prefix">Correo:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textUEmail" runat="server" placeholder="you email"/>                          
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Compañia:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textUCompany" runat="server" placeholder="you company"/>                          
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Fecha:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textUDate" runat="server" placeholder="you date"/>                          
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
                            <asp:TextBox ID="textID" runat="server" placeholder="input ID"/>                          
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
