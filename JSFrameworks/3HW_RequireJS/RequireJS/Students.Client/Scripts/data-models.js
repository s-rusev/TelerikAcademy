define(["libs/class"], function (Class) {

    var dataModels = (function () {
        var Student = Class.create({
            init: function (id, name, grade) {
                this.name = name;
                this.grade = grade;
                this.id = id;
            }
        });

        return {
            Student: Student
        };
    })();

    return dataModels;
});