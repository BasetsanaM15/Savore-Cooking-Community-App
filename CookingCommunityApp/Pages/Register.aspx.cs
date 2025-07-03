using System;
using System.Data.SqlClient;
using System.Configuration;

namespace CookingCommunityApp.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["CookingCommunityConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Users (Email, Password, FullName, SecretQuestion, SecretAnswer) " +
                               "VALUES (@Email, @Password, @FullName, @SecretQuestion, @SecretAnswer)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@SecretQuestion", txtQuestion.Text);
                cmd.Parameters.AddWithValue("@SecretAnswer", txtAnswer.Text);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Registration successful!";
                    ClearFields();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }

        private void ClearFields()
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtFullName.Text = "";
            txtQuestion.Text = "";
            txtAnswer.Text = "";
        }
    }
}
