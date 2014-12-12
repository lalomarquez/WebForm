<%@ Page Title="Save Image" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="SaveImage.aspx.cs" Inherits="ASP.NET.WebForm.CodesCSharp.SaveImage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <hr />
        <div class="large-12 columns">            
            <fieldset class="panel callout radius">
                <legend>Guardar una Imagen a la BD</legend>
                <asp:FileUpload ID="FileUpload1" runat="server" /><br />
                <asp:Button ID="Button1" class="small radius button submit" runat="server" Text="Guardar" OnClick="Button1_Click" />
            </fieldset>
        </div>
        <hr />
    </div>
</asp:Content>
