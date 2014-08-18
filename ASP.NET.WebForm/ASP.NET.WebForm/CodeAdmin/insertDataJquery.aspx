<%@ Page Title="Insert Data with Jquery" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="insertDataJquery.aspx.cs" Inherits="ASP.NET.WebForm.CodeAdmin.insertDataJquery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(document).ready(function () {
            $('#btnSave').click(function () {

                var contactName = $('#<%=txtContactName.ClientID%>').val();
                var contactNo = $('#<%=txtContactNo.ClientID%>').val();

                if (contactName.trim() == "" || contactNo.trim() == "") {
                    alert("All the fields are required!");
                    return false;
                }

                $('#loadingPanel').show();

                // here call server side function for save data using jquery ajax
                $.ajax({
                    url: "insertDataJquery.aspx/SaveData",
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({
                        "contactName": contactName,
                        "contactNo": contactNo
                    }),
                    success: function (data) {
                        if (data.d == "success") {
                            alert("Data saved successfully");
                            // clear text here after save complete
                            $('#<%=txtContactName.ClientID%>').val('');
                            $('#<%=txtContactNo.ClientID%>').val('');
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert(thrownError);
                    }
                }).done(function () {
                    // here hide loading panel as function complete
                    $('#loadingPanel').hide();
                });
            });
        });
    </script>
    <div class="row">
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
            <h3>Insert Data Into SQL Server Using jQuery (post method) in ASP.Net</h3>
            <div>
                <table>
                    <tr>
                        <td>Contact Name : </td>
                        <td>
                            <asp:TextBox ID="txtContactName" runat="server" Width="200px" /></td>
                    </tr>
                    <tr>
                        <td>Contact No: </td>
                        <td>
                            <asp:TextBox ID="txtContactNo" runat="server" Width="200px" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <input type="button" value="Submit" id="btnSave" />
                            <div id="loadingPanel" style="color: green; font-weight: bold; display: none;">Please wait! Data Saving...</div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
