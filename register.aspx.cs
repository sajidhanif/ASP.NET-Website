using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FormzConnectionString"].ConnectionString);
            conn.Open();

            
            string checkuser = "select count(*) from UserData where UserName='" + TextBoxUN.Text + "'";

            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if(temp == 1)
            {
                Response.Write("User Name Already Exists in Database");
            }

           
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       

        try
        {

            Guid newGUID = Guid.NewGuid();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FormzConnectionString"].ConnectionString);
            conn.Open();

            string insertQuery = "insert into UserData (ID,UserName,Email,Password,Age) values(@ID ,@Uname ,@email , @password , @age)";

            SqlCommand com = new SqlCommand(insertQuery, conn);

            com.Parameters.AddWithValue("@ID", newGUID.ToString());
            com.Parameters.AddWithValue("@Uname", TextBoxUN.Text);
            com.Parameters.AddWithValue("@email", TextBoxE.Text);
            com.Parameters.AddWithValue("@password", TextBoxP.Text);
            com.Parameters.AddWithValue("@age", DropDownList1.SelectedItem.ToString());

            com.ExecuteNonQuery();
            Response.Redirect("manager.aspx");
            Response.Write("You have sucessfully Registered");


            conn.Close();
        }
        catch(Exception ex)
        {
            Response.Write("Error:"+ex.ToString());
        }

    }
}