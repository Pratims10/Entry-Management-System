using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Data;
using System.Text;
using System.IO.Ports;
using System.Configuration;
//using Twilio.TwiML;
//using Twilio.AspNet.MVC;

namespace Entry_Management_System
{
    public partial class Entry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void entry_submit_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
            cn.Open();
            SqlCommand cmd=new SqlCommand();
            cmd.Connection=cn;
            StringBuilder sb=new StringBuilder();
            sb.AppendFormat(@"insert into entry(vis_name,vis_email,vis_ph,host_name,host_email,host_ph,chkin_time) values('{0}','{1}','{2}','{3}','{4}','{5}',getdate())",vis_name.Text,vis_email.Text,vis_phno.Text,host_name.Text,host_email.Text,host_phno.Text);
            cmd.CommandText = sb.ToString();
            cmd.ExecuteNonQuery();
            string message = "Hello " + host_name.Text.ToString() + ",\n" + "You have an appointment. The details are:\n\nVisitor Name: " + vis_name.Text.ToString() + "\nVisitor email address: " + vis_email.Text.ToString() + "\nVisitor phone number: " + vis_phno.Text.ToString() + "\nCheck in time: " + System.DateTime.Now.ToString();
            sendmail(host_email.Text.ToString(),"Visitor Details",message);
            cmd.CommandText = "select max(id) from entry";
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            int id = 1;
            if(dr.Read())
            {
                if (!dr.IsDBNull(0))
                    id = dr.GetInt32(0);
            }
            sendmail(vis_email.Text.ToString(),"Meeting/Appointment ID","Hello,"+vis_name.Text.ToString()+",\nYour meeting/appointment id is "+ id  +".Use this id to enter the check-out time while leaving the premises.");
            //sendsms(to, message);
            dr.Close();
            cn.Close();
            Response.Redirect("Home.aspx");
        }
        public void sendmail(string to,string subject,string message)
        {
            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.From = new MailAddress(ConfigurationManager.AppSettings["mail_id"]);
            mm.Subject = subject;
            mm.Body = message;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Timeout = 10000;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["mail_id"], ConfigurationManager.AppSettings["mail_password"]);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(mm);
        }
        /*public void sendsms(string to,string message)
        {
            //get the accountSid and authToken after registering your Twilio account
            var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            TwilioClient.Init(accountSid, authToken);
            var from = ConfigurationManager.AppSettings["TwilioPhoneNumber"];
            var message = MessageResource.Create(
            to: to,
            from: from,
            body: message);
            return Content(message.Sid);
        }*/
    }
}
