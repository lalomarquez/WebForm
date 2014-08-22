<%@ Page Title="Serialización" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Serializacion.aspx.cs" Inherits="ASP.NET.WebForm.CodesCSharp.Serializacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/js/datepicker.js"></script>
    <link href="../Content/datepicker.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).on('ready', function () {            
            setTimeout(function(){ 
                $('#divOK').fadeOut('slow') 
            }, 3000);


            //BirthDate plugin datepicker.js
            $( "#<%=textDate.ClientID %>" ).datepicker({                
                autoClose: true,
                dateFormat: "dd.mm.yyyy",
                //, //datepicker.js
                //changeMonth: true,
                //changeYear: true,
                //dayNamesMin: [ "Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab" ],
                //yearRange: "1985:2020"
            });
            
            //Validation textBox
            $('#form1').validateWebForm({
                rules: {
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

        });// end DOM
    </script>
    <div class="row">
        <br />
        <br />
        <div class="large-12 columns panel radius">
            <h4>Serialización/Deserialización Binay, Soap, XML & JSON</h4>
        </div>
        <div class="large-5 columns">
<%--            <div id="divOK">
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
                <asp:Button ID="btnSerializacion" Text="Serializar" runat="server" class="small radius button submit" OnClick="btnSerializacion_Click" />                
            </fieldset>
        </div>
        <div class="large-7 columns">
            <br />
            <br />            
            <div class="panel callout radius">
                <asp:Label ID="lblDesBinary" Text="" runat="server" /><br />
                <asp:Label ID="lblDesSoap" Text="" runat="server" /><br />
                <asp:Label ID="lblDesXML" Text="" runat="server" /><br />
                <asp:Label ID="lblDesJSON" Text="" runat="server" /><br />
                <asp:Label ID="lblDesJsoNet" Text="" runat="server" /><br />
                <asp:Button ID="btnDeserializacion" Text="Deserialización Binaria" runat="server" class="small radius button submit" OnClick="btnDeserializacion_Click"/>                
            </div>
        </div>        
    </div>
</asp:Content>
