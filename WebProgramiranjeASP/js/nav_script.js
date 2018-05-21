function LogoBig(){
  //resize navigation and logo on scroll
  //modified jquery http://codepen.io/dr_pivotal/pen/oLgKQE
  $('nav').css({'height':300});
  $('.logo').css({'height':200});
  $('.logo img').css({'width':200});
  $('.logo img').css({ 'height': 200 });
  $('.menu').css({'border-bottom': 'none'});
  function init(){
  window.addEventListener('scroll', function(e){

    var distanceY = window.pageYOffset || document.documentElement.scrollTop, shrinkOn = 450, header = $("header");
    if (distanceY > shrinkOn){
      $('nav').css({'height':200});
      $('.logo').css({'height':100});
      $('.logo img').css({'width':100});
      $('.logo img').css({ 'height': 100 });
      $('.menu').css({'border-bottom': '1px solid black'});
    } else{
      if($('nav').css({'height':200}) || $('.logo').css({'height':100})){
        $('nav').css({'height':300});
        $('.logo').css({'height':200});
        $('.logo img').css({'width':200});
        $('.logo img').css({'height':200});
        $('.logo').css({ 'top': 0 });
        $('.menu').css({'border-bottom': 'none'});
      }
    }
    });
  }
  window.onLoad = init();
  //end of resizing
};
