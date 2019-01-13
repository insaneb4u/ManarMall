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
  



    /*$( "#search_btn" ).click(function() {
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
*/

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
 
 
 


  $(".mapheight").matchHeight({
    byRow: true,
    property: 'height',
    target: null,
    remove: false
  });

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
                }, 1000);
            });

            $("#welcome").click(function (){
                $('html, body').animate({
                    scrollTop: $("#myVideo").offset().top
                }, 1000);
            });

             $('select').niceSelect();
        });



window.onload = function() {
    var d = new Date();
    var n = d.getFullYear();
    document.getElementById("curr_year").innerHTML = n;
  
}
 
function openNav() {

 if ( $('.overlay-search').hasClass( "zoom_in_pop" ) ) {
$('.overlay-search').removeClass('zoom_in_pop');
$('.overlay-search').toggleClass('zoom_out_pop');
}
else
{
  $('.overlay-search').removeClass('zoom_out_pop');
  $('.overlay-search').toggleClass('zoom_in_pop');
}
 
  

}
 $(document).keyup(function(e) {     
    if(e.keyCode== 27) {
        openNav();  
    } 
});

var isMobile = /Android|webOS|iPhone|iPad|iPod|BlackBerry/i.test(navigator.userAgent) ? true : false;
        jQuery(document).ready(function ($) {
            if (!isMobile) {
                $(function () {
                    $.scrollSpeed(100, 800);
                });
 
 
            }
        });

       

(function ($) {

"use strict";

function centerModal() {

$(this).css('display', 'block');

var $dialog = $(this).find(".modal-dialog"),

offset = ($(window).height() - $dialog.height()) / 2,

bottomMargin = parseInt($dialog.css('marginBottom'), 10);

if (offset < bottomMargin) offset = bottomMargin;

$dialog.css("margin-top", offset);

}

$(document).on('show.bs.modal', '.modal', centerModal);

$(window).on("resize", function () {

$('.modal:visible').each(centerModal);

});

}(jQuery));