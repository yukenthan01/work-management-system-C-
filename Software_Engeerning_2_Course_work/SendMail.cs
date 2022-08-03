using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Engeerning_2_Course_work
{
    class SendMail
    {
        string id,tittle,description,startDate,status;

        public SendMail(string id, string tittle, string description, string startDate, string status)
        {
            this.id = id;
            this.tittle = tittle;
            this.description = description;
            this.startDate = startDate;
            this.status = status;
        }

        public void mailGenerate(string email, string subject)
        {
            string body = "<table style='border - collapse: collapse; width: 100 %; ' border='1'><tbody><tr><td style='width: 50 %; '>ID</td><td style='width: 50 %; '>" + id + "</td></tr><tr><td style='width: 50 %; '>Tittle</td><td style='width: 50 %;'>" + tittle + "</td></tr><tr><td style='width: 50 %; '>Start Date</td><td style='width: 50 %; '>" + startDate + "</td></tr><tr><td style='width: 50 %; '>Status</td><td style='width: 50 %; '>" + status + "</td></tr></tbody></table>";

                try
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("mathu1152@gmail.com");
                        mail.To.Add(email);
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential("yukenthanportuno@gmail.com", "hjgzfjcruyihxrpx");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        
    }
}
