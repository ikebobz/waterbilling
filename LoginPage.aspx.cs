using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using LoginForm;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            list1.Items.Clear();
            string[] roles = new string[3] { "admin", "officer", "adviser" };
            foreach (string item in roles) list1.Items.Add(item);
        }
        
    }
    string privilege;
    private bool testCredentials(out string role)
    {
        role = "";
        bool success = false;
        string _path_to_db = Server.MapPath(@"~/resultdb.accdb");
        OleDbConnection con = new OleDbConnection();
        con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+_path_to_db;
        try
        {
            con.Open();
            OleDbCommand com = con.CreateCommand();
            com.CommandText = String.Format("select user_id,user_pass,user_role from users where user_id='{0}'", uid.Text);
            OleDbDataReader reader = com.ExecuteReader();
            if (!reader.HasRows)
            {
                role = "Invalid Username";
                return success;
            }

             reader.Read();
             string pass = reader[1].ToString();
            
            //role = reader[2].ToString();
            if (pass != this.pass.Text) 
            { 
              role = "Invalid password"; 
              return success; 
            }
            privilege = reader[2].ToString();
            success = true;
        }
        catch(Exception ex)
        {
            role = ex.Message;
        }
        con.Close();
        return success;

    }
   
    protected void logbtn_Click(object sender, EventArgs e)
    {
        string feedback="";
        if(testCredentials(out feedback))
        {
            Session["role"] = privilege;
            Response.Redirect("Home.aspx");
            
        }
        else
        {
            buffer.error = feedback;
            Response.Redirect("ErrorPage.aspx");
        }
    }
}