<%@ Page Title="DB10Digit" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="DB10Digit.aspx.cs" Inherits="ASP.NET.WebForm.VB.DB10Digit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="small-4 large-4 columns">
            <br />
            <label>
                <b>Ingresa la Referencia:</b>
                <asp:TextBox ID="textDB" runat="server" />
            </label>
            
            <asp:Button ID="btnDB10" class="small radius button" Text="Calcular DV" runat="server" OnClick="btnDB10_Click" />

        </div>
        <div class="small-4 large-4 columns">
            <br /><br />            
            <div runat="server" id="DivDB10">   
                <div data-alert class="alert-box info radius">     
                    <b>DV: </b>
                    <asp:Label ID="lblDB10" Text="" runat="server" />           
                    <a href="#" class="close">&times;</a>
                </div>
            </div>
        </div>
        <div class="small-4 large-4 columns">
        </div>
    </div>
</asp:Content>
