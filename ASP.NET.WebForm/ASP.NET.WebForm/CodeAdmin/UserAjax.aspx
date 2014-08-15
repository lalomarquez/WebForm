<%@ Page Title="Users Ajax" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="UserAjax.aspx.cs" Inherits="ASP.NET.WebForm.CodeAdmin.UserAjax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
    </style>
    <%--<script src="../Scripts/js/datepicker.js"></script>
    <link href="../Content/datepicker.css" rel="stylesheet" />--%>
    <script type="text/javascript">
        $(document).on('ready', function () {
            //datepicker
            $("#datepicker").datepicker({
                dateFormat: "dd.mm.yyyy",
                weekStart: 1
            });
            $("#fa-calendar").datepicker({
                dateFormat: "dd.mm.yyyy",
                weekStart: 1
            });

            //BirthDate
            $( "#<%=textDate.ClientID %>" ).datepicker({                
                dateFormat: "dd.mm.yyyy", //datepicker.js
                changeMonth: true,
                changeYear: true,
                dayNamesMin: [ "Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab" ],
                yearRange: "1985:2020"
            });        
            
            //Validation textBox
            $('#form1').validateWebForm({
                rules: {
                    <%=textSearch.UniqueID %>: {                     
                        required: true                                                
                    },
                    <%=textName.UniqueID %>: {                     
                        required: true                                           
                    },
                    <%=textLastName.UniqueID %>: {                     
                        required: true                                           
                    },
                    <%=textEmail.UniqueID %>: {                     
                        required: true,
                        email: true
                    },
                    <%=textCompany.UniqueID %>: {                     
                        required: true                                           
                    },
                    <%=textDate.UniqueID %>: {                     
                        required: true                                           
                    },
                    <%--<%=DDLStatus.UniqueID %>: {                     
                        selectNone: true
                    }--%>
                    '<%=DDLStatus.ClientID %>': {                   
                selectNone: true
                    }
                    <%--,
                    <%=textStatus.UniqueID %>: {                     
                        required: true,
                        number: true,
                        minlength: 1
                    }--%>
                },
                messages: {
                    <%=textSearch.UniqueID %>: {                  
                        required: "El campo no debe estar vacio."
                    },
                    <%=textName.UniqueID %>: {                  
                        required: "El campo no debe estar vacio."                        
                    },
                    <%=textLastName.UniqueID %>: {                     
                        required: "El campo no debe estar vacio."                        
                    },
                    <%=textEmail.UniqueID %>: {                     
                        required: "El campo no debe estar vacio.",
                        email: "Ingresa un correo valido"
                    },
                    <%=textCompany.UniqueID %>: {                     
                        required: "El campo no debe estar vacio."                        
                    },
                    <%=textDate.UniqueID %>: {                     
                        required: "El campo no debe estar vacio."                        
                    }<%--,
                    <%=DDLStatus.UniqueID %>: {                     
                        required: "El campo no debe estar vacio."                        
                    }--%>
                    <%--,
                    <%=textStatus.UniqueID %>: {
                        required: "El campo no debe estar vacio.",                        
                        number: "Plis bitch, solo numeros.",
                        minlength: "fsdf"
                    }--%>
                }
            });

        });// end DOM
    </script>
<%--    <div class="row">        
            <div class="large-5 columns">
                <p>
                    <input id="datepicker" type="text">
                </p>
              <div class="row collapse">
                <div class="small-9 columns">
                  <input type="text" datepicker data-trigger="#show-datepicker">
                </div>
                <div class="small-3 columns">                    
                  <span class="postfix radius">
                      <i class="fa fa-calendar"></i>		
                  </span>
                </div>
              </div>
            </div>
        </div>    --%>

    <div class="row">        
        <div class="large-5 columns">
            <fieldset class="form panel callout radius">
                <legend>Search Users</legend>
                <div class="row collapse">
                    <div class="small-3 large-3 columns">
                        <span class="prefix">Nombre:</span>
                    </div>
                    <div class="small-9 large-9 columns form-group">
                        <asp:TextBox ID="textSearch" runat="server" placeholder="Ingresa el nombre a buscar" />
                    </div>
                </div>
                <asp:Button ID="btnSearch" class="small radius button submit" Text="Search" runat="server" OnClick="btnSearch_Click" />
            </fieldset>            
        </div>

        <div class="large-7 columns">
            <fieldset class="panel radius">
                <legend>List Users</legend>            
                    <asp:GridView ID="GridviewSearch" runat="server" HeaderStyle-CssClass="panel callout radius"></asp:GridView>            
            </fieldset>            
        </div>

        <div class="large-12 columns"></div>
        <div class="large-5 columns">
            <fieldset class="form panel callout radius">
                <legend>Create User</legend>
                <div class="row collapse">
                    <div class="small-3 large-3 columns">
                        <span class="prefix">Name:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textName" runat="server" placeholder="you name" />
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">LastName:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textLastName" runat="server" placeholder="you lastname" />
                    </div>
                    <div class="small-3 large-3 columns">
                        <span class="prefix">Email:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textEmail" runat="server" placeholder="you email" />
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Company:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textCompany" runat="server" placeholder="you company" />
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Brithday:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="textDate" runat="server" placeholder="you brithday" />
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Status:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <%--<asp:TextBox ID="textStatus" runat="server" placeholder="you status" />--%>
                        <asp:DropDownList ID="DDLStatus" runat="server">
                            <asp:ListItem Value="1">Activo</asp:ListItem>
                            <asp:ListItem Value="0">Inactivo</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <asp:Button ID="btnCreateNew" class="small radius button submit" Text="Save" runat="server" OnClick="btnCreateNew_Click" />
            </fieldset>            
        </div>

        <div class="large-7 columns">
            <fieldset class="panel radius">
                <legend>Read Users</legend>
                <asp:GridView ID="GridViewFourTier" runat="server" HeaderStyle-CssClass="panel callout radius"></asp:GridView>
            </fieldset>
        </div>
        <%--<div class="large-12 columns"></div>--%>

        <div class="large-5 columns">
            <h1>lhsdjkl</h1>
        </div>

        <div class="large-7 columns">
            <h1>451415</h1>
        </div>

    </div>
</asp:Content>
