using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
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

    }
}