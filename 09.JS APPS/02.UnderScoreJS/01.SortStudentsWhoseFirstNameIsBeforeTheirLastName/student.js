var Student = (function () {
    function Student(firstName, lastName, age, marks) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.marks = marks;
    }

    Student.prototype.calculateAverageMarks = function () {
        var sumOfAllMarks;
        var allSubjects = Object.keys(this.marks).length;
        sumOfAllMarks = this.marks.biology + this.marks.history + this.marks.chemistry;

        return sumOfAllMarks / allSubjects;
    };

    Student.prototype.toString = function () {
        return this.firstName + " " + this.lastName + " -> " + this.age;
    };

    Student.prototype.logMarks = function () {
        return this.toString() +  " -> Average marks: " + this.calculateAverageMarks();
    };

    return Student;
}());
