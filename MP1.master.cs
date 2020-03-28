using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Logo_vericek();
    }

    private void Logo_vericek()
    {
        SqlDataAdapter adaptor1 = new SqlDataAdapter("SELECT TOP 1 * FROM TBL_FIRMA WHERE F_ID='" + Session["f_id"] + "' ", Config.conn);
        DataTable tablo1 = new DataTable();
        adaptor1.Fill(tablo1);
        DL_Logo.DataSource = tablo1;
        DL_Logo.DataBind();
        DL_Header.DataSource = tablo1;
        DL_Header.DataBind();
    }
}
