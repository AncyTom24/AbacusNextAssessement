﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AbacusNextAssessement.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Abacus Next</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>

    <style>
.login-form {
    width: 340px;
    margin: 50px auto;
  	font-size: 15px;
}
.login-form form {
    margin-bottom: 15px;
    background: #f7f7f7;
    box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
    padding: 30px;
}
.login-form h2 {
    margin: 0 0 15px;
}
.form-control, .btn {
    min-height: 38px;
    border-radius: 2px;
}
.btn {        
    font-size: 15px;
    font-weight: bold;
}
</style>

</head>
<body>
    <div class="login-form">
    <form runat="server" method="post">
        <h2 class="text-center">Log in</h2>       
        <div class="form-group">
            <%--<input type="text" class="form-control" placeholder="Username" required="required"/>--%>
            <asp:TextBox runat ="server" CssClass="form-control" ID="txtUserName" placeholder="Username" required="required"></asp:TextBox>
        </div>
        <div class="form-group">
            <%--<input type="password" class="form-control" placeholder="Password" required="required"/>--%>
            <asp:TextBox runat ="server" TextMode="Password" CssClass="form-control" ID="txtPassword" placeholder="Password" required="required"></asp:TextBox>
        </div>
        <div class="form-group">
            <%--<button type="submit" class="btn btn-primary btn-block">Log in</button>--%>
            <asp:Button runat="server" ID="btnLogin" Text="Log in" OnClick="btnLogin_Click" CssClass="btn btn-primary btn-block"/>
        </div>
        <div class="clearfix">
            <%--<label class="float-left form-check-label"><input type="checkbox"/> Remember me</label>--%>
            <%--<a href="#" class="float-right">Forgot Password?</a>--%>
        </div>        
    </form>
    <p class="text-center"><a href="CreateAccount.aspx">Create an Account</a></p>
</div>
</body>
</html>
