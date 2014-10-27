function onFindBiggerButtonClick() {
    var a = parseInt(document.getElementById('tb-first').value);
    var b = parseInt(document.getElementById('tb-second').value);
    var c = parseInt(document.getElementById('tb-third').value);

    var x1;
    var x2;
    var determinant;
    if (isNaN(a) || isNaN(b) || isNaN(c)) {
        console.log("'a', 'b' and 'c' must be  numbers");
    }
    else {
        console.log("Roots of ax" + '\u00B2' + "+bx+c:");
        if (a != 0) {
            determinant = b * b - 4 * a * c;
            if (determinant > 0) {
                x1 = (-b + Math.sqrt(determinant)) / (2 * a);
                x2 = (-b - Math.sqrt(determinant)) / (2 * a);
                console.log("x1= " + x1 + "; x2= " + x2);
            }
            else if (determinant == 0) {
                x1 = (-b) / (2 * a);
                console.log("x1,2 = " + x1);
            }
            else if (determinant < 0) {
                console.log("There is no real roots");
            }
        }
        else if (b != 0) {
            x1 = (-c) / b;
            console.log("x1,2 = " + x1);
        }
        else {
            console.log("No quadratic equation");
        }
    }
}