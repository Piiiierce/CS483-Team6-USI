using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Security.Cryptography;

namespace Senior_Project
{
    public partial class WebForm1 : System.Web.UI.Page
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
            int hold = 0;
            string email = "";
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT SubjectID FROM [User] WHERE Type = @Type ORDER BY SubjectID ASC";
            cmd.Parameters.AddWithValue("@Type", "Student");
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                hold = Convert.ToInt32(dr["SubjectID"]);
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("SELECT * FROM [User] WHERE Email = @Email", con);
            cmd.Parameters.Add(new SqlParameter("Email", TextBox3.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                email = dr["Email"].ToString().Trim();
            }
            con.Close();

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(TextBox4.Text, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "" || TextBox11.Text == "" || TextBox12.Text == "" || TextBox7.Text == "" || TextBox8.Text == "" || TextBox9.Text == "" || DropDownList3.SelectedItem.Value == "Select Payment Value" || DropDownList1.SelectedItem.Value == "Select Gender" || DropDownList2.SelectedItem.Value == "Select Major" )
            {
                MessageBox.Show("One of the fields that needs to be filled out is empty!");
            }
            else
            {
                if (TextBox4.Text == TextBox5.Text)
                {
                    if (email != TextBox3.Text)
                    {
                        if ((Convert.ToInt32(TextBox6.Text) >= 0 && Convert.ToInt32(TextBox6.Text) <= 4))
                        {
                            //try
                            //{
                            hold++;
                            con.Open();
                            cmd = new SqlCommand("INSERT INTO [User]" + "(Recruited,Type,SubjectID,FirstName,LastName,PaymentType,Email,Password,Gender,DateofBirth,Major,EnrollmentDate,GPA,Address,ZIP,PaymentInfo) VALUES (@Recruited,@Type,@SubjectID,@FirstName,@LastName,@PaymentType,@Email,@Password,@Gender,@DateofBirth,@Major,@EnrollmentDate,@GPA,@Address,@ZIP,@PaymentInfo)", con);
                            cmd.Parameters.AddWithValue("@FirstName", TextBox1.Text);
                            cmd.Parameters.AddWithValue("@LastName", TextBox2.Text);
                            cmd.Parameters.AddWithValue("@SubjectID", hold);
                            cmd.Parameters.AddWithValue("@Email", TextBox3.Text);
                            cmd.Parameters.AddWithValue("@Password", savedPasswordHash);
                            cmd.Parameters.AddWithValue("@Gender", DropDownList1.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@Type", "Student");
                            cmd.Parameters.AddWithValue("@DateofBirth", TextBox11.Text);
                            cmd.Parameters.AddWithValue("@Major", DropDownList2.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@EnrollmentDate", TextBox12.Text);
                            cmd.Parameters.AddWithValue("@GPA", TextBox6.Text);
                            cmd.Parameters.AddWithValue("@Address", TextBox7.Text);
                            cmd.Parameters.AddWithValue("@ZIP", TextBox8.Text);
                            cmd.Parameters.AddWithValue("@PaymentType", DropDownList3.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@PaymentInfo", TextBox9.Text);
                            cmd.Parameters.AddWithValue("@Recruited", Boolean.FalseString);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            Response.Redirect("~/Login Page.aspx");
                            //}
                            //catch
                            //{
                            //    TextBox6.Text = "";
                            //}
                        }
                        else
                        {
                            MessageBox.Show("Please enter a number between 0-4 into GPA");
                        }
                    }
                    else
                    {
                        MessageBox.Show("This email already exists!");
                    }
                }
                else
                {
                    MessageBox.Show("Your password does not match!");
                }
            }
        }
    }
}