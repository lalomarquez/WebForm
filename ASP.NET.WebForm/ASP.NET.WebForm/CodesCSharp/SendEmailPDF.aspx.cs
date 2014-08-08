using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

#region libreria necesarias
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Net.Mime;
using iTextSharp.text;
using iTextSharp.text.pdf;  
#endregion

namespace ASP.NET.WebForm
{
    public partial class SendEmailPDF : System.Web.UI.Page
    {
        codeSnippets CS = new codeSnippets();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private MemoryStream PDFGenerate(string message, string ImagePath)
        {
            MemoryStream output = new MemoryStream();

            Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, output);

            pdfDoc.Open();
            Paragraph Text = new Paragraph(message);
            pdfDoc.Add(Text);

            byte[] file;
            file = System.IO.File.ReadAllBytes(ImagePath);

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(file);
            jpg.ScaleToFit(550F, 200F);
            pdfDoc.Add(jpg);

            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            output.Position = 0;

            return output;
        } 
        protected void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.To.Add(txtEmail.Text);// Email-ID of Receiver  
                message.Subject = txtSubject.Text;// Subject of Email  
                message.From = new System.Net.Mail.MailAddress("no-reply@test.com");// Email-ID of Sender  
                message.IsBodyHtml = true;

                MemoryStream file = new MemoryStream(PDFGenerate("Header", Server.MapPath("~/Images/Desert.jpg")).ToArray());

                file.Seek(0, SeekOrigin.Begin);
                Attachment data = new Attachment(file, "Prueba.pdf", "application/pdf");
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.DateTime.Now;
                disposition.ModificationDate = System.DateTime.Now;
                disposition.DispositionType = DispositionTypeNames.Attachment;
                message.Attachments.Add(data);//Attach the file  

                message.Body = txtmessagebody.Text;
                SmtpClient SmtpMail = new SmtpClient();
                SmtpMail.Host = "smtp.gmail.com";//name or IP-Address of Host used for SMTP transactions  
                SmtpMail.Port = 587;//Port for sending the mail  
                SmtpMail.Credentials = new System.Net.NetworkCredential("@gmail.com", "");//username/password of network, if apply  
                SmtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpMail.EnableSsl = true;
                SmtpMail.ServicePoint.MaxIdleTime = 0;
                SmtpMail.ServicePoint.SetTcpKeepAlive(true, 2000, 2000);
                message.BodyEncoding = Encoding.Default;
                message.Priority = MailPriority.High;
                SmtpMail.Send(message); //Smtpclient to send the mail message  
                //Response.Write("Email has been sent");
                MessageBox.Show("Email has been sent");
            }
            catch (Exception ex)
            {              
                MessageBox.Show(Convert.ToString(ex));                                 
            }
            CS.ClearTextBox(Page.Controls);
        }
    }
}