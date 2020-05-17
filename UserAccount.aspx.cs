using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginForm;

public partial class UserAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            status.Visible = false;
            ddl.Items.Clear();
            string[] roles = new string[3] { "admin", "officer", "Manager" };
            foreach (string item in roles) ddl.Items.Add(item);
            ddl.SelectedIndex = 0;
        }
    }
    public void Update_Click(object source, EventArgs ev)
    {

        if (chk1.Checked)
        {
            string delete = String.Format("delete from users where user_id='{0}'", user.Text);
            if (buffer.insertRecord(delete))
            {
                status.Text = "Delete successful";
                status.Visible = true;
            }
            else
            {
                status.Text = "Delete Failed";
                status.Visible = true;
            }
            return;
        }
       string query = String.Format("insert into users(surname,firstname,user_id,user_pass,user_role) values ('{0}','{1}','{2}','{3}','{4}')", sname.Text, fname.Text, user.Text, pass.Text, ddl.SelectedItem);
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
    public void Button1_Click(object source, EventArgs ev)
    {
        string query = String.Format("select user_id,user_pass,user_role from users where surname ='{0}'", TextBox1.Text);
        List<object[]> result = buffer.getSet(query);
        if (result.Count == 0) { status.Text = "No records were found for specified information"; status.Visible = true; return; }
        
        uname.InnerText = TextBox1.Text;
        upass.InnerText = result[0][1].ToString();
        urole.InnerText = result[0][2].ToString();
        status.Text = "1 records were found for specified information";
        status.Visible = true;
    }

    protected void chk1_CheckedChanged(object sender, EventArgs e)
    {
        if (chk1.Checked)
        {
            pass.Enabled = false;
            ddl.Enabled = false;
        }
        else
        {
            pass.Enabled = true;
            ddl.Enabled = true;
        }
    }
}