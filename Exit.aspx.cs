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
using System.Globalization;
using System.Configuration;
//using Twilio.TwiML;
//using Twilio.AspNet.MVC;

namespace Entry_Management_System
{
    public partial class Exit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            chkout_time.Value = "00:00";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
            cn.Open();
            SqlCommand cm = new SqlCommand();
            SqlDataReader dr;
            cm.Connection = cn;
            cm.CommandText = "select convert(nvarchar,CAST(chkin_time as time),108),chkout_time from entry where id=" + meeting_id.Text.ToString();
            dr = cm.ExecuteReader();
            if(!dr.Read())
            {
                Response.Write("<script type='text/javascript'>alert('Enter valid meeting id')</script>");
                dr.Close();
            }
            else
            {
                if (!dr.IsDBNull(1))
                {
                    Response.Write("<script type='text/javascript'>alert('Checkout time for this id has already been entered')</script>");
                    cn.Close();
                    dr.Close();
                }
                else
                {
                    if (chkout_time.Value == null)
                    {
                        Response.Write("<script type='text/javascript'>alert('Check out time must be entered')</script>");
                        dr.Close();
                        cn.Close();
                        return;
                    }
                    DateTime chk_out = Convert.ToDateTime(chkout_time.Value);
                    DateTime now = DateTime.Now;
                    DateTime chk_in=Convert.ToDateTime(dr.GetString(0).Substring(0,5));
                    dr.Close();
                    if (DateTime.Compare(now,chk_out) < 0)
                    {
                        Response.Write("<script type='text/javascript'>alert('Check out time must be lesser or equal to present time')</script>");
                        chkout_time.Value = "00:00";
                    }
                    else
                    {
                        if(DateTime.Compare(chk_out,chk_in)<0)
                            Response.Write("<script type='text/javascript'>alert('Check out time must be after check in time')</script>");
                        else
                        {
                            string str=chk_out.ToString("dd-MM-yyyy HH:mm:ss");
                            StringBuilder sb=new StringBuilder();
                            sb.AppendFormat(str.Substring(6, 4) + "-" + str[3] + str[4] + "-" + str[0] + str[1] + " " + str.Substring(11));
                            cm.CommandText="update entry set chkout_time='"+ sb +"' where id="+meeting_id.Text.ToString();
                            cm.ExecuteNonQuery();
                            cm.CommandText="select * from entry where id="+meeting_id.Text.ToString();
                            dr = cm.ExecuteReader();
                            dr.Read();
                            string message=sendmail(dr.GetString(0),dr.GetString(1),dr.GetString(2),dr.GetString(3),dr.GetString(4),dr.GetString(5),dr.GetDateTime(6),dr.GetDateTime(8));
                            //sendsms(dr.GetString(2),message);
                            cn.Close();
                            dr.Close();
                            Response.Write("<script type='text/javascript'>alert('Check out time entered successfully')</script>");
                            Response.Redirect("Home.aspx");
                        }
                    }
                }
            }
            dr.Close();
            cn.Close();
        }
        public string sendmail(string vis_name,string vis_email,string vis_ph,string host_name,string host_email,string host_ph,DateTime chk_in,DateTime chk_out)
        {
            MailMessage mm = new MailMessage();
            mm.To.Add(vis_email);
            mm.From = new MailAddress(ConfigurationManager.AppSettings["mail_id"]);
            mm.Subject = "Meeting Details";
            string str="Hello "+vis_name+",\nHere are the details of your meeting:\nYour name: "+vis_name+"\nPhone number: "+vis_ph+"\nCheck-in time: "+chk_in+" IST\nCheck-out time: "+chk_out+" IST\nHost name: "+host_name+"\nAddress visited:\nInnovaccer,\nNoida,Uttar Pradesh.";
            mm.Body = str;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Timeout = 10000;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["mail_id"], ConfigurationManager.AppSettings["mail_password"]);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(mm);
            return str;
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
