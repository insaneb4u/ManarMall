 jQuery('.tp-banner').revolution(
    {
      delay:9000,
      startwidth:1170,
      startheight:768,
      hideThumbs:10,
      fullWidth:"on",
      forceFullWidth:"on",
    });

    /*youtube_player*/
    $('#play_vid').on('click', function() {
      $(this).html('<iframe src="http://www.youtube.com/embed/FJHuNTMguO8?rel=0&autoplay=1" width="100%"  height="100%"   frameborder="0" allowfullscreen="true">').css('background', 'none');
    });
    $('#play_vid3').on('click', function() {
      $(this).html('<iframe src="http://www.youtube.com/embed/FJHuNTMguO8?rel=0&autoplay=1" width="100%"  height="100%"   frameborder="0" allowfullscreen="true">').css('background', 'none');
    });
    $('#play_vid_2').on('click', function() {
      $(this).html('<iframe src="http://www.youtube.com/embed/FJHuNTMguO8?rel=0&autoplay=1" width="100%"  height="100%"   frameborder="0" allowfullscreen="true">').css('background', 'none');
    });
    /*youtube_player*/
    $('.grid').isotope({
      itemSelector: '.grid-item',
      masonry: {
        columnWidth: 1,
        gutter:0
      }
    });



    $( "#search_btn" ).click(function() {
      $('#search_bar').slideToggle('Slow');
    });
    var $menu = $('#search_bar');
    $('.container-fluid').mouseup(function (e) {
     if (!$menu.is(e.target)  
       && $menu.has(e.target).length === 0)  
     {
       $menu.slideUp();
     }
   }); 
    $('footer').mouseup(function (e) {
     if (!$menu.is(e.target)  
       && $menu.has(e.target).length === 0)  
     {
       $menu.slideUp();
     }
   }); 
    $('.service-area').mouseup(function (e) {
     if (!$menu.is(e.target)  
       && $menu.has(e.target).length === 0)  
     {
       $menu.slideUp();
     }
   }); 


  $('.top_bottom').owlCarousel({
    rtl:false,
    loop:true,
    autoplay:true,
    autoplayTimeout:4000,
    smartSpeed:3500,
    autoplayHoverPause:true,
    animateOut: 'slideOutUp',
    center: true,
    pagination: false,
    singleItem:true,
    dots: false,
    animateIn: 'slideInUp',
    autoHeight: true,
    mouseDrag:false,
    touchDrag:false,
    lazyLoad: true,
    margin:0,
    nav:false,
    responsive:{
      0:{
        items:1
      },
      600:{
        items:1
      },
      1000:{
        items:1
      }
    }
  });
  $('.bottom_top').owlCarousel({
    rtl:false,
    loop:true,
    autoplay:true,
    autoplayTimeout:4000,
    smartSpeed:3500,
    autoplayHoverPause:true,
    animateOut: 'slideOutDown',
    center: true,
    pagination: false,
    dots: false,
    animateIn: 'slideInDown',
    autoHeight: true,
    mouseDrag:false,
    touchDrag:false,
    lazyLoad: true,
    margin:0,
    nav:false,
    responsive:{
      0:{
        items:1
      },
      600:{
        items:1
      },
      1000:{
        items:1
      }
    }
  })
 
  $('.right_left').owlCarousel({
    singleItem:true,
	 navigation : false,
    items : 1, 
    loop:false,
       nav:false,
    animateOut: 'fadeOut',
       animateIn: 'fadeIn',
    mouseDrag:false,
    touchDrag:false,
    pullDrag:false,
    freeDrag:false, 
    responsive:{
      0:{
        items:1
      },
      600:{
        items:1
      },
      1000:{
        items:1
      }
    }
  })
 
 
 


  $(".eqheight").matchHeight({
    byRow: true,
    property: 'height',
    target: null,
    remove: false
  });
  $(".sub_cont1").matchHeight({
    byRow: true,
    property: 'height',
    target: null,
    remove: false
  });
  $(".eqheight1").matchHeight({
    byRow: true,
    property: 'height',
    target: null,
    remove: false
  });

  $(".tile_blank").matchHeight({
    byRow: true,
    property: 'height',
    target: null,
    remove: false
  });
  $(".tile_blank2").matchHeight({
    byRow: true,
    property: 'height',
    target: null,
    remove: false
  });
   $(document).ready(function (){
            $("#click").click(function (){
                $('html, body').animate({
                    scrollTop: $("#mall_time").offset().top
                }, 4000);
            });

             $('select').niceSelect();
        });



window.onload = function() {
    var d = new Date();
    var n = d.getFullYear();
    document.getElementById("curr_year").innerHTML = n;
  
}