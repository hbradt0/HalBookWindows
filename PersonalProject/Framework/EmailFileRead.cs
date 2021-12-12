using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmailReader //rename
{
    public class EmailFileRead
    {
        public EmailFileRead()
        {

        }

        public static List<String> Carriers
        {
            get
            {
                List<String> carrier = new List<String>();
                carrier.Add("@txt.att.net");
                carrier.Add("@vtext.com");
                carrier.Add("@messaging.sprintpcs.com");
                carrier.Add("@tmomail.net");
                carrier.Add("@vmobl.com");
                carrier.Add("@messaging.nextel.com");
                carrier.Add("@myboostmobile.com");
                carrier.Add("@message.alltel.com");
                carrier.Add("@mms.ee.co.uk");
                return carrier;
            }
        }           

        public static String ReadText(String fileName = "")
        {
            return File.ReadAllText(fileName);
        }

        public static String[] GetEmailsFromFile(String fileName = "")
        {
            var emaillist = File.ReadAllText(fileName);
            emaillist = emaillist.Replace("\n", "");
            emaillist = emaillist.Replace(" ", "");
            return emaillist.Split(',');
        }

        public static bool ValidateEmail(String email = "")
        {
            return email.Contains("@") && email.Contains(".") && email!="";
        }

        public static String[] GetTextsFromFile(String fileName = "")
        {
            var textList = File.ReadAllText(fileName);
            textList = textList.Replace("\n", "");
            textList = textList.Replace(" ", "");
            return textList.Split(',');
        }

        public static bool ValidateText(String text = "")
        {
            long i;
            bool result = long.TryParse(text, out i);
            return result && text != "";
        }

        public static void EmailTestResultsEmail(String email, String file = "")
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(Credentials.emailFrom);

                mail.To.Add(email);
                mail.Subject = "Your story creative...";
                mail.Body = "Here is your story booklet! Emailed to you at " + DateTime.Now.ToString();

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(file);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Credentials.SMTPEmail, Credentials.SMTPPassword);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                //MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static bool SendText(String text, String subject, String body, String file = "")
        {
            foreach (var v in Carriers)
            {
                try
                {
                    var message = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    message.From = new MailAddress(Credentials.SMTPEmail);
                    var textAddress = text + v;

                    message.To.Add(new MailAddress(text + v));
                    message.Subject = subject;
                    message.Body = body;
                    if (file != "")
                    {
                        Attachment a = new Attachment(file);
                        message.Attachments.Add(a);
                    }

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(Credentials.SMTPEmail, Credentials.SMTPPassword);
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(message);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return true;
        }

        public static void EmailTestResultsEmail(String email, String subject, String body, String file = "")
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(Credentials.emailFrom);

                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(file);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Credentials.SMTPEmail, Credentials.SMTPPassword);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                //MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
