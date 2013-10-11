var TIME_OUT = 5000;

$(document).ready(function () {

    var Slider = {
        init: function (content) {
            this.content = content;
        },
        render: function (selector) {
            this.selector = selector;
            for (var i = 0, len = this.content.length; i < len; i++) {
                if (i == 0) {
                    $(this.selector).append('<div class="current first"> ' + this.content[i] + '</div>');
                } else if (i == len - 1) {
                    $(this.selector).append('<div class="previous last"> ' + this.content[i] + '</div>');
                } else {
                    $(this.selector).append('<div class="previous"> ' + this.content[i] + '</div>');
                }
            }
        }
    };
    var theSlider = Object.create(Slider);
    var content = ["<h2>Image</h2><img src='images/guitar.png'>",
                    "<h2>Sample div</h2><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur.</div>",
                    "<h2>Unordered list</h2><div>Lorem ipsum dolor sit amet <ul><li>list item</li><li>list item2</li></ul></div>",
                    "<h2>Ordered list</h2><ol><li>First</li><li>Second</li><li>Third</li></ol>",
                    "<h2>Table<table><tr><td>1.1</td><td>1.2</td></tr><tr><td>2.1</td><td>2.2</td></tr></table></h2>"
    ];

    theSlider.init(content);
    theSlider.render('#slider');

    $("#left-arrow").on('click', prev);
    $("#right-arrow").on('click', next);
    var slide = setInterval(next, TIME_OUT);

    function next() {
        clearInterval(slide);
        slide = setInterval(next, TIME_OUT);
        var curContent = $('.current');
        var nextContent = curContent.next();
        if (nextContent.length == 0)
            nextContent = $('#slider .first');

        curContent.removeClass('current').addClass('previous');
        nextContent.hide().removeClass('previous').fadeIn().addClass('current');
    }

    function prev() {
        clearInterval(slide);
        slide = setInterval(next, TIME_OUT);
        var curContent = $('.current');
        var prevContent = curContent.prev();
        if (prevContent.length == 0)
            prevContent = $('#slider .last');
        curContent.removeClass('current').addClass('previous');
        prevContent.hide().removeClass('previous').fadeIn().addClass('current');
    }
});
