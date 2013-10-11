(function () {
    function changeBackgroundColor() {
        $("body").css("background-color", $("#color-picker").val());
    }

    $("#color-picker").on("change", changeBackgroundColor);
}());