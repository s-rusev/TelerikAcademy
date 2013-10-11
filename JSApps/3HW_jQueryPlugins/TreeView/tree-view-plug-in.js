(function ($) {
    $.fn.treeView = function () {

        $("#tree-view ul")
            .parent()
                .children("a")
                    .on("click", onClick);

        function onClick() {
            $(this).parent().addClass("selected");
            var ulStyle = $(".selected > ul").css("display");
            if (ulStyle=="none") {
                $(this).parent().addClass("selected");
                $(".selected > ul").fadeIn();
            }
            else {
                $(this).parent().addClass("selected");
                $(".selected > ul").fadeOut();
            }

            $(this).parent().removeClass("selected");
        }

        return this;
    }
})(jQuery);