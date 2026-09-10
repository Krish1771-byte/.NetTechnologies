using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practical_5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calAcademic(object sender, EventArgs e)
        {
            DateTime selectDT = Calendar1.SelectedDate;

            lblselectDate.Text = "You have selected " +
                selectDT.ToString("dd-MM-yyyy");

            // Store selected date in session
            Session["leaveDate"] = selectDT;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Leave Apply Button
            Response.Redirect("WebForm2.aspx");
        }
    }
}