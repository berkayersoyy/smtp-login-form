using System;
using System.Net;
using System.Net.Mail;

namespace Helpers
{
    public static class Helper
    {
        public static string GenerateOneTimePassword()
        {
            string list = "QWERTYUIOPASDFGHJKLZXCVBNM123456789";
            string oneTimePassword = "";
            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                var index = rand.Next(0, list.Length - 1);
                oneTimePassword = oneTimePassword + list[index];
            }
            return oneTimePassword;
        }

        public static void SendMail(string email,string otp)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("bilgisisguvenligismtp@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Password For Login";
                mail.Body = $"Password is {otp}";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("bilgisisguvenligismtp@gmail.com", "100almayihakettikbence");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
