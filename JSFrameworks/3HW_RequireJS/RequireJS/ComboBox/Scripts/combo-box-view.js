define(["class", "jquery", "mustache"], function (Class, $, mustache) {
    var controller = controller || {};

    var ComboBox = Class.create({
        init: function (itemsSource) {
            this.itemsSource = itemsSource;
        },

        render: function (template) {
            var ul = document.createElement("ul");

            var li = document.createElement("li");
            var currentItem = this.itemsSource[0];
            li.innerHTML = template(currentItem);

            li.className = "selected";

            ul.appendChild(li);

            $(ul).on("click", ".selected", function () {
                $(this).removeClass("selected");
                $(ul).children().addClass("shown").show();
            });


            $(ul).on("click", ".shown", function () {
                $(ul).children().removeClass("shown").hide();

                $(this).addClass("selected").show();
            });

            for (var i = 1; i < this.itemsSource.length; i++) {
                var item = this.itemsSource[i];
                var li = document.createElement('div');
                li.innerHTML = template(item);
                li.style.display = "none";
                ul.appendChild(li);
            }

            return ul;
        }
    });

    controller.ComboBox = function (itemsSource) {
        return new ComboBox(itemsSource);
    }

    return controller;
});