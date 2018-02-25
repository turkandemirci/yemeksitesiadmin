 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="YemekSitesi.adminSide.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Ana Sayfa</title>
    <!-- Bootstrap core CSS -->
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/assets/fonts/css/font-awesome.min.css" rel="stylesheet" />
    <link href="/assets/css/animate.min.css" rel="stylesheet" />
    <!-- Custom styling plus plugins -->
    <link href="/assets/css/custom.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/assets/css/maps/jquery-jvectormap-2.0.3.css" />
    <link href="/assets/css/icheck/flat/green.css" rel="stylesheet" />
    <link href="/assets/css/floatexamples.css" rel="stylesheet" type="text/css" />

</head>
<body class="nav-md" style="background-color: powderblue;">
    <form id="form1" runat="server">

        <div class="main_container">
            <div class="right_col" role="main">

                <div class="">
                    <a class="hiddenanchor" id="toregister"></a>
                    <a class="hiddenanchor" id="tologin"></a>

                    <div id="wrapper">
                        <div id="login" class="animate form">
                            <section class="login_content">

                                <h1 class="box-title">Hoşgeldiniz</h1>
                                 <asp:Panel ID="pnlAdmin" runat="server">
                                <div class="input-group">
                                    <div class="input-group-btn"> 
                                      <asp:TextBox ID="txtUserName" runat="server" required="required" class="form-control" placeholder="Kullanıcı Adı" BorderStyle="NotSet"></asp:TextBox><br />
                                                 <asp:TextBox ID="txtPsswrd" runat="server" required="required" class="form-control" placeholder="Şifre" TextMode="Password"></asp:TextBox>                          
                                    
                                        </div>
                                </div>
                                     </asp:Panel>
                                <asp:Button ID="Button1" runat="server" Text="Giriş" OnClick="Button1_Click" /><br /><br /><br />
                                <div>
                                    
                                    <a href="/adminSide/LoginRegister.aspx">Şifremi unuttum ya da üye ol </a>
                                </div>
                                <section class="login_content">
                                    <%--Çizgi Klası--%>

                                    <div>
                                        <h1><i class="fa fa-spoon" style="font-size: 26px;"></i>Hadi Pişirelim</h1>

                                        <p>©2017 YemekSitesi</p>
                                    </div>
                                </section>
                            </section>
                        </div>
                    </div>

                </div>

            </div>
        </div>

    </form>
</body>
</html>
