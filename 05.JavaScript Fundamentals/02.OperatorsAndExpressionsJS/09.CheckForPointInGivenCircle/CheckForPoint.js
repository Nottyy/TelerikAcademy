function onFindBiggerButtonClick() {

    var x = parseInt(document.getElementById('tb-first').value);
    var y = parseInt(document.getElementById('tb-second').value);

    var isInCircle = ((x - 1) * (x - 1) + (y - 1) * (y - 1) < 9 ? true : false);
    var isOutRectangle = ((x > -1 && x < 5) && (y > -1 && y < 1) ? false : true);

    console.log("The point" + (isInCircle && isOutRectangle ? " IS" : " IS NOT") +
    " within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).");
}