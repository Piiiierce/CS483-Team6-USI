using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

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
            if (Request.QueryString["ReserveID"] != null)
            {
                Label4.Text = Request.QueryString["ReserveID"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string reserve = "";
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Reservation WHERE ReservationId = @ReservationId", con);
                cmd.Parameters.Add(new SqlParameter("ReservationId", Label4.Text));
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    reserve = dr["ReservationId"].ToString();
                }
                con.Close();

                string savedPasswordHash = "";
                con.Open();
                cmd = new SqlCommand("SELECT * FROM [User] WHERE Email = @Email", con);
                cmd.Parameters.Add(new SqlParameter("Email", TextBox1.Text));
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    savedPasswordHash = dr["Password"].ToString();

                    byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                    /* Get the salt */
                    byte[] salt = new byte[16];
                    Array.Copy(hashBytes, 0, salt, 0, 16);
                    /* Compute the hash on the password the user entered */
                    var pbkdf2 = new Rfc2898DeriveBytes(TextBox2.Text, salt, 100000);
                    byte[] hash = pbkdf2.GetBytes(20);
                    /* Compare the results */
                    for (int i = 0; i < 20; i++)
                        if (hashBytes[i + 16] == hash[i])
                        {
                            Label3.Text = "it worked";

                            if (dr["Type"].ToString().Trim() == "Researcher")
                            {
                                Response.Redirect("~/Calendar.aspx", false);
                                Response.Redirect("~/Calendar.aspx?Email=" + TextBox1.Text);

                            }
                            else if (dr["Type"].ToString().Trim() == "Student")
                            {
                                if (Label4.Text == reserve)
                                {
                                    Session["Reserve"] = Label4.Text;
                                    Response.Redirect("~/ApproveReserve.aspx", false);
                                    Response.Redirect("~/ApproveReserve.aspx?Email=" + TextBox1.Text);
                                }
                                else
                                {
                                    Response.Redirect("~/CalendarStudent.aspx", false);
                                    Response.Redirect("~/CalendarStudent.aspx?Email=" + TextBox1.Text);
                                }
                            }
                            else if (dr["Type"].ToString().Trim() == "Admin")
                            {
                                Response.Redirect("~/AdminCalendar.aspx", false);
                                Response.Redirect("~/AdminCalendar.aspx?Email=" + TextBox1.Text);
                            }
                        }
                }
            }

            catch (Exception ex)
            {
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResetPassword.aspx");
        }
    }
}

