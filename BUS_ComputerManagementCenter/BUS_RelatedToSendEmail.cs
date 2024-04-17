using DAO_ComputerManagementCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BUS_ComputerManagementCenter
{
    public class BUS_RelatedToSendEmail
    {   
        private static BUS_RelatedToSendEmail instance;

        public static BUS_RelatedToSendEmail Instance
        {
            get { if (instance == null) instance = new BUS_RelatedToSendEmail(); return instance; }
            private set { instance = value; }
        }

        // Get body email with information account
        public static string GetBodyEmailWithAccountInformation (string username, string password, string fullName)
        {
            string emailBody = $@"
            Dear {fullName},

            We hope this email finds you well.

            As requested, we are sending you the login credentials for your account. Please find your details below:

            Username: {username}
            Password: {password}

            Please ensure to keep this information secure and do not share it with anyone. If you have any questions or concerns, feel free to reach out to our customer support team.

            Best regards,
            [Gia Bảo]
            ";
            return emailBody;
        }

        public static string CreateStringRadom(int n)
        {
            Random random = new Random();

            // Sequence character are selected
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            // Create radom string with 6 characters
            string randomString = "";
            for (int i = 0; i < n; i++)
            {
                // Get radom a character from characters
                randomString += characters[random.Next(characters.Length)];
            }
            return randomString;
        }

        // Check authentication code exists in data
        private string GetStringAuthenticationCode(string username)
        {
            int flag;
            do
            {
                string codeAuthen = CreateStringRadom(6);
                flag = DAO_RelatedToLogin.Instance.InsertDataIntoAuthenticationTable(codeAuthen, username);
                if (flag != 0)
                {
                    return codeAuthen;
                }
            } while (flag == 0);
            return "";
        }

        // Send email
        public static bool SendEmailToUser(string email, string emailSubject, string emailBody)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("nlgbaosw@gmail.com");
                mail.Subject = emailSubject;
                mail.Body = emailBody;

                SmtpClient smtp = new SmtpClient();
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; // Set the SMTP server accordingly
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("nlgbaosw@gmail.com", "rgnf iqfm eynb auuv"); // Replace with your credentials

                smtp.Send(mail);
                return true;
            }
            catch (SmtpException ex)
            {
                return false;
            }
        }
    }
}
