using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Default4 : System.Web.UI.Page
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataAdapter a = new SqlDataAdapter("SELECT [ser_id], [ser_title], [ser_description], [ser_status] FROM [services] WHERE [ser_status] = 1", c);
        DataTable d = new DataTable();
        a.Fill(d);
        Repeater1.DataSource = d;
        Repeater1.DataBind();
    }
}