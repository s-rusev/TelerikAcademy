(function () {
    "use strict"

    var Person = {
        init: function (fname, lname, age) {
            this.fname = fname;
            this.lname = lname;
            this.age = age;
        },
        toString: function () {
            var result = "Name: " + this.fname + " " + this.lname + ", Age: " + this.age;
            return result;
        }
    };

    var Student = Person.extend({
        init: function (fname, lname, age, grade) {
            this._super = Object.create(this._super);
            this._super.init(fname, lname, age);
            this.grade = grade;
        },
        toString: function () {
            return this._super.toString() + ", grade: " + this.grade;
        }
    });

    var Teacher = Person.extend({
        init: function (fname, lname, age, speciality) {
            this._super = Object.create(this._super);
            this._super.init(fname, lname, age);
            this.speciality = speciality;
        },
        toString: function () {
            return this._super.toString() + ", speciality: " + this.speciality;
        }
    });

    var School = {
        init: function (name, town, classes) {
            this.name = name;
            this.town = town;
            this.classes = classes;
        },
        toString: function () {
            var result = "Name: " + this.name + ", Town: " + this.town + ", Classes: ";
            for (var i = 0, len = this.classes.length; i < len; i += 1) {
                result += this.classes[i].name + ", ";
            }
            return result.substr(0, result.length - 2);
        }
    };

    var Course = {
        init: function (name, capacity, students, formTeacher) {
            this.name = name;
            this.capacity = capacity;
            this.students = students;
            this.formTeacher = formTeacher;
        },
        toString: function () {
            var result = "Name: " + this.name + ", Capacity: " + this.capacity + ", Students: ";
            for (var i = 0, len = this.students.length; i < len; i += 1) {
                result += this.students[i].toString() + ", ";
            }
            result += "Form-teacher " + this.formTeacher.toString();
            return result;
        }
    };

    var student1 = Object.create(Student);
    student1.init("Ivan", "Vodkata", 20, 5);
    var student2 = Object.create(Student);
    student2.init("Dragan", "Rakiqta", 30, 10);
    var student3 = Object.create(Student);
    student3.init("Petran", "Vinoto", 40, 15);
    var teacher1 = Object.create(Teacher);
    teacher1.init("Kolan", "Wiskito", 50, "C#");
    var teacher2 = Object.create(Teacher);
    teacher2.init("Molan", "Absenta", 60, "JS");
    console.log(student1.toString());
    console.log(student2.toString());
    console.log(teacher1.toString());
    console.log(teacher2.toString());

    var classA = Object.create(Course);
    classA.init("classA", 10, new Array(student1, student2, student3), teacher1);
    var classB = Object.create(Course);
    classB.init("classB", 30, new Array(student1, student3), teacher2);
    console.log(classA.toString());
    console.log(classB.toString());
    var school = Object.create(School);
    school.init("Telerik", "Sofia", new Array(classA, classB));
    console.log(school.toString());
}());
