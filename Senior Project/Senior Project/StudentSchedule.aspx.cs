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
    }
}