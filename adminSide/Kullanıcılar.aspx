<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kullanıcılar.aspx.cs" Inherits="YemekSitesi.adminSide.Kullanıcılar" %>


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
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
        <div class="container body">
            <div class="main_container">
                <uc1:UCTopMenu runat="server" ID="UCTopMenu" />
                <uc1:UCLeftMenu runat="server" ID="UCLeftMenu" />

                <div class="col-md-10" style="background-color: white">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>KULLANICILAR /YÖNETİM PANELİ </h2>
                                <ul class="nav navbar-right panel_toolbox">
                                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                    </li>


                                </ul>
                                <div class="clearfix"></div>


                            </div>
                            <div class="col-md-4">

                                <asp:TextBox ID="txtAra" CssClass="form-control" required="required" placeholder="Aranacak kelimeyi giriniz" runat="server"></asp:TextBox>

                            </div>
                            <div class="col-md-2 ">
                                <asp:LinkButton ID="lbAra" CssClass="btn btn-info " runat="server" OnClick="lbAra_Click"><i class="fa fa-search"></i></asp:LinkButton>

                            </div>
                             <asp:UpdatePanel ID="upKullanıcı" runat="server" UpdateMode="Conditional">
                                 <ContentTemplate>
                                       <div class="x_content">
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>İsim</th>
                                            <th>Soyisim</th>
                                            <th>Email Adresi</th>
                                            <th>Kayıt Tarihi</th>
                                            <th>Durumu</th>
                                        </tr>
                                    </thead>
                                    <asp:Repeater ID="kullanıcıRepeater" runat="server" OnItemCommand="kullanıcıRepeater_ItemCommand">
                                        <ItemTemplate>
                                            <tbody>
                                                <tr>
                                                    <td><%#Eval("Name") %> </td>
                                                    <td><%#Eval("SurName") %> </td>
                                                    <td><%#Eval("Email") %> </td>
                                                    <td><%#Eval("Date") %> </td>
                                                    <td><%#Convert.ToBoolean(Eval("isAdmin")) ? "Onaylı":"Onay bekliyor" %></td>
                                                    <td> <asp:LinkButton ID="btn_delete" runat="server" CssClass="btn btn-info" Text="Sil" CommandName="Delete" CommandArgument='<%#Eval("ID") %>' /></td>
                                                     <td> <asp:LinkButton ID="btnOnayla" runat="server" CssClass="btn btn-success" Text="Onayla" CommandName="Onayla" CommandArgument='<%#Eval("ID") %>'/> </td>
                                                     <td> <asp:LinkButton ID="btnOnayıKaldır" runat="server" CssClass="btn btn-danger" Text="Onayı Kaldır" CommandName="OnayKaldır" CommandArgument='<%#Eval("ID") %>'/> </td>

                                                     </tr>
                                            </tbody>
                                        </ItemTemplate>
                                        </asp:Repeater>
                                              

                                    


                                </table>
                            </div>


                                 </ContentTemplate>
                             </asp:UpdatePanel>
                                

                          
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <uc1:UCFooterScript runat="server" ID="UCFooterScript" />

</body>
</html>
