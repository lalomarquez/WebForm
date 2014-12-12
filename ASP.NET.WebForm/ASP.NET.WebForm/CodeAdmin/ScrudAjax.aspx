<%@ Page Title="Scrud Ajax" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="ScrudAjax.aspx.cs" Inherits="ASP.NET.WebForm.CodeAdmin.ScrudAjax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/js/datepicker.js"></script>
    <link href="../Content/datepicker.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).on('ready', function () {            
            function clearText() {
                <%--$('#<%=ddlStatus.ClientID%>').val('');--%>
                $('#Nombre').val('');
                $('#LastName').val('');
                $('#Email').val('');
                $('#Empresa').val('');
                $('#FechaNac').val('');
            }
            //BirthDate
            $("#FechaNac").datepicker({
                dateFormat: "dd.mm.yyyy"//datepicker.js
            });

            $('#divOK').hide();            

            $('#btnSave').click(function () {
                var ddlStatus = $('#<%=ddlStatus.ClientID%>').val();            
                var parameter = {
                    "Name": $('#Nombre').val(),
                    "LastName": $('#LastName').val(),
                    "Email": $('#Email').val(),
                    "Company": $('#Empresa').val(),
                    "Date": $('#FechaNac').val(),
                    "Status": ddlStatus
                }

                $.ajax({
                    url: "/WSBeginners.asmx/SaveData",
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(parameter),
                    success: function (data) {                        
                        if (data.d == "success") {                                                                                                        
                            clearText();
                            $('#divOK').show();                                                        
                        }
                    },
                    error: function (data, success, error) {
                        alert("Error: " + error);
                    }
                }).done(function () {                
                    $('#lblmsg').html('<b>Data Inserted Successfully</b>');
                    setTimeout(function () {
                        $('#divOK').fadeOut('slow')
                    }, 3000);
                });
            }); //end Click btn Guardar

        }); //end DOM
    </script>    

    <div class="row">
        <div class="large-12 columns ">            
            <br />            
            <h3>CREATE <small>new User.</small></h3>
            <hr />
        </div>

        <div class="large-5 columns">
            <fieldset class="form panel callout radius">
                <legend>Create</legend>
                <div class="row collapse">
                    <div class="small-3 large-3 columns">
                        <span class="prefix">Name:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <input type="text" id="Nombre" placeholder="Nombre completo"/>
                        <%--<asp:TextBox ID="textName" runat="server" placeholder="you name" />--%>
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">LastName:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <input type="text" id="LastName" placeholder="Apellidos"/>
                        <%--<asp:TextBox ID="textLastName" runat="server" placeholder="you lastname" />--%>
                    </div>
                    <div class="small-3 large-3 columns">
                        <span class="prefix">Email:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <input type="text" id="Email" placeholder="Correo electronico"/>
                        <%--<asp:TextBox ID="textEmail" runat="server" placeholder="you email" />--%>
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Company:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <input type="text" id="Empresa" placeholder="Empresa"/>
                        <%--<asp:TextBox ID="textCompany" runat="server" placeholder="you company" />--%>
                    </div>

                    <div class="small-3 large-3 columns">
                        <span class="prefix">Brithday:</span>
                    </div>
                    <div class="small-9 large-9 columns">
                        <input type="text" id="FechaNac" placeholder="Fecha de nacimieno"/>
                        <%--<asp:TextBox ID="textDate" runat="server" placeholder="you brithday" />--%>
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
                <input type="button" value="Guardar" id="btnSave" class="small radius button submit" />                
            </fieldset>
        </div>
        <div class="large-7 columns">
            <br /><br />
            <div ID="divOK" class="panel callout radius">                
                <label id="lblmsg" style="color:green" />
            </div>
        </div>
    
        <div class="large-5 columns">

        </div>
        <div class="large-7 columns">

        </div>
    </div>

</asp:Content>
