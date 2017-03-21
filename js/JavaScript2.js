$(document).ready(function () {
  $(".group1").colorbox();
  $("#goTop").click(function () {
        $("html,body").animate({ scrollTop: 0 }, 900);
        return false;
    })
    $(window).load(function(){
　　$(window).bind('scroll resize', function(){
　　var $this = $(this);
　　var $this_Top=$this.scrollTop();

　　//當高度小於100時，關閉區塊 
　　if($this_Top < 450){
　　　$('#top-bar').stop().animate({top:"-110px"});
　　　}
　　　　if($this_Top > 450){
　　　　$('#top-bar').stop().animate({top:"0px"});
　　　 }
　　}).scroll();
　});
})