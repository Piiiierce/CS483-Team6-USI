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
    public partial class ResearcherReservationSchedule : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        string hold = "";

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

            Label3.Text = row.Cells[8].Text;
            Label5.Text = row.Cells[2].Text;
            Label6.Text = row.Cells[3].Text;
            Label7.Text = row.Cells[4].Text;
            Label8.Text = row.Cells[5].Text;
            Label9.Text = row.Cells[6].Text;
            Label10.Text = row.Cells[7].Text;

            bool n = true;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Reservation WHERE StartTime = @StartTime AND EndTime = @EndTime AND Date = @Date AND Occupancy = @Occupancy", con);
            cmd.Parameters.Add(new SqlParameter("Date", Label5.Text));
            cmd.Parameters.Add(new SqlParameter("StartTime", Label6.Text));
            cmd.Parameters.Add(new SqlParameter("EndTime", Label7.Text));
            cmd.Parameters.Add(new SqlParameter("Occupancy", Label3.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                n = Convert.ToBoolean(dr["ManagerApprove"]);
            }
            con.Close();

            Button1.Visible = true;

            if (n == true)
            {
                Button2.Visible = true;
                Button5.Visible = true;
            }
            else
            {
                Button2.Visible = false;
                Button5.Visible = false;
            }

            con.Open();
            cmd = new SqlCommand("SELECT * FROM Reservation WHERE StartTime = @StartTime AND EndTime = @EndTime AND Date = @Date AND Occupancy = @Occupancy", con);
            cmd.Parameters.Add(new SqlParameter("Date", Label5.Text));
            cmd.Parameters.Add(new SqlParameter("StartTime", Label6.Text));
            cmd.Parameters.Add(new SqlParameter("EndTime", Label7.Text));
            cmd.Parameters.Add(new SqlParameter("Occupancy", Label3.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                hold = dr["ReservationId"].ToString();
                TextBox2.Text = hold;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("SELECT COUNT (*) FROM StudentReserve WHERE ReservationID = @ReservationID ", con);
            cmd.Parameters.Add(new SqlParameter("ReservationID", hold));
            TextBox3.Text = cmd.ExecuteScalar().ToString().Trim();
            con.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Reservation WHERE StartTime = @StartTime AND EndTime = @EndTime AND Date = @Date AND Occupancy = @Occupancy", con);
            cmd.Parameters.Add(new SqlParameter("Date", Label5.Text));
            cmd.Parameters.Add(new SqlParameter("StartTime", Label6.Text));
            cmd.Parameters.Add(new SqlParameter("EndTime", Label7.Text));
            cmd.Parameters.Add(new SqlParameter("Occupancy", Label3.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                hold = dr["ReservationId"].ToString();
            }
            con.Close();

                con.Open();
                cmd = new SqlCommand("DELETE FROM Notify WHERE(ReservationID = @ReservationId)", con);
                cmd.Parameters.Add(new SqlParameter("ReservationId", hold));
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("DELETE FROM StudentReserve WHERE(ReservationID = @ReservationID)", con);
                cmd.Parameters.Add(new SqlParameter("ReservationID", hold));
                cmd.ExecuteNonQuery();
                DataBind();
                con.Close();

                con.Open();
                cmd = new SqlCommand("DELETE FROM Reservation WHERE(ReservationId = @ReservationId)", con);
                cmd.Parameters.Add(new SqlParameter("ReservationId", hold));
                cmd.ExecuteNonQuery();
                DataBind();
                con.Close();

                Button1.Visible = false;
                Button2.Visible = false;
                Button3.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ListBox1.Visible = true;
            Button4.Visible = true;
            Button2.Visible = true;
            Button5.Visible = false;

            ListBox1.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * FROM [User]";
            dr = cmd.ExecuteReader();
            if (RadioButton2.Checked == true)
            {
                con.Close();
                con.Open();
                cmd.CommandText = "SELECT * FROM [User] where Gender = 'Male'";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListBox1.Items.Add((string)dr["FirstName"]);
                }
            }
            else if (RadioButton3.Checked == true)
            {
                con.Close();
                con.Open();
                cmd.CommandText = "SELECT * FROM [User] where Gender = 'Female'";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListBox1.Items.Add((string)dr["FirstName"]);
                }
            }
            else if (RadioButton4.Checked == true)
            {
                con.Close();
                con.Open();
                cmd.CommandText = "SELECT * FROM [User] where Gender = 'Other'";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListBox1.Items.Add((string)dr["FirstName"]);
                }
            }
            else
            {
                while (dr.Read())
                {
                    ListBox1.Items.Add((string)dr["FirstName"]);
                }
            }
            con.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Reservation WHERE ReservationId = @ReservationId", con);
            cmd.Parameters.Add(new SqlParameter("ReservationId", TextBox2.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                hold = dr["ReservationId"].ToString();
            }
            con.Close();

                foreach (ListItem email in ListBox1.Items)
            {
                if (email.Selected)
                {
                    MailMessage Msg = new MailMessage();
                    Msg.From = new MailAddress("testingforschoolprogram@gmail.com", "<DoNotReply>Lab");// Sender details here, replace with valid value
                    Msg.Subject = "TEST"; // subject of email
                    Msg.To.Add(email.Value.Trim()); //Add Email id, to which we will send email
                    Msg.Body = "Hello " + email.Text + "\n" + "https://localhost:44387/Login%20Page?ReserveID=" + hold;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.UseDefaultCredentials = false; // to get rid of error "SMTP server requires a secure connection"
                    smtp.Credentials = new System.Net.NetworkCredential("testingforschoolprogram@gmail.com", "Testing!234");// replace with valid value
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    smtp.Send(Msg);
                }
            }

            Button2.Visible = false;
            Button5.Visible = false;
            Button4.Visible = false;
            ListBox1.Visible = false;
            Response.Redirect("~/ResearcherReservationSchedule.aspx", false);
            Response.Redirect("~/ResearcherReservationSchedule.aspx?Email=" + Label4.Text);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
            foreach (ListItem email1 in ListBox2.Items)
            {

                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("testingforschoolprogram@gmail.com", "<DoNotReply>Lab");// Sender details here, replace with valid value
                Msg.Subject = "TEST"; // subject of email
                Msg.To.Add(email1.Value.Trim()); //Add Email id, to which we will send email
                Msg.Body = "Hello " + email1.Text + "\n" + "This is a reminder about the research that you have decided to join";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false; // to get rid of error "SMTP server requires a secure connection"
                smtp.Credentials = new System.Net.NetworkCredential("testingforschoolprogram@gmail.com", "Testing!234");// replace with valid value
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(Msg);


            }
            ListBox2.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            Button5.Visible = false;
            Response.Redirect("~/ResearcherReservationSchedule.aspx", false);
            Response.Redirect("~/ResearcherReservationSchedule.aspx?Email=" + Label4.Text);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Button3.Visible = true;
            ListBox2.Visible = true;
            Button2.Visible = false;
            Button5.Visible = false;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Calendar.aspx", false);
            Response.Redirect("~/Calendar.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearchProjects.aspx", false);
            Response.Redirect("~/ResearchProjects.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearcherReservationSchedule.aspx", false);
            Response.Redirect("~/ResearcherReservationSchedule.aspx?Email=" + Label4.Text);
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearchReservation.aspx", false);
            Response.Redirect("~/ResearchReservation.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearcherAccount.aspx", false);
            Response.Redirect("~/ResearcherAccount.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login Page.aspx");
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}