<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebProgramiranjeASP.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contents" runat="server">
<section id="contact">
<div class="contact-form">
<form class="awesome-form2" method="post" name="comm" id="comForm" runat="server">

  <div class="input-group2">
     <asp:TextBox ID="commText" runat="server" TextMode="MultiLine" Width="500px" />
    <%--<textarea id="comm-text" name="comm-text" autocomplete="off" role="textbox" aria-autocomplete="list"></textarea>--%>
    <label class="comm-title">Your Text</label>
  </div>
    <asp:Button Name="btnSub" ID="btnSub" runat="server" Text="Send" OnClick="btnSub_Click"/>

</form>
<h1 class="notice" id="notice" runat="server">Please <i class="li-reg">login/register</i> for contact form.</h1>
<form method="post" name="form" id="awesomeForm" class="awesome-form" runat="server">

<div class="input-group">
  <asp:TextBox ID="username" Name="username" runat="server"/>
  <label>Your User Name</label>
</div>
<div class="input-group">
  <asp:TextBox ID="password" Name="password" runat="server" TextMode="Password"/>
  <label>Your Password</label>
</div>
<div class="input-group" id="mail">
  <asp:TextBox ID="email" Name="email" runat="server" TextMode="Email"/>
  <label>Your Email Address</label>
</div>
<asp:Button Name="btnLog" ID="btnLog" Text="LogIn" runat="server" OnClick="btnLog_Click"/>
<input type="button" name="btnReg" id="btnReg" value="Register">
<asp:Button Name="btnRegister" ID="btnRegister" Text="Register" runat="server" OnClientClick="return validate();"  OnClick="btnRegister_Click"/>
<div class="backBtn">
  <p><</p>
</div>
</form>
</div>
</section>

</asp:Content>
