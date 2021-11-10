using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Senior_Project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into [User]" + "(Recruited,Type,SubjectID,FirstName,LastName,PaymentType,Email,Password,Gender,DateofBirth,Major,EnrollmentDate,GPA,Address,ZIP,PaymentInfo) values (@Recruited,@Type,@SubjectID,@FirstName,@LastName,@PaymentType,@Email,@Password,@Gender,@DateofBirth,@Major,@EnrollmentDate,@GPA,@Address,@ZIP,@PaymentInfo)", con);
            cmd.Parameters.AddWithValue("@FirstName", TextBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", TextBox2.Text);
            cmd.Parameters.AddWithValue("@SubjectID", TextBox10.Text);
            cmd.Parameters.AddWithValue("@Email", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Password", TextBox4.Text);
            cmd.Parameters.AddWithValue("@Gender", DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Type", DropDownList4.SelectedItem.Value);
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
            Label1.Text = "Registered Successfully";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            DropDownList1.SelectedValue = "Select Gender";
            DropDownList2.SelectedValue = "Select Major";
            DropDownList3.SelectedValue = "Select Payment Type";
            DropDownList4.SelectedValue = "Select Type";
        }
    }
}