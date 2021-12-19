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
                    File.WriteAllText(dir+"Error_"+ DateTime.Now.ToString("MMddYYYY"), "You didn't send anything today!");
                }
            }
        }

        [Test, Category("Sample Send Message"), Category("Sanity")] 
        public void Text()
        {
            String textListFile = Credentials.DocumentsFolder + @"HalBookApp\TextList.txt";
            DirectoryInfo dir = new DirectoryInfo(Credentials.DocumentsFolder + @"HalBookApp");
            String body = "To whom it may concern\n Please check the attachment below!\nThanks, Haley B";
            FileInfo file = null;
            bool bodyExists = false;

            foreach (var f in dir.GetFiles())
            {
                if ((f.FullName.Contains(DateTime.Now.ToString("MMddYYYY")) || f.FullName.Contains(DateTime.Now.ToString("MMddyy"))) && !f.FullName.ToLower().Contains("body"))
                {
                    file = new FileInfo(f.FullName);
                }
                if ((f.FullName.Contains(DateTime.Now.ToString("MMddYYYY")) || f.FullName.Contains(DateTime.Now.ToString("MMddyy"))) && f.FullName.ToLower().Contains("body"))
                {
                    body = File.ReadAllText(f.FullName);
                    bodyExists = true;
                }
            }

            FileInfo file2 = null;
            foreach (var f in dir.GetFiles())
            {
                if ((f.FullName.Contains(DateTime.Now.ToString("MMddYYYY")) || f.FullName.Contains(DateTime.Now.ToString("MMddyy"))) && !f.FullName.ToLower().Contains("body"))
                {
                    file2 = new FileInfo(f.FullName);
                }
            }

            var text = EmailFileRead.GetTextsFromFile(textListFile);
            foreach (var e in text)
            {
                if (file != null && file.Exists)
                {
                    if (EmailFileRead.ValidateText(e))
                        EmailFileRead.SendText(e, DateTime.Now.ToString("MMdd") + " Important", body, file.FullName);
                }
                else if(file == null && bodyExists)
                {
                    if (EmailFileRead.ValidateText(e))
                    {
                        if (file2 != null && file2.Exists)
                            EmailFileRead.SendText(e, DateTime.Now.ToString("MMdd") + " Important", body, file2.FullName);
                        else
                            EmailFileRead.SendText(e, DateTime.Now.ToString("MMdd") + " Important", body, "");
                    }
                }
                else
                {
                    Console.WriteLine("Didn't send anything");
                    File.WriteAllText(dir + "Error_" + DateTime.Now.ToString("MMddYYYY"), "You didn't send anything today!");
                }
            }
        }


    }
}