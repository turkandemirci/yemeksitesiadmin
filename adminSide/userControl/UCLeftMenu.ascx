<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLeftMenu.ascx.cs" Inherits="YemekSitesi.adminSide.userControl.UCLeftMenu" %>

<div class="col-md-2">
    <div class="left_col scroll-view">

        <div class="navbar nav_title" style="border: 0;">
            <a href="#" class="site_title"><i class="fa fa-spoon"></i><span>Hadi Pişirelim</span></a>
        </div>
        <div class="clearfix"></div>

        <!-- menu prile quick info -->
        <div class="profile">
            <div class="profile_pic">
                <img src="/assets/images/img.jpg" alt="..." class="img-circle profile_img">
            </div>
            <div class="profile_info">
                <span>Hoşgeldiniz</span>
                <h2>YEMEKCİLER</h2>
            </div>
        </div>
        <!-- /menu prile quick info -->

        <br />

        <!-- sidebar menu -->
        <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">
            <br />

            <div class="menu_section">
                <br />
                <h3></h3>
                <br />
                <ul class="nav side-menu">
                    <li><a href="/adminSide/Yemekler.aspx">Yemekler</a></li>
                    <li><a href="/adminSide/YemekEkle.aspx">Yemek Ekle</a></li>
                    <li><a href="/adminSide/Kategori.aspx">Kategoriler</a></li>
                   
                     <li><a href="/adminSide/GununMenusu.aspx">Günün Menüsü</a></li>
                    <li><a href="/adminSide/Kullanıcılar.aspx">Kullanıcılar</a></li>
                   <%-- <li><a href="/adminSide/LoginForm.aspx" style="visibility: hidden;"></a></li>--%>
                    
                </ul>
            </div>
            <%--<div class="menu_section">
                <h3>Live On</h3>
                <ul class="nav side-menu">
                    <li><a><i class="fa fa-bug"></i>Additional Pages <span class="fa fa-chevron-down"></span></a>
                        <ul class="nav child_menu" style="display: none">
                            <li><a href="e_commerce.html">E-commerce</a>
                            </li>
                            <li><a href="projects.html">Projects</a>
                            </li>
                            <li><a href="project_detail.html">Project Detail</a>
                            </li>
                            <li><a href="contacts.html">Contacts</a>
                            </li>
                            <li><a href="profile.html">Profile</a>
                            </li>
                        </ul>
                    </li>
                    <li><a><i class="fa fa-windows"></i>Extras <span class="fa fa-chevron-down"></span></a>
                        <ul class="nav child_menu" style="display: none">
                            <li><a href="page_404.html">404 Error</a>
                            </li>
                            <li><a href="page_500.html">500 Error</a>
                            </li>
                            <li><a href="plain_page.html">Plain Page</a>
                            </li>
                            <li><a href="login.html">Login Page</a>
                            </li>
                            <li><a href="pricing_tables.html">Pricing Tables</a>
                            </li>

                        </ul>
                    </li>
                    <li><a><i class="fa fa-laptop"></i>Landing Page <span class="label label-success pull-right">Coming Soon</span></a>
                    </li>
                </ul>
            </div>--%>
        </div>
        <!-- /sidebar menu -->

        <!-- /menu footer buttons -->
        <%-- <div class="sidebar-footer hidden-small">
            <a data-toggle="tooltip" data-placement="top" title="Settings">
                <span class="glyphicon glyphicon-cog" aria-hidden="true"></span>
            </a>
            <a data-toggle="tooltip" data-placement="top" title="FullScreen">
                <span class="glyphicon glyphicon-fullscreen" aria-hidden="true"></span>
            </a>
            <a data-toggle="tooltip" data-placement="top" title="Lock">
                <span class="glyphicon glyphicon-eye-close" aria-hidden="true"></span>
            </a>
            <asp:Button ID="Button1" runat="server" Text="LogOut" />
            <a data-toggle="tooltip" data-placement="top" title="Logout">
                <span class="glyphicon glyphicon-off" aria-hidden="true"></span>
            </a>
        </div>--%>
        <!-- /menu footer buttons -->
    </div>
</div>
