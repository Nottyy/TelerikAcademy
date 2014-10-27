function onFindBiggerButtonClick() {
    var sideA = parseInt(document.getElementById('tb-first').value);
    var sideB = parseInt(document.getElementById('tb-second').value);
    var height = parseInt(document.getElementById('tb-third').value);

    var area = (sideA + sideB) / 2 * height;

    console.log('The trapezoid area is: ' + area);
}