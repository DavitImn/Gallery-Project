using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using Gallery.DependencyInjection;
using Gallery.Domain.Interfaces;

namespace Gallery.Web.Pages.Public
{
    public partial class Register : System.Web.UI.Page
    {
        private IMailSenderService _mailSenderService;

        protected void Page_Load(object sender, EventArgs e)
        {
            _mailSenderService = UnityInjection.GetResolvedObject<IMailSenderService>();
        }

        protected void CreateAccount_Click(object sender, EventArgs e)
        {
            if (!CheckForValues()) return;
            if (!MailAlreadyRegistered()) return;

            SendRegistrationMail();
            Response.Redirect("Login.aspx");

            // www.mysite.com/Activation.aspx?id=65AE313F-7A13-4189-B558-8156EC1F70A5
        }

        private bool CheckForValues()
        {
            bool check = true;
            if (inputFirstName.Text.Length == 0) { check = false; inputFirstName.Text = ""; }
            if (inputLastName.Text.Length == 0) { check = false; inputLastName.Text = ""; }
            if (!IsValidEmail(inputEmail.Text)) { check = false; inputEmail.Text = ""; }
            if (inputPassword.Text.Length == 0 || inputPassword.Text != inputPasswordConfirm.Text)
            {
                inputPassword.Text = "";
                inputPasswordConfirm.Text = "";
                check = false;
            }

            return check;
        }

        private static bool IsValidEmail(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

        private bool MailAlreadyRegistered()
        {
            return false;
            //throw new NotImplementedException();
        }

        private void SendRegistrationMail()
        {
            MailMessage mail = new MailMessage("demsona12@yahoo.com", inputEmail.Text);
            mail.Subject = "Registration on Gallery project";
            mail.Body = "Hello, you have been successfully registerd";

            //_mailSenderService.Send(mail);
        }
    }
}