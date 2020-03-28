<%@ Page Title="" Language="C#" MasterPageFile="~/MP1.master" AutoEventWireup="true" CodeFile="SMS_Hizli_Gonder.aspx.cs" Inherits="Default2" %>
<%@ Register Src="~/WUC_Head.ascx" TagName="head" TagPrefix="wuc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<wuc1:head ID="head" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="basvuruFormu">
    <div class="contactform">
    <ol>
    <li>
        <label for="subject">Telefon No * </label> 
        <asp:TextBox ID="txt_tel" runat="server" class="text"></asp:TextBox> <br />
    </li>
    <li>
        <label for="message">Mesajınız * </label>
        <asp:TextBox ID="txt_mesaj" runat="server"  class="text" TextMode="MultiLine" Height="160px"></asp:TextBox>
    </li>
    <li class="buttons">
        <asp:ImageButton ID="imageField" runat="server" ImageUrl="~/images/send.gif" 
            onclick="imageField_Click" />
    </li>
    <li><asp:Label ID="lbl_bilgilendirme" runat="server" Text=""></asp:Label> 
    <br /> <asp:Label ID="lbl_rapor" runat="server" Text=""></asp:Label> </li>
</ol>
</div>
</div>
</asp:Content>

