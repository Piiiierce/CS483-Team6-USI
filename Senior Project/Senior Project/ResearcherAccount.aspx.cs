using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Senior_Project
{
    public partial class ResearcherAccount : System.Web.UI.Page
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
            }
            con.Close();
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
                    Session["Email"] = TextBox1.Text;

                    MailMessage Msg = new MailMessage();
                    Msg.From = new MailAddress("testingforschoolprogram@gmail.com", "<DoNotReply>Lab");// Sender details here, replace with valid value
                    Msg.Subject = "TEST"; // subject of email
                    Msg.To.Add(TextBox1.Text); //Add Email id, to which we will send email
                    Msg.Body = "Hello " + Label1.Text + "\n" + "Please click on the link below to confirm the change in your email" + "\n" + "https://localhost:44387/EmailChange?Email=" + Label4.Text;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.UseDefaultCredentials = false; // to get rid of error "SMTP server requires a secure connection"
                    smtp.Credentials = new System.Net.NetworkCredential("testingforschoolprogram@gmail.com", "Testing!234");// replace with valid value
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    smtp.Send(Msg);


                    con.Open();
                    cmd = new SqlCommand("UPDATE [User] SET Major = @Major , Address = @Address, ZIP = @ZIP WHERE Email= @Email1", con);
                    cmd.Parameters.Add(new SqlParameter("Major", TextBox2.Text));
                    cmd.Parameters.Add(new SqlParameter("Address", TextBox4.Text));
                    cmd.Parameters.Add(new SqlParameter("ZIP", TextBox5.Text));
                    cmd.Parameters.Add(new SqlParameter("Email1", Label4.Text));
                    cmd.ExecuteNonQuery();
                    DataBind();

                    Label4.Text = TextBox1.Text;
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    Response.Redirect("~/Login Page.aspx");
                }
                else
                {
                    MessageBox.Show("This email already exists. Please Try Again!");
                }

            con.Close();
            }
            catch (Exception ex)
            {
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string savedPasswordHash = "";
            string savedPasswordHashNew = "";

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM[User] WHERE Email = @Email ", con);
            cmd.Parameters.Add(new SqlParameter("Email", Label4.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                savedPasswordHash = dr["Password"].ToString();


                byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                /* Get the salt */
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                /* Compute the hash on the password the user entered */
                var pbkdf2 = new Rfc2898DeriveBytes(TextBox8.Text, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);
                /* Compare the results */
                for (int i = 0; i < 20; i++)
                    if (hashBytes[i + 16] != hash[i])
                    { }
                    else
                    {
                        try
                        {
                            if (TextBox9.Text == TextBox10.Text)
                            {
                                byte[] saltNew;
                                new RNGCryptoServiceProvider().GetBytes(saltNew = new byte[16]);

                                var pbkdf2New = new Rfc2898DeriveBytes(TextBox9.Text, saltNew, 100000);
                                byte[] hashNew = pbkdf2New.GetBytes(20);

                                byte[] hashBytesNew = new byte[36];
                                Array.Copy(saltNew, 0, hashBytesNew, 0, 16);
                                Array.Copy(hashNew, 0, hashBytesNew, 16, 20);

                                savedPasswordHashNew = Convert.ToBase64String(hashBytesNew);

                            }
                            else
                            {
                                MessageBox.Show("The new password you have entered and your confirm password do not match");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
            }

            con.Close();

            con.Open();
            cmd = new SqlCommand("UPDATE [User] SET Password = @Password WHERE Email= @Email", con);
            cmd.Parameters.Add(new SqlParameter("Password", savedPasswordHashNew));
            cmd.Parameters.Add(new SqlParameter("Email", Label4.Text));
            cmd.ExecuteNonQuery();

            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";

            con.Close();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Calendar.aspx", false);
            Response.Redirect("~/Calendar.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearchProjects.aspx", false);
            Response.Redirect("~/ResearchProjects.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearcherReservationSchedule.aspx", false);
            Response.Redirect("~/ResearcherReservationSchedule.aspx?Email=" + Label4.Text);
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearchReservation.aspx", false);
            Response.Redirect("~/ResearchReservation.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearcherAccount.aspx", false);
            Response.Redirect("~/ResearcherAccount.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login Page.aspx");
        }
    }
}