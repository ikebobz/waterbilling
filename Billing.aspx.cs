using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginForm;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Data;

public partial class Billing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (Request["Button2"] != null || clicked)
                dynamiclink();
        }
        else LoadOfficers();
       
    }
    static bool clicked = false;
    static Dictionary<string, string> officers = new Dictionary<string, string>();
    protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
    {
        Calendar1.Visible = true;
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        _date.Text = Calendar1.SelectedDate.ToShortDateString();
        Calendar1.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
         clicked = true;
		 history_grid.DataSource = null;
         history_grid.DataBind();
        //dynamiclink();
    }
    protected void Anchor_Click(object source, EventArgs e)
    {
        		
		LinkButton lnbtn = source as LinkButton;
        _ruid.Text = lnbtn.ID;
		_sname.Text = TextBox1.Text;
		_reading.Text = "";
	    _date.Text = "";
        string query = String.Format("select surname,firstname,othername,address,phone,email from resident where ruid='{0}'", lnbtn.ID);
        string query2 = String.Format("select surname,firstname,othername,meter_read,format(read_date,'dd-MMM-yyyy') as read_date from resident r inner join readings rs on r.ruid=rs.ruid where r.ruid='{0}'", lnbtn.ID);
        DataTable table = buffer.getTable(query2);
        List<object[]> set = buffer.getSet(query);
        if (set.Count == 0)
        {
            status.Text = "No record returned for given resident ID";
            status.Visible = true;
            return;
        }
        
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0} {1} {2}{3}{4}{5}(phone:) {6}{7}(email:) {8}", set[0][0], set[0][1], set[0][2],"<br/>",set[0][3], "<br/>", set[0][4],"<br/>", set[0][5]);
        details.InnerHtml = sb.ToString();
        if (table.Rows.Count == 0) return;
		history_grid.DataSource = table;
		history_grid.DataBind();
	    }

    protected void dynamiclink()
    {
        string query = String.Format("select ruid,surname,firstname,othername from resident where surname='{0}'", TextBox1.Text);
        List<object[]> set = buffer.getSet(query);
        if (set.Count == 0)
        {
            status.Text = "No record returned for given surname";
            status.Visible = true;
            return;
        }
        StringBuilder sb = new StringBuilder();
        foreach (object[] entry in set)
        {
            //sb.AppendFormat("<a style = 'color:blue' class='lnk' runat='server' id='{0}'  href = '#' onServerClick='Anchor_Click'>{1}:   {2}   {3}   {4}</a><br/>", entry[0], entry[0], entry[1], entry[2], entry[3]);
            LinkButton anc = new LinkButton();
			anc.ForeColor = System.Drawing.Color.DodgerBlue;
            anc.Click += Anchor_Click;
            anc.ID = entry[0].ToString();
            anc.PostBackUrl = "#";
            anc.Text = String.Format("{0}:   {1} {2} {3}", entry[0], entry[1], entry[2], entry[3]);
            links.Controls.Add(anc);
		}
        //links.InnerHtml = sb.ToString();
        status.Text = set.Count + " records were retrieved for specified surname";
        status.Visible = true;
    }
    protected void Update2_Click(object sender, EventArgs e)
    {
        string query = String.Format("insert into readings (ruid,sid,meter_read,read_date) values('{0}','{1}','{2}','{3}')", _ruid.Text, _sid.Text, _reading.Text, _date.Text);
        if (buffer.insertRecord(query))
        {
            status.Text = "Readings Update successful";
            status.Visible = true;
        }
        else
        {
            status.Text = "Failed";
            status.Visible = true;
        }
    }

     protected void LoadOfficers()
     {
         if (officers.Count > 0) officers.Clear();
         string query = "select surname,firstname,othername,sid from officer";
         List<object[]> set = buffer.getSet(query);
         if (set.Count == 0)
         {
             status.Text = "Could not retrive officer details";
             status.Visible = true;
             return;
         }
         foreach (object[] record in set)
         {
             string names = String.Format("{0} {1} {2}", record[0], record[1], record[2]);
             officers.Add(names, record[3].ToString());
             DropDownList1.Items.Add(names);
         }
     }

     protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
     {
         try
         {
             _sid.Text = officers[DropDownList1.SelectedItem.Value];
         }
         catch (Exception ex)
         {
             status.Text = ex.Message;
             status.Visible = true;
         }
     }
}