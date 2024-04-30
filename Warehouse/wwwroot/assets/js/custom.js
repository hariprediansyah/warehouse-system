$(window).on("load", function () {
  "use strict";
  /*=========================================================================
            Preloader
    =========================================================================*/
  $("#preloader").delay(750).fadeOut("slow");
});

/*=========================================================================
            Home Slider
=========================================================================*/
$(document).ready(function () {
  "use strict";

  /*=========================================================================
            Slick sliders
    =========================================================================*/
  $(".post-carousel-lg").slick({
    dots: true,
    arrows: true,
    slidesToShow: 1,
    slidesToScroll: 1,
    fade: true,
    cssEase: "linear",
    responsive: [
      {
        breakpoint: 768,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
          dots: true,
          arrows: false,
        },
      },
    ],
  });

  $(".post-carousel-featured").slick({
    dots: true,
    arrows: false,
    slidesToShow: 5,
    slidesToScroll: 2,
    responsive: [
      {
        breakpoint: 1440,
        settings: {
          slidesToShow: 4,
          slidesToScroll: 4,
          dots: true,
          arrows: false,
        },
      },
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          dots: true,
          arrows: false,
        },
      },
      {
        breakpoint: 768,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2,
          dots: true,
          arrows: false,
        },
      },
      {
        breakpoint: 576,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
          dots: true,
          arrows: false,
        },
      },
    ],
  });

  $(".post-carousel-twoCol").slick({
    dots: false,
    arrows: false,
    slidesToShow: 2,
    slidesToScroll: 1,
    responsive: [
      {
        breakpoint: 768,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2,
          dots: false,
          arrows: false,
        },
      },
      {
        breakpoint: 576,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
          dots: false,
          arrows: false,
        },
      },
    ],
  });
  // Custom carousel nav
  $(".carousel-topNav-prev").click(function () {
    $(".post-carousel-twoCol").slick("slickPrev");
  });
  $(".carousel-topNav-next").click(function () {
    $(".post-carousel-twoCol").slick("slickNext");
  });

  $(".post-carousel-widget").slick({
    dots: false,
    arrows: false,
    slidesToShow: 1,
    slidesToScroll: 1,
    responsive: [
      {
        breakpoint: 991,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 1,
        },
      },
      {
        breakpoint: 576,
        settings: {
          slidesToShow: 1,
          centerMode: true,
          slidesToScroll: 1,
        },
      },
    ],
  });
  // Custom carousel nav
  $(".carousel-botNav-prev").click(function () {
    $(".post-carousel-widget").slick("slickPrev");
  });
  $(".carousel-botNav-next").click(function () {
    $(".post-carousel-widget").slick("slickNext");
  });

  /*=========================================================================
            Sticky header
    =========================================================================*/
  var $header = $(
      ".header-default, .header-personal nav, .header-classic .header-bottom"
    ),
    $clone = $header.before($header.clone().addClass("clone"));

  $(window).on("scroll", function () {
    var fromTop = $(window).scrollTop();
    $("body").toggleClass("down", fromTop > 300);
  });
});
