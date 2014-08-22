<%@ Page Title="Insert Data with Jquery" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="insertDataJquery.aspx.cs" Inherits="ASP.NET.WebForm.CodeAdmin.insertDataJquery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        $(document).on('ready', function () {

            //Validation Email
            function isValidEmailAddress(emailAddress) {
                var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
                return pattern.test(emailAddress);
            };

            $('#btnSave').click(function () {
                var txtName = $('#<%=textName.ClientID%>').val();
                var txtLastName = $('#<%=textLastName.ClientID%>').val();
                var txtEmail = $('#<%=textEmail.ClientID%>').val();
                var txtCompany = $('#<%=textCompany.ClientID%>').val();
                var txtDate = $('#<%=textDate.ClientID%>').val();
                var ddlStatus = $('#<%=ddlStatus.ClientID%>').val();

                if (txtName.trim() == "" ) {
                    alert("El campo [Name] no debe estar vacio.");
                    return false;
                }
                else if(txtLastName.trim() == ""){
                    alert("El campo [LastName] no debe estar vacio.");
                    return false;
                }
                else if (txtEmail.trim() == "") {
                    alert("El campo [Email] no debe estar vacio.");
                    return false;
                }
                else if (!isValidEmailAddress(txtEmail)) {
                    alert("Ingresda un [Email] valido.");
                    return false;
                }
                else if (txtCompany.trim() == "") {
                    alert("El campo [Company] no debe estar vacio.");
                    return false;
                }
                else if (txtDate.trim() == "") {
                    alert("El campo [Date] no debe estar vacio.");
                    return false;
                }
                else if (ddlStatus.trim() == "") {
                    alert("El campo [Status] no debe estar vacio.");
                    return false;
                }

                $('#loadingPanel').show();

                // here call server side function for save data using jquery ajax
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
                    // here hide loading panel as function complete
                    $('#loadingPanel').hide();
                });
            }); //end Click btn Guardar

        }); //end DOM
    </script>
    <div class="row">
        <br /><br />
        <div class="large-12 columns panel radius">
            <h4>Insert Data Into SQL Server Using jQuery (post method) in ASP.Net</h4>
        </div>
        <div class="large-5 columns">
            <%--            <div id="divOK" >                
                <div runat="server" id="divMsg" data-alert class="alert-box success radius">   
                    <asp:Label ID="lblMsg" Text="" runat="server" />
                    <a href="#" class="close">&times;</a>
                </div>          
            </div>--%>
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
