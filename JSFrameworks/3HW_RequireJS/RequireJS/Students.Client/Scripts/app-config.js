(function () {
    require.config({
        paths:
            {
                jquery: "libs/jquery-2.0.3",
                httpRequester: "libs/http-requester",
                mustache: "libs/mustache",
                rsvp: "libs/rsvp.min"
            }
    });

    require(["jquery", "httpRequester", "mustache", "data-models", "table-view"], function ($, httpRequester, mustache, dataModels, controls) {

        var studentTemplate = mustache.compile(document.getElementById("student-template").innerHTML);
        var tableView;

        var marksTemplate = mustache.compile(document.getElementById("student-marks-template").innerHTML);

        $("#content").on("click", "td", function () {
            var studentId = $(this).data("id");

            httpRequester.getJSON("http://localhost:36673/api/students/" + studentId + "/marks")
            .then(function (data) {
                var marksHtml = '';
                for (var i = 0; i < data.length; i++) {
                    marksHtml += tableView.renderMarks(marksTemplate, data[i]);
                }
                document.getElementById("marks").innerHTML = marksHtml;
                $("#content").hide();
            }, function (message) {
                console.log(message);
            });
        });

        $("#wrapper").on("click", "#view-students-btn", function () {
            httpRequester.getJSON("http://localhost:36673/api/students")
            .then(function (data) {
                var students = [];
                for (var i = 0; i < data.length; i++) {
                    var studentItem = data[i];
                    var student = new dataModels.Student(
                        studentItem.StudentId, studentItem.Name, studentItem.Grade);
                    students.push(student);
                }

                tableView = controls.getTableView(students, 5, 1);
                var tableViewHtml = tableView.render(studentTemplate);
                document.getElementById("content").innerHTML = tableViewHtml;
            }, function (error) {
                console.log(error);
            });
        });

        $("#wrapper").on("click", "#back", function () {
            $("#content").show();
        });
    });
}());