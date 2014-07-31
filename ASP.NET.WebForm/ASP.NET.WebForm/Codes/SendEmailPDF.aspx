<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendEmailPDF.aspx.cs" Inherits="ASP.NET.WebForm.SendEmailPDF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Send Email with PDF</title>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container well well-sm">
            <table class="table table-striped">
                <tr>
                    <td>Mail To:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" class="form-control" runat="server" Width="200px">  
                        </asp:TextBox></td>
                </tr>
                <tr>
                    <td>Subject:</td>
                    <td>
                        <asp:TextBox ID="txtSubject" class="form-control" runat="server" Width="200px">  
                        </asp:TextBox></td>
                </tr>
                <tr>
                    <td>Message:</td>
                    <td>
                        <asp:TextBox ID="txtmessagebody" class="form-control" runat="server" TextMode="MultiLine" Height="200px" Width="400px">  
                        </asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btn_send" class="btn btn-info" runat="server" Text="Send Mail"
                            OnClick="btn_send_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
