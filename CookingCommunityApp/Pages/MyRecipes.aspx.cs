using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CookingCommunityApp.Pages
{
    public partial class MyRecipes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Pages/Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadMyRecipes();
            }
        }

        private void LoadMyRecipes()
        {
            string connStr = ConfigurationManager.ConnectionStrings["CookingCommunityConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
                    SELECT Title, Ingredients, Method, GETDATE() AS DateSubmitted
                    FROM Recipes
                    WHERE UserID = @UserID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gvMyRecipes.DataSource = dt;
                gvMyRecipes.DataBind();
            }
        }
    }
}
