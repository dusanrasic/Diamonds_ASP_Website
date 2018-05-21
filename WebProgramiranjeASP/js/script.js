$(document).ready(function () { 
  //pre loader
  function preload(){

    $('#spinner').fadeOut('slow');
    $('#preloader').fadeOut('slow');
    $('body').css({'overflow-y':'auto'});
  }
  setTimeout(preload,600);
  // end of pre loader
  //modified opacity on scroll http://codepen.io/michaeldoyle/pen/Bhsif
    var header = $('header');
    var range = 500;
  if ($("#first").length) {
  $(window).on('scroll', function () {

      var scrollTop = $(this).scrollTop();
      var offset = header.offset().top;
      var height = header.outerHeight();
      offset = offset + height / 2;
      var calc = 0.5 - (scrollTop - offset + range) / range;

      header.css({ 'opacity': calc });

      if ( calc > '1' ) {
        header.css({ 'opacity': 1 });
      } else if ( calc < '0' ) {
        header.css({ 'opacity': 0 });
      }

  });
    }

  //end of opacity
  
  //log in form toggle
  $('.btnLog').click(function(){

      if (!$(".form-log").is(":visible")) {
          $('.form-log').css({ 'display': 'none' });
      }
			
    $('.form-log').slideToggle(500 , function(){
        if (!$(".form-log").is(":visible")) {
            $('.form-log').css({ 'display': 'none' });
        }
    });
  });
  //end
  //hiding nav on section about-me-img
  function nav() {
     var $win = $(window);
     if ($('section').hasClass('about-me-img')) {
     $win.scroll(function () {
         if ($win.scrollTop() < $('#aboutme').height()-250){
          $('nav').css({"display":"block"});
         }
         else if ($win.height() + $win.scrollTop() > $('#aboutme').height()-250) {
             $('nav').css({"display":"none"});
         }
     });
     }
    }
    window.onLoad = nav();
  //end
  // contact form
  $(function(){

  $('.awesome-form .input-group input').focusout(function(){

    var text_val = $(this).val();

    if(text_val === "") {

      $(this).removeClass('has-value');

    } else {

      $(this).addClass('has-value');

    }

  });

});
  //end
  $(function(){

  $('.awesome-form3 .input-group3 input').focusout(function(){

    var text_val = $(this).val();

    if(text_val === "") {

      $(this).removeClass('has-value');

    } else {

      $(this).addClass('has-value');

    }

  });

});

  //script for table
  $('table tr').each(function(){
    $(this).find('th').first().addClass('first');
    $(this).find('th').last().addClass('last');
    $(this).find('td').first().addClass('first');
    $(this).find('td').last().addClass('last');
  });

  $('table tr').first().addClass('row-first');
  $('table tr').last().addClass('row-last');
  //end
  //dropdown
  $(".dropdown-content li").hover(
    function() {
      $(this).find('ul').slideDown();
    },
    function() {
      $(this).find('ul').slideUp();
    });
  //end
  
});
// form
function contactForm() {
    $('.awesome-form').css({ "display": "none" });
    $('.li-reg').click(function (event) {
        event.preventDefault();
        $('.notice').css({ "display": "none" });
        $('.awesome-form').css({ "display": "block" });
        $('.contact-form').css({ "width": "30%" });
        $('.contact-form').css({ "height": "40vh" });

    });
    $('#btnRegister').css({ "display": "none" });
    $('.backBtn').css({ "display": "none" });
    $('#mail').hide(0);
    $('#btnReg').click(function (event) {
        event.preventDefault();
        $('#btnReg').hide(0);
        $('#btnLog').hide(0);
        $('#btnRegister').css({ "display": "block", "margin": "0 auto", "margin-top": 15 });
        $(".backBtn").css({ "display": "block" });
        $('#mail').show(500);
    });
    $('.backBtn').click(function (event) {
        event.preventDefault();
        $('#mail').hide(500);
        $('#btnRegister').css({ "display": "none" });
        $('.backBtn').css({ "display": "none" });
        $('#btnReg').show(0);
        $('#btnLog').show(0);
    });
}
  //end