using System;
using System.Data.SqlClient;
using System.Configuration;

namespace CookingCommunityApp.Pages
{
    public partial class SubmitRecipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["CookingCommunityConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Recipes (UserID, Title, Ingredients, Method) VALUES (@UserID, @Title, @Ingredients, @Method)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@Ingredients", txtIngredients.Text);
                cmd.Parameters.AddWithValue("@Method", txtMethod.Text);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Recipe submitted successfully!";
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
            txtTitle.Text = "";
            txtIngredients.Text = "";
            txtMethod.Text = "";
        }
    }
}
