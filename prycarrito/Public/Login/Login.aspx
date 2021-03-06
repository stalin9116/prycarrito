<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="prycarrito.Public.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>

    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../../vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../../fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../../fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../../vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../../vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../../vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../../vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../../vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../../css/util.css">
    <link rel="stylesheet" type="text/css" href="../../css/main.css">
    <!--===============================================================================================-->
</head>
<body>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100 p-l-85 p-r-85 p-t-55 p-b-55">
                <form id="form1" runat="server">
                    <span class="login100-form-title p-b-32">Ingreso al Sistema
                    </span>

                    <span class="txt1 p-b-11">Usuario
                    </span>
                    <div class="wrap-input100 validate-input m-b-36" data-validate="Username is required">
                        <asp:TextBox ID="txtUser" runat="server" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <span class="txt1 p-b-11">Clave
                    </span>
                    <div class="wrap-input100 validate-input m-b-12" data-validate="Password is required">
                        <span class="btn-show-pass">
                            <i class="fa fa-eye"></i>
                        </span>
                        <asp:TextBox ID="txtpassword" runat="server" CssClass="input100" TextMode="Password"></asp:TextBox>

                        <span class="focus-input100"></span>
                    </div>

                    <div class="flex-sb-m w-full p-b-48">
                        <div class="contact100-form-checkbox">
                            <input class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me">
                            <label class="label-checkbox100" for="ckb1">
                                Remember me
                            </label>
                        </div>

                        <div>
                            <a href="#" class="txt3">Olvidó su clave?
                            </a>
                        </div>
                    </div>

                    <div class="container-login100-form-btn">

                        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="login100-form-btn" OnClick="btnLogin_Click" />

                    </div>

                </form>
            </div>
        </div>
    </div>


    <div id="dropDownSelect1"></div>

    <!--===============================================================================================-->
    <script src="../../vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="../../vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="../../vendor/bootstrap/js/popper.js"></script>
    <script src="../../vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="../../vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="../../vendor/daterangepicker/moment.min.js"></script>
    <script src="../../vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="../../vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="../../js/main.js"></script>

    <%--<form id="form1" runat="server">
        <div>
        </div>
    </form>--%>
</body>
</html>
