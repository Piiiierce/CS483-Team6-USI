using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Senior_Project
{
    public partial class Calendar : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

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
    }
}