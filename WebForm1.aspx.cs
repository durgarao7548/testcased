using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        // Connection string for your SQL Server
        private string connectionString = "Server=localHost;Database=UserLoginDB;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Your page load logic
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Fetch the entered username and password
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Check if the username and password are correct
            if (AuthenticateUser(username, password))
            {
                // If login successful
                loginDiv.Visible = false;
                logoutDiv.Visible = true;
                actionButtonsDiv.Visible = true;
            }
            else
            {
                // Display error message if login fails
                lblMessage.Text = "Invalid username or password!";
            }
        }

        // Method to authenticate user
        private bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = false;

            // SQL query to check for a matching username and password in the database
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open connection to the database
                    conn.Open();

                    // Create a command object to execute the query
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@PasswordHash", password);

                        // Execute the query and check if any rows are returned
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // If count is greater than 0, the user is authenticated
                        isAuthenticated = count > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors (you can log the error if needed)
                    lblMessage.Text = "An error occurred: " + ex.Message;
                }
            }

            return isAuthenticated;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Logout logic: reset visibility of controls
            loginDiv.Visible = true;
            logoutDiv.Visible = false;
            actionButtonsDiv.Visible = false;
        }

        protected void btnDataReport_Click(object sender, EventArgs e)
        {
            // Bind data to GridView (Example data)
            GridView1.DataSource = GetData();
            GridView1.DataBind();
        }

        private DataTable GetData()
        {
            // Example data source for demonstration purposes
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Rows.Add("Value1", "Value2");
            return dt;
        }
    }
}
