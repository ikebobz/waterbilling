using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginForm;
using System.Text;
using System.Data;

public partial class CourseInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
           if (!IsPostBack)
            status.Visible = false;
    }
    public void Update_Click(object src, EventArgs ev)
    {
        Random r = new Random();
        string sid = "SP" + r.Next(0, 99);
        string query = String.Format("insert into officer(sid,surname,firstname,othername,phone) values('{0}','{1}','{2}','{3}','{4}')", sid, _sname.Text, _fname.Text, _oname.Text, _phone.Text);
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
    public void Button1_Click(object src, EventArgs ev)
    {
        string query = String.Format("select * from officer where sid='{0}'", sub_code.Text);
        DataTable result = buffer.getTable(query);
        if (result.Rows.Count == 0) 
        {
        gridcontainer2.InnerHtml = emptyTable();
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
        gridcontainer2.InnerHtml = sb.ToString();
        status.Text = result.Rows.Count+" records were found for specified information";
        status.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string query = String.Format("select * from officer where surname='{0}'", TextBox1.Text);
        DataTable result = buffer.getTable(query);
        if (result.Rows.Count == 0)
        {
            gridcontainer2.InnerHtml = emptyTable();
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
        gridcontainer2.InnerHtml = sb.ToString();
        status.Text = result.Rows.Count + " records were found for specified information";
        status.Visible = true;
    }
    private string emptyTable()
    {
        string result = "<table><tr><th>SID</th><th>SURNAME</th><th>FIRSTNAME</th><th>OTHERNAME</th><th>PHONE</th></tr></table>";
        return result;
    }
}