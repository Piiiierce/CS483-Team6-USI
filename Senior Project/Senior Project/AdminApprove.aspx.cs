using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Senior_Project
{
    public partial class AdminApprove : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Email"] != null)
            { Label4.Text = Request.QueryString["Email"]; }
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM[User] WHERE Email = @Email ", con);
            cmd.Parameters.Add(new SqlParameter("Email", Label4.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Label1.Text = dr["FirstName"].ToString().Trim();
                Label2.Text = dr["LastName"].ToString().Trim();
            }
            con.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            GridView1.DataBind();
            GridView1.SelectedRow.BackColor = System.Drawing.Color.Gray;

            Button1.Visible = true;
            Button2.Visible = true;



            Label3.Text = row.Cells[5].Text;
            Label5.Text = row.Cells[6].Text;
            Label6.Text = row.Cells[7].Text;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string hold = "";
            string name = "";
            string email = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Reservation WHERE StartTime = @StartTime AND EndTime = @EndTime AND Date = @Date", con);
            cmd.Parameters.Add(new SqlParameter("Date", Label3.Text));
            cmd.Parameters.Add(new SqlParameter("StartTime", Label5.Text));
            cmd.Parameters.Add(new SqlParameter("EndTime", Label6.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                hold = dr["ReservationId"].ToString();
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("UPDATE Reservation SET ManagerApprove = @ManagerApprove, Status = @Status WHERE ReservationId = @ReservationId", con);
            cmd.Parameters.Add(new SqlParameter("ManagerApprove", "1"));
            cmd.Parameters.Add(new SqlParameter("Status", "Approved"));
            cmd.Parameters.Add(new SqlParameter("ReservationId", hold));
            cmd.ExecuteNonQuery();
            DataBind();
            con.Close();

            Button1.Visible = false;
            Button2.Visible = false;

            con.Open();
            cmd = new SqlCommand("SELECT * FROM Notify WHERE ReservationID = @ReservationID", con);
            cmd.Parameters.Add(new SqlParameter("ReservationID", hold));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                name = dr["UserID"].ToString();
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("SELECT * FROM [User] WHERE SubjectID = @SubjectID", con);
            cmd.Parameters.Add(new SqlParameter("SubjectID", name));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                email = dr["Email"].ToString().Trim();
                name = dr["LastName"].ToString().Trim();
            }
            con.Close();

      /*      MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("testingforschoolprogram@gmail.com", "<DoNotReply>Lab");// Sender details here, replace with valid value
            Msg.Subject = "Lab Approval"; // subject of email
            Msg.To.Add(email); //Add Email id, to which we will send email
            Msg.Body = "Hello Professor" + name;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false; // to get rid of error "SMTP server requires a secure connection"
            smtp.Credentials = new System.Net.NetworkCredential("testingforschoolprogram@gmail.com", "Testing!234");// replace with valid value
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.Send(Msg); */
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string hold = "";
            string name = "";
            string email = "";

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Reservation WHERE StartTime = @StartTime AND EndTime = @EndTime AND Date = @Date", con);
            cmd.Parameters.Add(new SqlParameter("Date", Label3.Text));
            cmd.Parameters.Add(new SqlParameter("StartTime", Label5.Text));
            cmd.Parameters.Add(new SqlParameter("EndTime", Label6.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                hold = dr["ReservationId"].ToString();
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("SELECT * FROM Notify WHERE ReservationID = @ReservationID", con);
            cmd.Parameters.Add(new SqlParameter("ReservationID", hold));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                name = dr["UserID"].ToString();
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("SELECT * FROM [User] WHERE SubjectID = @SubjectID", con);
            cmd.Parameters.Add(new SqlParameter("SubjectID", name));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                email = dr["Email"].ToString().Trim();
                name = dr["LastName"].ToString().Trim();
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("DELETE FROM Notify WHERE(ReservationID = @ReservationId)", con);
            cmd.Parameters.Add(new SqlParameter("ReservationId", hold));
            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();
            cmd = new SqlCommand("DELETE FROM Reservation WHERE(ReservationId = @ReservationId)", con);
            cmd.Parameters.Add(new SqlParameter("ReservationId", hold));
            cmd.ExecuteNonQuery();
            DataBind();
            con.Close();


            Button1.Visible = false;
            Button2.Visible = false;

       /*     MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("testingforschoolprogram@gmail.com", "<DoNotReply>Lab");// Sender details here, replace with valid value
            Msg.Subject = "Lab Approval"; // subject of email
            Msg.To.Add(email); //Add Email id, to which we will send email
            Msg.Body = "Hello Professor " + name +",\n"
                + "I am sorry to inform you that your reservation has been denied";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false; // to get rid of error "SMTP server requires a secure connection"
            smtp.Credentials = new System.Net.NetworkCredential("testingforschoolprogram@gmail.com", "Testing!234");// replace with valid value
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.Send(Msg);*/


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminCalendar.aspx", false);
            Response.Redirect("~/AdminCalendar.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminApprove.aspx", false);
            Response.Redirect("~/AdminApprove.aspx?Email=" + Label4.Text);
        }


        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminUserView.aspx", false);
            Response.Redirect("~/AdminUserView.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login Page.aspx");
        }
    }
}