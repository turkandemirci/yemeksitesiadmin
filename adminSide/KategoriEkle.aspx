<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="YemekSitesi.adminSide.KategoriEkle" %>


<%@ Register Src="~/adminSide/userControl/UCLeftMenu.ascx" TagPrefix="uc1" TagName="UCLeftMenu" %>
<%@ Register Src="~/adminSide/userControl/UCTopMenu.ascx" TagPrefix="uc1" TagName="UCTopMenu" %>
<%@ Register Src="~/adminSide/userControl/UCFooterScript.ascx" TagPrefix="uc1" TagName="UCFooterScript" %>



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
<body class="nav-md">
    <form id="form1" runat="server">
        <div class="container body">
            <div class="main_container">
                 <uc1:UCTopMenu runat="server" ID="UCTopMenu" />
                <uc1:UCLeftMenu runat="server" ID="UCLeftMenu" />
               

                <div class="col-md-10" style="background-color: white">
                    <h3 class="box-title">Kategori Ekle / Güncelle</h3>


                    <div class="box-body">

                        <div class="form-group myForm" data-toggle="Validator">
                            <div class="col-md-6">
                                <asp:TextBox ID="txtKategoriAdi" CssClass="form-control" required="required" placeholder="Kategori adını giriniz." runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2 pull-right">
                                <asp:LinkButton ID="lbKaydet" CssClass="btn btn-success" runat="server" OnClick="lbKaydet_Click">Kaydet</asp:LinkButton>
                                <asp:LinkButton ID="lbTemizle" CssClass="btn btn-default" runat="server" OnClick="lbTemizle_Click">Temizle</asp:LinkButton>
                            </div>


                        </div>

                    </div>


                </div>

            </div>
        </div>
    </form>

    <uc1:UCFooterScript runat="server" ID="UCFooterScript" />

</body>
</html>


