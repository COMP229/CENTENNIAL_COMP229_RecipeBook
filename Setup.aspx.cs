using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Setup : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        String theme = "Light";

        if (Request.Cookies["Theme"] != null)
        {
            theme = Server.HtmlEncode(Request.Cookies["Theme"].Value);
        }

        Page.Theme = theme;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Theme"] != null && !IsPostBack)
        {
            if (Server.HtmlEncode(Request.Cookies["Theme"].Value) == "Dark")
            {
                rdbDark.Checked = true;
            }
        }
    }

    protected void btnChange_Click(object sender, EventArgs e)
    {
        String theme = "Light";

        if (rdbDark.Checked)
        {
            theme = "Dark";
        }

        Response.Cookies["Theme"].Value = theme;
        Response.Cookies["Theme"].Expires = DateTime.Now.AddDays(30);

        Response.Redirect("Setup.aspx");
    }
}