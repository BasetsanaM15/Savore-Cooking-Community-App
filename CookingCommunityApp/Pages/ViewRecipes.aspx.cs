using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace CookingCommunityApp.Pages
{
    public partial class ViewRecipes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Pages/Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadRecipes();
            }
        }

        private void LoadRecipes()
        {
            string connStr = ConfigurationManager.ConnectionStrings["CookingCommunityConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
                    SELECT r.RecipeID, r.Title, r.Ingredients, r.Method,
                           ISNULL(AVG(CAST(rt.RatingValue AS FLOAT)), 0) AS AverageRating
                    FROM Recipes r
                    LEFT JOIN Ratings rt ON r.RecipeID = rt.RecipeID
                    GROUP BY r.RecipeID, r.Title, r.Ingredients, r.Method";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gvRecipes.DataSource = dt;
                gvRecipes.DataBind();
            }
        }

        protected void gvRecipes_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Rate")
            {
                GridViewRow row = ((System.Web.UI.WebControls.Button)e.CommandSource).NamingContainer as GridViewRow;

                var ddl = (System.Web.UI.WebControls.DropDownList)row.FindControl("ddlRating");
                int ratingValue = int.Parse(ddl.SelectedValue);
                int recipeID = int.Parse(e.CommandArgument.ToString());
                int userID = Convert.ToInt32(Session["UserID"]);

                string connStr = ConfigurationManager.ConnectionStrings["CookingCommunityConnectionString"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string insertQuery = "INSERT INTO Ratings (RecipeID, UserID, RatingValue) VALUES (@RecipeID, @UserID, @RatingValue)";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn);

                    cmd.Parameters.AddWithValue("@RecipeID", recipeID);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@RatingValue", ratingValue);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Rating submitted successfully!";
                        LogRating(Session["Email"].ToString(), recipeID, ratingValue);
                        LoadRecipes();
                    }
                    catch (Exception ex)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Error: " + ex.Message;
                    }
                }
            }
        }

        private void LogRating(string userEmail, int recipeID, int rating)
        {
            string logPath = Server.MapPath("~/Logs/RatingsLog.txt");

            string logEntry = $"User Email: {userEmail}, Recipe ID: {recipeID}, Rating: {rating}, Date: {DateTime.Now}";
            File.AppendAllText(logPath, logEntry + Environment.NewLine);
        }
    }
}
