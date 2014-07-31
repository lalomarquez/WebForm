<%@ Page Title="Home" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ASP.NET.WebForm.DePrueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#datepicker").datepicker();
        });
    </script>

    <div class="row">
        <div class="large-12 columns">
            <h1>Hello <small>world</small></h1>
            <h5 class="subheader">
                <b>Lorem Ipsum</b>
                es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500.
            </h5>

            <hr />
            <a href="#" class="small button">Simple Button</a><br />
            <a href="#" class="small radius button">Radius Button</a><br />
            <a href="#" class="small round button">Round Button</a><br />
            <a href="#" class="medium success button">Success Btn</a><br />
            <a href="#" class="medium alert button">Alert Btn</a><br />
            <a href="#" class="medium secondary button">Secondary Btn</a>

            <div class="row">
                <div class="large-4 columns">
                    <label>
                        <b>Fecha:</b>
                        <input id="datepicker" type="text" placeholder="input date" />
                    </label>

                </div>
            </div>

        </div>
    </div>
</asp:Content>
