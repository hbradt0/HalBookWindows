using PersonalProject.Framework;
using NUnit.Framework;
using PersonalProject.Pages;
using System;
using System.Diagnostics;
using System.IO;

namespace PersonalProject
{
    public class EmailTest: TestFixture
    {

        [Test, Category("Sample Send Message")]
        public void Email() 
        {
            var homePath = Environment.GetEnvironmentVariable("HOMEPATH");
            String emailListFile = @"C:\"+homePath+@"\Documents\HalEmailList.txt";
            FileInfo file = new FileInfo(@"C:\" + homePath + @"\Documents\XXX" + DateTime.Now.ToString("MMddYYYY")+".txt");

            var email = EmailReader.EmailFileRead.GetEmailsFromFile(emailListFile);
            String text = EmailReader.EmailFileRead.ReadText(file.FullName);
            foreach (var e in email)
            {
                if (file.Exists)
                {
                    if (EmailReader.EmailFileRead.ValidateEmail(e))
                        EmailReader.EmailFileRead.EmailTestResultsEmail(e,"EmailMePlease",text,file.FullName);
                }
            }
        }


    }
}