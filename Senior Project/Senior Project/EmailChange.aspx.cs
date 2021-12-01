using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Senior_Project
{
    public partial class EmailChange : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Email"] != null)
            {
                Label3.Text = Session["Email"].ToString();
                Label4.Text = Request.QueryString["Email"];
            }
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

            con.Open();
            cmd = new SqlCommand("UPDATE [User] SET Email = @Email WHERE Email= @Email1", con);
            cmd.Parameters.Add(new SqlParameter("Email", Label3.Text));
            cmd.Parameters.Add(new SqlParameter("Email1", Label4.Text));
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}