<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YemekEkle.aspx.cs" Inherits="YemekSitesi.adminSide.YemekEkle" %>


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
                    <div class="col-md-12">
                        <div class="x_panel">
                            <h3 class="box-title">Yemek Ekle / Güncelle</h3>

                            <div class="box-body">

                                <div class="form-group myForm" data-toggle="Validator">
                                    <asp:Panel ID="formPanel" runat="server">
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtYemekAdi" CssClass="form-control" placeholder="Yemek Adını Giriniz." runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                             <div class="input-group">
                                           
                                            <asp:DropDownList ID="ddlKategori" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                                <span class="input-group-btn">
                                           
                                 <asp:LinkButton ID="btnKategoriEkle" runat="server" class="btn btn-dark" data-toggle="modal" title="Veri Tabanına Ekle" data-target="#kategoriModal"><i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton> 
                                                 </span>
                                            <br />
                                                 <!-- Modal -->
                                                <div class="modal fade" id="kategoriModal" role="dialog">
                                                    <div class="modal-dialog">
                                                         <!-- Modal content-->
                                                          <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal">&times;</button>

                                                            </div>
                                                            <div class="modal-body">
                                                                <p>Veri tabanına eklemek istediğinizden emin misiniz ?</p>
                                                                <asp:TextBox ID="txtKategoriModal" runat="server" PlaceHolder="Kategori İsmini Giriniz"></asp:TextBox>

                                                            </div>
                                                            <div class="modal-footer">
                                                                <asp:Button ID="btnKategori" class="btn btn-default" runat="server" Text="Ekle" OnClick="btnKategori_Click" />
                                                            </div>
                                                        </div>
                                                        </div>
                                                    </div>
                                             </div>     
                                        </div>

                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtKacKisi" CssClass="form-control" placeholder="Yemeğin Kac Kişilik Oldugunu Giriniz." onkeypress="return numbersonly(this, event)" runat="server"></asp:TextBox><br />
                                        </div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtHazirlama" CssClass="form-control" placeholder="Yemeğin Hazırlama Süresini Giriniz." onkeypress="return numbersonly(this, event)" runat="server"></asp:TextBox><br />

                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />

                    <div class="col-md-12">
                        <div class="x_panel">
                            <h3 class="box-title">Resim Ekle </h3>
                            <asp:Panel ID="pnlResim" runat="server">


                                <div class="col-md-3">
                                    <asp:FileUpload ID="flResim" runat="server" />
                                    <asp:Button ID="btnResimKaydet" runat="server" Text="Yükle" OnClick="btnResimKaydet_Click" />
                                </div>

                                <div class="col-md-6">
                                    <asp:Image ID="imgYemekResim" runat="server" Height="100px" />
                                    <asp:LinkButton ID="btnResimSil" runat="server" CssClass="btn btn-danger" visible="false" Text="Sil" OnClick="btnResimSil_Click" />


                                </div>
                            </asp:Panel>
                        </div>
                    </div>

                    <div class="col-md-12">
                     <asp:UpdatePanel ID="upMalzelemer" runat="server">
                         <ContentTemplate>
                    
                        <div class="x_panel">
                            <h3 class="box-title">Malzemeler Ekle </h3>
                          
                                    <asp:Panel ID="pnlingredient" runat="server">

                                        <div class="col-md-3">

                                            <asp:TextBox ID="txtAdet" CssClass="form-control" runat="server" PlaceHolder="Adedi Giriniz"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3">
                                     
                                            <div class="input-group">
                                                <asp:TextBox ID="txtScale" CssClass="form-control" runat="server" PlaceHolder="Ölçeği giriniz"></asp:TextBox>
                                                <asp:HiddenField ID="hdnScaleID" runat="server" />
                                                <asp:HiddenField ID="hdnScaleLastSelected" runat="server" />
                                           
                                                
                                                  <span class="input-group-btn">
                                            <asp:UpdatePanel ID="upIngredients" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                                <asp:LinkButton ID="btnScaleAutoComplete" runat="server" class="btn btn-dark" data-toggle="modal" title="Veri Tabanına Ekle" data-target="#myModal"><i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>                                 
                                    </ContentTemplate>
                            </asp:UpdatePanel>
                                                               </span>
                                                <!-- Modal -->
                                                <div class="modal fade" id="myModal" role="dialog">
                                                    <div class="modal-dialog">

                                                        <!-- Modal content-->
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal">&times;</button>

                                                            </div>
                                                            <div class="modal-body">
                                                                <p>Veri tabanına eklemek istediğinizden emin misiniz ?</p>
                                                                <asp:TextBox ID="txtSearchAutoComplete" runat="server" PlaceHolder="Ölçeği giriniz"></asp:TextBox>

                                                            </div>
                                                            <div class="modal-footer">
                                                                <asp:Button ID="btnAutoEkle" class="btn btn-default" runat="server" Text="Ekle" OnClick="btnAutoEkle_Click" />
                                                            </div>
                                                        </div>

                                                
                                                </div>

                                            </div>
                                               </div>
                                        </div>
                                        <div class="col-md-3">
                                            
                                            <div class="input-group">
                                                <asp:TextBox ID="txtIngredient" CssClass="form-control" runat="server" PlaceHolder="Malzemeyi Giriniz"></asp:TextBox>

                                                <asp:HiddenField ID="hdnIngredientID" runat="server" />
                                                <asp:HiddenField ID="hdnIngredientLastSelected" runat="server" />
                                          
                                   <span class="input-group-btn">
                                               <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                               

                                                <asp:LinkButton ID="btnIgredientAutoComplete" class="btn btn-dark" runat="server" data-toggle="modal" title="Veri Tabanına Ekle" data-target="#Modal1"><i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>
                                                
                                               </ContentTemplate>
                            </asp:UpdatePanel>
                                          </span>
                                                <div class="modal fade" id="Modal1" role="dialog">
                                                    <div class="modal-dialog">

                                                        <!-- Modal1 content-->
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal">&times;</button>

                                                            </div>
                                                            <div class="modal-body">
                                                                <p>Veri tabanına eklemek istediğinizden emin misiniz ?</p>
                                                                <asp:TextBox ID="txtIngredientSearch" runat="server" PlaceHolder="Malzemeyi giriniz"></asp:TextBox>

                                                            </div>
                                                            <div class="modal-footer">
                                                                <asp:Button ID="btnIngredientSearch" class="btn btn-default " runat="server" Text="Ekle" OnClick="btnIngredientSearch_Click" />
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                           
                                            </div>
                                        </div>

                                        <div class="col-md-3">
                                            <asp:LinkButton ID="btnListeyeEkle" runat="server" CssClass="btn btn-danger btn-lg" OnClick="btnListeyeEkle_Click">Listeye Ekle</asp:LinkButton>
                                        </div>
                                  


                                            <div class="row">

                                                <div class="col-md-12 col-sm-6 col-xs-12">
                                                    <div class="x_panel">
                                                        <div class="x_title">
                                                            <h2>Malzemeler </h2>



                                                            <div class="clearfix"></div>
                                                        </div>
                                                  
                                                                 <div class="x_content">

                                                            <table class="table">
                                                                <thead>
                                                                    <tr>

                                                                        <th>Adet</th>
                                                                        <th>Ölçek</th>
                                                                        <th>Malzeme</th>
                                                                        <th>Seçenekler</th>
                                                                    </tr>
                                                                </thead>
                                                                <asp:Repeater ID="ingredientRepeater" runat="server" OnItemCommand="ingredientRepeater_ItemCommand">
                                                                    <ItemTemplate>
                                                                        <tbody>
                                                                            <tr>

                                                                                <td><%#Eval("amount") %> </td>
                                                                                <td><%#Eval("scaleName") %></td>
                                                                                <td><%#Eval("ingredientName") %>
                                                                                   <td> <asp:LinkButton ID="btn_delete" runat="server" CssClass="btn btn-danger" Text="Sil" CommandName="Delete" CommandArgument='<%#Eval("ID") %>' /></td>

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
                             </ContentTemplate>
                          </asp:UpdatePanel>
                    </div>
                    <div class="col-md-12">
                        <div class="x_panel">
                            <h3 class="box-title">Tarif Ekle</h3>
                            <asp:Panel ID="pnlRecipe" runat="server">
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtDescriptipon" CssClass="form-control" runat="server" TextMode="MultiLine"> </asp:TextBox>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>

                  

                            <div class="clear col-md-2 pull-right">
                               

                                <asp:LinkButton ID="lbKaydet" CssClass="btn btn-success" runat="server" OnClick="lbKaydet_Click">Kaydet</asp:LinkButton>

                                <asp:LinkButton ID="btnIptal" CssClass="btn btn-default" runat="server" OnClick="btnIptal_Click">İptal</asp:LinkButton>
                            </div>



               
            </div>
                
        </div>
            </div>

    </form>

    <uc1:UCFooterScript runat="server" ID="UCFooterScript" />

    <script type="text/javascript">

       
   
                $(function () {
                    $('input:text:first').focus();
                $('input:text').bind('keydown', function (e) {
                var key = (e.keyCode ? e.keyCode : e.charCode);
                if (key == 13) {
                    e.preventDefault();
                var sonrakitext = $('input:text').index(this) + 1;
                    $(":input:text:eq(" + sonrakitext + ")").focus();
                }
            });
          // www.aspnetornekleri.com
            $('#btntemizle').click(
           function () {
                    $('form')[0].reset();
           });
        });
             

        function numbersonly(myfield, e, dec) {
            var key;
            var keychar;

            if (window.event)
                key = window.event.keyCode;
            else if (e)
                key = e.which;
            else
                return true;
            keychar = String.fromCharCode(key);

            // control keys
            if ((key == null) || (key == 0) || (key == 8) ||
    (key == 9) || (key == 13) || (key == 27))
                return true;

                // numbers
            else if ((("0123456789").indexOf(keychar) > -1))
                return true;

                // decimal point jump
            else if (dec && (keychar == ".")) {
                myfield.form.elements[dec].focus();
                return false;
            }
            else
                return false;
        }

        $(document).ready(function () {
            $('[data-toggle="modal"]').tooltip();
        });



        //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InitializePage);
        function InitializePage() {
            $(document).ready(function () {
                $("#txtIngredient").change(function (event) { if ($("#txtIngredient").val() != $('#hdnIngredientLastSelected').val()) { $('#hdnIngredientID').val(''); } });
                $("#txtIngredient").autocomplete({
                    source: '/WebService/ServiceForAutocomplete.asmx/GetIngredientName',
                    minLength: 2,
                    autoFocus: true,
                    hiddenValue: $('#hdnIngredientID'),
                    hiddenLastSelected: $('#hdnIngredientLastSelected'),
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
                  })}
        InitializePage();
    </script>










    <script type="text/javascript">
        //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InitializePage);
        function InitializePage() {

            $(document).ready(function () {
                $("#txtScale").change(function (event) { if ($("#txtScale").val() != $('#hdnScaleLastSelected').val()) { $('#hdnScaleID').val(''); } });
                $("#txtScale").autocomplete({
                    source: '/WebService/ScaleService.asmx/GetScaleName',
                    minLength: 2,
                    autoFocus: true,
                    hiddenValue: $('#hdnScaleID'),
                    hiddenLastSelected: $('#hdnScaleLastSelected'),
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

