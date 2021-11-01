using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Senior_Project
{
    public partial class Login_Page : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM[User] WHERE Email = @Email and Password = @Password", con);
                cmd.Parameters.Add(new SqlParameter("Email", TextBox1.Text));
                cmd.Parameters.Add(new SqlParameter("Password", TextBox2.Text));
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["Type"].ToString().Trim() == "Researcher")
                    {
                        Response.Redirect("~/Calendar.aspx", false);
                        Response.Redirect("~/Calendar.aspx?Email=" + TextBox1.Text);

                    }
                    else if (dr["Type"].ToString().Trim() == "Student")
                    {
                        Response.Redirect("~/CalendarStudent.aspx", false);
                        Response.Redirect("~/CalendarStudent.aspx?Email=" + TextBox1.Text);
                    }
                    else if (dr["Type"].ToString().Trim() == "Admin")
                    {
                        Response.Redirect("~/AdminCalendar.aspx", false);
                        Response.Redirect("~/AdminCalendar.aspx?Email=" + TextBox1.Text);
                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Incorrect Login. Please try again.');</script>");
                        //Thread.Sleep(2000);
                        //Response.Redirect("~/Login%20Page.aspx");
                    }
                }
            }

            catch (Exception ex)
            {
            }
        }
    }
}

