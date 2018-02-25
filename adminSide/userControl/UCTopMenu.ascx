<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCTopMenu.ascx.cs" Inherits="YemekSitesi.adminSide.userControl.UCTopMenu" %>
<!-- top navigation -->
<div class="nav_menu">
    <nav>
        <div class="nav toggle">
            <a id="menu_toggle"><i class="fa fa-bars"></i></a>
        </div>

        <ul class="nav navbar-nav navbar-right">
            <!-- Tekli düğme -->
            <div class="btn-group">
                <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                    Yemekciler <span class="caret"></span>
                </button>
                <ul class="dropdown-menu" role="menu">
                    <li>  <asp:LinkButton ID="btnCıkış" runat="server"  class="box-title"  OnClick="btnCıkış_Click"  Text="ÇIKIŞ"></asp:LinkButton>
                    </li>
                </ul>
            </div>

        </ul>
    </nav>
</div>

<!-- /top navigation -->
