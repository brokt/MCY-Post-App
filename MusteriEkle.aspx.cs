using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            UserLoginControl();
    }
    private void UserLoginControl()
    {
        if (Session["k_id"] != null)
        { }
        else
            Response.Redirect("Login.aspx");
    }

    protected void btn_kaydet_Click(object sender, EventArgs e)
    {
        kaydet();
    }

    private void kaydet()
    {
        string insertText = "INSERT INTO TBL_MUSTERI (M_AD_SOYAD,M_CEP_TELEFON,M_EPOSTA,M_FIRMA_ADI,M_F_ID,M_K_ID) VALUES (@M_AD_SOYAD,@M_CEP_TELEFON,@M_EPOSTA,@M_FIRMA_ADI,@M_F_ID,@M_K_ID)";
        SqlCommand cmd = new SqlCommand(insertText, Config.conn);
        cmd.Parameters.AddWithValue("@M_AD_SOYAD", txt_adsoyad.Text).SqlDbType = SqlDbType.NVarChar;
        cmd.Parameters.AddWithValue("@M_CEP_TELEFON", txt_cepno.Text).SqlDbType = SqlDbType.Text;
        cmd.Parameters.AddWithValue("@M_EPOSTA", txt_eposta.Text).SqlDbType = SqlDbType.Text;
        cmd.Parameters.AddWithValue("@M_FIRMA_ADI", txt_firmaadi.Text).SqlDbType = SqlDbType.Text;
        cmd.Parameters.AddWithValue("@M_F_ID", Session["f_id"]).SqlDbType = SqlDbType.Int;
        cmd.Parameters.AddWithValue("@M_K_ID", Session["k_id"]).SqlDbType = SqlDbType.Int;
        try
        {
            Config.conn.Open();
            cmd.ExecuteNonQuery();
            lbl_bilgilendirme.Text = "Kayıt başarılı şekilde eklendi.";
        }
        catch
        {
            lbl_bilgilendirme.Text = "Hata oluştu. Veri alanlarını kontrol ediniz.";
        }
        finally
        {
            Config.conn.Close();
        }
    }
}