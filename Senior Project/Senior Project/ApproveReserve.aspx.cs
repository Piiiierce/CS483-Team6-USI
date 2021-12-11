using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Senior_Project
{
    public partial class ApproveReserve : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        string name = "";
        int pid = 2;
        int c = 0;
        int s = 1;


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.QueryString["Email"] != null)
            //{
            //    Label3.Text = Session["Reserve"].ToString();
            //    Label4.Text = Request.QueryString["Email"]; 
            //}
            //con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            //con.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM[User] WHERE Email = @Email ", con);
            //cmd.Parameters.Add(new SqlParameter("Email", Label4.Text));
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    Label1.Text = dr["FirstName"].ToString().Trim();
            //    Label2.Text = dr["LastName"].ToString().Trim();
            //    Label5.Text = dr["SubjectID"].ToString().Trim();
            //}
            //con.Close();

            //con.Open();
            //cmd = new SqlCommand("SELECT * FROM Reservation WHERE ReservationId = @ReservationId ", con);
            //cmd.Parameters.Add(new SqlParameter("ReservationId", Label3.Text));
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    pid = Convert.ToInt32(dr["ProjectID"]);
            //}
            //con.Close();

            //con.Open();
            //cmd = new SqlCommand("SELECT * FROM Project WHERE ProjectID = @ProjectID ", con);
            //cmd.Parameters.Add(new SqlParameter("@ProjectID", pid));
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    name = dr["Name"].ToString();
            //}
            //con.Close();

            //con.Open();
            //cmd = new SqlCommand("SELECT COUNT (*) FROM StudentReserve WHERE ReservationID = @ReservationID ", con);
            //cmd.Parameters.Add(new SqlParameter("@ReservationID", Label3.Text));
            //s = Convert.ToInt32(cmd.ExecuteScalar());
            //con.Close();

            //con.Open();
            //cmd = new SqlCommand("SELECT * FROM Reservation WHERE ReservationId = @ReservationId ", con);
            //cmd.Parameters.Add(new SqlParameter("ReservationId", Label3.Text));
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    c = Convert.ToInt32(dr["Occupancy"]);
            //}
            //con.Close();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (c != s)
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO StudentReserve(StudentID, ReservationID, ProjectName) VALUES (@StudentID, @ReservationID, @ProjectName)", con);
                    cmd.Parameters.Add(new SqlParameter("ReservationID", Label3.Text));
                    cmd.Parameters.Add(new SqlParameter("StudentID", Label5.Text));
                    cmd.Parameters.Add(new SqlParameter("ProjectName", name));
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Redirect("~/CalendarStudent.aspx", false);
                    Response.Redirect("~/CalendarStudent.aspx?Email=" + Label4.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You have already signed up for a session with the same name.");
                    Response.Redirect("~/CalendarStudent.aspx", false);
                    Response.Redirect("~/CalendarStudent.aspx?Email=" + Label4.Text);
                }
            }
            else 
            {
                Response.Redirect("~/CalendarStudent.aspx", false);
                Response.Redirect("~/CalendarStudent.aspx?Email=" + Label4.Text);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CalendarStudent.aspx", false);
            Response.Redirect("~/CalendarStudent.aspx?Email=" + Label4.Text);
        }
    }
}