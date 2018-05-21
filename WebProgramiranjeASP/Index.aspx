<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Index.aspx.cs" Inherits="WebProgramiranjeASP.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contents" runat="server">
    <script type="text/javascript">
            window.load = LogoBig();
    </script>
    <section id="first">
  <header>
    <div class='container'>
      <h1>Diamond</h1>
    </div>
  </header>
</section>
<section id="second">
  <div class="container">
    <div class='boxes box1' id="box1" runat="server" ></div>
    <div class='boxes box2' id="box2" runat="server" ></div>
    <div class='boxes box3' id="box3" runat="server" ></div>
    <div class='boxes box4' id="box4" runat="server" ></div>
    <div class='boxes box5' id="box5" runat="server" ></div>
    <div class='boxes box6' id="box6" runat="server" ></div>
  </div>
</section>

</asp:Content>
