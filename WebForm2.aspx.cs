using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practical_5
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check whether Employee Name is available in cookies
                if (Request.Cookies["EmpName"] != null)
                {
                    TextBox3.Text = Request.Cookies["EmpName"].Value;
                }

                // Get selected Leave Date from Session
                if (Session["leaveDate"] != null)
                {
                    DateTime lvDate = (DateTime)Session["leaveDate"];

                    lblleaveDate.Text = lvDate.ToString("dd-MM-yyyy");
                }
                else
                {
                    lblleaveDate.Text = "No Date Selected.......";
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Leave Type selection
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Remember Employee Name using Cookie

            if (CheckBox1.Checked)
            {
                Response.Cookies["EmpName"].Value = TextBox3.Text;
                Response.Cookies["EmpName"].Expires =
                    DateTime.Now.AddDays(7);
            }
            else
            {
                Response.Cookies["EmpName"].Expires =
                    DateTime.Now.AddDays(-1);
            }
        }

        protected void Btnsubmit_Click(object sender, EventArgs e)
        {
            // Submit Leave button

            string empnm = TextBox3.Text;
            string leavetype = DropDownList1.SelectedValue;
            string reason = TextBox2.Text;

            // Store Employee Name, Leave Type and Reason in Session
            Session["Empnm"] = empnm;
            Session["leaveType"] = leavetype;
            Session["Reason"] = reason;

            // Create Cookie if Checkbox is Selected
            if (CheckBox1.Checked)
            {
                Response.Cookies["EmpName"].Value = empnm;
                Response.Cookies["EmpName"].Expires =
                    DateTime.Now.AddDays(7);
            }

            lblMsg.Text = "<b>Leave Submitted Successfully.......</b><br/>" +
                "Employee Name: " + empnm + "<br/>" +
                "Leave Type: " + leavetype + "<br/>" +
                "Reason: " + reason;
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}