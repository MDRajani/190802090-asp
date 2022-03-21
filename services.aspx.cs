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
        //DeleteCommand="DELETE FROM [services] WHERE [ser_id] = @ser_id" 
        //InsertCommand="INSERT INTO [services] ([ser_title], [ser_description], [ser_status]) VALUES (@ser_title, @ser_description, @ser_status)" 
        //ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
        //SelectCommand="SELECT [ser_id], [ser_title], [ser_description], [ser_status] FROM [services]" 
        //UpdateCommand="UPDATE [services] SET [ser_title] = @ser_title, [ser_description] = @ser_description, [ser_status] = @ser_status WHERE [ser_id] = @ser_id"
    }
    public void print()
    {
        SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM [services]", c);
        DataTable d = new DataTable();
        a.Fill(d);
        GridView1.DataSource = d;
        GridView1.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        SqlCommand co = new SqlCommand("DELETE FROM [services] WHERE [ser_id] = "+btn.CommandArgument, c);
        c.Open();
        int s = co.ExecuteNonQuery();
        c.Close();
        if (s == 1)
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            RadioButtonList1.ClearSelection();
            print();
            Response.Write("<script>alert('Service deleted successfully.')</script");
        }
        else
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            RadioButtonList1.ClearSelection();
            print();
            Response.Write("<script>alert('Error deleting.')</script");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        SqlDataAdapter a = new SqlDataAdapter("SELECT [ser_id], [ser_title], [ser_description], [ser_status] FROM [services] WHERE [ser_id]="+ btn.CommandArgument,c);
        DataTable d = new DataTable();
        a.Fill(d);
        TextBox1.Text = d.Rows[0][1].ToString();
        TextBox2.Text = d.Rows[0][2].ToString();
        RadioButtonList1.SelectedValue = d.Rows[0][3].ToString();
        ViewState["ser_id"] = btn.CommandArgument;
        Button1.Text = "Update";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Insert")
        {
            SqlCommand co = new SqlCommand("INSERT INTO [services] ([ser_title], [ser_description], [ser_status]) VALUES (@ser_title, @ser_description, @ser_status)", c);
            co.Parameters.AddWithValue("@ser_title", TextBox1.Text);
            co.Parameters.AddWithValue("@ser_description", TextBox2.Text);
            co.Parameters.AddWithValue("@ser_status", RadioButtonList1.SelectedValue);
            c.Open();
            int s = co.ExecuteNonQuery();
            c.Close();
            if (s == 1)
            {
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
                RadioButtonList1.ClearSelection();
                print();
                Response.Write("<script>alert('Service inserted successfully.')</script");
            }
            else
            {
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
                RadioButtonList1.ClearSelection();
                print();
                Response.Write("<script>alert('Error!.')</script");
            }
        }
        else
        {
            SqlCommand co = new SqlCommand("UPDATE [services] SET [ser_title] = @ser_title, [ser_description] = @ser_description, [ser_status] = @ser_status WHERE [ser_id]="+ViewState["ser_id"], c);
            co.Parameters.AddWithValue("@ser_title", TextBox1.Text);
            co.Parameters.AddWithValue("@ser_description", TextBox2.Text);
            co.Parameters.AddWithValue("@ser_status", RadioButtonList1.SelectedValue);
            c.Open();
            int s = co.ExecuteNonQuery();
            c.Close();
            if (s == 1)
            {
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
                RadioButtonList1.ClearSelection();
                print();
                Button1.Text = "Insert";
                Response.Write("<script>alert('Service Updated successfully.')</script");
            }
            else
            {
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
                RadioButtonList1.ClearSelection();
                print();
                Button1.Text = "Insert";
                Response.Write("<script>alert('Error!.')</script");
            }
        }
    }
}