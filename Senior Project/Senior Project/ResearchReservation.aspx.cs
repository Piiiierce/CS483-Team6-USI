using System;
using System.Collections.Generic;
using System.Data;
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
                Label3.Text = dr["SubjectID"].ToString().Trim();
            }
            con.Close();

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Date FROM Reservation WHERE ManagerApprove = 1";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["Date"].ToString() == e.Day.Date.ToString() && !e.Day.IsOtherMonth)
                    {
                        e.Cell.BackColor = System.Drawing.Color.Red;
                    }

                    if (e.Day.IsOtherMonth)
                    {
                        e.Day.IsSelectable = false;
                    }

                }
                con.Close();
            }
            catch
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";

                Response.Redirect("~/ResearchReservation.aspx", false);
                Response.Redirect("~/ResearchReservation.aspx?Email=" + Label4.Text);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int c = 0;
            int d = 0;
            string holder = Label3.Text;
            con.Open();
            cmd = new SqlCommand("SELECT Project.ProjectID FROM [User], Project WHERE [User].Email= @Email AND Project.Name = @Name", con);
            cmd.Parameters.Add(new SqlParameter("Name", DropDownList1.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("Email", Label4.Text));

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                d = Convert.ToInt32(dr["ProjectID"]);
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

            int occ = 0;
            try
            {
                occ = Convert.ToInt32(TextBox4.Text);
            }
            catch { }

            if (occ >= 1 && occ <= 50)
            {
                if (TextBox1.Text == "")
                {
                    Label11.Visible = true;
                    if (TextBox2.Text == "")
                    {
                        Label12.Visible = true;
                        if (TextBox3.Text == "")
                        {
                            Label13.Visible = true;
                        }
                    }
                    else if (TextBox3.Text == "")
                    {
                        Label13.Visible = true;
                    }
                }
                else
                {
                    Label11.Visible = false;

                    if (TextBox2.Text == "")
                    {
                        Label12.Visible = true;
                        if (TextBox3.Text == "")
                        {
                            Label13.Visible = true;
                        }
                    }
                    else
                    {
                        Label12.Visible = false;
                        if (TextBox3.Text == "")
                        {
                            Label13.Visible = true;
                        }
                        else
                        {
                            try
                            {
                                int f = 0;
                                con.Open();
                                cmd = new SqlCommand("SELECT COUNT (*) FROM Reservation WHERE Date = @Date ", con);
                                cmd.Parameters.Add(new SqlParameter("Date", TextBox1.Text));
                                f = Convert.ToInt32(cmd.ExecuteScalar());
                                con.Close();

                                DateTime[] start = new DateTime[f];
                                int i = 0;
                                foreach (ListItem StartTime in ListBox1.Items)
                                {
                                    start[i] = DateTime.Parse(StartTime.Value);
                                    i++;
                                }

                                DateTime[] end = new DateTime[f];
                                int ii = 0;
                                foreach (ListItem EndTime in ListBox2.Items)
                                {
                                    end[ii] = DateTime.Parse(EndTime.Value);
                                    ii++;
                                }
                                if (f != 0)
                                {
                                    for (int iii = 0; iii < start.Length + 1; iii++)
                                    {
                                        try
                                        {
                                            DateTime Endz30 = DateTime.Parse(TextBox3.Text).AddMinutes(29);
                                            DateTime Start30 = DateTime.Parse(TextBox2.Text).AddMinutes(29);
                                            DateTime End30 = end[iii].AddMinutes(29);
                                            if (DateTime.Parse(TextBox2.Text).AddMinutes(14) >= DateTime.Parse(TextBox3.Text))
                                            {
                                                Label14.Visible = true;
                                                Label14.Text = "The Start Time can't be greater then the End time/The Start and End time must be at least 15 minutes apart";
                                            }
                                            else
                                            {
                                                if (Start30 >= start[iii] && DateTime.Parse(TextBox2.Text) <= End30 || start[iii] <= DateTime.Parse(TextBox3.Text).AddMinutes(29) && DateTime.Parse(TextBox3.Text) <= End30 || start[iii] >= Start30 && end[iii] <= DateTime.Parse(TextBox3.Text))
                                                {
                                                    Label14.Visible = true;
                                                    Label14.Text = "Start or End Time is within 30 mins of the start or end time of a different research";
                                                    break;
                                                }
                                                else
                                                {
                                                    DateTime dateNow = System.DateTime.Now;

                                                    Label14.Visible = false;
                                                    con.Open();
                                                    cmd = new SqlCommand("INSERT INTO Reservation (ReservationId, StartTime, EndTime, Status, isRecruit, isEmail, ProjectID, ManagerApprove, Date, Occupancy, CreateDate) VALUES (@ReservationId, @StartTime, @EndTime, @Status, @isRecruit, @isEmail, @ProjectID, @ManagerApprove, @Date, @Occupancy, @CreateDate)", con);
                                                    cmd.Parameters.Add(new SqlParameter("ReservationId", c.ToString()));
                                                    cmd.Parameters.Add(new SqlParameter("StartTime", TextBox2.Text));
                                                    cmd.Parameters.Add(new SqlParameter("EndTime", TextBox3.Text));
                                                    cmd.Parameters.Add(new SqlParameter("ProjectID", d.ToString()));
                                                    cmd.Parameters.Add(new SqlParameter("Date", TextBox1.Text));
                                                    cmd.Parameters.Add(new SqlParameter("Occupancy", TextBox4.Text));
                                                    cmd.Parameters.Add(new SqlParameter("Status", "Pending"));
                                                    cmd.Parameters.Add(new SqlParameter("isEmail", "False"));
                                                    cmd.Parameters.Add(new SqlParameter("isRecruit", "False"));
                                                    cmd.Parameters.Add(new SqlParameter("ManagerApprove", "0"));
                                                    cmd.Parameters.Add(new SqlParameter("CreateDate", System.DateTime.Now.ToString()));
                                                    cmd.ExecuteNonQuery();
                                                    con.Close();

                                                    con.Open();
                                                    cmd = new SqlCommand("INSERT INTO Notify (ReservationID, UserID) VALUES(@ReservationID, @UserID)", con);
                                                    cmd.Parameters.Add(new SqlParameter("ReservationID", c.ToString()));
                                                    cmd.Parameters.Add(new SqlParameter("UserID", holder));
                                                    cmd.ExecuteNonQuery();
                                                    con.Close();



                                                    TextBox1.Text = "";
                                                    TextBox2.Text = "";
                                                    TextBox3.Text = "";
                                                    TextBox4.Text = "";

                                                    Response.Redirect("~/ResearchReservation.aspx", false);
                                                    Response.Redirect("~/ResearchReservation.aspx?Email=" + Label4.Text);

                                                    Label10.Visible = false;
                                                }
                                            }

                                        }
                                        catch { }
                                    }
                                }
                                else
                                {
                                    if (DateTime.Parse(TextBox2.Text).AddMinutes(14) >= DateTime.Parse(TextBox3.Text))
                                    {
                                        Label14.Visible = true;
                                        Label14.Text = "The Start Time can't be greater then the End time/The Start and End time must be at least 15 minutes apart";
                                    }
                                    else
                                    {
                                        Label14.Visible = false;
                                        con.Open();
                                        cmd = new SqlCommand("INSERT INTO Reservation (ReservationId, StartTime, EndTime, Status, isRecruit, isEmail, ProjectID, ManagerApprove, Date, Occupancy) VALUES (@ReservationId, @StartTime, @EndTime, @Status, @isRecruit, @isEmail, @ProjectID, @ManagerApprove, @Date, @Occupancy)", con);
                                        cmd.Parameters.Add(new SqlParameter("ReservationId", c.ToString()));
                                        cmd.Parameters.Add(new SqlParameter("StartTime", TextBox2.Text));
                                        cmd.Parameters.Add(new SqlParameter("EndTime", TextBox3.Text));
                                        cmd.Parameters.Add(new SqlParameter("ProjectID", d.ToString()));
                                        cmd.Parameters.Add(new SqlParameter("Date", TextBox1.Text));
                                        cmd.Parameters.Add(new SqlParameter("Occupancy", TextBox4.Text));
                                        cmd.Parameters.Add(new SqlParameter("Status", "Pending"));
                                        cmd.Parameters.Add(new SqlParameter("isEmail", "False"));
                                        cmd.Parameters.Add(new SqlParameter("isRecruit", "False"));
                                        cmd.Parameters.Add(new SqlParameter("ManagerApprove", "0"));
                                        cmd.ExecuteNonQuery();
                                        con.Close();

                                        con.Open();
                                        cmd = new SqlCommand("INSERT INTO Notify (ReservationID, UserID) VALUES(@ReservationID, @UserID)", con);
                                        cmd.Parameters.Add(new SqlParameter("ReservationID", c.ToString()));
                                        cmd.Parameters.Add(new SqlParameter("UserID", holder));
                                        cmd.ExecuteNonQuery();
                                        con.Close();



                                        TextBox1.Text = "";
                                        TextBox2.Text = "";
                                        TextBox3.Text = "";
                                        TextBox4.Text = "";

                                        Response.Redirect("~/ResearchReservation.aspx", false);
                                        Response.Redirect("~/ResearchReservation.aspx?Email=" + Label4.Text);

                                        Label10.Visible = false;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }
            }
            else
            {
                Label10.Visible = true;
                Label10.Text = "Please insert a number between 1 - 50";
            }
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