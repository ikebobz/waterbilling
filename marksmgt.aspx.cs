using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginForm;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using CrystalDecisions.ReportSource;
using System.Data;
using System.Data.OleDb;
using System.Configuration;


public partial class marksmgt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getparams();
            //rev_zone.Enabled = false;
        }
		
    }
    protected static ReportDocument dreport;

    [System.Web.Script.Services.ScriptMethodAttribute()]
    [System.Web.Services.WebMethodAttribute()]
    public static List<string> getResidents(string prefixText, int count)
    {
        List<string> names = new List<string>();
        string _path_to_db = HttpContext.Current.Server.MapPath(@"~/resultdb.accdb");
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _path_to_db);
        try
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandText = "select surname, firstname, othername from resident where surname like @search + '%'";
            cmd.Parameters.AddWithValue("@search",prefixText);
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                names.Add(rdr[0].ToString()+" "+rdr[1].ToString()+" "+rdr[2].ToString());
            }
        }
        catch (Exception ex)
        { 
        
        }
        con.Close();
        return names;
    
    }

    protected void chk_surname_CheckedChanged(object sender, EventArgs e)
    {
       if (chk_zone.Checked) chk_zone.Checked = false;
    }
    protected void chk_zone_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_surname.Checked) chk_surname.Checked = false;
    }
    protected void rev_chk_surname_CheckedChanged(object sender, EventArgs e)
    {
        if (rev_chk_zone.Checked) rev_chk_zone.Checked = false;
    }
    protected void rev_chk_zone_CheckedChanged(object sender, EventArgs e)
    {
        if (rev_chk_surname.Checked) rev_chk_surname.Checked = false;
    }

    protected void getparams()
    {
        string query = "select par_value from parameterz where par_name='rate'";
        List<object[]> set= buffer.getSet(query);
        if (set.Count == 0) return;
        string value=set[0][0].ToString();
        Decimal val = Decimal.Round(Convert.ToDecimal(value), 2);
        rate.Text = val.ToString();
    }
    protected void report_Click(object sender, EventArgs e)
    {
        if (chk_surname.Checked && surname.Text != ""&&date_begin.Text!=""&&date_end.Text!="")
        {
            string ruid = getId(surname.Text);
            ReportDocument doc = new ReportDocument();
            doc.Load(Server.MapPath(@"~/history_house.rpt"));
			doc.SetParameterValue("ruid",ruid);
            doc.SetParameterValue("start_date",date_begin.Text);
            doc.SetParameterValue("end_date",date_end.Text);
		    report_viewer.ReportSource = doc;
			
			//report_viewer.RefreshReport();
			//dreport = doc;
            
            
        }
        else if (chk_zone.Checked && zone.Text != "" && date_begin.Text != "" && date_end.Text != "")
        {
            //status.Text = "Please specify a resident full name";
            ReportDocument doc = new ReportDocument();
            doc.Load(Server.MapPath(@"~/zone_breakdown.rpt"));
            doc.SetParameterValue("zone",zone.Text);
            doc.SetParameterValue("start", date_begin.Text);
            doc.SetParameterValue("end", date_end.Text);
            report_viewer.ReportSource = doc;
			//report_viewer.RefreshReport();
            dreport = doc;
        }
        else if (chk_zone.Checked && zone.Text==""&&date_begin.Text != "" && date_end.Text != "")
        {
            ReportDocument doc = new ReportDocument();
            doc.Load(Server.MapPath(@"~/zone_history.rpt"));
            doc.SetParameterValue("START",date_begin.Text);
            doc.SetParameterValue("END",date_end.Text);
            report_viewer.ReportSource = doc;
            dreport = doc;
        }
    }

    protected string getId(string names)
    {
        string id = "";
        string[] res_names = names.Split(' ');
        string query = String.Format("select ruid from resident where surname='{0}' and firstname='{1}' and othername='{2}'",res_names[0],res_names[1],res_names[2]);
        List<object[]> result = buffer.getSet(query);
        id= result[0][0].ToString();
        return id;
    }
    protected void rev_report_Click(object sender, EventArgs e)
    {
        if (rev_chk_surname.Checked && rev_surname.Text != "" && rev_date_begin.Text != "" && rev_date_end.Text != "")
        {
            string ruid = getId(rev_surname.Text);
            ReportDocument doc = new ReportDocument();
            doc.Load(Server.MapPath(@"~/rev_house.rpt"));
            //dynamicLogon(doc);
            doc.SetParameterValue("ruid", ruid);
            doc.SetParameterValue("start_date", rev_date_begin.Text);
            doc.SetParameterValue("end_date", rev_date_end.Text);
            doc.SetParameterValue("rate", rate.Text);
            report_viewer.ReportSource = doc;
            dreport = doc;

        }

        else if (rev_chk_zone.Checked && rev_date_begin.Text != "" && rev_date_end.Text != "")
        {
            ReportDocument doc = new ReportDocument();
            doc.Load(Server.MapPath(@"~/rev_zone.rpt"));
            doc.SetParameterValue("START", rev_date_begin.Text);
            doc.SetParameterValue("END", rev_date_end.Text);
            doc.SetParameterValue("rate", rate.Text);
            report_viewer.ReportSource = doc;
            dreport = doc;
        
        }
    }
    protected void print_Click(object sender, EventArgs e)
    {
        if (dreport == null) return;
        dreport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "your_report");
        Response.End();
    }
    protected void dynamicLogon(ReportDocument doc)
    {
        ConnectionInfo info = new ConnectionInfo();
        info.ServerName = ConfigurationManager.AppSettings["server"];
        info.DatabaseName = "";
        info.UserID = ConfigurationManager.AppSettings["user"];
        info.Password = "";
        foreach(CrystalDecisions.CrystalReports.Engine.Table crtable in doc.Database.Tables)
        {
            TableLogOnInfo tableinfo = crtable.LogOnInfo;
            tableinfo.ConnectionInfo = info;
            crtable.ApplyLogOnInfo(tableinfo);
            
        
        }
    }
}