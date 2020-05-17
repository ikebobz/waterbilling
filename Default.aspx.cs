using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LoginForm;
using System.Text;
using System.IO;
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        status.Visible = false;
    }
    protected void Update_Click(object sender, EventArgs e)
    {
        Random r = new Random();
        string ruid = "WDR" + r.Next(0, 999);
        //string getrec = String.Format("select * from resident where ruid='{0}'", ruid);
        //List<object[]> entry = buffer.getSet(getrec);
        string query = String.Format("insert into resident(ruid,surname,firstname,othername,address,phone,email,[zone]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",ruid, _sname.Text, _fname.Text, _oname.Text, _addr.Text, _phone.Text, _email.Text,_zone.Text);
        if (buffer.insertRecord(query))
        {
            status.Text = "Update successful";
            status.Visible = true;
        }
        else
        {
            status.Text = "Failed";
            status.Visible = true;
        }
  
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string query = String.Format("select ruid,surname,firstname,othername,address,phone,email from resident where ruid='{0}'", TextBox1.Text);
        DataTable result = buffer.getTable(query);
        if (result.Rows.Count == 0)
        {
            gridcontainer.InnerHtml = emptyTable();
            status.Text = "No records were found for specified information";
            status.Visible = true;
            return;
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("<table><tr>");
        foreach (DataColumn col in result.Columns)
            sb.AppendFormat("<th>{0}</th>", HttpUtility.HtmlEncode(col.ColumnName));
        sb.Append("</tr>");
        foreach (DataRow row in result.Rows)
        {
            sb.Append("<tr>");
            foreach (DataColumn col in result.Columns)
                sb.AppendFormat("<td>{0}</td>", HttpUtility.HtmlEncode(row[col.ColumnName]));
            sb.Append("</tr>");
        }
        sb.Append("</table>");
        gridcontainer.InnerHtml = sb.ToString();
        status.Text = result.Rows.Count + " records were found for specified information";
        status.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string query = String.Format("select ruid,surname,firstname,othername,address,phone,email from resident where surname='{0}'", TextBox2.Text);
        DataTable result = buffer.getTable(query);
        if (result.Rows.Count == 0)
        {
            gridcontainer.InnerHtml = emptyTable();
            status.Text = "No records were found for specified information";
            status.Visible = true;
            return;
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("<table><tr>");
        foreach (DataColumn col in result.Columns)
            sb.AppendFormat("<th>{0}</th>", HttpUtility.HtmlEncode(col.ColumnName));
        sb.Append("</tr>");
        foreach (DataRow row in result.Rows)
        {
            sb.Append("<tr>");
            foreach (DataColumn col in result.Columns)
            sb.AppendFormat("<td>{0}</td>", HttpUtility.HtmlEncode(row[col.ColumnName]));
            sb.Append("</tr>");
        }
        sb.Append("</table>");
        gridcontainer.InnerHtml = sb.ToString();
        status.Text = result.Rows.Count+" records were found for specified information";
        status.Visible = true;
    }
    private string emptyTable()
    {
        string result = "<table><tr><th>RUID</th><th>SURNAME</th><th>FIRSTNAME</th><th>OTHERNAME</th><th>ADDRESS</th><th>PHONE</th><th>EMAIL</th></tr></table>";
        return result;
    }
}