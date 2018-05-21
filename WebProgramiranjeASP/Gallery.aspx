<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="WebProgramiranjeASP.Gallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="ResponsiveSlides.js-master/responsiveslides.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contents" runat="server">
    <script type="text/javascript">
        /* slider plugin*/
        $(function () {
            $(".rslides").responsiveSlides({
                auto: false,
                pager: true,
                nav: true,
                speed: 500,
                maxwidth: 800,
                namespace: "centered-btns"
            });
        });
        

  //end
    </script>
    <section id="fourth">
  <div class="content-text">
      <div class="gall">
        <ul class="rslides" id="rslides" runat="server">

        </ul>
     </div>
  </div>
</section>

</asp:Content>
