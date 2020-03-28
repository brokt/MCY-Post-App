using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;
using System.Xml;
using System.Net.Sockets;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            UserLoginControl();
        NumaraListesiniDoldur();
    }
    private void UserLoginControl()
    {
        if (Session["k_id"] != null)
        { }
        else
            Response.Redirect("Login.aspx");
    }

    private void NumaraListesiniDoldur()
    {
        SqlCommand commlistbox = new SqlCommand("SELECT * FROM TBL_MUSTERI WHERE M_K_ID='" + Session["k_id"] + "' AND M_F_ID='" + Session["f_id"] + "' ORDER BY M_AD_SOYAD", Config.conn);
        commlistbox.Connection.Open();
        SqlDataReader listboxread =
        commlistbox.ExecuteReader();
        while (listboxread.Read())
        {
            lb_tum_numaralar_id.Items.Add(listboxread[0].ToString());
            lb_tum_numaralar.Items.Add(listboxread[1].ToString());

        }
        commlistbox.Connection.Close();
    }

    public static string secilmisID = "";
    protected void lb_tum_numaralar_SelectedIndexChanged(object sender, EventArgs e)
    {
        lb_tum_numaralar_id.SelectedIndex = lb_tum_numaralar.SelectedIndex;
        txt_secilmis_id.Text = lb_tum_numaralar_id.SelectedItem.ToString();
        secilmisID = txt_secilmis_id.Text;

        DDL_Kullanici();
        AlanlariDoldur();

        lb_tum_numaralar.Items.Clear();
        lb_tum_numaralar_id.Items.Clear();
        NumaraListesiniDoldur();
    }

    private void AlanlariDoldur()
    {
        String vericek = "SELECT * FROM TBL_MUSTERI WHERE M_ID = '" + secilmisID + "' AND M_F_ID='" + Session["f_id"] + "'";
        SqlCommand comm = new SqlCommand(vericek, Config.conn);
        comm.Parameters.AddWithValue("M_AD_SOYAD", txt_adsoyad.Text).SqlDbType = SqlDbType.NVarChar;
        comm.Parameters.AddWithValue("M_CEP_TELEFON", txt_cepno.Text).SqlDbType = SqlDbType.NVarChar;
        comm.Parameters.AddWithValue("M_EPOSTA", txt_eposta.Text).SqlDbType = SqlDbType.NVarChar;
        comm.Parameters.AddWithValue("M_FIRMA_ADI", txt_firmaadi.Text).SqlDbType = SqlDbType.NVarChar;

        Config.conn.Open();
        SqlDataReader verioku = comm.ExecuteReader();
        try
        {
            while (verioku.Read())
            {
                txt_adsoyad.Text = verioku["M_AD_SOYAD"].ToString();
                txt_cepno.Text = verioku["M_CEP_TELEFON"].ToString();
                txt_eposta.Text = verioku["M_EPOSTA"].ToString();
                txt_firmaadi.Text = verioku["M_FIRMA_ADI"].ToString();
            }
        }
        finally
        {
            verioku.Close();
            Config.conn.Close();
        }
        secilmisID = "";
    }

    private void DDL_Kullanici()
    {
        SqlDataReader ddDR = null;
        SqlCommand ddSqlCommand = new SqlCommand("SELECT * FROM TBL_KULLANICI WHERE K_F_ID='" + Session["f_id"] + "'", Config.conn);
        Config.conn.Open();
        ddDR = ddSqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        ddl_kullanici_adi.DataSource = ddDR;
        ddl_kullanici_adi.DataTextField = "K_KULLANICI_ADI";
        ddl_kullanici_adi.DataValueField = "K_ID";
        ddl_kullanici_adi.DataBind();
        Config.conn.Close();
    }

    private void DDL_Kullanici_Secili_Getir()
    { 
        
    }

    protected void btn_sil_Click(object sender, EventArgs e)
    {
        Sil();

        txt_secilmis_id.Text = "";
        txt_firmaadi.Text = "";
        txt_eposta.Text = "";
        txt_cepno.Text = "";
        txt_adsoyad.Text = "";
        ddl_kullanici_adi.Items.Clear();
        lb_tum_numaralar.Items.Clear();
        lb_tum_numaralar_id.Items.Clear();
        NumaraListesiniDoldur();
        secilmisID = "";
    }

    private void Sil()
    {
        string VeriSil = "DELETE FROM TBL_MUSTERI WHERE M_ID ='" + txt_secilmis_id.Text + "'";
        SqlCommand cmd = new SqlCommand(VeriSil, Config.conn);
        try
        {
            Config.conn.Open();
            cmd.ExecuteNonQuery();
            lbl_bilgilendirme.Text = "Müşteri bilgileri silindi.";
        }
        catch (Exception hata)
        {
            lbl_bilgilendirme.Text = hata.ToString();
        }
        finally
        {
            Config.conn.Close();
        }
    }
}