using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week7codingAsp.net
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnaddnew_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HRCon"].ConnectionString);
            SqlCommand cmdobj = new SqlCommand("InsertPosition", con);
            cmdobj.CommandType = System.Data.CommandType.StoredProcedure;
            cmdobj.Parameters.AddWithValue("@cpositioncode", txtpositioncode.Text);
            cmdobj.Parameters.AddWithValue("@vdescription", txtdescription.Text);
            cmdobj.Parameters.AddWithValue("@iBudgetedStrength", txtbudgetedstrength.Text);
            cmdobj.Parameters.AddWithValue("@siYear", ddlyear.SelectedValue);
            cmdobj.Parameters.AddWithValue("@iCurrentStrength", txtcurrentstrength.Text);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            int res = cmdobj.ExecuteNonQuery();
            if (res > 0)
            {
                lblmessage.Text = "product created successfully";
            }
            cmdobj.Dispose();
            con.Close();

        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            txtpositioncode.Text = "";
            txtdescription.Text = "";
            ddlyear.Text = "";
            txtbudgetedstrength.Text = "";
            txtcurrentstrength.Text = "";
            lblmessage.Text = "";

        }
    }
}