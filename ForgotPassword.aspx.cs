using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            Server.Transfer("ShopBook.aspx");
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        List<User> users = (List<User>)Application["users"];
        foreach (User u in users)
        {
            if (tbxEmail.Text == u.Email)
            {
                Session["rPass"] = u;
                int num = new Random().Next(9999999, 999999999);
                string nPass = num.ToString();
                //update password in Db
                u.Password = nPass;


                //i am using mailkit instaed of SmtpClient because it is officially replaced in place of smtpClient by microsoft
                string EmailMsg = "Hello " + u.Username + "  Your Password Has Changed Sucessfully. Since this is the auto Generated Password We Recommand U to Change a new password After u Log In.  Your New Generated Password Is  " + nPass;
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Book Sore", "noreply.BookStore@mail.com"));
                message.To.Add(new MailboxAddress(u.Username, u.Email));
                message.Subject = "Password Resetted";
                message.Body = new TextPart("plain")
                {
                    Text = EmailMsg
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);//smtp connect
                    client.Authenticate("kyawfamily10100@gmail.com", "Kk63996399");//email login
                    client.Send(message);
                    client.Disconnect(true);
                    Response.Write("<script>alert('Passsword Sucessfully Resetted. Please Check Your Mail!');</script>");
                    Server.Transfer("LoginForm.aspx");
                }


            }
            pnlLoginError.Visible = true;
            lblOutput.Text = "invalid Email!";
        }

    }
}