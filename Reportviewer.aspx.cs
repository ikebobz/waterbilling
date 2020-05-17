using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.Data;
using LoginForm;

public partial class Reportviewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
            CrystalReportViewer1.ReportSource = buffer.doc;
            CrystalReportViewer1.DataBind();
            CrystalReportViewer1.DisplayGroupTree = false;
           
        
            
    }
    protected void bgenerate_Click(object sender, EventArgs e)
    {

        if (buffer.isMark)
        {
            CrystalReportViewer1.ReportSource = null;
            ReportDocument doc = new ReportDocument();
            doc.Load(@"D:\transcript.rpt");
            string qry = "SELECT s.surname + ' ' + s.firstname + ' ' + s.middlename AS name, c.course_title,c.credit_units,s.matno, m.exam_score, m.test_score, m.assignment_score FROM ((marks m INNER JOIN student s ON m.matno = s.matno) INNER JOIN course c ON m.course_id = c.course_code) WHERE (s.matno ='" + imatno.Text + "') AND (m.sessn ='" + isession.Text + "') AND (c.semester_no=" + isemester.Text + ")";
            DataTable tab = buffer.getTable(qry);
            double gpa = buffer.getGPA(tab, 2, 4, 5, 6);
            doc.SetDataSource(tab);
            doc.SetParameterValue("cgpa", gpa);
            buffer.doc = doc;
            CrystalReportViewer1.ReportSource = doc;
        }
        else
        {
            CrystalReportViewer1.ReportSource = null;
            ReportDocument doc = new ReportDocument();
            doc.Load(@"D:\transcript2.rpt");
            string qry = "SELECT s.surname + ' ' + s.firstname + ' ' + s.middlename AS name, c.course_title,c.credit_units,c.semester_no,m.sessn,s.matno, m.exam_score, m.test_score, m.assignment_score FROM ((marks m INNER JOIN student s ON m.matno = s.matno) INNER JOIN course c ON m.course_id = c.course_code) WHERE (s.matno ='" + imatno.Text + "')";
            DataTable tab = buffer.getTable(qry);
            double cgpa = buffer.getGPA(tab, 2, 6, 7, 8);
            doc.SetDataSource(tab);
            doc.SetParameterValue("cumulative", cgpa);
            buffer.doc = doc;
            Response.Redirect("reportviewer.aspx");
        
        }
      
    }

    protected void btnexp_Click(object sender, EventArgs e)
    {
        Response.Buffer = false;
        Response.Clear();
        Response.ClearHeaders();
        buffer.doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true,buffer.docTitle);
    }
}