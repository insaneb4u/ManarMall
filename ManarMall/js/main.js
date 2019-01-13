(function($) {
    "use strict";
    
    
    /* menu  sticky */
     var header = $('.header-sticky');
    var win = $(window);
    
    win.on('scroll', function() {

        var scroll = win.scrollTop();
        if (scroll < 40) {
           
            header.removeClass("sticky");
         
        } else {
            header.addClass("sticky");
            
        }

 

    }); 
    
    
    /* mobile-menu  */
    $('.main-menu nav').meanmenu({
        meanScreenWidth: "991",
        meanMenuContainer: '.mobile-menu'
    });
  
    
    /* portfolio menu  */
    $('.portfolio-menu button').on('click', function(event) {
        $(this).siblings('.active').removeClass('active');
        $(this).addClass('active');
        event.preventDefault();
    });
    
    
       
    /* menu-toggle */
	
	var menutoggle = $('.menu-toggle');
	var mainmenu = $('.main-menu nav');
	
    menutoggle.on('click', function() {
        if (menutoggle.hasClass('is-active')) {
            mainmenu.removeClass('menu-open');
        } else {
            mainmenu.addClass('menu-open');
        }
    });
    
    
    /* menu 10 */
	var menu10 = $('.main-menu-10');
	
    $('.menu-toggle-10').on('click', function() {
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
            menu10.animate({
                left: '-225px'
            }, 500);
        } else {
            $(this).addClass('active');
            menu10.animate({
                left: '0'
            }, 500);
        }
    });
    
    
    /* Hamburger js */
    var forEach = function(t, o, r) {
        if ("[object Object]" === Object.prototype.toString.call(t))
            for (var c in t) Object.prototype.hasOwnProperty.call(t, c) && o.call(r, t[c], c, t);
        else
            for (var e = 0, l = t.length; l > e; e++) o.call(r, t[e], e, t)
    };
    
    var hamburgers = document.querySelectorAll(".hamburger");
    if (hamburgers.length > 0) {
        forEach(hamburgers, function(hamburger) {
            hamburger.addEventListener("click", function() {
                this.classList.toggle("is-active");
            }, false);
        });
    }
     
     
    
    /*  counter js active  */
    $(".about-counter").counterUp({
        delay: 10,
        time: 2000
    });
    
    
    
    /* scrollUp */
	var totop = $('#toTop');
	
    win.on('scroll', function() {
        if (win.scrollTop() > 200) {
            totop.fadeIn();
        } else {
            totop.fadeOut();
        }
    });
    totop.on('click', function() {
        $("html,body").animate({
            scrollTop: 0
        }, 500)
    });
 
     /*----------------------------
    kenburne
    ------------------------------ */   
    $(".slide-kenburne").kenburnsy({
      fullscreen: true
    });
    
    
    
    /*----------------------------
    ripples-active
    ------------------------------ */  
    $('.ripples-active').ripples({
     resolution: 1024,
     dropRadius: 15,
     perturbance: 0.01,
    });

    
    
    
    
    
 
    



})(jQuery);