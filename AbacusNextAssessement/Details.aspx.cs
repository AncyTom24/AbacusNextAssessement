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
    public partial class Details : System.Web.UI.Page
    {
        string id = "";
        string connectionString = "Data Source=ANNANJITH;Initial Catalog = AbacusNext; Integrated Security=true;";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM UserAccountDetails WHERE id = " + id + ";", sqlconn);
            sqlconn.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            grdUserDetails.DataSource = dataTable;
            grdUserDetails.DataBind();            
        }

    }
}