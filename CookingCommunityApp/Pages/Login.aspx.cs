using System;
using System.Data.SqlClient;
using System.Configuration;

namespace CookingCommunityApp.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["CookingCommunityConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT UserID FROM Users WHERE Email = @Email AND Password = @Password";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        Session["UserID"] = result.ToString();
                        Session["Email"] = txtEmail.Text;

                        Response.Redirect("~/Pages/SubmitRecipe.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Invalid login credentials.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}
