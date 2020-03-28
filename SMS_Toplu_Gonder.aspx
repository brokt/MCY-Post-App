<%@ Page Title="" Language="C#" MasterPageFile="~/MP1.master" AutoEventWireup="true" CodeFile="SMS_Toplu_Gonder.aspx.cs" Inherits="Default2" %>
<%@ Register Src="~/WUC_Head.ascx" TagName="head" TagPrefix="wuc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<wuc1:head ID="head" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="basvuruFormu">
<div>
    <div style="float:left;">
    <div class="contactform">
        <ol>
            <li>
                <div style="float:left;">
                    <div style="float:left; width:200px;">
                        <asp:Label ID="Label1" runat="server" Text="Tüm Müşteriler : "></asp:Label> <br />

                        <asp:ListBox ID="lb_tum_numaralar" runat="server" Width="190px" Height="300px" CssClass="text"
                            AutoPostBack="True"
                            onselectedindexchanged="lb_tum_numaralar_SelectedIndexChanged"></asp:ListBox>

                        <asp:ListBox ID="lb_tum_numaralar_id" runat="server" Visible="false" 
                            AutoPostBack="True" ></asp:ListBox>

                        <asp:ListBox ID="lb_tum_numaralar_no" runat="server" Visible="false" 
                            AutoPostBack="True"></asp:ListBox>
                    </div>

                    <div  style="float:left; width:70px; padding-top:100px;">
                        <asp:Button ID="btn_numara_ekle" runat="server" Text=" >> " 
                            onclick="btn_numara_ekle_Click" /> <br />
                        <asp:Button ID="btn_numara_cikar" runat="server" Text=" << " 
                            onclick="btn_numara_cikar_Click" />
                    </div>

                    <div style="float:right; width:200px;">
                        <asp:Label ID="Label2" runat="server" Text="Alıcı Numaraları : "></asp:Label> <br />
                        <asp:ListBox ID="lb_gonderilecek_numaralar" runat="server" Width="190px" 
                            Height="300px" AutoPostBack="True" 
                            onselectedindexchanged="lb_gonderilecek_numaralar_SelectedIndexChanged"></asp:ListBox>
                        <asp:ListBox ID="lb_gonderilecek_isim_numaralar" runat="server" Visible="false"></asp:ListBox>
                        <asp:ListBox ID="lb_gonderilecek_numaralar_id" runat="server" Visible="false" 
                            AutoPostBack="True"></asp:ListBox>
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
            <label for="message">Mesajınız * </label>
            <asp:TextBox ID="txt_mesaj" runat="server"  class="text" TextMode="MultiLine" Height="250px"></asp:TextBox>
        </li>
        <li class="buttons">
            <asp:ImageButton ID="imageField" runat="server" ImageUrl="~/images/send.gif" 
                onclick="imageField_Click" />
        </li>
        <li><asp:Label ID="lbl_bilgilendirme" runat="server" Text=""></asp:Label> 
        <br /> <asp:Label ID="lbl_rapor" runat="server" Text=""></asp:Label> </li>
        </ol>
    </div>
        <asp:TextBox ID="txt_secilmis_id" runat="server" class="text" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txt_secilmis_no" runat="server" class="text" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txt_secilmis_isim" runat="server" class="text" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txt_gonderilecek_numaralar" runat="server" class="text" Visible="false"></asp:TextBox>
    </div>
</div>
    

    
</div>
</asp:Content>

