using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AbacusNextAssessement
{
    public partial class Login : System.Web.UI.Page
    {
        string connectionString = "Data Source=ANNANJITH;Initial Catalog = AbacusNext; Integrated Security=true;";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM UserAccountDetails", sqlconn);
            sqlconn.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            string id = "";
            foreach (DataRow dr in dataTable.Rows)
            {
                if (dr["UserName"].ToString().ToLower() == txtUserName.Text.ToLower() && dr["Password"].ToString().ToLower() == txtPassword.Text.ToLower())
                {
                    id = dr["id"].ToString();                    
                }
            }
            Response.Redirect("Details.aspx?id=" + id);
        }
    }
}