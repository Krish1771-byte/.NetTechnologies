using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Practical_4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                pnlResult.Visible = false;

                return;
            }
            lblName.Text =
                Server.HtmlEncode(txtName.Text.Trim());
            lblEmail.Text =
                Server.HtmlEncode(txtEmail.Text.Trim());
            lblContact.Text =
                Server.HtmlEncode(txtContact.Text.Trim());
            lblCollege.Text =
                Server.HtmlEncode(txtCollege.Text.Trim());

            string department = "Not Selected";

            if (rdoComputer.Checked)
            {
                department = "Computer";
            }
            else if (rdoMechanical.Checked)
            {
                department = "Mechanical";
            }
            else if (rdoChemical.Checked)
            {
                department = "Chemical";
            }
            else if (rdoCivil.Checked)
            {
                department = "Civil";
            }

            lblDepartment.Text = department;


            if (ddlEvent.SelectedIndex == 0)
            {
                lblEvent.Text = "Not Selected";
            }
            else
            {
                lblEvent.Text =
                    Server.HtmlEncode(
                        ddlEvent.SelectedItem.Text
                    );
            }


            string gender = "Not Selected";

            if (rdoMale.Checked)
            {
                gender = "Male";
            }
            else if (rdoFemale.Checked)
            {
                gender = "Female";
            }

            lblGender.Text = gender;



            List<string> skills = new List<string>();

            if (chkCSharp.Checked)
            {
                skills.Add("C#");
            }

            if (chkPython.Checked)
            {
                skills.Add("Python");
            }

            if (chkAI.Checked)
            {
                skills.Add("AI");
            }


            if (skills.Count > 0)
            {
                lblSkills.Text =
                    Server.HtmlEncode(
                        string.Join(", ", skills)
                    );
            }
            else
            {
                lblSkills.Text = "No Skill Selected";
            }


            string address =
                Server.HtmlEncode(
                    txtAddress.Text.Trim()
                );

            address = address
                .Replace("\r\n", "<br />")
                .Replace("\n", "<br />");

            lblAddress.Text = address;


            if (chkTerms.Checked)
            {
                lblTerms.Text = "Accepted";
            }
            else
            {
                lblTerms.Text = "Not Accepted";
            }


            pnlResult.Visible = true;
        }
    }
}