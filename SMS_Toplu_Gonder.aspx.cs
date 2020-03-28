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
        {
            UserLoginControl();
            NumaraListesiniDoldur();
        }
    }
    private void UserLoginControl()
    {
        if (Session["k_id"] != null)
        { }
        else
            Response.Redirect("Login.aspx");
    }

    string sb_kull = "";
    string sb_paro = "";
    string sb_isim = "";
    private void SunucuBilgileri()
    {
        String vericek = "SELECT * FROM TBL_SUNUCU WHERE S_F_ID= '" + Session["f_id"] + "'";
        SqlCommand comm = new SqlCommand(vericek, Config.conn);
        comm.Parameters.AddWithValue("S_SMS_K_ADI", sb_kull).SqlDbType = SqlDbType.NVarChar;
        comm.Parameters.AddWithValue("S_SMS_PAROLA", sb_paro).SqlDbType = SqlDbType.NVarChar;
        comm.Parameters.AddWithValue("S_SMS_ISIM", sb_isim).SqlDbType = SqlDbType.NVarChar;
        Config.conn.Open();
        SqlDataReader verioku = comm.ExecuteReader();
        try
        {
            while (verioku.Read())
            {
                sb_kull = verioku["S_SMS_K_ADI"].ToString();
                sb_paro = verioku["S_SMS_PAROLA"].ToString();
                sb_isim = verioku["S_SMS_ISIM"].ToString();
            }
        }
        finally
        {
            verioku.Close();
            Config.conn.Close();
        }
    }

    protected void imageField_Click(object sender, ImageClickEventArgs e)
    {
        SunucuBilgileri();

        string dongu_numaralari = "";
        foreach (ListItem satir in lb_gonderilecek_numaralar.Items)
        {
            dongu_numaralari = dongu_numaralari + "," + satir.Value;
        }

        txt_gonderilecek_numaralar.Text = dongu_numaralari;

        string telnumaralar;
        string smsmesaji;
        smsmesaji = resim1_karakterIslemleri(txt_mesaj.Text);
        telnumaralar = txt_gonderilecek_numaralar.Text;

        try
        {
            // Kullanici adi, parola ve Originator kullanilarak bir sms paketi olusturulur.
            SMSPaketi smspak = new SMSPaketi(sb_kull, sb_paro, sb_isim);

            // eger ileri tarihli sms gonderilecekse tarh parametreli asagidai Consturctor kullanilabilir
            // ornek: 2010-11-20 saat 19:30:00 'da gonder
            //SMSPaketi smspak = new SMSPaketi("username","password","SMSBASLIK", new DateTime(2010,11,20,19,30,0));

            // mesajin gidecegi numaralar bir array'e doldurulur
            // numara formati onemli degildir, bosluklu parantezli, sifirli, sifirsiz, +90li vs olabilir
            String[] numaralar = { telnumaralar };

            // gidecek mesaj metni ve numaralar pakaete eklenir. 
            // bu sekilde bir sms paketine birden fazla mesaj eklenebilir
            smspak.addSMS(smsmesaji, numaralar);

            // sonuc eger mesaj basarili ise # ile baslayan bir mesaj ID'dir. 
            // bir hata olusmussa XML dokumaninda belirtilen hata kodlarindan biri doner
            String sonuc = smspak.gonder();
            lbl_bilgilendirme.Text = sonuc;
            //MessageBox.Show( sonuc );

            //Raporun cekilmesi
            // rapor kullanici adi, parola ve mesaj gonderme isleminde sonuc olarak donen 
            // message ID ile cekilir. XML dokumaninda belirtilen formatta doner

            int paketID = Convert.ToInt32(sonuc.Replace("$", ""));
            String rapor = SMSPaketi.rapor(sb_kull, sb_paro, paketID);
            lbl_rapor.Text = rapor;

            //MessageBox.Show( rapor );
        }
        catch (Exception ex)
        {
            lbl_bilgilendirme.Text = "Hata: " + ex;
        }
    }

    public string resim1_karakterIslemleri(string DosyaAdiDuzenle)
    {
        DosyaAdiDuzenle = DosyaAdiDuzenle.Replace("ğ", "g");
        DosyaAdiDuzenle = DosyaAdiDuzenle.Replace("ş", "s");
        DosyaAdiDuzenle = DosyaAdiDuzenle.Replace("ö", "o");
        DosyaAdiDuzenle = DosyaAdiDuzenle.Replace("ı", "i");
        DosyaAdiDuzenle = DosyaAdiDuzenle.Replace("I", "i");
        DosyaAdiDuzenle = DosyaAdiDuzenle.Replace("ç", "c");
        //DosyaAdiDuzenle = DosyaAdiDuzenle.Replace(" ", "_");
        DosyaAdiDuzenle = DosyaAdiDuzenle.Replace("Ğ", "g");
        DosyaAdiDuzenle = DosyaAdiDuzenle.Replace("Ş", "s");
        DosyaAdiDuzenle = DosyaAdiDuzenle.Replace("Ö", "o");
        DosyaAdiDuzenle = DosyaAdiDuzenle.Replace("İ", "i");
        DosyaAdiDuzenle = DosyaAdiDuzenle.Replace("Ç", "c");
        DosyaAdiDuzenle = DosyaAdiDuzenle.Replace("Ü", "u");
        DosyaAdiDuzenle = DosyaAdiDuzenle.Replace("ü", "u");
        return DosyaAdiDuzenle;
    }

    public class SMSPaketi
    {
        public SMSPaketi(String ka, String parola, String org)
        {
            start += "<smspack ka=\"" + xmlEncode(ka) + "\" pwd=\"" + xmlEncode(parola)
                + "\" org=\"" + xmlEncode(org) + "\">";

        }

        public SMSPaketi(String ka, String parola, String org, DateTime tarih)
        {
            start += "<smspack ka=\"" + xmlEncode(ka) + "\" pwd=\"" + xmlEncode(parola) +
                "\" org=\"" + xmlEncode(org) + "\" tarih=\"" + tarihStr(tarih) + "\">";

        }

        public void addSMS(String mesaj, String[] numaralar)
        {
            body += "<mesaj><metin>";
            body += xmlEncode(mesaj);
            body += "</metin><nums>";
            foreach (String s in numaralar)
            {
                body += xmlEncode(s) + ",";
            }
            body += "</nums></mesaj>";
        }

        public String xml()
        {
            if (body.Length == 0)
                throw new ArgumentException("SMS paketinede sms yok!");
            return start + body + end;
        }

        public String gonder()
        {
            WebClient wc = new WebClient();

            string postData = xml();
            wc.Headers.Add("Content-Type", "text/xml; charset=ISO-8859-9");
            // Apply ASCII Encoding to obtain the string as a byte array.
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            byte[] responseArray = wc.UploadData("http://ws.smster.net/xmlpost/sms.do", "POST", byteArray);
            String response = Encoding.ASCII.GetString(responseArray);
            return response;
        }

        /**
         * ka = kullanici adi
         * parola
         * id: gonderim sonucu donen paket ID
         * 
         */

        public static String rapor(String ka, String parola, long id)
        {
            String xml = "<?xml version=\"1.0\" encoding=\"iso-8859-9\"?>" +
                "<smsrapor ka=\"" + ka + "\" pwd=\"" + parola + "\" id=\"" + id + "\" />";
            WebClient wc = new WebClient();
            //MessageBox.Show(xml);
            string postData = xml;
            wc.Headers.Add("Content-Type", "text/xml; charset=ISO-8859-9");
            // Apply ASCII Encoding to obtain the string as a byte array.
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            byte[] responseArray = wc.UploadData("http://ws.smster.net/xmlpost/rapor.do", "POST", byteArray);
            String response = Encoding.ASCII.GetString(responseArray);
            return response;
        }

        private static String tarihStr(DateTime d)
        {
            return xmlEncode(d.ToString("yyyy-MM-dd HH:mm"));
        }

        private static String xmlEncode(String s)
        {
            s = s.Replace("&", "&amp;");
            s = s.Replace("<", "&lt;");
            s = s.Replace(">", "&gt;");
            s = s.Replace("'", "&apos;");
            s = s.Replace("\"", "&quot;");
            return s;
        }

        private String start = "<?xml version=\"1.0\" encoding=\"iso-8859-9\"?>";
        private String end = "</smspack>";
        private String body = "";
    }

    protected void lb_tum_numaralar_SelectedIndexChanged(object sender, EventArgs e)
    {

        lb_tum_numaralar_id.SelectedIndex = lb_tum_numaralar.SelectedIndex;
        lb_tum_numaralar_no.SelectedIndex = lb_tum_numaralar.SelectedIndex;

        txt_secilmis_id.Text = lb_tum_numaralar_id.SelectedItem.ToString();
        txt_secilmis_no.Text = lb_tum_numaralar_no.SelectedItem.ToString();
        txt_secilmis_isim.Text = lb_tum_numaralar.SelectedItem.ToString();

        //lb_tum_numaralar.Items.Clear();
        //lb_tum_numaralar_id.Items.Clear();
        //lb_tum_numaralar_no.Items.Clear();
        //NumaraListesiniDoldur();

    }

    int silmek_icin_secilen_numara;
    protected void lb_gonderilecek_numaralar_SelectedIndexChanged(object sender, EventArgs e)
    {
        silmek_icin_secilen_numara = lb_gonderilecek_numaralar.SelectedIndex;
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
            lb_tum_numaralar_no.Items.Add(listboxread[2].ToString());

        }
        commlistbox.Connection.Close();
    }

    protected void btn_numara_ekle_Click(object sender, EventArgs e)
    {
        lb_gonderilecek_numaralar.Items.Add(txt_secilmis_no.Text);
        //lb_gonderilecek_numaralar.Items.Add(txt_secilmis_isim.Text + " - " + txt_secilmis_no.Text);
    }

    protected void btn_numara_cikar_Click(object sender, EventArgs e)
    {
        lb_gonderilecek_numaralar.Items.RemoveAt(silmek_icin_secilen_numara);
    }

}