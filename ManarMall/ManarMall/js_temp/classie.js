( function( window ) {

  'use strict';

  function classReg( className ) {
    return new RegExp("(^|\\s+)" + className + "(\\s+|$)");
  }

  var hasClass, addClass, removeClass;

  if ( 'classList' in document.documentElement ) {
    hasClass = function( elem, c ) {
      return elem.classList.contains( c );
    };
    addClass = function( elem, c ) {
      elem.classList.add( c );
    };
    removeClass = function( elem, c ) {
      elem.classList.remove( c );
    };
  }
  else {
    hasClass = function( elem, c ) {
      return classReg( c ).test( elem.className );
    };
    addClass = function( elem, c ) {
      if ( !hasClass( elem, c ) ) {
        elem.className = elem.className + ' ' + c;
      }
    };
    removeClass = function( elem, c ) {
      elem.className = elem.className.replace( classReg( c ), ' ' );
    };
  }

  function toggleClass( elem, c ) {
    var fn = hasClass( elem, c ) ? removeClass : addClass;
    fn( elem, c );
  }

  var classie = {
  // full names
  hasClass: hasClass,
  addClass: addClass,
  removeClass: removeClass,
  toggleClass: toggleClass,
  // short names
  has: hasClass,
  add: addClass,
  remove: removeClass,
  toggle: toggleClass
};

// transport
if ( typeof define === 'function' && define.amd ) {
  // AMD
  define( classie );
} else {
  // browser global
  window.classie = classie;
}

})( window );

(function( window ){  
  'use strict';
  var body = document.body,
  mask = document.createElement("div"),
  toggleSlideRight = document.querySelector( ".toggle-slide-right" ),
  activeNav
  ;
  mask.className = "mask";

  /* slide menu right */
  toggleSlideRight.addEventListener( "click", function(){
    classie.add( body, "smr-open" );
    document.body.appendChild(mask);
    activeNav = "smr-open";
  } );

  /* hide active menu if mask is clicked */
  mask.addEventListener( "click", function(){
    classie.remove( body, activeNav );
    activeNav = "";
    document.body.removeChild(mask);
  } );

  /* hide active menu if close menu button is clicked */
  [].slice.call(document.querySelectorAll(".close-menu")).forEach(function(el,i){
    el.addEventListener( "click", function(){
      classie.remove( body, activeNav );
      activeNav = "";
      document.body.removeChild(mask);
    } );
  });
})( window );