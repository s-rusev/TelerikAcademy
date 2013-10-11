(function () {
    require.config({
        paths:
            {
                jquery: "libs/jquery-2.0.3",
                mustache: "libs/mustache",
                rsvp: "libs/rsvp.min",
                "class": "libs/class"
            }
    });

    require(["jquery", "mustache", "combo-box-view", "class"], function ($, mustache, controls, Class) {

        var people = [
                     { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "../Images/doncho.jpg" },
                     { id: 2, name: "Georgi Georgiev", age: 19, avatarUrl: "../Images/joreto.jpg" },
                     { id: 3, name: "Niki Kostov", age: 20, avatarUrl: "../Images/niki.jpg" }];

        var comboBox = controls.ComboBox(people);

        var peopleTemplate = mustache.compile(document.getElementById("person-template").innerHTML);

        var comboBoxHTML = comboBox.render(peopleTemplate);

        $("#combo-box-holder").append(comboBoxHTML);


    });
}());