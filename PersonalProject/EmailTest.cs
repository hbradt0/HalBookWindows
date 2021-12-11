using PersonalProject.Framework;
using NUnit.Framework;
using PersonalProject.Pages;
using System;
using System.Diagnostics;
using System.IO;
using EmailReader;

namespace PersonalProject
{
    public class EmailTest: TestFixture
    {
        [Test, Category("Sample Send Message"), Category("Sanity")] //Change creds in credentials.cs
        public void Email() 
        {
            String emailListFile = Credentials.DocumentsFolder+@"HalBookApp\EmailList.txt";
            DirectoryInfo dir = new DirectoryInfo(Credentials.DocumentsFolder + @"HalBookApp");
            String body = "To whom it may concern\n Please check the attachment below!\nThanks, Haley B";
            FileInfo file = null;
            foreach (var f in dir.GetFiles())
            {
                if ((f.FullName.Contains(DateTime.Now.ToString("MMddYYYY")) || f.FullName.Contains(DateTime.Now.ToString("MMddyy"))) && !f.FullName.ToLower().Contains("body"))
                {
                    file = new FileInfo(f.FullName);
                }
                if ((f.FullName.Contains(DateTime.Now.ToString("MMddYYYY")) || f.FullName.Contains(DateTime.Now.ToString("MMddyy"))) && f.FullName.ToLower().Contains("body"))
                {
                    body = File.ReadAllText(f.FullName);
                }
            }

            var email = EmailFileRead.GetEmailsFromFile(emailListFile);
            foreach (var e in email)
            {
                if (file!=null && file.Exists)
                {
                    if (EmailFileRead.ValidateEmail(e))
                        EmailFileRead.EmailTestResultsEmail(e,DateTime.Now.ToString("MMdd")+" Important",body,file.FullName);
                }
                else
                {
                    Console.WriteLine("Didn't send anything");
                    File.WriteAllText(file.FullName,"You didn't send anything today!");
                }
            }
        }


    }
}