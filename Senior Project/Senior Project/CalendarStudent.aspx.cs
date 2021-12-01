using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Senior_Project
{
    public partial class CalendarStudent : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.DataBind();
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


        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            int hold = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentReserve WHERE StudentID = @StudentID", con);
            cmd.Parameters.Add(new SqlParameter("StudentID", Label3.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                hold = Convert.ToInt32(dr["ReservationID"]);
            }
            con.Close();

            con.Open();
            string sql = "SELECT Date FROM Reservation WHERE ReservationId = '" + hold + "'";
            cmd = new SqlCommand(sql, con);
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

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentSchedule.aspx", false);
            Response.Redirect("~/StudentSchedule.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CalendarStudent.aspx", false);
            Response.Redirect("~/CalendarStudent.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAccount.aspx", false);
            Response.Redirect("~/StudentAccount.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login Page.aspx");
        }
    }
}