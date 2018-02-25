<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Yemekler.aspx.cs" Inherits="YemekSitesi.adminSide.Yemekler" %>

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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container body">
            <div class="main_container">
                <uc1:UCTopMenu runat="server" ID="UCTopMenu" />
                <uc1:UCLeftMenu runat="server" ID="UCLeftMenu" />


                <div class="col-md-10" style="background-color: white">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Yemek Ekle/Güncelle </h2>
                                <ul class="nav navbar-right panel_toolbox">
                                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                    </li>


                                </ul>
                                <div class="clearfix"></div>
                                
                         
                            </div>
                            <div class="col-md-4">
                            
                                <asp:TextBox ID="txtAra" CssClass="form-control" required="required" placeholder="Aranacak kelimeyi giriniz" runat="server"></asp:TextBox>
                         
                             </div>
                         <div class="col-md-2">
                                <asp:LinkButton ID="lbAra" CssClass="btn btn-info " runat="server" OnClick="lbAra_Click"><i class="fa fa-search"></i></asp:LinkButton>
                               
                            </div>
                       
                             
                            <div class="x_content">

                                <table id="datatable-responsive" class="table table-striped table-bordered dt-responsive nowrap">
                                    <thead>
                                        <tr>
                                            <th>Yemek Id</th>
                                            <th>Yemek Adı</th>
                                            <th>Kategori Adı</th>
                                            <th>Eklenme Tarihi</th>
                                            <th>Kac Kişilik</th>
                                            <th>Hazırlama Süresi</th>
                                            <th>Seçenekler</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Panel ID="pnltable" runat="server">
                                            <asp:Repeater ID="rptlistele" runat="server" OnItemCommand="rptlistele_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("Id") %></td>
                                                        <td><%#Eval("MealName") %></td>
                                                        <td><%#Eval("CategoryName") %></td>
                                                        <td><%#Eval("Date") %></td>
                                                        <td><%#Eval("NumberPeople") %></td>
                                                        <td><%#Eval("CookingTime") %></td>
                                                        <td>

                                                            <a href="YemekDetay.aspx?Id=<%#Eval("Id")%>" class="btn btn-info btn-xs"><i class="fa fa-recycle"></i>&nbsp;Detay</a>

                                                            <a href="YemekEkle.aspx?Id=<%#Eval("Id") %>" class="btn btn-success btn-xs"><i class="fa fa-recycle"></i>&nbsp;Güncelle</a>
                                                            <asp:LinkButton ID="btnSil" CommandName="Delete" CssClass="btn btn-danger btn-xs" OnClientClick="javascript:if(!confirm('Silmek istediğinizden emin misiniz?')) return false;" CommandArgument='<%#Eval("Id") %>' runat="server"><i class="fa fa-trash"></i>&nbsp;Sil</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </asp:Panel>
                                       

                                    </tbody>
                                </table>

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
