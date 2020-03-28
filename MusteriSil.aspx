<%@ Page Title="" Language="C#" MasterPageFile="~/MP1.master" AutoEventWireup="true" CodeFile="MusteriSil.aspx.cs" Inherits="Default2" %>
<%@ Register Src="~/WUC_Head.ascx" TagName="head" TagPrefix="wuc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<wuc1:head ID="head" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="basvuruFormu">
<div>
    <div style="float:left;">
        <div class="MusteriList">
        <ol>
            <li>
                <div style="float:left;">
                    <div style="float:left; width:200px;">
                        <asp:Label ID="Label1" runat="server" Text="Tüm Müşteriler : "></asp:Label> <br />

                        <asp:ListBox ID="lb_tum_numaralar" runat="server" Width="190px" Height="300px"
                            AutoPostBack="True"
                            onselectedindexchanged="lb_tum_numaralar_SelectedIndexChanged"></asp:ListBox>

                        <asp:ListBox ID="lb_tum_numaralar_id" runat="server" Visible="false" 
                            AutoPostBack="True" ></asp:ListBox>

                    </div>

                </div>
            </li>
        </ol>
    </div>
    </div>
        <div style="float:left;">
    <div class="contactform">
    <ol>
    <li>
        <label for="subject">Kullanici Adı </label> 
        <asp:DropDownList ID="ddl_kullanici_adi" runat="server" Enabled="false" class="dropdownlist_il">
        </asp:DropDownList>    <br />
    </li>
    <li>
        <label for="subject">Ad, Soyad * </label> 
        <asp:TextBox ID="txt_adsoyad" runat="server" class="text" Enabled="false"></asp:TextBox> <br />
    </li>
    <li>
        <label for="subject">Firma Adı * </label> 
        <asp:TextBox ID="txt_firmaadi" runat="server" class="text" Enabled="false"></asp:TextBox> <br />
    </li>
        <li>
        <label for="subject">Cep Telefon No * </label> 
        <asp:TextBox ID="txt_cepno" runat="server" class="text" Enabled="false"></asp:TextBox> <br />
    </li>
        <li>
        <label for="subject">E-Posta Adresi * </label> 
        <asp:TextBox ID="txt_eposta" runat="server" class="text" Enabled="false"></asp:TextBox> <br />
    </li>
    <li>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_sil" runat="server" Text="Sil" 
            Height="30px" Width="86px" onclick="btn_sil_Click" />
    </li>
    <li><asp:Label ID="lbl_bilgilendirme" runat="server" Text=""></asp:Label> 
    <br /> <asp:Label ID="lbl_rapor" runat="server" Text=""></asp:Label> </li>
</ol>
</div>
            <asp:TextBox ID="txt_secilmis_id" runat="server" Visible="false"></asp:TextBox>
    </div>
</div>
    
</div>
</asp:Content>

