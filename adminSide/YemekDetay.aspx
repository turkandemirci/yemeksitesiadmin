<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YemekDetay.aspx.cs" Inherits="YemekSitesi.adminSide.YemekDetay" %>

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
                        <asp:UpdatePanel ID="upYemekDetay" runat="server">
                            <ContentTemplate>

                      

                                    </div><div class="x_panel">
                            <div class="x_title">
                                <h3 class="text-center">Yemek Detayi</h3>
                                <div class="box-body">

                                    <div class="form-group myForm" data-toggle="Validator">

                                        <asp:Panel ID="pnlYemek" runat="server">


                                            <div class="col-sm-6">

                                                <table class="table table-bordered">
                                                    <tr>
                                                        <td class="text-center" colspan="2">
                                                            <label style="width: 100%;" class="btn btn-success">Yemek Bilgileri</label>
                                                            <label id="lblYemek" runat="server" visible="false"><%#Eval("Id") %></label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label>Yemek Adı:</label>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltlYemekAdi" runat="server" ></asp:Literal></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label>Yemeğin Kategorisi:</label></td>
                                                        <td>
                                                            <asp:Literal ID="ltlKatgoryID" runat="server" ></asp:Literal></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label>Yemek Kaç Kişilik:</label></td>
                                                        <td>
                                                            <asp:Literal ID="ltlNumberPeople" runat="server"></asp:Literal></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label>Yemeği Hazirlama Süresi:</label></td>
                                                        <td>
                                                            <asp:Literal ID="ltlCookTime" runat="server" ></asp:Literal></td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label>Yemeğin Onay Durumu</label>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltlOnayDurumu" runat="server" ></asp:Literal>
                                                        </td>   
                                                    </tr>
                                                </table>


                                            </div>

                                        

                                            <div class="box-body">
                                                <div class="form-group myForm" data-toggle="Validator">
                                                      
                                                    <asp:Panel ID="Panel1" runat="server">
                                                        <div class="col-md-6">
                                                            <table class="table table-bordered">
                                                                <tr>
                                                                    <td class="text-center" colspan="3">
                                                                        <label style="width: 100%;" class="btn btn-success">Yemeğin Resmi:</label></td>
                                                               

                                                                </tr>

                                                                <tr>
                                                                    <td>
                                                                        <label>Resim:</label>
                                                                    </td>
                                                                     <td><asp:Image ID="imgResim" runat="server" Height="145px" /></td>
                                                                </tr>

                                                            </table>
                                                        </div>

                                                    </asp:Panel>
                                                </div>
                                            </div>
                                                

                                            <div class="row">

                                                <div class="col-md-12 col-sm-6 col-xs-12">
                                                    <div class="x_panel">
                                                        <div class="x_title">
                                                            <label style="width: 100%;" class="btn btn-success">Malzemeler</label>
                                                            <label id="Label1" runat="server" visible="false"><%#Eval("Id") %></label>



                                                            <div class="clearfix"></div>
                                                        </div>
                                                        <div class="x_content">

                                                            <table class="table">
                                                                <thead>
                                                                    <tr>
                                                                         <td>Adet:</td>
                                                                         <td>Ölçek:</td>
                                                                         <td>Malzemeler:</td>
                                                                        </tr>
                                                                    <tr>
                                                                        <th>
                                                                            <asp:Literal ID="ltlAmount" runat="server" Text='<%#Eval("Amount")%>'></asp:Literal></th>
                                                                         
                                                         
                                                                        <th>
                                                                            <asp:Literal ID="ltlScaleName" runat="server" Text='<%#Eval("ScaleName")%>'></asp:Literal></th>
                                                                         
                                                                        <th>
                                                                            <asp:Literal ID="ltlIngredientName" runat="server" Text='<%#Eval("IngredientName")%>'></asp:Literal></th>
                                                                    </tr>
                                                                </thead>
                                                                <asp:Repeater ID="ingredientRepeater" runat="server" >
                                                                    <ItemTemplate>
                                                                        <tbody>
                                                                            <tr>

                                                                                <td><%#Eval("Amount") %> </td>
                                                                                <td><%#Eval("ScaleName") %></td>
                                                                                <td><%#Eval("IngredientName") %>

                                                                                </td>
                                                                            </tr>

                                                                        </tbody>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </table>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>

                                </div>
                            </div>








                            <div class="x_panel">
                                <div class="box-body">
                                    <div class="form-group myForm" data-toggle="Validator">

                                        <asp:Panel ID="pnlTarif" runat="server">
                                            <div class="col-md-12">
                                                <table class="table table-bordered">
                                                    <tr>
                                                        <td class="text-center" colspan="2">
                                                            <label style="width: 100%;" class="btn btn-success">Yemeğin Tarifi</label></td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            <label>Tarif:</label>
                                                        </td>
                                                        <td><asp:Literal ID="ltlDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Literal></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text-right" colspan="2">
                                                            

                                                          
                                                            <asp:LinkButton ID="btnYayinla" runat="server" CssClass="btn btn-success" visible="false" OnClick="btnYayinla_Click"><i class="fa fa-upload"></i>&nbsp;Yayınla</asp:LinkButton>
                                                            <asp:LinkButton ID="btnYayindanKaldir" runat="server" CssClass="btn btn-danger" visible="false" OnClick="btnYayindanKaldir_Click"><i class="fa fa-times"></i>&nbsp;Yayından Kaldır</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>

                                        </asp:Panel>
                                              </ContentTemplate>
                                        </asp:UpdatePanel>
                        
                                    </div>
                                </div>
                            </div>
                        </div>

    </form>
    <uc1:UCFooterScript runat="server" ID="UCFooterScript" />

</body>
</html>
