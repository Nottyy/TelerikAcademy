function onFindBiggerButtonClick() {
    var width = parseFloat(document.getElementById("tb-first").value);
    var height = parseFloat(document.getElementById("tb-second").value);

    var areaCalc = width * height;
    console.log('The rectangle"s area is: ' + areaCalc);
}