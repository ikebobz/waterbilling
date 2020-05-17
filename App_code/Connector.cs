using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

/// <summary>
/// Summary description for Connector
/// </summary>
public class Connector
{
	public Connector()
	{
	
	}
    private string connectstring = "data source=spooler;initialcatalog=development;integrated security=sspi;id=ikenna;password=''";

    public DataTable getSet(string query,out string err)
    {
        DataTable table = null;
        SqlConnection con = new SqlConnection(connectstring);
        try
        {
            con.Open();
            SqlDataAdapter dptr = new SqlDataAdapter(query, con);
            dptr.Fill(table);
            err = "Success on table populating";
        }
        catch (Exception ex)
        {
            err = ex.Message;
        
        }
        return table;
    
    }
    public void insertSet(string query, out string err)
    {
        err = "";
        SqlConnection con = new SqlConnection(connectstring);
        try
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.ExecuteNonQuery();
            err = "Success on insert";
        }
        catch (Exception ex)
        {
            err = ex.Message;
        }
    }
}