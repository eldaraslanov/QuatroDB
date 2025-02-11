jQuery(function ($) {

    'use strict';

	/**
	 * @param state - (object) current object { name_of_param : value }
	 * @param title - (string) title
	 */
	function pix_change_url(state, title, href){
		title = title || '';
		href = href || false;

		var data = {
            action: 'pixcars_filter',
            href: href,
            nonce: pixcarsAjax.nonce
        },
            currentState = {},
            qstring = '',
            url_str = '';

		if( !href ){
		    currentState = history.state == null ? {} : history.state;
        } else {
		    qstring = $('.pix-filter-box .pix-button').data('href');
		    currentState = qstring == '' ? {} : JSON.parse(qstring);
        }

        $.extend( currentState, state );
        if($('#sort-purpose').val() != ''){
            var purpose = { 'purpose' : $('#sort-purpose').val() }
            $.extend( currentState, purpose );
        }
        $.each( currentState, function( key, val ) {
            if(val != '')
				url_str = url_str + "&" + key + "=" + val;
		});
        url_str = url_str.replace('&','?');

        if( !href ){
            history.pushState(currentState, title, url_str);
        }

        $.extend( data, currentState );

        if( href ) {
            var page = $('.pix-filter-box .pix-button').data('page');
            $('.pix-filter-box .pix-button').data('href', JSON.stringify(currentState));
            $('.pix-filter-box .pix-button').attr('href', page + url_str);
        }

		return data;
	}

	function goToByScroll(id){
	    $('html,body').animate({
	        scrollTop: $('#pix-sorting').offset().top - 110
	    }, 700);
	}

	function showAjaxLoader(){
		//goToByScroll();
		$('.pix-ajax-loader').addClass('ajax-loading');
	}

	function hideAjaxLoader(){
		$('.pix-ajax-loader').removeClass('ajax-loading');
		pageClick();
	}

    $('#ajax-make').on( 'change', function (e) {
        e.preventDefault();
        var make_val = $(this).val(),
            args = {},
            href = $(this).hasClass('pix-count');
        args['make'] = '';
        pix_change_url(args, 'make', href);
        args['model'] = '';
        pix_change_url(args, 'model', href);
		var data = {
            action: 'pixcars_filter',
            nonce: pixcarsAjax.nonce,
            make_model: make_val,
        };
        console.log(href);
        $.get( pixcarsAjax.url, data, function( response ){
            //console.log('AJAX response : ',response.data);
            $('#pixcars-model').html(response.data).customSelect('reset');
            $('#pixcars-model').parent().find('.pix-custom-select .custom-select__option--value').prop('disabled', false);
        });

        //showAjaxLoader();
        var args = {};
        if(make_val.length > 0) {
            args['make'] = make_val;
        }
        else
            args['make'] = '';
        var data = pix_change_url(args, 'make', href);
		console.log('AJAX data : ',data);
		if(href){
            $.get(pixcarsAjax.url, data, function (response) {
                //console.log('AJAX response : ',response.data);
                $('.pix-filter-box .pix-button span').text(response.data);
            });
        } else {
            $.get(pixcarsAjax.url, data, function (response) {
                //console.log('AJAX response : ',response.data);
                $('#pixcars-listing').html(response.data);
                createImgSlider();
                //hideAjaxLoader();
            });
        }
    });


    $('.pix-pagination li a').live('click', function (e) {
        e.preventDefault();
        //showAjaxLoader();

        var state = {'paged': $(this).data('page')}
        var data = pix_change_url(state, 'paged');
        //console.log(data);

        $.get(pixcarsAjax.url, data, function (response) {
            console.log('AJAX response : ',response.data);
            $('#pixcars-listing').html(response.data);
            createImgSlider();
            //hideAjaxLoader();
        });
    });


	$(".pixcars-filter").on( 'change', function (e) {
        //showAjaxLoader();
        e.preventDefault();
	    var args = {},
            args_str = '',
            type = $(this).data('type'), // check - checkbox, number - input with int, text - input with string, select - select
	        field = $(this).data('field'),
	        href = $(this).hasClass('pix-count');
		//console.log('type : ',type);
		//console.log(href);
        if(type == 'check'){
			$("[name^='pixcars-"+field+"']").each(function(key,val) {
				if( $(this).prop( "checked" ) ){
					args_str = args_str + ',' + $(this).val();
				}
			});
			if(args_str.length > 0) {
				args_str = args_str.replace(',', '');
				args[field] = args_str;
			}
			else
				args[field] = '';
        }
        if(type == 'number'){
            var pair_input = $(this).siblings('.pixcars-filter');
            if(pair_input.hasClass('pix-min')){
                args_str = pair_input.val() + ',' + $(this).val();
            }
            if(pair_input.hasClass('pix-max')){
                args_str = $(this).val() + ',' + pair_input.val();
            }
            //console.log(args_str);
			if(args_str.length > 0) {
				args[field] = args_str;
			}
			else
				args[field] = '';
        }
        if(type == 'select'){
	        args_str = $(this).val();
	        //console.log(args_str);
			if(args_str.length > 0) {
				args[field] = args_str;
			}
			else {
				if(field == 'model'){
                    args_str = $(this).val();
                    args[field] = args_str;
				} else
                	args[field] = '';
            }
        }
		//console.log('args data : ',args);
        var data = pix_change_url(args, 'filter', href);

		console.log('AJAX data : ',data);
        if(href){
            $.get(pixcarsAjax.url, data, function (response) {
                //console.log('AJAX response : ',response.data);
                $('.pix-filter-box .pix-button span').text(response.data);
            });
        } else {
            $.get(pixcarsAjax.url, data, function (response) {
                //console.log('AJAX response : ',response.data);
                $('#pixcars-listing').html(response.data);
                createImgSlider();
                //hideAjaxLoader();
            });
        }

    });


    // $('#pixcars-reset-button').on('click', function (e) {
    //     e.preventDefault();
	// 	window.location.href = $(this).data('href');
    // });




    //init range slider
    function pixSliderRange() {
        var sliderRangeBox = $('.pix-range-box');

        sliderRangeBox.each(function () {
            var sliderRange = $(this).find('.pix-slider-range'),
            sliderMin = +sliderRange.attr('data-min'),
            sliderMax = +sliderRange.attr('data-max'),
            sliderStep = +sliderRange.attr('data-step'),
            sliderUnit = sliderRange.attr('data-unit'),
            sliderUnitPos = sliderRange.attr('data-unit-pos'),
            valLeft = '', valRight = '',
            firstVal = $(this).find('.pix-first-value'),
            lastVal = $(this).find('.pix-last-value'),
            input_minVal = $(this).find('.pix-min'),
            input_maxVal = $(this).find('.pix-max');
            if( input_minVal.val() == '' ){
                input_minVal.val(sliderMin);
            }
            if( input_maxVal.val() == '' ){
                input_maxVal.val(sliderMax);
            }

            if(typeof sliderUnit != 'undefined') {
                if (sliderUnitPos == 'left') {
                    valLeft = sliderUnit;
                } else if (sliderUnitPos == 'left_space') {
                    valLeft = sliderUnit+' ';
                } else if (sliderUnitPos == 'right') {
                    valLeft = sliderUnit;
                } else if (sliderUnitPos == 'right_space') {
                    valLeft = ' '+sliderUnit;
                }
            }

            sliderRange.slider({
                range: true,
                min: sliderMin,
                max: sliderMax,
                step: sliderStep,
                values: [input_minVal.val(), input_maxVal.val()],
                slide: function( event, ui ) {
                    firstVal.text(valLeft + ui.values[0] + valRight);
                    lastVal.text(valLeft + ui.values[1] + valRight);
                    input_minVal.val(ui.values[0]);
                    input_maxVal.val(ui.values[1]);
                },
                stop: function( event, ui ) {
                    if(ui.handleIndex == 0){
                        input_minVal.change();
                    } else {
                       input_maxVal.change();
                    }
                }
            });

            firstVal.text(valLeft + sliderRange.slider('values', 0) + valRight);
            lastVal.text(valLeft + sliderRange.slider('values', 1) + valRight);
            input_minVal.val(sliderRange.slider('values', 0));
            input_maxVal.val(sliderRange.slider('values', 1));
        });


    }
    pixSliderRange();
    //-------------------------------------------




    //-------02_listing-------//

    //init custom select
    $('.pix-sort-select select').customSelect();
    $('.pix-sidebar-form select').customSelect();
    $('.pix-test-drive-select select').customSelect();
    $('.pix-filter-box select').customSelect();
    //-------------------------------------------


    //img hover slider
    function createImgSlider() {
        var productBox = $('.pix-product-box');
        var fullStack = false;

        productBox.each(function () {
            var hoverBoxes = $(this).find('.pix-product-hover-boxes');
            var hoverDots = $(this).find('.pix-product-dots-boxes');

            var countImg = $(this).find('.pix-product-show-boxes img').length;

            if(countImg <= 1){

            }else if(countImg < 6){
                for(var i = 0; i < countImg;i++){
                    hoverBoxes.append('<div class="pix-hover-box"></div>');

                    if(i === 0){
                        hoverDots.append('<div class="pix-dot-box pix-active"></div>');
                    }else{
                        hoverDots.append('<div class="pix-dot-box"></div>');
                    }
                }
            }else{
                for(var j = 0; j < 6;j++){
                    if(j === 5){
                        fullStack = true;
                        break;
                    }

                    hoverBoxes.append('<div class="pix-hover-box"></div>');

                    if(j === 0){
                        hoverDots.append('<div class="pix-dot-box pix-active"></div>');
                    }else{
                        hoverDots.append('<div class="pix-dot-box"></div>');
                    }
                }
            }
        });

        if (screen.width <= '1000') {
            pixcarListingScreenWidth();
        }

        $('.pix-hover-box').hover(function () {
            var imgBoxes = $(this).parents('.pix-product-box-img').find('.pix-product-show-boxes');
            var hoverDots = $(this).parents('.pix-product-box-img').find('.pix-product-dots-boxes');

            var index = $(this).index();
            imgBoxes.find('img').css('opacity','0').css('visibility','hidden');
            imgBoxes.find('img').eq(index).css('opacity','1').css('visibility','visible');
            hoverDots.find('.pix-dot-box').removeClass('pix-active');
            hoverDots.find('.pix-dot-box').eq(index).addClass('pix-active');
            if(index === 4 && fullStack){
                imgBoxes.addClass('pix-full-stack');
            }
        }, function () {
            var imgBoxes = $(this).parents('.pix-product-box-img').find('.pix-product-show-boxes');
            imgBoxes.removeClass('pix-full-stack');
        })

        if (screen.width <= '768'){
            $('.pix-product-box-img a').on( 'click', function(e){
                e.preventDefault();
            });
        }
    }
    createImgSlider();
    //-------------------------------------------

    function pixcarListingScreenWidth() {

        var widthContainer = $('.page-template-pixcars-listing > .layout > .container').width();
        var height = Math.ceil(widthContainer / 1.652173913043478);
        $('.pix-product-box .pix-product-show-boxes').css('min-height', height);

    }

    if (screen.width <= '1000') {
        pixcarListingScreenWidth();
    }

    $(window).resize(function () {
        if (screen.width <= '1000') {
            pixcarListingScreenWidth();
        } else {
            $('.pix-product-box .pix-product-show-boxes').css('min-height', '230px');
        }
    });



    //toggle list/grid
    $('.pix-view-btn-1').on('click', function () {
        $('.pix-product-list').addClass('pix-hidden-list');
        setTimeout(function () {
            $('.pix-product-list').hide();
            $('.pix-product-grid').show();

            setTimeout(function () {
                $('.pix-product-grid').removeClass('pix-hidden-list');
            }, 10);
        }, 150);
    });
    $('.pix-view-btn-2').on('click', function () {
        $('.pix-product-grid').addClass('pix-hidden-list');
        setTimeout(function () {
            $('.pix-product-grid').hide();
            $('.pix-product-list').show();

            setTimeout(function () {
                $('.pix-product-list').removeClass('pix-hidden-list');
            }, 10);
        }, 150);
    });
    //------------------------------------------------


    //-------car1-------//
    var singleSlider = $('.pix-single-slider');
    var miniatureSlider = $('.pix-miniature-slider');
    var slidesPerPage = 5; //globaly define number of elements per page
    var syncedSecondary = false;

    //init single slider
    singleSlider.owlCarousel({
        items: 1,
        dots: false,
        nav: true,
        loop: false,
        autoHeight: true,
        onInitialized:function (event) {
            $('.pix-slider-count-slides').text('1/'+event.item.count);
            $('.fancybox').jqPhotoSwipe({
                index: 0
            });
        },
        onChanged: function (event) {
            var items = event.item.count,
                item = event.item.index;
            $('.pix-slider-count-slides').text((item+1)+'/'+items);
            $('.fancybox').jqPhotoSwipe({
                index: item
            });
        }
    }).on('changed.owl.carousel', syncPosition);
    //------------------------------------------------


    //init miniature slider
    miniatureSlider.owlCarousel({
        items: slidesPerPage,
        dots: false,
        nav: false,
        loop: false,
        slideBy: slidesPerPage, //alternatively you can slide by 1, this way the active slide will stick to the first item in the second carousel
        onInitialized:function (event) {
            miniatureSlider.find(".owl-item").eq(0).addClass("current");
        }
    }).on('changed.owl.carousel', syncPosition2);


    function syncPosition(el) {
        //if you set loop to false, you have to restore this next line
        var current = el.item.index;

        //if you disable loop you have to comment this block
        // var count = el.item.count - 1;
        // var current = Math.round(el.item.index - (el.item.count / 2) - .5);
        //
        // if (current < 0) {
        //     current = count;
        // }
        // if (current > count) {
        //     current = 0;
        // }

        //end block

        miniatureSlider
            .find(".owl-item")
            .removeClass("current")
            .eq(current)
            .addClass("current");
        var onscreen = miniatureSlider.find('.owl-item.active').length - 1;
        var start = miniatureSlider.find('.owl-item.active').first().index();
        var end = miniatureSlider.find('.owl-item.active').last().index();

        if (current > end) {
            miniatureSlider.data('owl.carousel').to(current, 100, true);
        }
        if (current < start) {
            miniatureSlider.data('owl.carousel').to(current - onscreen, 100, true);
        }
    }

    function syncPosition2(el) {
        if (syncedSecondary) {
            var number = el.item.index;
            singleSlider.data('owl.carousel').to(number, 100, true);
        }
    }

    miniatureSlider.on("click", ".owl-item", function(e) {
        e.preventDefault();
        var number = $(this).index();
        singleSlider.data('owl.carousel').to(number, 300, true);
    });


    $('img.pix-svg-fill, .pix-theme-tone-dark .pix-single-info .pix-single-list ul li span img').each(function(){
        var $img = $(this),
            imgID = $img.attr('id'),
            imgClass = $img.attr('class'),
            imgURL = $img.attr('src');

        jQuery.get(imgURL, function(data) {
            // Get the SVG tag, ignore the rest
            var $svg = jQuery(data).find('svg');

            // Add replaced image's ID to the new SVG
            if(typeof imgID !== 'undefined') {
                $svg = $svg.attr('id', imgID);
            }
            // Add replaced image's classes to the new SVG
            if(typeof imgClass !== 'undefined') {
                $svg = $svg.attr('class', imgClass+' replaced-svg');
            }

            // Remove any invalid XML tags as per http://validator.w3.org
            $svg = $svg.removeAttr('xmlns:a');

            // Check if the viewport is set, else we gonna set it if we can.
            if(!$svg.attr('viewBox') && $svg.attr('height') && $svg.attr('width')) {
                $svg.attr('viewBox', '0 0 ' + $svg.attr('height') + ' ' + $svg.attr('width'))
            }

            // Replace image with new SVG
            $img.replaceWith($svg);

        }, 'xml');

    });


});