using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveWebForms
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btSignup_Click(object sender, EventArgs e)
        {
            if (tbUname.Text != "" & tbPass.Text != "" && tbName.Text != "" && tbEmail.Text != "" && tbCPass.Text != "")
            {
                if (tbPass.Text == tbCPass.Text)
                {
                    String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("insert into Users values('" + tbUname.Text + "','" + tbPass.Text + "','" + tbEmail.Text + "','" + tbName.Text + "', 'U')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        lblMsg.Text = "Registration Successful";
                        lblMsg.ForeColor = Color.Green;
                        Response.Redirect("~/Singin.aspx");
                    }
                }

                else
                    lblMsg.Text = "Passowords do not match";
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "All Fields Are Mandatory";
            }
        }
    }
}