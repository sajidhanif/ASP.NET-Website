using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_Login_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FormzConnectionString"].ConnectionString);
        conn.Open();


        string checkuser = "select count(*) from UserData where UserName='" + TextBoxLoginUN.Text + "'";

        SqlCommand com = new SqlCommand(checkuser, conn);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        conn.Close();
        if (temp == 1)
        {
            conn.Open();
            string checkPasswordQuery = "select password from UserData where UserName='" + TextBoxLoginUN.Text + "'";
            SqlCommand passComm = new SqlCommand(checkPasswordQuery, conn);
            string password = passComm.ExecuteScalar().ToString().Replace(" ","");
            if (password == TextBoxLoginP.Text)
            {
                Session["New"] = TextBoxLoginUN.Text;
                Response.Write("Password is correct");
                Response.Redirect("users.aspx");
            }
            else
            {
                Response.Write("Password is in-correct");
            }

        }
        else {
            Response.Write("User Name is in-correct");
        }


    }
}