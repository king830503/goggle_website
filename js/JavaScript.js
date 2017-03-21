
          //幻燈片
          $(function () {
              // 先取得必要的元素並用 jQuery 包裝
              // 再來取得 $slides 的高度及設定動畫時間
              var $block = $('#abgneBlock'),
                  $slides = $('#player ul.list', $block),
                  _height = $slides.find('li').height(),
                  $li = $('li', $slides),
                  _animateSpeed = 900,
                  timer, _speed = 6000;

              // 產生 li 選項
              var _str = '';
              for (var i = 0, j = $li.length; i < j; i++) {
                  // 每一個 li 都有自己的 className = playerControl_號碼
                  _str += '<li class="playerControl_' + (i + 1) + '">' + (i + 1) + '</li>';
              }

              // 產生 ul 並把 li 選項加到其中
              // 並幫 li 加上 mouseover 事件
              var $controlLi = $('<ul class="playerControl"></ul>').html(_str).appendTo($slides.parent()).find('li');
              $controlLi.mouseover(function () {
                  clearTimeout(timer);

                  var $this = $(this);
                  $this.addClass('current').siblings('.current').removeClass('current');
                  // 移動位置到相對應的號碼
                  $slides.stop().animate({
                      top: _height * $this.index() * -1
                  }, _animateSpeed, function () {
                      if (!_isOver) timer = setTimeout(moveNext, _speed);
                  });

                  return false;
              }).eq(0).mouseover();

              // 當滑鼠移到 $block 時則停止輪播
              // 移出時則繼續輪播
              var _isOver = false;
              $block.mouseenter(function () {
                  clearTimeout(timer);
                  _isOver = true;
              }).mouseleave(function () {
                  _isOver = false;
                  timer = setTimeout(moveNext, _speed);
              });

              // 用來控制移動的函式
              function moveNext() {
                  var _now = $controlLi.filter('.current').index();
                  $controlLi.eq((_now + 1) % $controlLi.length).mouseover();
              }
          });



       var Imgs = new Array(); //設定圖片的網址
Imgs[0] = "menu/menu-home.gif";

function showPic(picUrl) {


    show = document.getElementById("pic");
    if (arguments.length > 0)  //有引數就顯示圖片，沒有引數就隱形。
        show.innerHTML = '<img src="' + Imgs[picUrl] + '" style=width:70px;>';

    else
        show.innerHTML = '';
}


      var Imgs1 = new Array(); //設定圖片的網址
Imgs1[0] = "menu/vote.gif";

function showPic1(picUrl) {


    show = document.getElementById("D1");
    if (arguments.length > 0)  //有引數就顯示圖片，沒有引數就隱形。
        show.innerHTML = '<img src="' + Imgs1[picUrl] + '" style=width:70px;>';

    else
        show.innerHTML = '';
}


    var Imgs2 = new Array(); //設定圖片的網址
Imgs2[0] = "menu/menu-message.gif";

function showPic2(picUrl) {


    show = document.getElementById("D2");
    if (arguments.length > 0)  //有引數就顯示圖片，沒有引數就隱形。
        show.innerHTML = '<img src="' + Imgs2[picUrl] + '" style=width:70px;>';

    else
        show.innerHTML = '';
}


    var Imgs3 = new Array(); //設定圖片的網址
Imgs3[0] = "menu/menu-news.gif";

function showPic3(picUrl) {


    show = document.getElementById("D3");
    if (arguments.length > 0)  //有引數就顯示圖片，沒有引數就隱形。
        show.innerHTML = '<img src="' + Imgs3[picUrl] + '" style=width:70px;>';

    else
        show.innerHTML = '';
}


    var Imgs4 = new Array(); //設定圖片的網址
Imgs4[0] = "menu/download.gif";

function showPic4(picUrl) {


    show = document.getElementById("D4");
    if (arguments.length > 0)  //有引數就顯示圖片，沒有引數就隱形。
        show.innerHTML = '<img src="' + Imgs4[picUrl] + '" style=width:70px;>';

    else
        show.innerHTML = '';
}


    var Imgs5 = new Array(); //設定圖片的網址
Imgs5[0] = "menu/menu-about.gif";

function showPic5(picUrl) {


    show = document.getElementById("D5");
    if (arguments.length > 0)  //有引數就顯示圖片，沒有引數就隱形。
        show.innerHTML = '<img src="' + Imgs5[picUrl] + '" style=width:70px;>';

    else
        show.innerHTML = '';
}



    var Imgs6 = new Array(); //設定圖片的網址
Imgs6[0] = "menu/login.gif";

function showPic6(picUrl) {


    show = document.getElementById("D6");
    if (arguments.length > 0)  //有引數就顯示圖片，沒有引數就隱形。
        show.innerHTML = '<img src="' + Imgs6[picUrl] + '" style=width:70px;>';

    else
        show.innerHTML = '';
}


$(document).ready(function () {
    //Examples of how to assign the Colorbox event to elements
    $(".group1").colorbox();
});

$(function () {
            $("#goTop").click(function () {
                $("html,body").animate({ scrollTop: 0 }, 900);
                return false;
            })
        })

$(function(){
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
});