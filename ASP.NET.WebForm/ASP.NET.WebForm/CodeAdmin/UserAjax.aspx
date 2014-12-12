<%@ Page Title="Users Ajax" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="UserAjax.aspx.cs" Inherits="ASP.NET.WebForm.CodeAdmin.UserAjax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/js/datepicker.js"></script>
    <link href="../Content/datepicker.css" rel="stylesheet" />
    <style>
        table {
            border-collapse: collapse;
        }

        table, td, th {
            border: 1px solid black;
        }
    </style>
    <script type="text/javascript">
        $(document).on('ready', function () { 
            var name = $('#<%=textSearch.ClientID%>').val();            

            setTimeout(function(){ 
                $('#divOK').fadeOut('slow') 
            }, 3000);

            //datepicker
            $("#datepicker").datepicker({
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
                    '<%=ddlStatus.ClientID %>': {                   
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
            });// end Validate textBox
            
            //Fill GridView AJAX            
            $.ajax({
                url: "/WSBeginners.asmx/ShowAllRecords",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ "Nombre": name }),
                success: function (data) {                                        
                    var datos = JSON.parse(data.d);    
                    
                    var TableContent = "<table >" +
                              "<tr>" +
                                  "<td><b>ID</b></td>" +
                                  "<td><b>Nombre Name</b></td>" +
                                  "<td><b>Apellidos</b></td>" +
                                  "<td><b>Correo</b></td>" +
                                  "<td><b>Compañia</b></td>" +
                                  "<td><b>Fecha</b></td>" +
                                  "<td><b>Estatus</b></td>" +
                              "</tr>";
                    for (var i = 0; i < datos.length; i++) {                                                
                        TableContent += "<tr>" +
                                                "<td>"+ datos[i].ID_User +"</td>" +
                                                "<td>"+ datos[i].Name+"</td>" +
                                                "<td>"+ datos[i].LastName+"</td>" +
                                                "<td>"+ datos[i].Email+"</td>" +
                                                "<td>"+ datos[i].Company+"</td>" +
                                                "<td>"+ datos[i].Date+"</td>" +
                                                "<td>"+ datos[i].Status+"</td>" +
                                            "</tr>";
                    }
                    TableContent += "</table>";
                    $("#UpdatePanel").html(TableContent);
                
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(thrownError);
                }
            });

            $('#btnSave').click(function () {
                var txtName = $('#<%=textName.ClientID%>').val();
                var txtLastName = $('#<%=textLastName.ClientID%>').val();
                var txtEmail = $('#<%=textEmail.ClientID%>').val();
                var txtCompany = $('#<%=textCompany.ClientID%>').val();
                var txtDate = $('#<%=textDate.ClientID%>').val();
                var ddlStatus = $('#<%=ddlStatus.ClientID%>').val();
                $('#loadingPanel').show();
                
                $.ajax({
                    url: "/WSBeginners.asmx/SaveData",
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({
                        "Name": txtName,
                        "LastName": txtLastName,
                        "Email": txtEmail,
                        "Company": txtCompany,
                        "Date": txtDate,
                        "Status": ddlStatus,
                    }),
                    success: function (data) {
                        if (data.d == "success") {
                            //alert("Data saved successfully");
                            alert(JSON.stringify(data));
                            $('#<%=textName.ClientID%>').val('');
                            $('#<%=textLastName.ClientID%>').val('');
                            $('#<%=textEmail.ClientID%>').val('');
                            $('#<%=textCompany.ClientID%>').val('');
                            $('#<%=textDate.ClientID%>').val('');
                            $('#<%=ddlStatus.ClientID%>').val('');
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert(thrownError);
                    }
                }).done(function () {                    
                    $('#loadingPanel').hide();
                });
            }); //end Click btn Guardar

        });// end DOM
    </script>

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
                <br />
                <div id="UpdatePanel"></div>                     
            </fieldset>            
        </div>

        <div class="large-12 columns"></div>
        <div class="large-5 columns">
            <div id="divOK" >                
                <div runat="server" id="divMsg" data-alert class="alert-box success radius">   
                    <asp:Label ID="lblMsg" Text="" runat="server" />
                    <a href="#" class="close">&times;</a>
                </div>          
            </div>
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
                        <asp:DropDownList ID="ddlStatus" runat="server">
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
        
        <div class="large-5 columns">
            <fieldset class="form panel callout radius">
                <legend>Create User</legend>
                <div class="row collapse">
                    <div class="small-3 large-3 columns">
                        <span class="prefix">Name:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="TextBox1" runat="server" placeholder="you name" />
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">LastName:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="TextBox2" runat="server" placeholder="you lastname" />
                    </div>
                    <div class="small-3 large-3 columns">
                        <span class="prefix">Email:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="TextBox3" runat="server" placeholder="you email" />
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Company:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="TextBox4" runat="server" placeholder="you company" />
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Brithday:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <asp:TextBox ID="TextBox5" runat="server" placeholder="you brithday" />
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Status:</span>
                    </div>
                    <div class="small-9 large-9 columns">                        
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="1">Activo</asp:ListItem>
                            <asp:ListItem Value="0">Inactivo</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <input type="button" value="Guardar" id="btnSave" class="small radius button submit" />                
            </fieldset>
        </div>
        <div class="large-7 columns">
            <br /><br />
            <div class="panel callout radius">                
                <div id="loadingPanel" style="color: green; font-weight: bold; display: none;">Please wait! Data Saving...</div>            
            </div>
        </div>    	
        </div>    
</asp:Content>
