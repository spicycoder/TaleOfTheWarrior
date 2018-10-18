var tabs = $('.tabs');
var items = $('.tabs').find('a').length;
var selector = $(".tabs").find(".selector");
var activeItem = tabs.find('.active');
var activeWidth = activeItem.innerWidth();

$(document).ready(function () {
  // $('#frame').attr('src', './demo/index.html');
});

$('iframe').on('load', function(){
  var height = $(this).contents().outerHeight() + 'px';
  $('#frame').css('height', height);
});

$(".selector").css({
  "left": activeItem.position.left + "px", 
  "width": activeWidth + "px"
});

$(".tabs").on("click","a",function(e){
  e.preventDefault();
  
   var url = this.href;
   var id = $(this).attr('id');
   
   if(id === 'demo') {
    $('#frame').css('height', "0px");
    $('#frame').hide();
    $('#animated-demo').show();
   }
   else if (id === 'fork') {
     document.location.href = url;
   }
   else {
    $('#frame').attr('src', url);
    $('#frame').show();
    $('#animated-demo').hide();
   }

  $('.tabs a').removeClass("active");
  $(this).addClass('active');
  
  var activeWidth = $(this).innerWidth();
  var itemPos = $(this).position();
  $(".selector").css({
    "left":itemPos.left + "px", 
    "width": activeWidth + "px"
  });
});