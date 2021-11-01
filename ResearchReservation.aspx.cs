using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Senior_Project
{
    public partial class ResearchReservation : System.Web.UI.Page
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
                Label3.Text = dr["SubjectID"].ToString().Trim();
            }
            con.Close();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Calendar.aspx", false);
            Response.Redirect("~/Calendar.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearchProjects.aspx", false);
            Response.Redirect("~/ResearchProjects.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearcherReservationSchedule.aspx", false);
            Response.Redirect("~/ResearcherReservationSchedule.aspx?Email=" + Label4.Text);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Date FROM Reservation WHERE ManagerApprove = 1";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["Date"].ToString() == e.Day.Date.ToString() && !e.Day.IsOtherMonth)
                    {
                        e.Cell.BackColor = System.Drawing.Color.Red;
                    }

                    if (e.Day.IsOtherMonth)
                    {
                        e.Day.IsSelectable = false;
                    }

                }
                con.Close();
            }
            catch
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";

                Response.Redirect("~/ResearchReservation.aspx", false);
                Response.Redirect("~/ResearchReservation.aspx?Email=" + Label4.Text);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int c = 0;
            int d = 0;
            string holder = Label3.Text;
            con.Open();
            cmd = new SqlCommand("SELECT Project.ProjectID FROM [User], Project WHERE [User].Email= @Email AND Project.Name = @Name", con);
            cmd.Parameters.Add(new SqlParameter("Name", DropDownList1.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("Email", Label4.Text));

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                d = Convert.ToInt32(dr["ProjectID"]);
            }
            con.Close();

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ReservationId FROM Reservation ORDER BY ReservationId ASC";

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                c = Convert.ToInt32(dr["ReservationId"]);
            }
            con.Close();
            c++;

            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO Reservation (ReservationId, StartTime, EndTime, Status, isRecruit, isEmail, ProjectID, ManagerApprove, Date, Occupancy) VALUES (@ReservationId, @StartTime, @EndTime, @Status, @isRecruit, @isEmail, @ProjectID, @ManagerApprove, @Date, @Occupancy)", con);
                cmd.Parameters.Add(new SqlParameter("ReservationId", c.ToString()));
                cmd.Parameters.Add(new SqlParameter("StartTime", TextBox2.Text));
                cmd.Parameters.Add(new SqlParameter("EndTime", TextBox3.Text));
                cmd.Parameters.Add(new SqlParameter("ProjectID", d.ToString()));
                cmd.Parameters.Add(new SqlParameter("Date", TextBox1.Text));
                cmd.Parameters.Add(new SqlParameter("Occupancy", TextBox4.Text));
                cmd.Parameters.Add(new SqlParameter("Status", "Pending"));
                cmd.Parameters.Add(new SqlParameter("isEmail", "False"));
                cmd.Parameters.Add(new SqlParameter("isRecruit", "False"));
                cmd.Parameters.Add(new SqlParameter("ManagerApprove", "0"));
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("INSERT INTO Notify (ReservationID, UserID) VALUES(@ReservationID, @UserID)", con);
                cmd.Parameters.Add(new SqlParameter("ReservationID", c.ToString()));
                cmd.Parameters.Add(new SqlParameter("UserID", holder));
                cmd.ExecuteNonQuery();
                con.Close();
            


                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";

                Response.Redirect("~/ResearchReservation.aspx", false);
                Response.Redirect("~/ResearchReservation.aspx?Email=" + Label4.Text);
            }
            catch (Exception ex)
            {
            }

        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearcherAccount.aspx", false);
            Response.Redirect("~/ResearcherAccount.aspx?Email=" + Label4.Text);
        }
    }
}