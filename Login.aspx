<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MCY Post</title>
    <link href="css/login-box.css" rel="stylesheet" type="text/css" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <center>
        <form id="form1" runat="server">
            <div style="margin-top:50px;">
                <div id="login-box"
                    style="background-image: url('images/login-box-backg.png')">

                    <h2>MCY Post</h2>
                       Toplu mesaj mcypost.com web yönetim sayfasına giriş yapmak için alanları doldurunuz.

                    <br />
                    <br />
                    <div class="login-box-name" style="margin-top:20px;">Kullanıcı Adı :</div>
                    <div class="login-box-field" style="margin-top:20px;">
                        <asp:TextBox ID="txt_kullanici" runat="server" Width="205px" MaxLength="2048" class="form-login"></asp:TextBox>
                    </div>
                    <div class="login-box-name">Parola :</div>
                    <div class="login-box-field">
                        <asp:TextBox ID="txt_parola" runat="server" class="form-login" MaxLength="2048" Width="205px" TextMode="Password"></asp:TextBox>
                    </div>
                    <br />
                    <span class="login-box-options">
                        <input type="checkbox" name="1" value="1" /> Beni Hatırla <a href="#" style="margin-left:30px;">Parolamı unuttum?</a> 
                    </span>
                    <br />
                    <br />
                    <asp:ImageButton ID="ib_sisteme_giris" CssClass="login-button" runat="server" 
                        ImageUrl="images/login-btn.png" onclick="ib_sisteme_giris_Click" />
                    <br />
                    <br />
                    <asp:Label ID="lbl_errortext" runat="server" Text="" CssClass="login-lable"></asp:Label>
                </div>
            </div>
            <div style="width:433px;">
            <div class="login_footer">
            <div style="padding:19px 5px 18px 5px; float:left;">
            <asp:Label ID="lbl_mcysoft" runat="server" Text="Powered By" CssClass="font"></asp:Label> 
            </div>
            <div style="float:right;">
            <a href="http://www.mcysoft.com/" target="_blank">
            <img style="border:0px;" alt="MCYSoft" title="MCYSoft" src="images/mcylogo.png" />
            </a> 
            </div>
            </div>
            </div>
            
        </form>
    </center>
</body>
</html>
