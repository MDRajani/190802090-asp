using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Default2 : System.Web.UI.Page
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        print();
        //DeleteCommand="DELETE FROM [categories] WHERE [c_id] = @c_id" 
        //InsertCommand="INSERT INTO [categories] ([c_name], [c_status]) VALUES (@c_name, @c_status)" 
        //ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
        //SelectCommand="SELECT [c_id], [c_name], [c_status] FROM [categories]" 
        //UpdateCommand="UPDATE [categories] SET [c_name] = @c_name, [c_status] = @c_status WHERE [c_id] = @c_id"
    }
    public void print()
    {
        SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM [categories]",c);
        DataTable d = new DataTable();
        a.Fill(d);
        GridView1.DataSource=d;
        GridView1.DataBind();
    }
    public void clear()
    {
        TextBox3.Text = String.Empty;
        RadioButtonList1.ClearSelection();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Update")
        {
            SqlCommand co = new SqlCommand("UPDATE [categories] SET [c_name] = @c_name, [c_status] = @c_status WHERE [c_id] = "+ViewState["id"], c);
            co.Parameters.AddWithValue("@c_name", TextBox3.Text);
            co.Parameters.AddWithValue("@c_status", RadioButtonList1.SelectedValue);
            c.Open();
            int result = co.ExecuteNonQuery();
            c.Close();
            if (result == 1)
            {
                Response.Write("<script>alert('Data Updated Successfully.')</script>");
                Button1.Text = "Insert";
                clear();
                print();
            }
            else
            {
                Response.Write("<script>alert('Error updating data..')</script>");
                clear();
                print();
            }
        }
        else
        {
            SqlCommand co = new SqlCommand("INSERT INTO [categories] ([c_name], [c_status]) VALUES (@c_name, @c_status)", c);
            co.Parameters.AddWithValue("@c_name", TextBox3.Text);
            co.Parameters.AddWithValue("@c_status", RadioButtonList1.SelectedValue);
            c.Open();
            int result = co.ExecuteNonQuery();
            c.Close();
            if (result == 1)
            {
                Response.Write("<script>alert('Data Inserted Successfully.')</script>");
                clear();
                print();
            }
            else
            {
                Response.Write("<script>alert('Error inserting category..')</script>");
                clear();
                print();
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Button btn=(Button)sender;
        SqlCommand co = new SqlCommand("DELETE FROM [categories] WHERE [c_id] = "+btn.CommandArgument, c);
        c.Open();
        int result = co.ExecuteNonQuery();
        c.Close();
        if (result == 1)
        {
            Response.Write("<script>alert('Data deleted Successfully.')</script>");
            print();
        }
        else
        {
            Response.Write("<script>alert('Error inserting category..')</script>");
            print();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        SqlDataAdapter a = new SqlDataAdapter("SELECT [c_id], [c_name], [c_status] FROM [categories] WHERE [c_id]=" + btn.CommandArgument, c);
        DataTable d = new DataTable();
        a.Fill(d);
        TextBox3.Text = d.Rows[0][1].ToString();
        RadioButtonList1.SelectedValue = d.Rows[0][2].ToString();
        ViewState["id"] = btn.CommandArgument;
        Button1.Text = "Update";
    }
}