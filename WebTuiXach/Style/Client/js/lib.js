/*
* jquery-match-height 0.7.2 by @liabru
* http://brm.io/jquery-match-height/
* License MIT
*/
!function(t){"use strict";"function"==typeof define&&define.amd?define(["jquery"],t):"undefined"!=typeof module&&module.exports?module.exports=t(require("jquery")):t(jQuery)}(function(t){var e=-1,o=-1,n=function(t){return parseFloat(t)||0},a=function(e){var o=1,a=t(e),i=null,r=[];return a.each(function(){var e=t(this),a=e.offset().top-n(e.css("margin-top")),s=r.length>0?r[r.length-1]:null;null===s?r.push(e):Math.floor(Math.abs(i-a))<=o?r[r.length-1]=s.add(e):r.push(e),i=a}),r},i=function(e){var o={
byRow:!0,property:"height",target:null,remove:!1};return"object"==typeof e?t.extend(o,e):("boolean"==typeof e?o.byRow=e:"remove"===e&&(o.remove=!0),o)},r=t.fn.matchHeight=function(e){var o=i(e);if(o.remove){var n=this;return this.css(o.property,""),t.each(r._groups,function(t,e){e.elements=e.elements.not(n)}),this}return this.length<=1&&!o.target?this:(r._groups.push({elements:this,options:o}),r._apply(this,o),this)};r.version="0.7.2",r._groups=[],r._throttle=80,r._maintainScroll=!1,r._beforeUpdate=null,
r._afterUpdate=null,r._rows=a,r._parse=n,r._parseOptions=i,r._apply=function(e,o){var s=i(o),h=t(e),l=[h],c=t(window).scrollTop(),p=t("html").outerHeight(!0),u=h.parents().filter(":hidden");return u.each(function(){var e=t(this);e.data("style-cache",e.attr("style"))}),u.css("display","block"),s.byRow&&!s.target&&(h.each(function(){var e=t(this),o=e.css("display");"inline-block"!==o&&"flex"!==o&&"inline-flex"!==o&&(o="block"),e.data("style-cache",e.attr("style")),e.css({display:o,"padding-top":"0",
"padding-bottom":"0","margin-top":"0","margin-bottom":"0","border-top-width":"0","border-bottom-width":"0",height:"100px",overflow:"hidden"})}),l=a(h),h.each(function(){var e=t(this);e.attr("style",e.data("style-cache")||"")})),t.each(l,function(e,o){var a=t(o),i=0;if(s.target)i=s.target.outerHeight(!1);else{if(s.byRow&&a.length<=1)return void a.css(s.property,"");a.each(function(){var e=t(this),o=e.attr("style"),n=e.css("display");"inline-block"!==n&&"flex"!==n&&"inline-flex"!==n&&(n="block");var a={
display:n};a[s.property]="",e.css(a),e.outerHeight(!1)>i&&(i=e.outerHeight(!1)),o?e.attr("style",o):e.css("display","")})}a.each(function(){var e=t(this),o=0;s.target&&e.is(s.target)||("border-box"!==e.css("box-sizing")&&(o+=n(e.css("border-top-width"))+n(e.css("border-bottom-width")),o+=n(e.css("padding-top"))+n(e.css("padding-bottom"))),e.css(s.property,i-o+"px"))})}),u.each(function(){var e=t(this);e.attr("style",e.data("style-cache")||null)}),r._maintainScroll&&t(window).scrollTop(c/p*t("html").outerHeight(!0)),
this},r._applyDataApi=function(){var e={};t("[data-match-height], [data-mh]").each(function(){var o=t(this),n=o.attr("data-mh")||o.attr("data-match-height");n in e?e[n]=e[n].add(o):e[n]=o}),t.each(e,function(){this.matchHeight(!0)})};var s=function(e){r._beforeUpdate&&r._beforeUpdate(e,r._groups),t.each(r._groups,function(){r._apply(this.elements,this.options)}),r._afterUpdate&&r._afterUpdate(e,r._groups)};r._update=function(n,a){if(a&&"resize"===a.type){var i=t(window).width();if(i===e)return;e=i;
}n?o===-1&&(o=setTimeout(function(){s(a),o=-1},r._throttle)):s(a)},t(r._applyDataApi);var h=t.fn.on?"on":"bind";t(window)[h]("load",function(t){r._update(!1,t)}),t(window)[h]("resize orientationchange",function(t){r._update(!0,t)})});

/*!
* jQuery meanMenu v2.0.8
* @Copyright (C) 2012-2014 Chris Wharton @ MeanThemes (https://github.com/meanthemes/meanMenu)
*
*/
(function(n){"use strict";n.fn.meanmenu=function(t){var r={meanMenuTarget:jQuery(this),meanMenuContainer:"body",meanMenuClose:"X",meanMenuCloseSize:"18px",meanMenuOpen:"<span /><span /><span />",meanRevealPosition:"right",meanRevealPositionDistance:"0",meanRevealColour:"",meanScreenWidth:"480",meanNavPush:"",meanShowChildren:!0,meanExpandableChildren:!0,meanExpand:"+",meanContract:"-",meanRemoveAttrs:!1,onePage:!1,meanDisplay:"block",removeElements:""},i;return t=n.extend(r,t),i=window.innerWidth||document.documentElement.clientWidth,this.each(function(){var e=t.meanMenuTarget,p=t.meanMenuContainer,nt=t.meanMenuClose,w=t.meanMenuCloseSize,l=t.meanMenuOpen,a=t.meanRevealPosition,b=t.meanRevealPositionDistance,k=t.meanRevealColour,u=t.meanScreenWidth,tt=t.meanNavPush,d=".meanmenu-reveal",it=t.meanShowChildren,rt=t.meanExpandableChildren,g=t.meanExpand,ut=t.meanContract,ft=t.meanRemoveAttrs,et=t.onePage,ot=t.meanDisplay,v=t.removeElements,o=!1;(navigator.userAgent.match(/iPhone/i)||navigator.userAgent.match(/iPod/i)||navigator.userAgent.match(/iPad/i)||navigator.userAgent.match(/Android/i)||navigator.userAgent.match(/Blackberry/i)||navigator.userAgent.match(/Windows Phone/i))&&(o=!0);(navigator.userAgent.match(/MSIE 8/i)||navigator.userAgent.match(/MSIE 7/i))&&jQuery("html").css("overflow-y","scroll");var s="",h=function(){if(a==="center"){var t=window.innerWidth||document.documentElement.clientWidth,n=t/2-22+"px";s="left:"+n+";right:auto;";o?jQuery(".meanmenu-reveal").animate({left:n}):jQuery(".meanmenu-reveal").css("left",n)}},f=!1,y=!1;a==="right"&&(s="right:"+b+";left:auto;");a==="left"&&(s="left:"+b+";right:auto;");h();var n="",st=function(){jQuery(n).is(".meanmenu-reveal.meanclose")?(n.html(nt),jQuery("body").addClass("mean-overflow")):(n.html(l),jQuery("body").removeClass("mean-overflow"))},r=function(){jQuery(".mean-bar,.mean-push").remove();jQuery(p).removeClass("mean-container");jQuery(e).css("display",ot);f=!1;y=!1;jQuery(v).removeClass("mean-remove")},c=function(){var o="background:"+k+";color:"+k+";"+s,t;if(i<=u){if(jQuery(v).addClass("mean-remove"),y=!0,jQuery(p).addClass("mean-container"),jQuery(".mean-container").prepend('<div class="mean-bar"><a href="#nav" class="meanmenu-reveal" style="'+o+'">Show Navigation<\/a><nav class="mean-nav"><\/nav><\/div>'),t=jQuery(e).html(),jQuery(".mean-nav").html(t),ft&&jQuery("nav.mean-nav ul, nav.mean-nav ul *").each(function(){jQuery(this).is(".mean-remove")?jQuery(this).attr("class","mean-remove"):jQuery(this).removeAttr("class");jQuery(this).removeAttr("id")}),jQuery(e).before('<div class="mean-push" />'),jQuery(".mean-push").css("margin-top",tt),jQuery(e).hide(),jQuery(".meanmenu-reveal").show(),jQuery(d).html(l),n=jQuery(d),jQuery(".mean-nav ul").hide(),it)if(rt){jQuery(".mean-nav ul ul").each(function(){jQuery(this).children().length&&jQuery(this,"li:first").parent().append('<a class="mean-expand" href="#" style="font-size: '+w+'">'+g+"<\/a>")});jQuery(".mean-expand").on("click",function(n){n.preventDefault();jQuery(this).hasClass("mean-clicked")?(jQuery(this).html(g),jQuery(this).prev("ul").slideUp(300,function(){})):(jQuery(this).html(ut),jQuery(this).prev("ul").slideDown(300,function(){}));jQuery(this).toggleClass("mean-clicked")})}else jQuery(".mean-nav ul ul").show();else jQuery(".mean-nav ul ul").hide();if(jQuery(".mean-nav ul li").last().addClass("mean-last"),n.removeClass("meanclose"),jQuery(n).click(function(t){t.preventDefault();f===!1?(n.css("text-align","center"),n.css("text-indent","0"),n.css("font-size",w),jQuery(".mean-nav ul:first").slideDown(),f=!0):(jQuery(".mean-nav ul:first").slideUp(),f=!1);n.toggleClass("meanclose");st();jQuery(v).addClass("mean-remove")}),et)jQuery(".mean-nav ul > li > a:first-child").on("click",function(){jQuery(".mean-nav ul:first").slideUp();f=!1;jQuery(n).toggleClass("meanclose").html(l)})}else r()};o||jQuery(window).resize(function(){i=window.innerWidth||document.documentElement.clientWidth;i>u?r():r();i<=u?(c(),h()):r()});jQuery(window).resize(function(){i=window.innerWidth||document.documentElement.clientWidth;o?(h(),i<=u?y===!1&&c():r()):(r(),i<=u&&(c(),h()))});c()})}})(jQuery);
