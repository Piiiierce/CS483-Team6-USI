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
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM [User] WHERE Email='" + TextBox1.Text + "'and Password= '" + TextBox2.Text + "'";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["Type"].ToString().Trim() == "Researcher")
                    {
                        Response.Redirect("~/Calendar.aspx");
                    }
                    else if (dr["Type"].ToString().Trim() == "Student")
                    {
                        Response.Redirect("~/CalendarStudent.aspx", false);
                        Response.Redirect("~/CalendarStudent.aspx?Email=" + TextBox1.Text);
                    }
                    else if (dr["Type"].ToString().Trim() == "Admin")
                    {
                        //Response.Redirect("~/CalendarStudent.aspx");
                        Label3.Text = "Admin";
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

