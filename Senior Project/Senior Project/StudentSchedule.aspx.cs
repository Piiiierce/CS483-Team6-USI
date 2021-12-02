using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Senior_Project
{
    public partial class StudentSchedule : System.Web.UI.Page
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            GridView1.DataBind();
            GridView1.SelectedRow.BackColor = System.Drawing.Color.Gray;

            Label5.Text = row.Cells[3].Text;
            Label6.Text = row.Cells[4].Text;
            Label7.Text = row.Cells[5].Text;

            string status = "";

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Reservation WHERE StartTime = @StartTime AND EndTime = @EndTime AND Date = @Date", con);
            cmd.Parameters.Add(new SqlParameter("Date", Label5.Text));
            cmd.Parameters.Add(new SqlParameter("StartTime", Label6.Text));
            cmd.Parameters.Add(new SqlParameter("EndTime", Label7.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                status = dr["Status"].ToString().Trim();
            }
            con.Close();

            Label1.Text = status;

            if (status.ToLower() != "finished")
            {
                Button1.Visible = true;
            }
            else
            {

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string hold = "";
            int sid = 1;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Reservation WHERE StartTime = @StartTime AND EndTime = @EndTime AND Date = @Date", con);
            cmd.Parameters.Add(new SqlParameter("Date", Label5.Text));
            cmd.Parameters.Add(new SqlParameter("StartTime", Label6.Text));
            cmd.Parameters.Add(new SqlParameter("EndTime", Label7.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                hold = dr["ReservationId"].ToString().Trim();
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("SELECT * FROM [User] WHERE Email = @Email", con);
            cmd.Parameters.Add(new SqlParameter("Email", Label4.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sid = Convert.ToInt32(dr["SubjectID"]);
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("DELETE FROM StudentReserve WHERE(ReservationID = @ReservationId AND StudentID = @StudentID)", con);
            cmd.Parameters.Add(new SqlParameter("ReservationId", hold));
            cmd.Parameters.Add(new SqlParameter("StudentID", sid));
            cmd.ExecuteNonQuery();
            DataBind();
            con.Close();

            Button1.Visible = false;
        }
    }
}