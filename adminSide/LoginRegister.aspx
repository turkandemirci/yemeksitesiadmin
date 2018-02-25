<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginRegister.aspx.cs" Inherits="YemekSitesi.adminSide.LoginRegister" %>

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
<body class="nav-md" style="background-color: powderblue;">
    <form id="form1" runat="server">
        <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <div class="main_container">


            <div class="right_col" role="main">

                <div class="">
                    <a class="hiddenanchor" id="toregister"></a>
                    <a class="hiddenanchor" id="tologin"></a>

                    <div id="wrapper">
                        <div id="login" class="animate form">
                            <section class="login_content">
                                <asp:Panel ID="pnlAdmin" runat="server">

                                <h1>Create Account</h1>
                                
                                    <div>
                                        <asp:TextBox ID="txtUserName" runat="server" required="required" class="form-control" placeholder="User Name"></asp:TextBox><br />
                                    </div>
                                    
                                    <div>
                                        <asp:TextBox ID="txtSurName" runat="server" required="required" class="form-control" placeholder="Last Name"></asp:TextBox><br />
                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtPsswrd" runat="server" required="required" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox><br />

                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtEmail" runat="server" required="required" class="form-control" placeholder="Email"></asp:TextBox><br />
                                       
                                    </div>

                                </asp:Panel>
                                <div>

                                    <asp:Button ID="btnKaydet" runat="server" class="btn btn-default submit" Text="Submit" OnClick="btnKaydet_Click" />


                                </div>
                     

                                <div class="clearfix"></div>
                                <div class="separator">

                                    <p class="change_link">
                                       
                <a href="/adminSide/LoginForm.aspx" class="to_register">Log in </a>
                                    </p>
                                    <div class="clearfix"></div>
                                    <br />
                                    <div>
                                        <h1><i class="fa fa-paw" style="font-size: 26px;"></i>Let's Cooking</h1>

                                        <p>©2017 YemekSitesi</p>
                                    </div>
                                </div>

                            </section>
                            <!-- content -->
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </form>
  <uc1:UCFooterScript runat="server" ID="UCFooterScript" />

<%--    $(function () {
                    $('input:text:first').focus();
                $('input:text').bind('keydown', function (e) {
                var key = (e.keyCode ? e.keyCode : e.charCode);
                if (key == 13) {
                    e.preventDefault();
                var sonrakitext = $('input:text').index(this) + 1;
                    $(":input:text:eq(" + sonrakitext + ")").focus();
                }
            });--%>
</body>
</html>

