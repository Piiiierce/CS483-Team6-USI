using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Senior_Project
{
    public partial class StudentAccount : System.Web.UI.Page
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
                Label3.Text = dr["ReservationID"].ToString().Trim();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Email = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Email = @Email", con);
            cmd.Parameters.Add(new SqlParameter("Email", TextBox1.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Email = dr["Email"].ToString().Trim();
            }
            con.Close();


            try
            {
                if (Email != TextBox1.Text)
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE [User] SET Email = @Email , Major = @Major , GPA = @GPA , Address = @Address, ZIP = @ZIP, PaymentType = @PaymentType, PaymentInfo = @PaymentInfo  WHERE Email= @Email1", con);
                    cmd.Parameters.Add(new SqlParameter("Email", TextBox1.Text));
                    cmd.Parameters.Add(new SqlParameter("Major", TextBox2.Text));
                    cmd.Parameters.Add(new SqlParameter("GPA", TextBox3.Text));
                    cmd.Parameters.Add(new SqlParameter("Address", TextBox4.Text));
                    cmd.Parameters.Add(new SqlParameter("ZIP", TextBox5.Text));
                    cmd.Parameters.Add(new SqlParameter("PaymentType", TextBox6.Text));
                    cmd.Parameters.Add(new SqlParameter("PaymentInfo", TextBox7.Text));
                    cmd.Parameters.Add(new SqlParameter("Email1", Label4.Text));


                    cmd.ExecuteNonQuery();
                    DataBind();
                    con.Close();

                    Label4.Text = TextBox1.Text;
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox6.Text = "";
                    TextBox7.Text = "";
                    Response.Redirect("~/StudentAccount.aspx", false);
                    Response.Redirect("~/StudentAccount.aspx?Email=" + Label4.Text);
                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string pass = "";

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM[User] WHERE Email = @Email ", con);
            cmd.Parameters.Add(new SqlParameter("Email", Label4.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pass = dr["Password"].ToString().Trim();
            }

            con.Close();
            try
            {
                if (pass == TextBox8.Text)
                {
                    if (TextBox9.Text == TextBox10.Text)
                    {
                        con.Open();
                        cmd = new SqlCommand("UPDATE [User] SET Password = @Password WHERE Email= @Email", con);
                        cmd.Parameters.Add(new SqlParameter("Password", TextBox9.Text));
                        cmd.Parameters.Add(new SqlParameter("Email", Label4.Text));
                        cmd.ExecuteNonQuery();

                        TextBox8.Text = "";
                        TextBox9.Text = "";
                        TextBox10.Text = "";

                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
            }
        }
    }
}