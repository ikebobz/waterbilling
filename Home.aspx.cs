using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginForm;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) testRoles();
    }
    private void testRoles()
    {
        if (Session["role"].ToString() == "officer")
        {
            useracc.HRef = "javascript:void(0)";
        }
        else
        if (Session["role"].ToString() == "admin")
       {
           student.HRef="javascript:void(0)";
           subject.HRef="javascript:void(0)";
           score.HRef = "javascript:void(0)";
          
       }
     
    
    }
}