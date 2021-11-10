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
    public partial class ResearchProjects : System.Web.UI.Page
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Calendar.aspx", false);
            Response.Redirect("~/Calendar.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearcherReservationSchedule.aspx", false);
            Response.Redirect("~/ResearcherReservationSchedule.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearchReservation.aspx", false);
            Response.Redirect("~/ResearchReservation.aspx?Email=" + Label4.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CreateProject.aspx", false);
            Response.Redirect("~/CreateProject.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearcherAccount.aspx", false);
            Response.Redirect("~/ResearcherAccount.aspx?Email=" + Label4.Text);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            GridView1.DataBind();
            GridView1.SelectedRow.BackColor = System.Drawing.Color.Gray;

            Label3.Text = row.Cells[1].Text;
            Label5.Text = row.Cells[2].Text;
            Button2.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string hold = "";
            string reserve = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Project WHERE Name = @Name AND Sessions = Sessions", con);
            cmd.Parameters.Add(new SqlParameter("Name", Label3.Text));
            cmd.Parameters.Add(new SqlParameter("Sessions", Label5.Text));
     //       cmd.Parameters.Add(new SqlParameter("RecordLocation", Label6.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                hold = dr["ProjectID"].ToString();
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("SELECT * FROM Reservation WHERE ProjectID = @ProjectID", con);
            cmd.Parameters.Add(new SqlParameter("ProjectID", hold));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                reserve = dr["ReservationId"].ToString();
            }
            con.Close();

            try
            {
                if (reserve == "") 
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM Recruit WHERE(ProjectID = @ProjectID)", con);
                    cmd.Parameters.Add(new SqlParameter("ProjectID", hold));
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    cmd = new SqlCommand("DELETE FROM Project WHERE(ProjectID = @ProjectID)", con);
                    cmd.Parameters.Add(new SqlParameter("ProjectID", hold));
                    cmd.ExecuteNonQuery();
                    DataBind();
                    con.Close();

                    Button2.Visible = false; 
                }
                else
                {
                    MessageBox.Show("An error occured! You probably have a reservation for that project please cancel it and try again.");
                }
            }
            catch
            {

            }
        }
    }
}