using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Default2 : System.Web.UI.Page
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        print();
        //DeleteCommand="DELETE FROM [users] WHERE [id] = @id" 
        //InsertCommand="INSERT INTO [users] ([fullname], [email], [password]) VALUES (@fullname, @email, @password)" 
        //ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
        //SelectCommand="SELECT [id], [fullname], [email], [password] FROM [users]" 
        //UpdateCommand="UPDATE [users] SET [fullname] = @fullname, [email] = @email, [password] = @password WHERE [id] = @id"
    }
    private void print()
    {
        SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM [users]",c);
        DataTable d = new DataTable();
        a.Fill(d);
        GridView1.DataSource = d;
        GridView1.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        SqlCommand s = new SqlCommand("DELETE FROM [users] WHERE [id]=" + b.CommandArgument, c);
        c.Open();
        int a = s.ExecuteNonQuery();
        if (a == 1)
        {
            Response.Write("<script>alert('Successfully Deleted.')</script>");
            print();
        }
        else
        {
            Response.Write("<script>alert('Error deleting data.')</script>");
            print();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        SqlDataAdapter adpt = new SqlDataAdapter("SELECT * FROM [users] WHERE [id]=" + b.CommandArgument, c);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        TextBox3.Text = dt.Rows[0][1].ToString();
        TextBox1.Text = dt.Rows[0][2].ToString();
        TextBox2.Text = dt.Rows[0][3].ToString();
        ViewState["id"] = b.CommandArgument;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand s = new SqlCommand("UPDATE [users] SET [fullname] = @fullname, [email] = @email, [password] = @password WHERE [id] =" + ViewState["id"].ToString(), c);
        s.Parameters.AddWithValue("@fullname", TextBox3.Text);
        s.Parameters.AddWithValue("@email", TextBox1.Text);
        s.Parameters.AddWithValue("@password", TextBox2.Text);
        c.Open();
        int a = s.ExecuteNonQuery();
        c.Close();
        if (a > 0)
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            Response.Write("<script>alert('Updated Successfully.')</script>");
            print();
        }
        else
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            Response.Write("<script>alert('Error.')</script>");
            print();
        }
    }
}