using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace AbacusNextAssessement
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        string connectionString = "Data Source=ANNANJITH;Initial Catalog = AbacusNext; Integrated Security=true;";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static bool HasMinimumLength(string password, int minLength)
        {
            return password.Length >= minLength;
        }
        public static bool HasMinimumUniqueChars(string password, int minUniqueChars)
        {
            return password.Distinct().Count() >= minUniqueChars;
        }
        public static bool HasDigit(string password)
        {
            return password.Any(c => char.IsDigit(c));
        }
        public static bool HasSpecialChar(string password)
        {
            return password.IndexOfAny("[&^%$#@]".ToCharArray()) != -1;
        }
        public static bool HasUpperCaseLetter(string password)
        {
            return password.Any(c => char.IsUpper(c));
        }
        public static bool HasLowerCaseLetter(string password)
        {
            return password.Any(c => char.IsLower(c));
        }

        public static bool IsValidPassword(
            string password,
            int requiredLength,
            int requiredUniqueChars,
            bool requireNonAlphanumeric,
            bool requireLowercase,
            bool requireUppercase,
            bool requireDigit)
        {
            if (!HasMinimumLength(password, requiredLength)) return false;
            if (!HasMinimumUniqueChars(password, requiredUniqueChars)) return false;
            if (requireNonAlphanumeric && !HasSpecialChar(password)) return false;
            if (requireLowercase && !HasLowerCaseLetter(password)) return false;
            if (requireUppercase && !HasUpperCaseLetter(password)) return false;
            if (requireDigit && !HasDigit(password)) return false;
            return true;
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM UserAccountDetails", sqlconn);
            sqlconn.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            string username = txtUserName.Text;
            string passwordText = "";
            string password = "";
            if(txtPassword.Text == txtConfirmPswd.Text)
            {
                passwordText = txtPassword.Text;
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Passwords doesnt match')", true);
            }
            bool isValid = IsValidPassword(passwordText, 10, 1, true, true, true, true);
            if (isValid)
            {
                password = passwordText;
                foreach (DataRow dr in dataTable.Rows)
                {
                    if (dr["UserName"].ToString().ToLower() != username.ToLower())
                    {
                        SqlCommand inserCommand = new SqlCommand("INSERT INTO UserAccountDetails VALUES(@FirstName, @FamilyName, @UserName, @Password, @Postalcode)", sqlconn);
                        inserCommand.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        inserCommand.Parameters.AddWithValue("@FamilyName", txtFamName.Text);
                        inserCommand.Parameters.AddWithValue("@UserName", txtUserName.Text);
                        inserCommand.Parameters.AddWithValue("@Password", password);
                        inserCommand.Parameters.AddWithValue("@Postalcode", txtPostalcode.Text);
                        inserCommand.ExecuteNonQuery();
                        
                    }
                    else
                    {
                        MessageBox.Show("User Already Exists. Please login");
                    }
                    //Response.Redirect("Login.aspx");
                }
               
            }
            else
            {
                MessageBox.Show("Enter a valid password. Password should be at least 10 characters in length and containing one digit, one uppercase character, one special character within the following set[&^%$#@].");
            }
            sqlconn.Close();
            da.Dispose();
            Response.Redirect("Login.aspx");
        }

        protected void txtConfirmPswd_TextChanged(object sender, EventArgs e)
        {
            if(txtPassword.Text != txtConfirmPswd.Text)
            {
                lblpassword.Text = "Password missmatch";
                lblpassword.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show("Passwords doesn't match");
            }
        }
    }
}