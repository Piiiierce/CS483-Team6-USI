using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Senior_Project
{
    public partial class AdminApprove : System.Web.UI.Page
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
            }
            con.Close();

            DateTime dateNow = DateTime.Now;
            string dateHold = "";

            con.Open();
            cmd = new SqlCommand("SELECT * FROM Reservation", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                    dateHold = dr["CreateDate"].ToString().Trim();
            }
            con.Close();

            DateTime dateCompare = DateTime.Parse(dateHold);

            int f = 0;
            con.Open();
            cmd = new SqlCommand("SELECT COUNT (*) FROM Reservation WHERE Date = @Date ", con);
            cmd.Parameters.Add(new SqlParameter("Date", TextBox1.Text));
            f = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            DateTime Start = DateTime.Now;
            DateTime End = DateTime.Now;

            con.Open();
            cmd = new SqlCommand("SELECT * FROM Reservation WHERE Status = @Status AND CreateDate <= @CreateDate", con);
            cmd.Parameters.Add(new SqlParameter("Status", "Pending"));
            cmd.Parameters.Add(new SqlParameter("CreateDate", dateNow.AddDays(-2).ToShortDateString()));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Start = DateTime.Parse(dr["StartTime"].ToString());
                End = DateTime.Parse(dr["EndTime"].ToString());
            }
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
                        DateTime Endz30 = Start.AddMinutes(29);
                        DateTime Start30 = End.AddMinutes(29);
                        DateTime End30 = end[iii].AddMinutes(29);
                        if (Start30 >= start[iii] && Start <= End30 || start[iii] <= End.AddMinutes(29) && End <= End30 || start[iii] >= Start30 && end[iii] <= End)
                        {

                        }
                        else
                        {
                            if (dateNow.ToShortDateString() == dateCompare.AddDays(2).ToShortDateString())
                            {
                                con.Open();
                                cmd = new SqlCommand("UPDATE Reservation SET ManagerApprove = @ManagerApprove, Status = @Status WHERE Status = @Status1 AND CreateDate <= @CreateDate", con);
                                cmd.Parameters.Add(new SqlParameter("ManagerApprove", "1"));
                                cmd.Parameters.Add(new SqlParameter("Status", "Approved"));
                                cmd.Parameters.Add(new SqlParameter("Status1", "Pending"));
                                cmd.Parameters.Add(new SqlParameter("CreateDate", dateNow.AddDays(-2).ToShortDateString()));
                                cmd.ExecuteNonQuery();
                                GridView1.DataBind();
                                con.Close();
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
                    {
                        GridViewRow row = GridView1.SelectedRow;
                        GridView1.DataBind();
                        GridView1.SelectedRow.BackColor = System.Drawing.Color.Gray;

                        Button1.Visible = true;
                        Button2.Visible = true;


                        TextBox1.Text = row.Cells[5].Text;
                        Label3.Text = row.Cells[5].Text;
                        Label5.Text = row.Cells[6].Text;
                        Label6.Text = row.Cells[7].Text;
                    }

                    protected void Button1_Click1(object sender, EventArgs e)
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
                                    DateTime Endz30 = DateTime.Parse(Label5.Text).AddMinutes(29);
                                    DateTime Start30 = DateTime.Parse(Label6.Text).AddMinutes(29);
                                    DateTime End30 = end[iii].AddMinutes(29);
                                    if (Start30 >= start[iii] && DateTime.Parse(Label5.Text) <= End30 || start[iii] <= DateTime.Parse(Label6.Text).AddMinutes(29) && DateTime.Parse(Label6.Text) <= End30 || start[iii] >= Start30 && end[iii] <= DateTime.Parse(Label6.Text))
                                    {
                                        MessageBox.Show("A reservation already exists in this time slot");
                                        break;
                                    }
                                    else
                                    {


                                        string hold = "";
                                        string name = "";
                                        string email = "";
                                        con.Open();
                                        SqlCommand cmd = new SqlCommand("SELECT * FROM Reservation WHERE StartTime = @StartTime AND EndTime = @EndTime AND Date = @Date", con);
                                        cmd.Parameters.Add(new SqlParameter("Date", Label3.Text));
                                        cmd.Parameters.Add(new SqlParameter("StartTime", Label5.Text));
                                        cmd.Parameters.Add(new SqlParameter("EndTime", Label6.Text));
                                        dr = cmd.ExecuteReader();
                                        while (dr.Read())
                                        {
                                            hold = dr["ReservationId"].ToString();
                                        }
                                        con.Close();

                                        con.Open();
                                        cmd = new SqlCommand("UPDATE Reservation SET ManagerApprove = @ManagerApprove, Status = @Status WHERE ReservationId = @ReservationId", con);
                                        cmd.Parameters.Add(new SqlParameter("ManagerApprove", "1"));
                                        cmd.Parameters.Add(new SqlParameter("Status", "Approved"));
                                        cmd.Parameters.Add(new SqlParameter("ReservationId", hold));
                                        cmd.ExecuteNonQuery();
                                        DataBind();
                                        con.Close();

                                        Button1.Visible = false;
                                        Button2.Visible = false;

                                        con.Open();
                                        cmd = new SqlCommand("SELECT * FROM Notify WHERE ReservationID = @ReservationID", con);
                                        cmd.Parameters.Add(new SqlParameter("ReservationID", hold));
                                        dr = cmd.ExecuteReader();
                                        while (dr.Read())
                                        {
                                            name = dr["UserID"].ToString();
                                        }
                                        con.Close();

                                        con.Open();
                                        cmd = new SqlCommand("SELECT * FROM [User] WHERE SubjectID = @SubjectID", con);
                                        cmd.Parameters.Add(new SqlParameter("SubjectID", name));
                                        dr = cmd.ExecuteReader();
                                        while (dr.Read())
                                        {
                                            email = dr["Email"].ToString().Trim();
                                            name = dr["LastName"].ToString().Trim();
                                        }
                                        con.Close();

                                        MailMessage Msg = new MailMessage();
                                        Msg.From = new MailAddress("testingforschoolprogram@gmail.com", "<DoNotReply>Lab");// Sender details here, replace with valid value
                                        Msg.Subject = "Lab Approval"; // subject of email
                                        Msg.To.Add(email); //Add Email id, to which we will send email
                                        Msg.Body = "Hello Professor " + name + ",\n"
                                            + "Your reservation for " + Label3.Text + " has been approved.";

                                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                                        smtp.UseDefaultCredentials = false; // to get rid of error "SMTP server requires a secure connection"
                                        smtp.Credentials = new System.Net.NetworkCredential("testingforschoolprogram@gmail.com", "Testing!234");// replace with valid value
                                        smtp.EnableSsl = true;
                                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                                        smtp.Send(Msg);
                                    }
                                }
                                catch { }
                            }
                        }
                    }

                    protected void Button2_Click(object sender, EventArgs e)
                    {
                        string hold = "";
                        string name = "";
                        string email = "";

                        con.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Reservation WHERE StartTime = @StartTime AND EndTime = @EndTime AND Date = @Date", con);
                        cmd.Parameters.Add(new SqlParameter("Date", Label3.Text));
                        cmd.Parameters.Add(new SqlParameter("StartTime", Label5.Text));
                        cmd.Parameters.Add(new SqlParameter("EndTime", Label6.Text));
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            hold = dr["ReservationId"].ToString();
                        }
                        con.Close();

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM Notify WHERE ReservationID = @ReservationID", con);
                        cmd.Parameters.Add(new SqlParameter("ReservationID", hold));
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            name = dr["UserID"].ToString();
                        }
                        con.Close();

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM [User] WHERE SubjectID = @SubjectID", con);
                        cmd.Parameters.Add(new SqlParameter("SubjectID", name));
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            email = dr["Email"].ToString().Trim();
                            name = dr["LastName"].ToString().Trim();
                        }
                        con.Close();

                        con.Open();
                        cmd = new SqlCommand("DELETE FROM Notify WHERE(ReservationID = @ReservationId)", con);
                        cmd.Parameters.Add(new SqlParameter("ReservationId", hold));
                        cmd.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        cmd = new SqlCommand("DELETE FROM Reservation WHERE(ReservationId = @ReservationId)", con);
                        cmd.Parameters.Add(new SqlParameter("ReservationId", hold));
                        cmd.ExecuteNonQuery();
                        DataBind();
                        con.Close();


                        Button1.Visible = false;
                        Button2.Visible = false;

                        MailMessage Msg = new MailMessage();
                        Msg.From = new MailAddress("testingforschoolprogram@gmail.com", "<DoNotReply>Lab");// Sender details here, replace with valid value
                        Msg.Subject = "Lab Decline"; // subject of email
                        Msg.To.Add(email); //Add Email id, to which we will send email
                        Msg.Body = "Hello Professor " + name + ",\n"
                            + "I am sorry to inform you that your reservation for " + Label3.Text + " has been denied.";

                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.UseDefaultCredentials = false; // to get rid of error "SMTP server requires a secure connection"
                        smtp.Credentials = new System.Net.NetworkCredential("testingforschoolprogram@gmail.com", "Testing!234");// replace with valid value
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                        smtp.Send(Msg);


                    }

                    protected void LinkButton1_Click(object sender, EventArgs e)
                    {
                        Response.Redirect("~/AdminCalendar.aspx", false);
                        Response.Redirect("~/AdminCalendar.aspx?Email=" + Label4.Text);
                    }

                    protected void LinkButton2_Click(object sender, EventArgs e)
                    {
                        Response.Redirect("~/AdminApprove.aspx", false);
                        Response.Redirect("~/AdminApprove.aspx?Email=" + Label4.Text);
                    }


                    protected void LinkButton3_Click(object sender, EventArgs e)
                    {
                        Response.Redirect("~/AdminUserView.aspx", false);
                        Response.Redirect("~/AdminUserView.aspx?Email=" + Label4.Text);
                    }

                    protected void LinkButton4_Click(object sender, EventArgs e)
                    {
                        Response.Redirect("~/Login Page.aspx");
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
                            SqlCommand cmd = new SqlCommand("SELECT Date FROM Reservation WHERE ManagerApprove = @Approve", con);
                            cmd.Parameters.Add(new SqlParameter("Approve", "1"));
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
                        }

                    }
                }
            }