<%@ Page Title="" Language="C#" MasterPageFile="~/MP1.master" AutoEventWireup="true" CodeFile="MusteriEkle.aspx.cs" Inherits="Default2" %>
<%@ Register Src="~/WUC_Head.ascx" TagName="head" TagPrefix="wuc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<wuc1:head ID="head" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="basvuruFormu">
    <div class="contactform">
    <ol>
    <li>
        <label for="subject">Ad, Soyad * </label> 
        <asp:TextBox ID="txt_adsoyad" runat="server" class="text"></asp:TextBox> <br />
    </li>
    <li>
        <label for="subject">Firma Adı * </label> 
        <asp:TextBox ID="txt_firmaadi" runat="server" class="text"></asp:TextBox> <br />
    </li>
        <li>
        <label for="subject">Cep Telefon No * </label> 
        <asp:TextBox ID="txt_cepno" runat="server" class="text"></asp:TextBox> <br />
    </li>
        <li>
        <label for="subject">E-Posta Adresi * </label> 
        <asp:TextBox ID="txt_eposta" runat="server" class="text"></asp:TextBox> <br />
    </li>
    <li>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_kaydet" runat="server" Text="Kaydet" 
            onclick="btn_kaydet_Click" Height="30px" Width="86px" />
    </li>
    <li><asp:Label ID="lbl_bilgilendirme" runat="server" Text=""></asp:Label> 
    <br /> <asp:Label ID="lbl_rapor" runat="server" Text=""></asp:Label> </li>
</ol>
</div>
</div>
</asp:Content>

