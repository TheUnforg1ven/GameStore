var $btnTop = $(".btn-top");

$(window).on("scroll", () => {
    if ($(window).scrollTop() >= 400){
        $btnTop.fadeIn();
    }
    else {
        $btnTop.fadeOut();
    }
});

$btnTop.on("click", () => {
    $("html, body").animate({ scrollTop: 0 }, 900);
});