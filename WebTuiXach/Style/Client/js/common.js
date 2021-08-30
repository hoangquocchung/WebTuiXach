$(document).ready(function(){
    $('.btn_menu_mobile').click( function(event){
        index = $(this).index();
        //$('.qc__header_menu').css({'transform':'translate(-100%)'});
        $('.qc__header_menu').addClass('menu_mobile')
        $('html').addClass('cc')
    })
    $('.close').click( function(){
        //$('.qc__header_menu').css({'transform':'translate(100%)'});
        $('.qc__header_menu').removeClass('menu_mobile')
        $('html').removeClass('cc')
    })
    $('.btn_search_mobile').off('click').on('click', function(e){
        index = $(this).index();
        //$('.qc__form_search').css({'display':'block'})
        $('.qc__form_search').addClass('q')
    })
    // $('html').off('click').on('click', function(e){
    //     $('.qc__form_search').css({'display':'none'})
    // })
    
})

$(document).ready(function(){
    $('#my_carousel').owlCarousel({
                items:1,
                loop:true,
                autoplay: true,
                autoplayHoverPause: true,
                autoplayTimeout: 5000000,
                nav:false,
                dots: true,
                margin: 30,
                responsiveClass:true,
                
            });
    $('#my_carousel2,#my_carousel3').owlCarousel({
                loop:true,
                autoplay: true,
                autoplayHoverPause: true,
                autoplayTimeout: 5000000,
                nav:true,
                dots: false,
                margin:30,
                responsiveClass:true,
                responsive:{
                    0:{
                        items:2,
                        nav: false,
                        margin: 30,
                    },
                    600:{
                        items:3,
                    },
                    1000:{
                        items:4,
                    }
                }
                
            });

// button next,prev
    $('.owl-next span').html('<i class="fa fa-arrow-circle-right" style="font-size:30px;transition:ease .5s" aria-hidden="true"></i>')
    $('.owl-prev span').html('<i class="fa fa-arrow-circle-left" style="font-size:30px;transition:ease .5s" aria-hidden="true"></i>')
})