<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GununMenusu.aspx.cs" Inherits="YemekSitesi.adminSide.GununMenusu" %>



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

    <!-- css  for autocomplete-->
    <link href="../assets/css/jquery-ui-1.10.4.custom.css" rel="stylesheet" />

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
                                <h2>Günün Menüsü Belirleme/Onaylama</h2>



                                <div class="clearfix"></div>
                            </div>
                            <asp:Panel ID="pnlGununMenusu" runat="server" Visible="true">
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtGununMenusu" runat="server"  placeHolder="Eklemek istediğiniz yemeğin adını giriniz"       CssClass="form-control"> </asp:TextBox>
                                    <asp:HiddenField ID="hdnGununMenusuID" runat="server" />
                                    <asp:HiddenField ID="hdnGununMenusuLastSelected" runat="server" />


                                </div>
                                <div class="col-md-3">
                                    <asp:LinkButton ID="btnEkle" runat="server" CssClass="btn btn-info" OnClick="btnEkle_Click">EKLE</asp:LinkButton>

                                </div>
                                <div class="col-md-6">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <th>Yemeğin Adı </th>
                                                <th>Durumu</th>
                                                <th>Seçenekler</th>
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptGununMenusu" runat="server" OnItemCommand="rptGununMenusu_ItemCommand">
                                            <ItemTemplate>
                                                <tbody>
                                                    <tr>
                                                        <td><%#Eval("MealName") %> </td>
                                                        <td><%#Convert.ToBoolean(Eval("Status")) ? "Onaylı":"Onay bekliyor" %></td>
                                                        <td>
                                                            <asp:LinkButton ID="btnSil" runat="server" CssClass="btn btn-danger" Text="Sil" CommandName="Delete" CommandArgument='<%#Eval("Id") %>' /></td>
                                                    </tr>
                                                </tbody>
                                            </ItemTemplate>

                                        </asp:Repeater>

                                    </table>

                                </div>
                                <div class="col-md-7" style="text-align: right">

                                    <asp:LinkButton ID="btnTamam" runat="server" CssClass="btn btn-info"  Text="ONAY İÇİN"    OnClick="btnTamam_Click"></asp:LinkButton>

                                </div>
                            </asp:Panel>
                             

                             

                            <asp:UpdatePanel ID="upDayMenuConfirm" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                

                                    <asp:Panel ID="pnlGununMenusuOnay" runat="server" Visible="false">
                                        <div class="col-md-6">
                                            <table class="table">
                                                <thead>
                                                    <tr>
                                                        <th>Yemeğin Adı </th>
                                                        <th>Onay Durumu</th>
                                                        <th>Seçenekler</th>
                                                    </tr>
                                                </thead>
                                                <asp:Repeater ID="rptGununMenusuOnay" runat="server" OnItemCommand="rptGununMenusuOnay_ItemCommand">
                                                    <ItemTemplate>
                                                        <tbody>
                                                            <tr>
                                                                <td><%#Eval("MealName") %> </td>
                                                                <td><%#Convert.ToBoolean(Eval("Status")) ? "Onaylı":"Onay bekliyor" %></td>
                                                                <td>
                                                                    <asp:LinkButton ID="btnOnayla" runat="server" CssClass="btn btn-success" Text="Onayla" CommandName="Onayla" CommandArgument='<%#Eval("Id") %>' /></td>
                                                                <td>
                                                                    <asp:LinkButton ID="btnOnayıKaldır" runat="server" CssClass="btn btn-danger" Text="Onayı Kaldır" CommandName="OnayıKaldır" CommandArgument='<%#Eval("Id") %>' /></td>
                                                        </tbody>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                        <div class="col-md-7" style="text-align: right">


                                            <asp:LinkButton ID="btnIptal" runat="server" CssClass="btn btn-info"  Text="DEĞİŞİKLİK İÇİN GERİ DÖN" OnClick="btnIptal_Click"></asp:LinkButton>
                                        </div>

                                    </asp:Panel>




                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>














    <uc1:UCFooterScript runat="server" ID="UCFooterScript" />
    <script type="text/javascript">
        //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InitializePage);
        function InitializePage() {

            $(document).ready(function () {
                $("#txtGununMenusu").change(function (event) { if ($("#txtGununMenusu").val() != $('#hdnGununMenusuLastSelected').val()) { $('#hdnGununMenusuID').val(''); } });
                $("#txtGununMenusu").autocomplete({
                    source: '/WebService/GununMenusuWebService.asmx/GetMealName',
                    minLength: 2,
                    autoFocus: true,
                    hiddenValue: $('#hdnGununMenusuID'),
                    hiddenLastSelected: $('#hdnGununMenusuLastSelected'),
                    select: function (event, ui) {
                        if (ui.item.label == "-1") {
                            return false;
                        } else {
                            $(this).autocomplete('widget').css('z-index', 0);
                        }
                    },
                    open: function () {
                        $(this).autocomplete('widget').css('z-index', 100);
                        $(this).autocomplete('widget').css('float', 'right');
                        return false;
                    },
                    focus: function (event, ui) {
                        if (ui.item.value == "-1") {
                            ui.item.value = "";
                        }
                        event.preventDefault();
                    }
                }).autocomplete("instance")._renderItem = function (ul, item) {
                    if (item.value == "-1") {
                        item.label = "Kayıt Bulunamadı!";
                    }
                    var html = '';
                    html += "<div class='AutoCompleteResult'>";
                    html += "<div class='row'><div class='col-xs-12'>" + item.label + "</div></div>";
                    html += "</div>";
                    return $("<li>")
                        .append(html)
                        .appendTo(ul);
                };

            })



        }
        InitializePage();
    </script>
</body>
</html>
