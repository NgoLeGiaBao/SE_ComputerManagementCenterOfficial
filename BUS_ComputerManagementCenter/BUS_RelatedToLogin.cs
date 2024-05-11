using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAO_ComputerManagementCenter;
using System.Windows;

namespace BUS_ComputerManagementCenter
{
    public class BUS_RelatedToLogin
    {
            // Singleton design pattern
            private static BUS_RelatedToLogin instance;
            public static BUS_RelatedToLogin Instance
            {
                get { if (instance == null) { instance = new BUS_RelatedToLogin(); } return instance; }
                private set { instance = value; }
            }
            // Initial Constructor
            private BUS_RelatedToLogin() { }


            // Check username and password is valid
            public bool CheckLogin(string username, string password)
            {
                return DAO_RelatedToLogin.Instance.CheckLogin(username, password).Rows.Count > 0 ? true : false;
            }

            // Check username in system to reset password
            public bool CheckUserNameExist(string username)
            {
                return DAO_RelatedToLogin.Instance.CheckExistUserName(username).Rows.Count > 0 ? true : false;
            }
            // Get user's email 
            private string GetUserMail(string username)
            {
                DataTable dataTableInfor = DAO_RelatedToLogin.Instance.GetUserInformation(username);
                if (dataTableInfor.Rows.Count > 0)
                {
                    return dataTableInfor.Rows[0]["DiaChiEmail"].ToString();
                }
                return "";
            }


            // Process forgot password with below funcitons
            // Create string radom with 6 characters
            private string CreateStringRadom()
            {
                Random random = new Random();

                // Sequence character are selected
                string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                // Create radom string with 6 characters
                string randomString = "";
                for (int i = 0; i < 6; i++)
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
                    string codeAuthen = CreateStringRadom();
                    flag = DAO_RelatedToLogin.Instance.InsertDataIntoAuthenticationTable(codeAuthen, username);
                    if (flag != 0)
                    {
                        return codeAuthen;
                    }
                } while (flag == 0);
                return "";
            }
            // Send email to authentication
            public string SendEmailToUser(string username)
            {
            string code = "";
                try
                {   
                    MailMessage mail = new MailMessage();
                    mail.To.Add(GetUserMail(username));
                    mail.From = new MailAddress("nlgbaosw@gmail.com");
                    mail.Subject = "Password reset verification code";
                    code = GetStringAuthenticationCode(username);
                    mail.Body = $"Your verification code is: {code}";
                
                    SmtpClient smtp = new SmtpClient();
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com"; // Set the SMTP server accordingly
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("nlgbaosw@gmail.com", "rgnf iqfm eynb auuv"); // Replace with your credentials

                    smtp.Send(mail);
                    
                }
                catch (SmtpException ex)
                {
             
                }
            return code;
            }
            // Check verify code
            public bool CheckVerifyCode(string verifyCode, string username)
            {
                return DAO_RelatedToLogin.Instance.CheckValidVerifyCode(verifyCode, username).Rows.Count > 0;
                //return "Verify code is not valid or effective, please click resend verify code";
            }
            // Change newpassword for user
            public bool ChangeNewPassword(string username, string newPassword)
            {
                return DAO_RelatedToLogin.Instance.ChangeOrResetNewPassword(username, newPassword) > 0;
            }
        }
}
