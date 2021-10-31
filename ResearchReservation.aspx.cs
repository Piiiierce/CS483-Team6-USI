using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Senior_Project
{
    public partial class ResearchReservation : System.Web.UI.Page
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
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM [User] WHERE Email='" + Label4.Text.Trim() + "'";
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
            Response.Redirect("~/Calendar.aspx", false);
            Response.Redirect("~/Calendar.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearchProjects.aspx", false);
            Response.Redirect("~/ResearchProjects.aspx?Email=" + Label4.Text);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResearcherReservationSchedule.aspx", false);
            Response.Redirect("~/ResearcherReservationSchedule.aspx?Email=" + Label4.Text);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            con.Open();
            string sql = "SELECT Date FROM Reservation WHERE ManagerApprove = 1";
            SqlCommand cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["Date"].ToString() == e.Day.Date.ToString() && !e.Day.IsOtherMonth)
                {
                    e.Cell.BackColor = System.Drawing.Color.Red;
                }
            }
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int c =3110;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Project.ProjectID FROM [User], Project WHERE [User].Email='" + Label4.Text.Trim() + "' AND Project.Name = '" + DropDownList1.SelectedValue + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Label3.Text = dr["ProjectID"].ToString().Trim();
            }
            con.Close();

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ReservationId FROM Reservation ORDER BY ReservationId ASC";

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                c = Convert.ToInt32(dr["ReservationId"]);
            }
            con.Close();
            c++;
            Label9.Text = c.ToString();
            var parameter = SqlDataSource1.InsertParameters;
            parameter["ReservationId"].DefaultValue = c.ToString();
            parameter["StartTime"].DefaultValue = TextBox2.Text;
            parameter["EndTime"].DefaultValue = TextBox3.Text;
            parameter["Status"].DefaultValue = "Pending";
            parameter["isRecruit"].DefaultValue = "False";
            parameter["isEmail"].DefaultValue = "False";
            parameter["ProjectID"].DefaultValue = Label3.Text;
            parameter["ManagerApprove"].DefaultValue = "0";
            parameter["Date"].DefaultValue = TextBox1.Text;
            parameter["Occupancy"].DefaultValue = TextBox4.Text;
            //insert and bind data table
            try
            {
                SqlDataSource1.Insert();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
            }
        }
    }
}